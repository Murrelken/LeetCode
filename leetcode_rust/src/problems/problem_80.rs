pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
    let mut current = nums[0];
    let mut current_added_twice = false;
    let mut index_to_insert = 1;

    for i in 1..nums.len() {
        if nums[i] != current {
            nums[index_to_insert] = nums[i];
            index_to_insert += 1;
            current = nums[i];
            current_added_twice = false;
        } else if !current_added_twice {
            nums[index_to_insert] = nums[i];
            index_to_insert += 1;
            current_added_twice = true;
        }
    }

    index_to_insert as i32
}
