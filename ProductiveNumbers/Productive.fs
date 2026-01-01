namespace ProductiveNumbers

open ProductiveNumbers.Prime

module Productive =
    let partition (n:int) =
        let s = n.ToString()
        [ for i in 1 .. s.Length - 1 ->
            let a = int (s.Substring(0,i))
            let b = int (s.Substring(i))
            (a, b)
        ]
        
    let isProductive n =
        let baseCheck = isPrime (n + 1)
        
        let partitionCheck =
            partition n
            |> List.forall (fun (a, b) ->
                isPrime ((a * b) + 1)
            )
            
        baseCheck && partitionCheck
    
    let firstNProductives count =
        Seq.initInfinite (fun i -> i + 10)
        |> Seq.filter isProductive
        |> Seq.take count
        |> Seq.toList
        
    let nthProductive n =
        firstNProductives n
        |> List.last