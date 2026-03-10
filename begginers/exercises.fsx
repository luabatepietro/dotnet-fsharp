


// 1. Escreva uma função que calcula um hash simples: h(x) = (x^3 mod n)
let hash (x : float) (n : float) = (x ** 3) % n
let ex1 = hash 3.0 10.0 
// printfn "h(x) = %.2f" ex1



// 2. Escreva uma função que recebe 3 números e retorna o maior

// aprendendo condicionais
let bigger x y z = 
    if ((x > y) && (x > z)) then
        printfn "%i" x // se quisesse retornar era só colocar um "x"
    elif ((y >= x ) && (y > z))  then
        printfn "%i" y
    else
        printfn "%i" z

// bigger 5 5 1

// usando o max
let bigger2 x y z = 
    max (max x y) z // bem melhor!

// printfn "%i" (bigger2 2 5 5)



// 3. Escreva uma função que calcula a soma dos dígitos de um número

let rec sum_digits x = 

    let ultimoDigito: int = x % 10

    let prox_numero = x / 10

    if prox_numero > 0 then
        ultimoDigito + sum_digits prox_numero
    else
        ultimoDigito
        
// printfn "%i" (sum_digits 1234)



// 4. Escreva uma função que calcula o n-ésimo número de Tribonacci
let rec tribonnaci x = 
    if x = 0 then 0
    elif x = 1 then 1
    elif x = 2 then 1
    else 
        tribonnaci (x-1) + tribonnaci (x-2) + tribonnaci (x-3)

// printfn "%i" (tribonnaci 10)



// 5. Escreva uma função que verifica se um número é primo
let prime_number x= 

    let rec test divisor = 
        if divisor = x then
            true
        elif x % divisor = 0 then
            false
        else 
            test (divisor + 1)
    if x <= 1 then
        false
    else
        test 2

// printfn "%b" (prime_number 13)



// 6. Escreva uma função que retorna o próximo primo
let next_prime_number x= 
    let rec find n= 
        if prime_number n then n
        else find (n + 1)
    find (x + 1)

// printfn "%i" (next_prime_number 3)



// 7. Escreva uma função que recebe um prefixo e devolve uma função que adiciona o prefixo a qualquer string
let addPrefix prefixo string = 
    prefixo + string

printfn "%s" (addPrefix "Sr." "Lucas")

    
    
            


