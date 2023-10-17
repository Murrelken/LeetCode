use std::collections::{HashSet, VecDeque};

pub fn validate_binary_tree_nodes(n: i32, left_child: Vec<i32>, right_child: Vec<i32>) -> bool {
    let root = find_root(n, &left_child, &right_child);
    if root == -1 {
        return false;
    }

    let mut seen = HashSet::new();
    let mut queue = VecDeque::new();
    seen.insert(root);
    queue.push_back(root);

    while !queue.is_empty() {
        let node = queue.pop_front().unwrap() as usize;
        let children = vec![left_child[node], right_child[node]];

        for child in children {
            if child != -1 {
                if seen.contains(&child) {
                    return false;
                }

                queue.push_back(child);
                seen.insert(child);
            }
        }
    }

    return seen.len() as i32 == n;
}

fn find_root(n: i32, left_child: &Vec<i32>, right_child: &Vec<i32>) -> i32 {
    let mut hash_set = HashSet::new();
    for x in left_child {
        hash_set.insert(*x);
    }

    for x in right_child {
        hash_set.insert(*x);
    }

    for i in 0..n {
        if !hash_set.contains(&i) {
            return i;
        }
    }

    return -1;
}
