module Types

type Order = {
    id: int
    client_id: int
    order_date: string
    status: string
    origin: string
}

type OrderItem = {
    order_id: int
    product_id: int
    quantity: int
    price: float
    tax: float
}

type OrderSummary = {
    order_id: int
    total_amount: float
    total_taxes: float
}