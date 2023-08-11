pub fn get_shift_of_rotated_vector<T>(n: usize, nums: &Vec<T>) -> usize {
    match nums.iter().zip(nums.iter().skip(1)).find(|(l, r)| l > r) {
        Some((x, ..)) => { x.0 + 1 },
        None => {n}
    }
}