pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
    let mut current_replace = 1usize;
    let mut current_element = nums[0];

    for i in 1..nums.len() {
        let x = nums[i];
        if x != current_element {
            nums[current_replace] = x;
            current_element = x;
            current_replace += 1;
        }
    }

    current_replace as i32
}
