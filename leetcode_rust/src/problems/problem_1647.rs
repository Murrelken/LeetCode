use std::collections::HashMap;

pub fn min_deletions(s: String) -> i32 {
    let mut count_by_char: HashMap<char, i32> = HashMap::new();

    for c in s.chars() {
        *count_by_char.entry(c).or_default() += 1;
    }

    let mut max = i32::MIN;

    let mut count_by_count: HashMap<i32, i32> = HashMap::new();
    for x in count_by_char.values() {
        *count_by_count.entry(*x).or_default() += 1;
        max = max.max(*x);
    }

    let mut temp_max = max;
    println!("{:?}", max);
    loop {
        if temp_max == 0 || !count_by_count.contains_key(&temp_max) {
            break;
        }
        temp_max -= 1;
    }

    let mut res = 0;

    for i in (1..max + 1).rev() {
        println!("{:?}", i);
        if !count_by_count.contains_key(&i) {
            continue;
        }
        let x = count_by_count.entry(i).or_default();
        while *x > 1 {
            res += *x - max;
            loop {
                if temp_max == 0 || !count_by_count.contains_key(&temp_max) {
                    break;
                }
                temp_max -= 1;
            }
            *x -= 1;
        }
    }

    res
}
