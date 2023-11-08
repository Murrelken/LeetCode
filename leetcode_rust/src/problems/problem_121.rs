pub fn max_profit(prices: Vec<i32>) -> i32 {
    let mut min = prices[0];
    let mut target = min;
    for i in 1..prices.len() {
        if prices[i] < min {
            target -= min - prices[i];
            min = prices[i];
        } else if prices[i] > target {
            target = prices[i];
        }
    }

    target - min
}
