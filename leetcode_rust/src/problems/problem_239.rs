use std::collections::VecDeque;

pub fn max_sliding_window(nums: Vec<i32>, k: i32) -> Vec<i32> {
    let k = k as usize;
    let mut sw_i = VecDeque::new();
    for i in 0..k {
        while sw_i.len() > 0 && nums[i]  >= nums[sw_i[sw_i.len() - 1]] {
            sw_i.pop_back();
        }
        sw_i.push_back(i);
    }
    let mut res = vec![nums[sw_i[0]]];

    for i in k..nums.len() {
        if sw_i[0] == (i - k) {
            sw_i.pop_front();
        }
        while sw_i.len() > 0 && nums[i]  >= nums[sw_i[sw_i.len() - 1]] {
            sw_i.pop_back();
        }
        sw_i.push_back(i);
        res.push(nums[sw_i[0]]);
    }

    res
}
