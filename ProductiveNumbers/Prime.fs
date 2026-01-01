namespace ProductiveNumbers

module Prime =
    let isPrime n =
        if n < 2 then false
        elif n = 2 then true
        elif n % 2 = 0 then false
        else
            let limit = int (sqrt (float n))
            seq { 3 .. 2 .. limit }
            |> Seq.forall (fun d -> n % d <> 0)