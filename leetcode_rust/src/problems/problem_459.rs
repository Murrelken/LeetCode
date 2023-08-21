pub fn repeated_substring_pattern(s: String) -> bool {
    let n = s.len();

    if n == 1 {
        return false;
    }

    for i in 1..n / 2 + 1 {
        let modulo = n % i;
        if modulo != 0 {
            continue;
        }

        let temp = &s[..i];

        if temp.repeat(n / i) == s {
            return true;
        }
    }

    false
}
