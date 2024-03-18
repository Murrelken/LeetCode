pub fn find_array(pref: Vec<i32>) -> Vec<i32> {
    let mut prev_xor = 0;
    let mut result = Vec::new();

    for x in pref {
        let new_item = prev_xor ^ x;
        result.push(new_item);
        prev_xor ^= new_item;
    }

    result
}
