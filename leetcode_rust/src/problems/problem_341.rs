use std::collections::VecDeque;

#[derive(Debug, PartialEq, Eq)]
pub enum NestedInteger {
    Int(i32),
    List(Vec<NestedInteger>),
}

pub struct NestedIterator {
    queue: VecDeque<i32>,
}

impl NestedIterator {
    pub fn new(nested_list: Vec<NestedInteger>) -> Self {
        let mut new = NestedIterator {
            queue: VecDeque::new(),
        };

        for x in nested_list {
            new.dfs(x);
        }

        new
    }

    pub fn next(&mut self) -> i32 {
        self.queue.pop_front().unwrap_or_default()
    }

    pub fn has_next(&self) -> bool {
        !self.queue.is_empty()
    }

    fn dfs(&mut self, curr: NestedInteger) {
        match curr {
            NestedInteger::Int(x) => {
                self.queue.push_back(x);
            }
            NestedInteger::List(x) => {
                for x in x {
                    self.dfs(x);
                }
            }
        }
    }
}
