pub fn minimize_max(mut nums: Vec<i32>, p: i32) -> i32 {
    nums.sort();
    let mut left = 0;
    let mut right = nums[nums.len() - 1] - nums[0];

    while left < right {
        let mid = left + (right - left) / 2;

        if count_pairs(&nums, mid) >= p {
            right = mid;
        } else {
            left = mid + 1;
        }
    }

    left
}

fn count_pairs(nums: &Vec<i32>, threshold: i32) -> i32 {
    let mut count = 0;
    let mut i = 0;

    while i < nums.len() - 1 {
        if nums[i + 1] - nums[i] <= threshold {
            count += 1;
            i += 1;
        }
        i += 1;
    }

    count
}
