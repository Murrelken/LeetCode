use std::collections::{HashMap, HashSet};

pub fn is_interleave(s1: String, s2: String, s3: String) -> bool {
    if s3.len() != s1.len() + s2.len() {
        return false;
    }
    if s1.is_empty() {
        return s2.eq(&s3);
    }
    if s2.is_empty() {
        return s1.eq(&s3);
    }
    let s1: Vec<_> = s1.chars().collect();
    let s2: Vec<_> = s2.chars().collect();
    let s3: Vec<_> = s3.chars().collect();
    let mut dp: HashMap<(usize, usize), bool> = HashMap::new();

    req(0, 0, 0, &s1, &s2, &s3, &mut dp)
}

fn req(res_i: usize, l: usize, r: usize, s1: &Vec<char>, s2: &Vec<char>, s3: &Vec<char>, dp: &mut HashMap<(usize, usize), bool>) -> bool {
    if res_i == s3.len() {
        return true;
    }

    if dp.contains_key(&(l, r)) {
        return dp[&(l, r)];
    }

    let mut res = false;

    if l < s1.len() && s1[l] == s3[res_i] {
        res = res || req(res_i + 1, l + 1, r, s1, s2, s3, dp);
    }

    if r < s2.len() && s2[r] == s3[res_i] {
        res = res || req(res_i + 1, l, r + 1, s1, s2, s3, dp);
    }

    dp.insert((l, r), res);

    res
}
