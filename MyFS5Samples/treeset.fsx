open System 
open System.IO 


type TreeNode = 
    {
        Name : int 
        Label : string 
        Level : int 
        Children : TreeNode list 
    }

let createLevel level nodecount 