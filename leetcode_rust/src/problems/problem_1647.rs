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

    let mut res = 0;

    for i in (1..max + 1).rev() {
        if !count_by_count.contains_key(&i) {
            continue;
        }
        loop {
            loop {
                if (max == 0 || !count_by_count.contains_key(&max)) && max < i {
                    break;
                }
                max -= 1;
            }
            let x = count_by_count.entry(i).or_default();
            if *x <= 1 {
                break;
            }
            *x -= 1;
            res += i - max;
            count_by_count.insert(max, 1);
        }
    }

    res
}
