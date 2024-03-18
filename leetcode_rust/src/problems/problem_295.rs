use std::cmp::Reverse;
use std::collections::BinaryHeap;

#[derive(Debug)]
pub struct MedianFinder {
    min: BinaryHeap<i32>,
    max: BinaryHeap<Reverse<i32>>,
}

impl MedianFinder {
    pub fn new() -> Self {
        MedianFinder {
            min: BinaryHeap::new(),
            max: BinaryHeap::new(),
        }
    }

    pub fn add_num(&mut self, num: i32) {
        match self.max.peek() {
            None => match self.min.peek() {
                None => {
                    self.min.push(num);
                }
                Some(y) => {
                    if &num >= y {
                        self.max.push(Reverse(num));
                    } else {
                        self.max.push(Reverse(self.min.pop().unwrap()));
                        self.min.push(num);
                    }
                }
            },
            Some(x) => match self.min.peek() {
                None => {
                    if num <= x.0 {
                        self.min.push(num);
                    } else {
                        self.min.push(self.max.pop().unwrap().0);
                        self.max.push(Reverse(num));
                    }
                }
                Some(y) => {
                    if &num < y {
                        if self.min.len() <= self.max.len() {
                            self.min.push(num);
                        } else {
                            self.max.push(Reverse(self.min.pop().unwrap()));
                            self.min.push(num);
                        }
                    } else if num > x.0 {
                        if self.max.len() <= self.min.len() {
                            self.max.push(Reverse(num));
                        } else {
                            self.min.push(self.max.pop().unwrap().0);
                            self.max.push(Reverse(num));
                        }
                    } else {
                        if self.max.len() < self.min.len() {
                            self.max.push(Reverse(num));
                        } else {
                            self.min.push(num);
                        }
                    }
                }
            },
        }
    }

    pub fn find_median(&self) -> f64 {
        match self.max.peek() {
            None => match self.min.peek() {
                None => 0f64,
                Some(y) => *y as f64,
            },
            Some(x) => match self.min.peek() {
                None => x.0 as f64,
                Some(y) => {
                    if (self.min.len() + self.max.len()) % 2 == 0 {
                        (x.0 + *y) as f64 / 2.0
                    } else {
                        if self.max.len() > self.min.len() {
                            x.0 as f64
                        } else {
                            *y as f64
                        }
                    }
                }
            },
        }
    }
}
