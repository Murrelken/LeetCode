use std::collections::VecDeque;
use std::iter::repeat;

pub fn find_kth_largest(nums: Vec<i32>, k: i32) -> i32 {
    let mut vec: VecDeque<_> = repeat(i32::MIN).take(k as usize).collect();

    for el in nums {
        let i = match vec.binary_search(&el) {
            Ok(x) => { x }
            Err(x) => { x }
        };
        if i == 0 {
            continue;
        }
        vec.insert(i, el);
        vec.pop_front();
    }

    vec[0]
}
