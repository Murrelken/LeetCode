pub fn find_duplicate(nums: Vec<i32>) -> i32 {
    let mut hash_set = vec![false; nums.len()];
    for x in nums {
        if hash_set[(x - 1) as usize] {
            return x;
        }
        hash_set[(x - 1) as usize] = true;
    }
    -1
}
