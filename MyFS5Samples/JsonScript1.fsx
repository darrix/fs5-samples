#r "nuget: Newtonsoft.Json"

open Newtonsoft.Json
open System.IO

type Report =
    {
        reportUri: string
        reportTable: string
        report: string
        table: string
        title: string
        subtitle: string
      }

let get<'T> filename =
    let json = File.ReadAllText(filename)
    JsonConvert.DeserializeObject<'T>(json)
    
get<Report list> @"c:\temp\reports.json"
