open System
open System.Collections.Generic
open System.Data.SqlClient
open System.IO

let debugfile = Path.Combine(__SOURCE_DIRECTORY__,"debuginfo.csv")
let rssdSet = HashSet<int>()

let captureDebug level rssd = 
    File.Append(debugfile,sprintf "%s, %d" rssd level)

// tell me if we have hit a duplicate
let addToRssdSet level rssd =
    match rssdSet.Contains(rssd) with  
    | true ->   captureDebug level rssd 
                printfn "duplicate rssd found %d at level %d" rssd level  
                rssd,true  // is duplicate
    | false ->  rssdSet.Add(rssd)
                rssd,false // is not duplicate



let buildHierarchy parentRSSD =
    let rec buildHierarchyRec level parentRSSD =
        let childRSSDs = getChildRSSDs level parentRSSD
        let annotatedRSSDs = childRSSDs |> Array.map level addToRssdSet
        annotatedRSSDs 
        |> Array.filter (fun (r,dup) -> not dup)
        |> Array.map fst 
        |> Array.iter (buildHierarchyRec (level+1))

    buildHierarchyRec 1 parentRSSD












let RunCore () =
    let cn = CreateCollection ()

    getProblemRSSDs()
    |> Array.iter buildHierarchy



    cn.Close()

RunCore()