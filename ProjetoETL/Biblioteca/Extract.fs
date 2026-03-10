module Extract

open System.IO
open Types

let parseOrder (linha: string) =
    let colunas = linha.Split(',')
    {
        id = int colunas[0]
        client_id = int colunas[1]
        order_date = colunas[2]
        status = colunas[3]
        origin = colunas[4]
    }

let parseOrderItem (linha: string) =
    let colunas = linha.Split(',')
    {
        order_id = int colunas[0]
        product_id = int colunas[1]
        quantity = int colunas[2]
        price = float colunas[3]
        tax = float colunas[4]
    }

let readCsv path parseFunction =
    File.ReadAllLines(path)
    |> Array.skip 1
    |> Array.map parseFunction
    |> Array.toList