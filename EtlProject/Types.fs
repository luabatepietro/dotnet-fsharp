module Types

/// Representa um pedido da tabela Order
type Order = {
    Id: int
    ClientId: int
    OrderDate: string
    Status: string
    Origin: string
}

/// Representa um item de pedido da tabela OrderItem
type OrderItem = {
    OrderId: int
    ProductId: int
    Quantity: int
    Price: float
    Tax: float
}

/// Representa a junção de Order e OrderItem (inner join)
type OrderJoined = {
    OrderId: int
    OrderDate: string
    Status: string
    Origin: string
    Quantity: int
    Price: float
    Tax: float
}

/// Representa a linha de saída agregada por pedido
type OrderSummary = {
    OrderId: int
    TotalAmount: float
    TotalTaxes: float
}
