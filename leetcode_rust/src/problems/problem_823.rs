const MOD: i64 = 1_000_000_007;

pub fn num_factored_binary_trees(arr: Vec<i32>) -> i32 {
    let mut arr = arr;
    arr.sort();
    let s: std::collections::HashSet<_> = arr.iter().cloned().collect();
    let mut dp = std::collections::HashMap::new();
    for &x in &arr {
        dp.insert(x, 1i64);
    }

    for &i in &arr {
        for &j in &arr {
            if j > (i as f64).sqrt() as i32 {
                break;
            }
            if i % j == 0 && s.contains(&(i / j)) {
                let temp = (dp[&j] * dp[&(i / j)]) % MOD;
                if i / j == j {
                    dp.insert(i, (dp[&i] + temp) % MOD);
                } else {
                    dp.insert(i, (dp[&i] + temp * 2) % MOD);
                }
            }
        }
    }

    (dp.values().sum::<i64>() % MOD) as i32
}
