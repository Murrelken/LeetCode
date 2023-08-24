use std::cell::RefCell;
use std::cmp::Ordering;
use std::collections::{BinaryHeap, HashMap};
use std::ops::DerefMut;
use std::rc::Rc;
use std::iter::repeat;

#[derive(Copy, Clone, Eq, PartialEq, Debug)]
struct CharWithWeight {
    weight: i32,
    val: char,
}

impl Ord for CharWithWeight {
    fn cmp(&self, other: &Self) -> Ordering {
        other.weight.cmp(&self.weight)
    }
}

impl PartialOrd for CharWithWeight {
    fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

pub fn reorganize_string(s: String) -> String {
    let mut result: Vec<char> = Vec::new();
    let mut dic: HashMap<char, i32> = HashMap::new();
    let mut heap = BinaryHeap::new();

    for c in s.chars() {
        *dic.entry(c).or_insert(0) -= 1;
    }

    for k in dic.keys() {
        heap.push(CharWithWeight { weight: dic[k], val: *k });
    }

    while let Some(mut x) = heap.pop() {
        if x.weight == 0 {
            break;
        }
        if !result.is_empty() && &x.val == result.last().unwrap() {
            if let Some(mut x) = heap.peek_mut() {
                if x.weight == 0 {
                    break;
                }
                result.push(x.val);
                x.weight += 1;
            } else {
                break;
            }
        } else {
            result.push(x.val);
            x.weight += 1;
        }

        heap.push(x);
    }

    if result.len() < s.len() {
        String::new()
    } else {
        result.iter().collect()
    }
}

pub fn reorganize_string_v2(s: String) -> String {
    let mut vec: Vec<_> = repeat(0)
        .take(26)
        .collect();

    for c in s.chars() {
        vec[char_to_index(c)] += 1;
    }


    let mut result: Vec<char> = Vec::new();

    loop {
        let (i, w) = vec
            .iter()
            .enumerate()
            .filter(|(i, w)| result.is_empty() || result.last().unwrap() != &index_to_char(*i))
            .max_by(|(_, w), (_, w2)| w.cmp(w2))
            .unwrap();

        if w == &0 {
            break;
        }

        result.push(index_to_char(i));
        vec[i] -= 1;
    }

    if result.len() < s.len() {
        String::new()
    } else {
        result.iter().collect()
    }
}

fn index_to_char(i: usize) -> char {
    (i as u8 + 'a' as u8) as char
}

fn char_to_index(c: char) -> usize {
    (c as u8 - 'a' as u8) as usize
}
