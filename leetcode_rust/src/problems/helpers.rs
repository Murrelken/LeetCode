pub fn get_shift_of_rotated_vector<T: PartialOrd>(n: usize, nums: &Vec<T>) -> usize {
    match nums.iter().zip(nums.iter().skip(1)).enumerate().find(|(_, (l, r))| l > r) {
        Some((x, ..)) => { x + 1 }
        None => { n }
    }
}