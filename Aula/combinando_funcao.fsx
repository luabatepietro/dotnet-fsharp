let apply_twice f x = f (f x)

let double x = x * 2
let square x = x * x

let double_square x = square >> double 





