pub fn is_subsequence(s: String, t: String) -> bool {
    let mut s_i = 0;
    let subs_vec: Vec<_> = s.chars().collect();

    for x in t.chars() {
        if s_i == s.len() {
            break;
        }
        if x == subs_vec[s_i] {
            s_i += 1;
        }
    }

    s_i == s.len()
}
