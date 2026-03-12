module Program

open Extract
open Transform
open Load

[<EntryPoint>]
let main argv =
    // --- Parâmetros configuráveis ---
    let status = "Complete"
    let origin = "O"        // O = Online, P = Physical
    let outputPath = "output.csv"

    // --- Fonte dos dados: arquivo local ou URL ---
    // Para usar arquivos locais, ajuste os caminhos abaixo:
    let orderPath     = "order.csv"
    let orderItemPath = "order_item.csv"

    // Descomente as linhas abaixo para usar leitura via HTTP:
    // let orderUrl     = "https://seu-servidor/order.csv"
    // let orderItemUrl = "https://seu-servidor/order_item.csv"

    printfn "=== ETL Project - Programação Funcional ==="
    printfn "Filtro: status=%s, origin=%s" status origin

    // --- EXTRACT ---
    printfn "\n[1/3] Extraindo dados..."
    let orders     = readOrdersFromFile orderPath
    let orderItems = readOrderItemsFromFile orderItemPath
    printfn "  Orders carregadas: %d" (List.length orders)
    printfn "  OrderItems carregados: %d" (List.length orderItems)

    // --- TRANSFORM ---
    printfn "\n[2/3] Transformando dados..."

    // Filtra os pedidos pelo status e origem desejados
    let filteredOrders = filterOrders status origin orders
    printfn "  Pedidos após filtro: %d" (List.length filteredOrders)

    // Realiza o inner join entre pedidos filtrados e seus itens
    let joined = innerJoin filteredOrders orderItems
    printfn "  Itens após join: %d" (List.length joined)

    // Agrega os itens em summaries por OrderId
    let summaries = buildSummaries joined
    printfn "  Summaries gerados: %d" (List.length summaries)

    // --- LOAD ---
    printfn "\n[3/3] Carregando saída..."
    writeSummariesToFile outputPath summaries

    printfn "\nProcessamento concluído com sucesso!"
    0
