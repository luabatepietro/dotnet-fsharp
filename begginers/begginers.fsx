open System

let hello() =
    printf "Enter your name : "

    let name = Console.ReadLine()

    printfn "Hello %s" name

// hello()


let floats() = 
    printfn "PI : %f" 3.141592653589 // vai até 6 casas decimais por padrao
    printfn "PI : %.4f" 3.141592653589 // é possivel diminuir as casas

    let big_pi = 3.141592653589793284M // usar o M no final
    printfn "Big PI : %M" big_pi

// floats()

let bind_stuff() =
    let mutable weight = 175
    weight <- 170

    printfn "Weight : %i" weight

    let change_me = ref 10
    change_me := 50

    printfn "Change : %i" ! change_me


// bind_stuff()

let do_funcs() = 

    let get_sum (x: int, y : int) : int = x + y

    printfn "5 + 7 = %i" (get_sum(5, 7))


// do_funcs()

let recursive_funcs() =
    let rec factorial x =
        if x < 1 then 1
        else x * factorial (x - 1)
    
    printfn "Factorial 4 : %i" (factorial 4)

    // 1st : result = 4 * factorial(3) = 4 * 6 = 24
    // 2nd : result = 3 * factorial(2) = 3 * 2 = 6
    // 3rd : resul = 2 * factorial(1) = 2 * 1 = 2

// recursive_funcs()

let lambda_func() = 
    let rand_list = [1;2;3]

    let rand_list2 = List.map (fun x -> x * 2) rand_list

    printfn "Double List : %A" rand_list2

    // -----------------------------------

    [5;6;7;8]
    |> List.filter (fun v -> (v % 2) = 0)
    |> List.map (fun x -> x * 2)
    |> printfn "Even Doubles : %A" 

    // -----------------------------------

    let mult_num x = x * 3
    let add_num y = y + 5

    let mult_add = mult_num >> add_num
    let add_mult = mult_num << add_num

    printfn "mult_add : %i" (mult_add 10)
    printfn "add_mult : %i" (add_mult 10)


// lambda_func()

let do_math() = 
    printfn "5 + 4 = %i" (5 + 4)
    printfn "5 - 4 = %i" (5 - 4)
    printfn "5 * 4 = %i" (5 * 4)
    printfn "5 / 4 = %i" (5 / 4)
    printfn "5 %% 4 = %i" (5 % 4)
    printfn "5 ** 4 = %.1f" (5.0 ** 4.0)

    let number = 2
    printfn "Type : %A" (number.GetType())

    
    printfn "A Float : %.2f" (float number)
    printfn "An Int : %i" (int 3.14)

    // Also cos, sin, tan, acos, asin, atan.
    // cosh, sinh, tanh
    printfn "abs 4.5 : %i" (abs -1)
    printfn "ceil 4.5 : %f" (ceil 4.5)
    printfn "floor 4.5 : %f" (floor 4.5)
    printfn "log 2.71828 : %f" (log 2.71828)
    printfn "log10 1000 : %f" (log10 1000.0)
    printfn "sqrt 25 : %f" (sqrt 25.0)

//do_math()

let string_stuff() = 
    let str1 = "This is a random string"

    let str2 = @"I ignore backslashes"

    let str3 = """ "I ignore double quotes and backslashes" """

    let str4 = str1 + " " + str2

    printfn "Length : %i" (String.length str4)

    printfn "%c" str1.[1]

    printfn "1st Word : %s" (str1.[0..3])

    let upper_str = String.collect (fun c -> sprintf"%c, " c) "commas"
    printfn "Commas : %s" upper_str

    printfn "Any upper : %b" (String.exists (fun c -> Char.IsUpper(c)) str1)

    let string1 = String.init 10 (fun i -> i.ToString())
    printfn "Numbers : %s" string1

    String.iter(fun c -> printfn "%c" c) "Print Me"

// string_stuff()

let while_stuff() =
    let magic_num = "7"
    let mutable guess = ""

    while not (magic_num.Equals(guess)) do
        printf "Guess the number : "
        guess <- Console.ReadLine()

    printfn "You guessed the number!!!"

// while_stuff()

let loop_stuff() =
    for i = 1 to 10 do
        printfn "%i" i 
    
    for i = 10 downto 1 do
        printfn "%i" i
    
    for i in [1..10] do
        printfn "%i" i 
    
    [1..10] |> List.iter (printfn "Num : %i")

    let sum = List.reduce (+) [1..10]
    printfn "Sum : %i" sum

// loop_stuff()

let cond_stuff() =
    let age = 8

    if age < 5 then
        printfn "Preschool"
    elif age = 5 then
        printfn "Epstein"
    elif (age > 5) && (age <= 18) then
        let grade = age - 5
        printfn "Go to Grade %i" grade
    else
        printfn "Go to college"

    let gpa = 3.9
    let income = 15000

    printfn "College Grant : %b" ((gpa >= 3.8) || (income <= 12000))

    printfn "Not True : %b" (not true)

    let grade2: string =
        match age with
        | age when age < 5 -> "Preschool"
        | 5 -> "Kindergarten"
        | age when ((age > 5) && (age <= 18)) -> (age - 5).ToString()
        | _ -> "College"
    
    printfn "Grade2 : %s" grade2

// cond_stuff()

let list_stuff() =
    let list1 = [1;2;3;4]

    list1 |> List.iter(printfn "Num : %i")
    printfn "%A" list1

    let list2 = 5::6::7::[]
    printfn "%A" list2

    let list3 = [1..5]
    let list4 = ['a'..'g']
    printfn "%A" list4

    let list5 = List.init 5 (fun i -> i * 2)
    printfn "%A" list5




list_stuff()
Console.ReadKey() |> ignore 

