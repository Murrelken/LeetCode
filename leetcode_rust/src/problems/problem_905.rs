pub fn sort_array_by_parity(mut nums: Vec<i32>) -> Vec<i32> {
    let mut left_odd = 0usize;

    while left_odd < nums.len() {
        if nums[left_odd] % 2 == 0 {
            left_odd += 1;
        } else {
            let mut do_return = true;
            for i in left_odd + 1..nums.len() {
                if nums[i] % 2 == 0 {
                    let temp = nums[i];
                    nums[i] = nums[left_odd];
                    nums[left_odd] = temp;
                    do_return = false;
                    break;
                }
            }
            if do_return {
                return nums;
            }
        }
    }

    nums
}

pub fn sort_array_by_parity_v2(mut nums: Vec<i32>) -> Vec<i32> {
    let mut right = nums.len() - 1;
    let mut left = 0;

    while left < right {
        if nums[left] % 2 == 1 {
            let temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            right -= 1;
        } else {
            left += 1;
        }
    }

    nums
}
