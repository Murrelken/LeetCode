pub fn num_ways(steps: i32, arr_len: i32) -> i32 {
    const MOD: i32 = 1_000_000_007;
    let arr_len = i32::min(arr_len, steps);
    let mut dp = vec![0; arr_len as usize];
    let mut prev_dp = vec![0; arr_len as usize];
    prev_dp[0] = 1;

    for _ in 1..=steps {
        dp = vec![0; arr_len as usize];

        for curr in (0..arr_len).rev() {
            let curr = curr as usize;
            let mut ans = prev_dp[curr];

            if curr > 0 {
                ans = (ans + prev_dp[curr - 1]) % MOD;
            }

            if (curr as i32) < arr_len - 1 {
                ans = (ans + prev_dp[curr + 1]) % MOD;
            }

            dp[curr] = ans;
        }

        prev_dp = dp.clone();
    }

    return dp[0];
}
