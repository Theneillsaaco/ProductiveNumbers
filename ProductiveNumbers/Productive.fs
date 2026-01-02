namespace ProductiveNumbers

open System.Collections.Concurrent
open ProductiveNumbers.Prime

module Productive =
        
    let isProductive (n:int) =
        if not (isPrime (n + 1)) then
            false
        else
            let s = n.ToString()
            let len = s.Length
            let mutable ok = true
            let mutable i = 1
            
            while ok && i < len do
                let a = int (s.Substring(0, i))
                let b = int (s.Substring(i))
                
                if not (isPrime ((a * b) + 1)) then
                    ok <- false
                    
                i <- i + 1
                
            ok
    
    let firstNProductives count =
        let result = ConcurrentBag<int>()
        let mutable n = 0
        
        while result.Count < count do
            let block = [|n .. n + 10_000|]
            n <- n + 10_000
            
            block
            |> Array.filter isCandidate 
            |> Array.Parallel.iter (fun x ->
                if isProductive x then
                    result.Add x
            )
            
        result
        |> Seq.sort
        |> Seq.take count
        |> Seq.toList
        
    let nthProductive n =
        let mutable count = 0
        let mutable x = 0
        let mutable result = 0
        
        while count < n do
            if isCandidate x && isProductive x then
                count <- count + 1
                result <- x
            x <- x + 1
            
        result