pub fn jump(nums: Vec<i32>) -> i32 {
    let n = nums.len();
    let mut dp = vec![i32::MAX; n];
    dp[0] = 0;
    for i in 0..n {
        let current_step = dp[i] + 1;
        for j in (i + 1..=(n - 1).min(i + nums[i] as usize)).rev() {
            if dp[j] <= current_step {
                break;
            } else {
                dp[j] = current_step;
            }
        }
    }

    dp[n - 1]
}

pub fn jump_v2(mut nums: Vec<i32>) -> i32 {
    let n = nums.len();
    for i in 1..n {
        nums[i] = (nums[i] + i as i32).max(nums[i - 1]);
    }

    let mut ind = 0;
    let mut res = 0;

    while ind < n - 1 {
        res += 1;
        ind = nums[ind] as usize;
    }

    res
}
