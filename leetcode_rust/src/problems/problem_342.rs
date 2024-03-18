pub fn is_power_of_four(n: i32) -> bool {
    let n = n as i64;
    let mut a = 1i64;
    while a < n {
        a *= 4;
    }

    a == n
}
