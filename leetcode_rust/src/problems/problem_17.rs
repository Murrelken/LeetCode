use std::collections::HashMap;

pub fn letter_combinations(digits: String) -> Vec<String> {
    let letters = HashMap::from([
        ('2', Vec::from(['a', 'b', 'c'])), ('3', Vec::from(['d', 'e', 'f'])),
        ('4', Vec::from(['g', 'h', 'i'])), ('5', Vec::from(['j', 'k', 'l'])),
        ('6', Vec::from(['m', 'n', 'o'])), ('7', Vec::from(['p', 'q', 'r', 's'])),
        ('8', Vec::from(['t', 'u', 'v'])), ('9', Vec::from(['w', 'x', 'y', 'z']))]);

    let mut total_count = 1;
    for digit in digits.chars() {
        total_count *= letters
            .get(&digit)
            .expect("Should exist")
            .len();
    }

    let mut res: Vec<String> = Vec::new();

    if total_count > 1 {
        for _ in 0..total_count {
            res.push(String::new());
        }
    }

    let mut step = total_count;

    for digit in digits.chars() {
        let letters_by_digit = letters
            .get(&digit)
            .expect("Should exist");
        let l = letters_by_digit.len();
        step = step / l;

        for (j, el) in res.iter_mut().enumerate() {
            el.push(letters_by_digit[(j / step) % l]);
        }
    }

    res
}
