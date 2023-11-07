pub fn rotate(nums: &mut Vec<i32>, k: i32) {
    let n = nums.len();
    let k = k as usize % n;
    if k == 0 {
        return;
    }

    let mut rotated = vec![false; n];

    let mut index_to_insert = k;

    while rotated.iter().any(|x| !x) {
        let starting_index = index_to_insert - k;
        let mut holding_element = nums[starting_index];
        loop {
            let temp = nums[index_to_insert];
            nums[index_to_insert] = holding_element;
            index_to_insert = (index_to_insert + k) % n;
            holding_element = temp;
            rotated[index_to_insert] = true;

            if index_to_insert == starting_index + k {
                break;
            }
        }

        index_to_insert += 1;
    }
}

pub fn rotate_with_reverses(nums: &mut Vec<i32>, k: i32) {
    let n = nums.len();
    let k = k as usize % n;
    nums.reverse();
    nums[0..k].reverse();
    nums[k..n].reverse();
}
