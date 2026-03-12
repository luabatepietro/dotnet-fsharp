module Load

open Types
open Transform

/// Escreve a lista de OrderSummary em um arquivo CSV de saída
let writeSummariesToFile (path: string) (summaries: OrderSummary list) : unit =
    let header = "order_id,total_amount,total_taxes"
    let lines =
        summaries
        |> List.map formatSummaryLine
    System.IO.File.WriteAllLines(path, header :: lines)
    printfn "Arquivo gerado: %s (%d registros)" path (List.length summaries)
