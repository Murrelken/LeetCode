pub fn integer_break(n: i32) -> i32 {
    let mut res = 1;
    if n == 3 {
        res = 2;
    }

    let mut number_of_multipliers = n / 2;

    while number_of_multipliers > 1 {
        let mut temp_res = 1;
        let mut remaining = n % number_of_multipliers;
        let multiplier = n / number_of_multipliers;

        let mut temp_number_of_multipliers = number_of_multipliers;
        while temp_number_of_multipliers > 0 {
            temp_number_of_multipliers -= 1;
            temp_res *= multiplier
                + if remaining > 0 {
                    remaining -= 1;
                    1
                } else {
                    0
                }
        }

        if temp_res <= res {
            break;
        }

        res = temp_res;
        number_of_multipliers -= 1;
    }

    res
}
