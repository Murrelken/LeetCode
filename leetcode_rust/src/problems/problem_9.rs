pub fn is_palindrome(x: i32) -> bool {
    if x < 0 {
        return false;
    }

    let mut rev = 0;
    let mut temp = x;

    while temp > 0 {
        rev *= 10;
        rev += temp % 10;
        temp /= 10;
    }

    rev == x
}
