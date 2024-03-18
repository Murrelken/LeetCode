use crate::structures::tree_node::TreeNode;
use std::cell::RefCell;
use std::cmp::Ordering;
use std::collections::HashMap;
use std::rc::Rc;

pub fn find_mode_recursive(root: &Option<Rc<RefCell<TreeNode>>>, count: &mut HashMap<i32, u32>) {
    if let Some(node) = root {
        count
            .entry((*node).borrow().val)
            .and_modify(|counter| *counter += 1)
            .or_insert(1);
        find_mode_recursive(&(**node).borrow().left, count);
        find_mode_recursive(&(**node).borrow().right, count);
    }
}

pub fn find_mode(root: Option<Rc<RefCell<TreeNode>>>) -> Vec<i32> {
    let mut count: HashMap<i32, u32> = HashMap::new();

    find_mode_recursive(&root, &mut count);

    let mut solution: Vec<i32> = Vec::new();
    let mut highest_count = 0;
    for (key, value) in count.iter() {
        match value.cmp(&highest_count) {
            Ordering::Less => {}
            Ordering::Equal => {
                solution.push(*key);
            }
            Ordering::Greater => {
                solution.clear();
                solution.push(*key);
                highest_count = *value;
            }
        }
    }
    return solution;
}
