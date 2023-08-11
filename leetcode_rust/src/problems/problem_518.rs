use std::iter::repeat;

pub fn change(amount: i32, coins: Vec<i32>) -> i32 {
    let mut dp: Vec<i32> = repeat(0).take((amount + 1) as usize).collect();
    dp[0] = 1;

    for i in (0..coins.len()).rev() {
        for j in coins[i]..amount + 1 {
            dp[j as usize] += dp[(j - coins[i]) as usize];
        }
    }

    dp[amount as usize]
}
