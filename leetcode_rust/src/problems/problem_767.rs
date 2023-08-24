use std::cell::RefCell;
use std::cmp::Ordering;
use std::collections::{BinaryHeap, HashMap};
use std::ops::DerefMut;
use std::rc::Rc;

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

    let mut heap_ref = &mut heap as *mut BinaryHeap<CharWithWeight>;
    unsafe {
        while let Some(mut x) = (&mut *heap_ref).pop() {
            if x.weight == 0 {
                break;
            }
            if !result.is_empty() && &x.val == result.last().unwrap() {
                if let Some(mut x) = (&mut *heap_ref).peek_mut() {
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

            (&mut *heap_ref).push(x);
        }
    }

    if result.len() < s.len() {
        String::new()
    } else {
        result.iter().collect()
    }
}
