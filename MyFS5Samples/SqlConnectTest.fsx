
#r "nuget: System.Data.SqlClient"

open System.Data
open System.Data.SqlClient

let getSqlConnectionString () = "data source=localhost;Initial Catalog=Northwind;Integrated Security=true"

let connection = new SqlConnection()
connection.ConnectionString <- getSqlConnectionString()
connection.Open()

let command = new SqlCommand("SELECT * FROM Categories",connection)
let reader = command.ExecuteReader()

let writeData (reader : SqlDataReader) = 
    let record = reader :> IDataRecord 
    printfn "%A %A" record.[0] record.[1]


while reader.Read() do 
    writeData reader  

reader.Close()



