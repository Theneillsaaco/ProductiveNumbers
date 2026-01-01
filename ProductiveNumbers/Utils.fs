namespace ProductiveNumbers

open System

module Utils =
    let readInt prompt =
        printfn "%s" prompt
        Console.ReadLine() |> int
        
    let pause () =
        printfn "\nPresiona ENTER para continuar..."
        Console.ReadLine() |> ignore
        
    let clear () =
        Console.Clear()