pub fn find_longest_chain(mut pairs: Vec<Vec<i32>>) -> i32 {
    pairs.sort_by(|x, y| x[1].cmp(&y[1]));
    let mut prev_right = -1001;
    let mut res = 0;

    for pair in pairs.iter() {
        if pair[0] > prev_right {
            res += 1;
            prev_right = pair[1];
        }
    }

    res
}

/// Common with dp. Skip or take.
pub fn find_longest_chain_v2(mut pairs: Vec<Vec<i32>>) -> i32 {
    pairs.sort_by(|x, y| x[0].cmp(&y[0]));
    let mut dp = vec![0; pairs.len()];
    let mut res = 0;

    for i in 0..pairs.len() {
        res = i32::max(res, req(i, &pairs, &mut dp));
    }

    res
}

fn req(i: usize, pairs: &Vec<Vec<i32>>, dp: &mut Vec<i32>) -> i32 {
    if dp[i] > 0 {
        return dp[i];
    }
    dp[i] = 1;
    for j in i+1..pairs.len() {
        if pairs[i][1] < pairs[j][0] {
            dp[i] = i32::max(dp[i], 1 + req(j, pairs, dp));
        }
    }

    dp[i]
}
