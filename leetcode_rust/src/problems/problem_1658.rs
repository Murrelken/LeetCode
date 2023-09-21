use std::collections::HashMap;

pub fn min_operations(nums: Vec<i32>, x: i32) -> i32 {
    let x = x as i64;
    let mut sums = vec![0i64; nums.len()];
    sums[0] = nums[0] as i64;

    for i in 1..nums.len() {
        sums[i] = sums[i - 1] + nums[i] as i64;
    }

    let mut res = i32::MAX;
    let target = sums[nums.len() - 1] - x;
    let mut sum_2_idx: HashMap<i64, i32> = HashMap::new();

    for i in 0..nums.len() {
        let curr = sums[i];
        let prev = curr - target;

        if prev == 0 {
            res = i32::min(res, (nums.len() - (i + 1)) as i32);
        } else if sum_2_idx.contains_key(&prev) {
            res = i32::min(res, (nums.len() - (i + 1)) as i32 + sum_2_idx[&prev] + 1);
        }

        if !sum_2_idx.contains_key(&curr) {
            sum_2_idx.insert(curr, i as i32);
        }
    }

    if target == 0 {
        res = i32::min(res, sums.len() as i32);
    }

    if res == i32::MAX {
        -1
    } else {
        res
    }
}
