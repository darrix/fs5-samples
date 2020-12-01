open System
open System.Collections.Generic

let hashset = HashSet<int>()
hashset.Count |> printfn "%d"
hashset.Add(1)
hashset.Add(2)
hashset.Add(3)
hashset.Add(1)
hashset.Count |> printfn "%d"
hashset.Contains(3) |> printfn "%b"

let set = Set.empty    
set.Add(1).Add(2).Add(3).Add(1)
set.Count |> printfn "%d"