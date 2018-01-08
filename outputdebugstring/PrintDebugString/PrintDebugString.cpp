#include "stdafx.h"

using BaseObjectOpenFunc = NTSTATUS(NTAPI *) (
    _Out_ PHANDLE handle,
    _In_ ACCESS_MASK DesiredAccess,
    _In_ POBJECT_ATTRIBUTES ObjectAttributes);

void RaiseExceptionIfStatusInvalid(NTSTATUS status) {
    if (!NT_SUCCESS(status)) {
        EXCEPTION_RECORD exception{ 0 };
        exception.ExceptionCode = status;
        exception.ExceptionFlags = EXCEPTION_NONCONTINUABLE;

        RtlRaiseException(&exception);
    }
}

void OpenBaseNamedObject(PHANDLE handle, PCWSTR objectName, ACCESS_MASK accessMask,
    BaseObjectOpenFunc openFunction) {
    OBJECT_ATTRIBUTES objectAttributes;
    UNICODE_STRING objectNameUnicodeString;
    RaiseExceptionIfStatusInvalid(
        RtlInitUnicodeStringEx(&objectNameUnicodeString,
            const_cast<PWSTR>(objectName)));

    InitializeObjectAttributes(&objectAttributes, &objectNameUnicodeString, 0, NULL, NULL);
    RaiseExceptionIfStatusInvalid(openFunction(handle, accessMask, &objectAttributes));
}

VOID NotifyGlobalDebugOutputMonitor(_In_ LPCSTR OutputString) {
    // assumes OutputString != null
    HANDLE dbgOutputMutexHandle = NULL;
    HANDLE eventBufferReadyHandle = NULL;
    HANDLE eventDataReadyHandle = NULL;
    HANDLE dbgOutputSectionHandle = NULL;
    PVOID writeBufferAddress = NULL;

    __try {
        __try {
            OpenBaseNamedObject(&dbgOutputMutexHandle, L"\\BaseNamedObjects\\DBWinMutex",
                MUTANT_ALL_ACCESS, NtOpenMutant);
            OpenBaseNamedObject(&eventBufferReadyHandle, L"\\BaseNamedObjects\\DBWIN_BUFFER_READY",
                SYNCHRONIZE, NtOpenEvent);
            OpenBaseNamedObject(&eventDataReadyHandle, L"\\BaseNamedObjects\\DBWIN_DATA_READY",
                EVENT_MODIFY_STATE, NtOpenEvent);
            OpenBaseNamedObject(&dbgOutputSectionHandle, L"\\BaseNamedObjects\\DBWIN_BUFFER",
                SECTION_MAP_WRITE | SECTION_MAP_READ, NtOpenSection);

            LARGE_INTEGER sectionOffset = { 0 };
            SIZE_T writeBufferSize;
            RaiseExceptionIfStatusInvalid(
                NtMapViewOfSection(dbgOutputSectionHandle, NtCurrentProcess(),
                    &writeBufferAddress, 0, 0, &sectionOffset, &writeBufferSize, ViewShare, 0, PAGE_READWRITE));

            RaiseExceptionIfStatusInvalid(
                NtWaitForSingleObject(dbgOutputMutexHandle, FALSE, NULL)); // infinite wait

            RaiseExceptionIfStatusInvalid(
                NtWaitForSingleObject(eventBufferReadyHandle, FALSE, NULL)); // FIXME: should not be inifinite

            auto debugStringLength = strlen(OutputString) + 1;
            size_t debugStringBytesToCopy = debugStringLength + sizeof(DWORD) > writeBufferSize ?
                writeBufferSize - sizeof(DWORD) : debugStringLength;
            struct {
                DWORD ProcessId;
                char Buffer[1];
            } *debugMessage = reinterpret_cast<decltype(debugMessage)>(writeBufferAddress);
            debugMessage->ProcessId = HandleToUlong(NtCurrentTeb()->ClientId.UniqueProcess);
            memcpy(debugMessage->Buffer, OutputString, debugStringBytesToCopy);

            NtSetEvent(eventDataReadyHandle, NULL);
        } __finally {
            if (eventBufferReadyHandle) {
                NtClose(eventBufferReadyHandle);
            }
            if (writeBufferAddress) {
                NtUnmapViewOfSection(NtCurrentProcess(), writeBufferAddress);
            }
            if (dbgOutputSectionHandle) {
                NtClose(dbgOutputSectionHandle);
            }
            if (eventDataReadyHandle) {
                NtClose(eventDataReadyHandle);
            }
            if (dbgOutputMutexHandle) {
                NtReleaseMutant(dbgOutputMutexHandle, NULL);
                NtClose(dbgOutputMutexHandle);
            }
        }
    } __except (EXCEPTION_EXECUTE_HANDLER) {}
}

VOID NTAPI RtlOutputDebugStringA(_In_opt_ LPCSTR OutputString) {
    if (OutputString) {
        EXCEPTION_RECORD exceptionRecord{ 0 };

        exceptionRecord.ExceptionCode = DBG_PRINTEXCEPTION_C;
        exceptionRecord.NumberParameters = 2;
        exceptionRecord.ExceptionInformation[0] = strlen(OutputString) + 1;
        exceptionRecord.ExceptionInformation[1] = reinterpret_cast<ULONG_PTR>(OutputString);

        __try {
            RtlRaiseException(&exceptionRecord);
        } __except (EXCEPTION_EXECUTE_HANDLER) {
            NotifyGlobalDebugOutputMonitor(OutputString);
        }
    }
}

VOID NTAPI RtlOutputDebugStringW(_In_opt_ LPCWSTR OutputString) {
    if (OutputString) {
        int len = 0;
        while (*(OutputString + len)) {
            len++;
        }
        len += 1;

        UNICODE_STRING outputUnicodeString;
        RtlInitUnicodeString(&outputUnicodeString, const_cast<PWSTR>(OutputString));
        ANSI_STRING outputAnsiString{ 0 };
        if (!NT_SUCCESS(RtlUnicodeStringToAnsiString(
            &outputAnsiString, &outputUnicodeString, TRUE))) {
            return;
        }

        EXCEPTION_RECORD exceptionRecord{ 0 };

        exceptionRecord.ExceptionCode = DBG_PRINTEXCEPTION_WIDE_C;
        exceptionRecord.NumberParameters = 4;
        exceptionRecord.ExceptionInformation[0] = (outputUnicodeString.Length / sizeof(wchar_t)) + 1;
        exceptionRecord.ExceptionInformation[1] = reinterpret_cast<ULONG_PTR>(outputUnicodeString.Buffer);
        exceptionRecord.ExceptionInformation[2] = outputAnsiString.Length + 1;
        exceptionRecord.ExceptionInformation[3] = reinterpret_cast<ULONG_PTR>(outputAnsiString.Buffer);

        __try {
            RtlRaiseException(&exceptionRecord);
        } __except (EXCEPTION_EXECUTE_HANDLER) {
            NotifyGlobalDebugOutputMonitor(outputAnsiString.Buffer);
        }

        RtlFreeAnsiString(&outputAnsiString);
    }
}

int main() {
    RtlOutputDebugStringW(L"test kljsdf");

    return 0;
}
