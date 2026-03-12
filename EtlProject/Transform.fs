module Transform

open Types

/// Helper: converte uma linha CSV (array de strings) em um record Order
let parseOrder (fields: string[]) : Order =
    { Id        = int fields.[0]
      ClientId  = int fields.[1]
      OrderDate = fields.[2]
      Status    = fields.[3]
      Origin    = fields.[4] }

/// Helper: converte uma linha CSV (array de strings) em um record OrderItem
let parseOrderItem (fields: string[]) : OrderItem =
    { OrderId   = int    fields.[0]
      ProductId = int    fields.[1]
      Quantity  = int    fields.[2]
      Price     = float  fields.[3]
      Tax       = float  fields.[4] }

/// Filtra pedidos pelo status e origem fornecidos
let filterOrders (status: string) (origin: string) (orders: Order list) : Order list =
    orders
    |> List.filter (fun o ->
        o.Status.ToLower() = status.ToLower() &&
        o.Origin.ToUpper() = origin.ToUpper())

/// Realiza inner join entre Orders e OrderItems pelo OrderId
let innerJoin (orders: Order list) (items: OrderItem list) : OrderJoined list =
    orders
    |> List.collect (fun o ->
        items
        |> List.filter (fun i -> i.OrderId = o.Id)
        |> List.map (fun i ->
            { OrderId   = o.Id
              OrderDate = o.OrderDate
              Status    = o.Status
              Origin    = o.Origin
              Quantity  = i.Quantity
              Price     = i.Price
              Tax       = i.Tax }))

/// Calcula a receita de um item (preço * quantidade)
let calcRevenue (item: OrderJoined) : float =
    item.Price * float item.Quantity

/// Calcula o imposto de um item (percentual * receita)
let calcTax (item: OrderJoined) : float =
    item.Tax * calcRevenue item

/// Agrega os itens de um pedido em um OrderSummary
let summarizeGroup (orderId: int) (items: OrderJoined list) : OrderSummary =
    let totalAmount = items |> List.fold (fun acc i -> acc + calcRevenue i) 0.0
    let totalTaxes  = items |> List.fold (fun acc i -> acc + calcTax i)    0.0
    { OrderId     = orderId
      TotalAmount = System.Math.Round(totalAmount, 2)
      TotalTaxes  = System.Math.Round(totalTaxes,  2) }

/// Transforma a lista de itens joined em summaries agrupados por OrderId
let buildSummaries (joined: OrderJoined list) : OrderSummary list =
    joined
    |> List.groupBy (fun i -> i.OrderId)
    |> List.map (fun (orderId, items) -> summarizeGroup orderId items)

/// Formata um OrderSummary como linha CSV
let formatSummaryLine (s: OrderSummary) : string =
    $"{s.OrderId},{s.TotalAmount},{s.TotalTaxes}"
