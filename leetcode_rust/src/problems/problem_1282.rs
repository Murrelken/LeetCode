use std::collections::HashMap;

pub fn group_the_people(group_sizes: Vec<i32>) -> Vec<Vec<i32>> {
    let mut result: Vec<Vec<i32>> = Vec::new();
    let mut dic: HashMap<i32, usize> = HashMap::new();

    for (i, x) in group_sizes.iter().enumerate() {
        if !dic.contains_key(x) || result[dic[x]].len() == *x as usize {
            result.push(Vec::new());
            dic.insert(*x, result.len() - 1);
        }
        let vec_i = dic[x];
        result[vec_i].push(i as i32);
    }

    result.sort_by(|x, y| x.len().cmp(&y.len()));
    result
}
