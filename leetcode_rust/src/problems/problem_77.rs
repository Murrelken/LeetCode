pub fn combine(n: i32, k: i32) -> Vec<Vec<i32>> {
    let mut result: Vec<Vec<i32>> = Vec::new();
    req(n, k as usize, 1, &mut Vec::new(), &mut result);
    return result;
}

fn req(n: i32, k: usize, i: i32, l: &mut Vec<i32>, res: &mut Vec<Vec<i32>>) {
    if l.len() == k {
        res.push(l.clone())
    } else {
        for new_item in i..n + 1 {
            l.push(new_item);
            req(n, k, new_item + 1, l, res);
            l.pop();
        }
    }
}
