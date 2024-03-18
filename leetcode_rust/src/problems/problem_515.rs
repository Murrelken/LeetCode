use crate::structures::tree_node::TreeNode;
use std::cell::RefCell;
use std::collections::VecDeque;
use std::rc::Rc;

pub fn largest_values(root: Option<Rc<RefCell<TreeNode>>>) -> Vec<i32> {
    let mut res = Vec::new();

    if let Some(node) = root {
        let mut q = VecDeque::new();
        q.push_back(node);

        while !q.is_empty() {
            let mut count = q.len();
            let mut max = i32::MIN;
            while count > 0 {
                count -= 1;
                if let Some(node) = q.pop_front() {
                    let current = node.borrow();
                    max = max.max(current.val);
                    if let Some(node) = current.left.clone() {
                        q.push_back(node);
                    }
                    if let Some(node) = current.right.clone() {
                        q.push_back(node);
                    }
                }
            }

            res.push(max);
        }
    }

    return res;
}
