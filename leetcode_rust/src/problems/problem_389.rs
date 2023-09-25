use std::collections::HashMap;

pub fn find_the_difference(s: String, t: String) -> char {
    let mut dictionary: HashMap<char, i32> = HashMap::new();

    for c in s.chars() {
        *dictionary.entry(c).or_default() += 1;
    }

    for c in t.chars() {
        if !dictionary.contains_key(&c) || dictionary[&c] == 0 {
            return c;
        } else {
            *dictionary.entry(c).or_default() -= 1;
        }
    }

    '\n'
}
