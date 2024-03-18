use std::collections::HashMap;

pub fn num_identical_pairs(nums: Vec<i32>) -> i32 {
    let mut dictionary: HashMap<i32, i32> = HashMap::new();

    for x in nums {
        *dictionary.entry(x).or_default() += 1;
    }

    let mut res = 0;

    for (_, mut v) in dictionary {
        while v > 0 {
            v -= 1;
            res += v;
        }
    }

    res
}
