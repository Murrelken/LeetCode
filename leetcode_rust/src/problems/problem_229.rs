use std::collections::HashMap;

pub fn majority_element(nums: Vec<i32>) -> Vec<i32> {
    let mut frequency: HashMap<i32, i32> = HashMap::new();

    for x in nums.iter() {
        *frequency.entry(*x).or_default() += 1;
    }

    let mut temp: Vec<_> = frequency.iter().collect();
    temp.sort_by(|x, y| x.1.cmp(y.1));

    let mut res = Vec::new();
    let third = (nums.len() / 3) as i32;

    for x in temp.iter().rev().take(2) {
        if x.1 > &third {
            res.push(*x.0);
        }
    }

    res
}
