pub fn is_monotonic(nums: Vec<i32>) -> bool {
    let mut ascending = false;

    let mut i = None;

    for j in 0..nums.len() - 1 {
        if nums[j + 1] > nums[j] {
            ascending = true;
            i = Some(j + 1);
            break;
        }
        if nums[j + 1] < nums[j] {
            i = Some(j + 1);
            break;
        }
    }

    if i == None {
        return true;
    }

    for j in i.unwrap()..nums.len() - 1 {
        if ascending && nums[j + 1] < nums[j] || !ascending && nums[j + 1] > nums[j] {
            return false;
        }
    }

    true
}
