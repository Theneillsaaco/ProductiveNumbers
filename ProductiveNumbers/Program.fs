open System
open ProductiveNumbers.Productive
open ProductiveNumbers.Utils

let showMenu () =
    clear()
    printfn "════════════════════════════════"
    printfn "   PRODUCTIVE NUMBERS (F#)"
    printfn "════════════════════════════════"
    printfn "1) Verificar si un número es productivo"
    printfn "2) Buscar el n-ésimo número productivo"
    printfn "3) Mostrar los primeros N números productivos"
    printfn "0) Salir"
    printfn "════════════════════════════════"
    
let optionsCheck () =
    let n = readInt "Numero: "
    printfn "\nResultado: %b" (isProductive n)
    pause()
    
let optionNth () =
    let n = readInt "Posicion: "
    printfn "\nNumero productivo: #%d = %d" n (nthProductive n)
    pause()
    
let optionList () =
    let n = readInt "Cantidad: "
    let list = firstNProductives n
    printfn "\nPrimeros %d numeros productivos:" n
    list |> List.iter (printf "%d ")
    pause()
    
[<EntryPoint>]
let main _ =
    let mutable running = true
    
    while running do
        showMenu()
        match Console.ReadLine() with
        | "1" -> optionsCheck()
        | "2" -> optionNth()
        | "3" -> optionList()
        | "0" -> running <- false
        | _ ->
            printfn "Opcion invalida."
            pause()
    0