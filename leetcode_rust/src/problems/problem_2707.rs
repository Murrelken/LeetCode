use std::collections::HashSet;
use std::iter::repeat;

pub fn min_extra_char(s: String, dictionary: Vec<String>) -> i32 {
    let n = s.len();
    let mut memo: Vec<Option<i32>> = repeat(None).take(n).collect();
    let mut words: HashSet<_> = dictionary.into_iter().collect();
    return dp(0, n, &s, &mut memo, &mut words);
}

fn dp(start: usize, n: usize, s: &str, memo: &mut Vec<Option<i32>>, words: &mut HashSet<String>) -> i32 {
    if start == n {
        return 0;
    }

    if let Some(res) = memo[start] {
        return res;
    }

    let mut ans = dp(start + 1, n, s, memo, words) + 1;
    for end in start..n {
        let curr = &s[start..end + 1];
        if words.contains(curr) {
            ans = ans.min(dp(end + 1, n, s, memo, words));
        }
    }

    memo[start] = Some(ans);
    ans
}