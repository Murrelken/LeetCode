use std::cmp::Ordering;

pub fn min_taps(n: i32, ranges: Vec<i32>) -> i32 {
    let mut sorted: Vec<_> = ranges
        .iter()
        .enumerate()
        .filter(|(_, r)| r != &&0)
        .collect();

    sorted.sort_by(|(a_i, a_r), (b_i, b_r)| {
        let left_border_first = *a_i as i32 - **a_r;
        let left_border_second = *b_i as i32 - **b_r;

        return match left_border_first.cmp(&left_border_second) {
            Ordering::Equal => {
                let right_border_first = *a_i as i32 + **a_r;
                let right_border_second = *b_i as i32 + **b_r;

                right_border_first.cmp(&right_border_second)
            }
            x => { x }
        };
    });

    let mut right = 0;
    let mut temp_right = 0;
    let mut res = 0;
    let mut i = 0;

    while right < n && i < sorted.len() {
        let (item_index, item_range) = sorted[i];
        let left_border = item_index as i32 - *item_range;

        if left_border > right {
            if temp_right == right {
                return -1;
            } else {
                right = temp_right;
                res += 1;
            }
        } else {
            temp_right = temp_right.max(item_index as i32 + *item_range);
            i += 1;
        }
    }

    if right < n {
        if temp_right >= n {
            res += 1;
        } else {
            return -1;
        }
    }

    res
}
