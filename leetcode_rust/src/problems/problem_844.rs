pub fn backspace_compare(s: String, t: String) -> bool {
    get_shortened(s) == get_shortened(t)
}

fn get_shortened(s: String) -> String {
    let mut left = 0i32;
    let mut right = 0;
    let mut chars: Vec<_> = s.chars().collect();

    while left < chars.len() as i32 {
        if right == chars.len() {
            break;
        }
        if chars[right] == '#' {
            left = (left - 2).max(-1);
        } else {
            chars[left as usize] = chars[right];
        }

        left += 1;
        right += 1;
    }

    chars.iter().take(left as usize).collect()
}
