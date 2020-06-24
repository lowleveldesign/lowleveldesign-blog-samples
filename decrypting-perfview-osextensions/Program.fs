open System
open System.IO
open System.Reflection
open System.Security.Cryptography
open System.Text
open System.Threading

let chars = "0123456789abcdef"B

[<Literal>]
let PassLen = 8

let homePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)

let decrypt (des : DESCryptoServiceProvider) (cipher : byte array) (plain : byte array) (key : byte array) =
    use instream = new MemoryStream(cipher)
    use outstream = new MemoryStream(plain)
    use decryptor =  des.CreateDecryptor(key, key)
    use cryptostream = new CryptoStream(instream, decryptor, CryptoStreamMode.Read)
    cryptostream.CopyTo(outstream)

let rec gen n (s : byte array) = seq {
    for i = 0 to chars.Length - 1 do
        if n = s.Length - 1 then
            s.[n] <- chars.[i]
            yield s
        else
            s.[n] <- chars.[i] 
            yield! gen (n + 1) s
            s.[n + 1] <- chars.[0]
}

let cipher = File.ReadAllBytes(Path.Combine(homePath, @"OSExtensions.cs.crypt"))

let tryDecrypt (state : byte array) =

    let checkIfValid (plain : byte array) = 
        plain.[0] = byte(0xef) && plain.[1] = byte(0xbb) && plain.[2] = byte(0xbf)

    // no padding so we won't throw unnecessary exceptions
    use des = new DESCryptoServiceProvider(Padding = PaddingMode.None)
    let plain = Array.create PassLen 0uy

    // we will generate all random strings starting from the second place in the string
    for pass in (gen 1 state) do
        decrypt des cipher plain pass
        if checkIfValid plain then
            let fileName = sprintf "pass_%d_%d.txt" Thread.CurrentThread.ManagedThreadId DateTime.UtcNow.Ticks
            File.WriteAllLines(Path.Combine(homePath, fileName), [| 
                sprintf "Found pass: %s" (Encoding.ASCII.GetString(pass));
                sprintf "Decrypted: %s" (Encoding.ASCII.GetString(plain))
            |])

[<EntryPoint>]
let main argv =
    let zeroArray = Array.create (PassLen - 1) '0'B

    chars |> Array.map (fun ch -> async { zeroArray |> Array.append [| ch |] |> tryDecrypt }) 
          |> Async.Parallel 
          |> Async.RunSynchronously 
          |> ignore
    0 // return an integer exit code
