pub fn search(nums: Vec<i32>, target: i32) -> i32 {
    let n = nums.len();

    let shift = super::helpers::get_shift_of_rotated_vector(n, &nums);

    let mut left = 0usize;
    let mut right = n - 1;

    while right - left > 1 {
        let mid = (right + left) / 2;
        let shifted_mid = (mid + shift) % n;
        let mid_el = nums[shifted_mid];
        if mid_el == target { return shifted_mid as i32; }
        if mid_el > target { right = mid; } else { left = mid; }
    }

    let shifted_right = (right + shift) % n;
    let shifted_left = (left + shift) % n;

    if nums[shifted_right] == target { shifted_right as i32 } else if nums[shifted_left] == target { shifted_left as i32 } else { -1 }
}
