namespace ProductiveNumbers

open System.Collections.Concurrent
open System.Collections.Generic

module Prime =
    let primeCache = ConcurrentDictionary<int, bool>()
    
    let smallPrimes = [|3;5;7;11;13;17;19;23;29|]
    
    let isCandidate n =
        n > 1 &&
        n % 2 = 0 &&
        match n % 10 with
        | 0 | 2 | 6 | 8 -> true
        | _ -> false
    
    let isPrime (n:int) =
        if n < 2 then false
        elif n = 2 then true
        elif n % 2 = 0 then false
        elif primeCache.ContainsKey n then true
        else
            let mutable i = 0
            let mutable composite = false
            
            while not composite && i < smallPrimes.Length do
                let p = smallPrimes.[i]
                if n = p then
                    composite <- false
                    i <- smallPrimes.Length
                elif n % p = 0 then
                    composite <- true
                i <- i + 1
                
            if composite then false
            else
                let limit = int (sqrt (float n))
                let mutable d = 31
                let mutable prime = true
                
                while prime && d <= limit do
                    if n % d = 0 then prime <- false
                    d <- d + 2
                
                if prime then primeCache.TryAdd(n, true) |> ignore
                prime
    