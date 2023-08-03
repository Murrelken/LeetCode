use std::collections::HashMap;

pub fn soup_servings(n: i32) -> f64 {
    let mut m = n / 25;
    if n % 25 > 0 {
        m += 1;
    }
    let mut dp: HashMap<i32, HashMap<i32, f64>> = HashMap::new();

    for i in 1..m {
        if calc_dp(i, i, &mut dp) > 1f64 - 1e-5 {
            return 1.0;
        }
    }

    calc_dp(m, m, &mut dp)
}

fn calc_dp(i: i32, j: i32, dp: &mut HashMap<i32, HashMap<i32, f64>>) -> f64 {
    if i <= 0 && j <= 0 {
        return 0.5;
    }
    if i <= 0 {
        return 1.0;
    }
    if j <= 0 {
        return 0.0;
    }
    if let Some(x) = dp.get(&i) {
        if let Some(y) = x.get(&j) {
            return *y;
        }
    }

    let res = (
        calc_dp(i - 4, j, dp) +
            calc_dp(i - 3, j - 1, dp) +
            calc_dp(i - 2, j - 2, dp) +
            calc_dp(i - 1, j - 3, dp))
        / 4.0;

    *dp
        .entry(i)
        .or_insert(HashMap::from([(j, res)]))
        .entry(j)
        .or_insert(res) = res;

    res
}