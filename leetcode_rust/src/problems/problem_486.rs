pub fn predict_the_winner(nums: Vec<i32>) -> bool {
    let n = nums.len();
    let mut dp = vec![vec![-1; n]; n];

    max_diff(&mut dp, &nums, 0, n - 1) >= 0
}

fn max_diff(memo: &mut Vec<Vec<i32>>, nums: &Vec<i32>, left: usize, right: usize) -> i32 {
    if memo[left][right] != -1 {
        return memo[left][right];
    }
    if left == right {
        return nums[left];
    }

    let left_score = nums[left] - max_diff(memo, nums, left + 1, right);
    let right_score = nums[right] - max_diff(memo, nums, left, right - 1);
    memo[left][right] = std::cmp::max(left_score, right_score);

    memo[left][right]
}
