pub fn generate(num_rows: i32) -> Vec<Vec<i32>> {
    let mut res = vec![vec![1]];
    while res.len() < num_rows as usize {
        let mut last = Vec::new();
        let prev = res.last().unwrap();
        last.push(1);
        for i in 0..prev.len() - 1 {
            last.push(prev[i] + prev[i + 1]);
        }
        last.push(1);
        res.push(last);
    }

    res
}
