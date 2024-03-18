pub fn kth_grammar(_: i32, mut k: i32) -> i32 {
    k = k - 1;
    let bits = format!("{k:b}").chars().filter(|x| x == &'1').count();
    if bits % 2 == 0 {
        0
    } else {
        1
    }
}
