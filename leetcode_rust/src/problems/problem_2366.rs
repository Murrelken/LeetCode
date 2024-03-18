pub fn minimum_replacement(mut nums: Vec<i32>) -> i64 {
    let mut res = 0i64;

    for i in (0..nums.len() - 1).rev() {
        if nums[i] <= nums[i + 1] {
            continue;
        }

        let mut parts_num = nums[i] / nums[i + 1];

        if nums[i] % nums[i+1] != 0 {
            parts_num += 1;
        }

        res += (parts_num - 1) as i64;

        nums[i] = nums[i] / parts_num;
    }

    res
}
