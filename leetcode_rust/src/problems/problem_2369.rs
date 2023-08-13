use std::collections::HashMap;

pub fn valid_partition(nums: Vec<i32>) -> bool {
    check(0, &nums, &mut HashMap::new())
}

fn check(i: usize, nums: &Vec<i32>, dp: &mut HashMap<usize, bool>) -> bool {
    if i == nums.len() {
        return true;
    }

    if let Some((_, val)) = dp.get_key_value(&i) {
        return *val;
    }

    if i > nums.len() - 2 {
        dp.insert(i, false);
        return false;
    } else if i < nums.len() - 2 {
        if nums[i] == nums[i + 1] && nums[i] == nums[i + 2] && check(i + 3, nums, dp) {
            dp.insert(i, true);
            return true;
        }
        if nums[i] == nums[i + 1] - 1 && nums[i] == nums[i + 2] - 2 && check(i + 3, nums, dp) {
            dp.insert(i, true);
            return true;
        }
    }

    if nums[i] == nums[i + 1] && check(i + 2, nums, dp) {
        dp.insert(i, true);
        return true;
    }

    dp.insert(i, false);
    false
}
