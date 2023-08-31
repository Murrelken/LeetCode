use std::collections::VecDeque;

pub fn sort_items(n: i32, m: i32, mut group: Vec<i32>, before_items: Vec<Vec<i32>>) -> Vec<i32> {
    let mut indegree = vec![0; n as usize];
    let mut adj = vec![vec![]; n as usize];
    for (item, deps) in before_items.iter().enumerate() {
        for &dep in deps {
            adj[dep as usize].push(item);
            indegree[item] += 1;
        }
    }
    let items_ids = top_sort(adj, indegree);
    if items_ids.len() != n as usize { return vec![]; }

    let mut groups = items_ids.into_iter().fold(vec![vec![]; m as usize], |mut acc, i| {
        if group[i] == -1 {
            group[i] = acc.len() as i32;
            acc.push(vec![]);
        }
        acc[group[i] as usize].push(i as i32);
        acc
    });

    let mut indegree = vec![0; groups.len()];
    let mut adj = vec![vec![]; groups.len()];
    for (item, deps) in before_items.into_iter().enumerate() {
        for dep in deps {
            let (src, dst) = (group[dep as usize] as usize, group[item] as usize);
            if src == dst { continue; }
            adj[src].push(dst);
            indegree[dst] += 1;
        }
    }
    let group_ids = top_sort(adj, indegree);
    if group_ids.len() != groups.len() { return vec![]; }

    group_ids.into_iter().fold(Vec::new(), |mut acc, i| {
        acc.append(&mut groups[i]);
        acc
    })
}

fn top_sort(adj: Vec<Vec<usize>>, mut indegree: Vec<u32>) -> Vec<usize> {
    let mut q = indegree
        .iter()
        .enumerate()
        .filter(|(_, &d)| d == 0)
        .map(|(node, _)| node)
        .collect::<VecDeque<_>>();

    let mut res = Vec::new();

    while let Some(node) = q.pop_front() {
        res.push(node);
        for &adj_node in adj[node].iter() {
            indegree[adj_node] -= 1;
            if indegree[adj_node] == 0 {
                q.push_back(adj_node)
            }
        }
    }

    res
}
