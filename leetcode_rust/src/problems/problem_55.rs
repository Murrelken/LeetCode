pub fn can_jump(nums: Vec<i32>) -> bool {
    let mut consecutive_zeros = 0;
    for i in (0..nums.len() - 1).rev() {
        if nums[i] == 0 {
            consecutive_zeros += 1;
        } else if consecutive_zeros > 0 {
            if nums[i] >= consecutive_zeros + 1 {
                consecutive_zeros = 0;
            } else {
                consecutive_zeros += 1;
            }
        }
    }
    consecutive_zeros == 0
}

pub fn can_jump_v2(nums: Vec<i32>) -> bool {
    let mut reachable = 0;
    for i in 0..nums.len() {
        if i > reachable {
            return false;
        }
        reachable = reachable.max(i + nums[i] as usize);
    }
    true
}
