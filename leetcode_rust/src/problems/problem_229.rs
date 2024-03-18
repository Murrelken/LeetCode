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

pub fn majority_element_v2(nums: Vec<i32>) -> Vec<i32> {
    let mut frequency: HashMap<i32, i32> = HashMap::new();

    for x in nums.iter() {
        *frequency.entry(*x).or_default() += 1;
    }

    let mut max = i32::MIN;
    let mut max_value = i32::MIN;
    let mut second_max = i32::MIN;
    let mut second_max_value = i32::MIN;

    for x in frequency {
        if x.1 > max {
            second_max = max;
            second_max_value = max_value;
            max = x.1;
            max_value = x.0;
        } else if x.1 > second_max {
            second_max = x.1;
            second_max_value = x.0;
        }
    }

    let mut res = Vec::new();
    let third = (nums.len() / 3) as i32;

    if max > third {
        res.push(max_value);
    }
    if second_max > third {
        res.push(second_max_value);
    }

    res
}

pub fn majority_element_v3(nums: Vec<i32>) -> Vec<i32> {
    let mut first_num = i32::MIN;
    let mut second_num = i32::MIN;
    let mut first_count = 0;
    let mut second_count = 0;

    for num in nums.iter() {
        if num == &first_num {
            first_count += 1;
        } else if num == &second_num {
            second_count += 1;
        } else if first_count == 0 {
            first_num = *num;
            first_count = 1;
        } else if second_count == 0 {
            second_num = *num;
            second_count = 1;
        } else {
            first_count -= 1;
            second_count -= 1;
        }
    }

    first_count = 0;
    second_count = 0;

    let third = nums.len() / 3;

    for x in nums {
        if x == first_num {
            first_count += 1;
        }
        if x == second_num {
            second_count += 1;
        }
    }

    let mut res = Vec::new();

    if first_count > third {
        res.push(first_num);
    }
    if second_count > third {
        res.push(second_num);
    }

    res
}
