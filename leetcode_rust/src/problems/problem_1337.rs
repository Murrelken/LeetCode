pub fn k_weakest_rows(mat: Vec<Vec<i32>>, k: i32) -> Vec<i32> {
    let mut res: Vec<(usize, i32)> = mat
        .iter()
        .enumerate()
        .map(|(i, x)| (i, x.iter().sum()))
        .collect();
    res.sort_by(|x, y| x.1.cmp(&y.1));
    res.iter().take(k as usize).map(|x| x.0 as i32).collect()
}
