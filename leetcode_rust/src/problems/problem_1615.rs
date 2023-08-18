use std::collections::{HashMap, HashSet};
use std::collections::hash_map::Entry::Occupied;

pub fn maximal_network_rank(n: i32, roads: Vec<Vec<i32>>) -> i32 {
    let n = n as usize;
    let mut weights: Vec<_> = (0..n).map(|i| (0, i as i32)).collect(); //vec!(0; n as usize);
    let mut paths = HashMap::new();

    for x in roads {
        weights[x[0] as usize].0 += 1;
        weights[x[1] as usize].0 += 1;

        paths.entry(x[0]).or_insert(HashSet::new()).insert(x[1]);
        paths.entry(x[1]).or_insert(HashSet::new()).insert(x[0]);
    }

    weights.sort_by(|(f_w, _), (s_w, _)| f_w.cmp(s_w));

    if weights[n - 1].0 != weights[n - 2].0 {
        let mut start_i = n - 2;
        while start_i > 0 && weights[start_i - 1].0 == weights[n - 2].0 {
            start_i -= 1;
        }

        for i in start_i..n - 1 {
            if let Some(x) = paths.get(&weights[i].1) {
                if x.contains(&weights[n - 1].1) {
                    continue;
                } else {
                    return weights[n - 1].0 + weights[n - 2].0;
                }
            } else {
                return weights[n - 1].0 + weights[n - 2].0;
            }
        }

        weights[n - 1].0 + weights[n - 2].0 - 1
    } else {
        let mut start_i = n - 1;
        while start_i > 0 && weights[start_i - 1].0 == weights[n - 1].0 {
            start_i -= 1;
        }

        for i in start_i..n {
            for j in i + 1..n {
                if let Some(x) = paths.get(&weights[i].1) {
                    if x.contains(&weights[j].1) {
                        continue;
                    } else {
                        return weights[n - 1].0 + weights[n - 2].0;
                    }
                } else {
                    return weights[n - 1].0 + weights[n - 2].0;
                }
            }
        }

        weights[n - 1].0 + weights[n - 2].0 - 1
    }
}
