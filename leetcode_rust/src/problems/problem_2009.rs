use std::collections::HashSet;

pub fn min_operations(nums: Vec<i32>) -> i32 {
    let n = nums.len() as i32;
    let mut res = n - 1;
    let unique: HashSet<_> = nums.into_iter().collect();

    let mut new_nums: Vec<_> = unique.clone().into_iter().collect();
    new_nums.sort();

    for i in 0..new_nums.len() {
        let left = new_nums[i];
        let right = left + n - 1;
        let j = match new_nums.binary_search(&right) {
            Ok(i) => i + 1,
            Err(i) => i,
        };
        let count = j as i32 - i as i32;
        res = res.min(n - count);
    }

    res
}
