use std::collections::VecDeque;

struct MyStack {
    base_queue: VecDeque<i32>,
    temp_queue: VecDeque<i32>,
}


/**
 * `&self` means the method takes an immutable reference
 * If you need a mutable reference, change it to `&mut self` instead.
 */
impl MyStack {
    fn new() -> Self {
        MyStack {
            base_queue: VecDeque::new(),
            temp_queue: VecDeque::new(),
        }
    }

    fn push(&mut self, x: i32) {
        self.base_queue.push_back(x);
    }

    fn pop(&mut self) -> i32 {
        let mut res = 0;
        while let Some(x) = self.base_queue.pop_front() {
            if self.base_queue.is_empty() {
                res = x;
            } else {
                self.temp_queue.push_back(x);
            }
        }

        while let Some(x) = self.temp_queue.pop_front() {
            self.base_queue.push_back(x);
        }

        res
    }

    fn top(&mut self) -> i32 {
        let res = self.pop();
        self.push(res);

        res
    }

    fn empty(&self) -> bool {
        self.base_queue.is_empty()
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * let obj = MyStack::new();
 * obj.push(x);
 * let ret_2: i32 = obj.pop();
 * let ret_3: i32 = obj.top();
 * let ret_4: bool = obj.empty();
 */