pub fn longest_common_prefix(strs: Vec<String>) -> String {
    let strs: Vec<Vec<_>> = strs.iter().map(|s| s.chars().collect()).collect();
    let mut result = strs[0].clone();

    for x in strs.iter().skip(1) {
        println!("{:?}", x);
        if result.len() == 0 {
            break;
        }
        let mut last = result.len().min(x.len());
        for i in 0..last {
            if result[i] == x[i] {
                continue;
            }
            last = i;
            break;
        }
        for _ in 0..result.len() - last {
            result.pop();
        }
    }

    result.iter().collect()
}
