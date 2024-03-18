pub fn num_of_arrays(n: i32, m: i32, k: i32) -> i32 {
    let mut dp = vec![vec![0i64; (k + 1) as usize]; (m + 1) as usize];
    let mut prefix = vec![vec![0i64; (k + 1) as usize]; (m + 1) as usize];
    let mut prev_dp = vec![vec![0i64; (k + 1) as usize]; (m + 1) as usize];
    let mut prev_prefix = vec![vec![0i64; (k + 1) as usize]; (m + 1) as usize];
    const MOD: i64 = 1_000_000_007;

    for num in 1..=m {
        dp[num as usize][1] = 1;
    }

    for i in 1..=n {
        if i > 1 {
            dp = vec![vec![0; (k + 1) as usize]; (m + 1) as usize];
        }

        prefix = vec![vec![0; (k + 1) as usize]; (m + 1) as usize];

        for max_num in 1..=m {
            for cost in 1..=k {
                let max_num = max_num as usize;
                let cost = cost as usize;
                let mut ans = (max_num as i64 * prev_dp[max_num][cost]) % MOD;
                ans = (ans + prev_prefix[max_num - 1][cost - 1]) % MOD;

                dp[max_num][cost] += ans;
                dp[max_num][cost] %= MOD;

                prefix[max_num][cost] = prefix[max_num - 1][cost] + dp[max_num][cost];
                prefix[max_num][cost] %= MOD;
            }
        }

        for max_num in 0..=m {
            for cost in 0..=k {
                let max_num = max_num as usize;
                let cost = cost as usize;
                prev_dp[max_num][cost] = dp[max_num][cost];
                prev_prefix[max_num][cost] = prefix[max_num][cost];
            }
        }
    }

    return prefix[m as usize][k as usize] as i32;
}
