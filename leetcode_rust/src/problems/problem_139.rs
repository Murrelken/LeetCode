use std::collections::{HashSet, VecDeque};

pub fn word_break(s: String, word_dict: Vec<String>) -> bool {
    let mut seen = vec![false; s.len() + 1];
    let hashset: HashSet<String> = HashSet::from_iter(word_dict);
    let mut queue = VecDeque::from([0usize]);

    loop {
        let Some(start) = queue.pop_front() else {
            break;
        };

        if start == s.len() {
            return true;
        }

        for end in start + 1..s.len() + 1 {
            if seen[end] {
                continue;
            }

            if hashset.contains(&s[start..end]) {
                seen[end] = true;
                queue.push_back(end);
            }
        }
    }

    false
}
