use std::cmp::Ordering;

pub fn sort_by_bits(arr: Vec<i32>) -> Vec<i32> {
    let mut arr: Vec<_> = arr
        .iter()
        .map(|x| {
            let mut y = *x;
            let mut count = 0;
            while y > 0 {
                if y >> 1 << 1 != y {
                    count += 1;
                }
                y >>= 1;
            }
            return (*x, count);
        })
        .collect();

    arr.sort_by(|(x1, count1), (x2, count2)| {
        let count_cmp = count1.cmp(count2);
        if let Ordering::Equal = count_cmp {
            x1.cmp(x2)
        } else {
            count_cmp
        }
    });

    arr.iter().map(|(x, _)| *x).collect()
}
