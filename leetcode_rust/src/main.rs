#![allow(dead_code, unused_imports)]
mod problems;
mod structures;

use crate::problems::problem_295::MedianFinder;
use problems::*;
use std::cmp::Reverse;
use std::collections::{BinaryHeap, HashMap, VecDeque};
use std::sync::Mutex;
use structures::list_node::ListNode;

fn main() {
    //let input = gobln(1,gobln(4,gobln(3,gobln(2,gobln(5,gobln(2, None))))));

    // let mut input = vec!["flower", "flow", "flight"];
    // let input: Vec<String> = input.iter().map(|s| String::from(*s)).collect();

    // let mut input = vec![[1, 2, 2], [3, 8, 2], [5, 3, 5], [1, 2, 2]];
    // let input = input.iter().map(|x| x.to_vec()).collect();

    let input = vec![0, 1, 2, 3, 4, 5, 6, 7, 8];
    println!("{:?}", input);

    let res = problem_1356::sort_by_bits(input);
    dbg!(res);
}

fn gobln(val: i32, next: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
    Some(Box::new(ListNode::new_with_next(val, next)))
}
