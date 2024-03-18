pub fn unique_paths(m: i32, n: i32) -> i32 {
    let half_pascal_triangle = get_half_pascal_triangle((m+n-1) as usize, m.min(n) as usize);
    half_pascal_triangle[(m+n-2) as usize][(m.min(n) - 1) as usize]
}

fn get_half_pascal_triangle(depth: usize, width: usize) -> Vec<Vec<i32>> {
    let mut res = vec![vec![1], vec![1]];
    let mut double = true;
    while res.len() < depth {
        let last_i = res.len() - 1;
        res.push(Vec::from([1]));
        for i in 1..res[last_i].len().min(width) {
            let item = res[last_i][i - 1] + res[last_i][i];
            res.last_mut().unwrap().push(item);
        }
        if double {
            let double_item = res[last_i][res[last_i].len() - 1];
            res.last_mut().unwrap().push(double_item * 2);
        }
        double = !double;
    }

    res
}
