namespace ProductiveNumbers

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
        let result = ResizeArray<int>()
        let mutable n = 0
        
        while result.Count < count do
            if isProductive n then
                result.Add n
            n <- n + 1
            
        result |> List.ofSeq
        
    let nthProductive n =
        let mutable count = 0
        let mutable x = 0
        let mutable result = 0
        
        while count < n do
            if isProductive x then
                count <- count + 1
                result <- x
            x <- x + 1
            
        result