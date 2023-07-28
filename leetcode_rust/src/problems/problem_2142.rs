pub fn max_run_time(n: i32, mut batteries: Vec<i32>) -> i64 {
    batteries.sort();
    let n = n as usize;
    let mut extra = 0i64;

    for i in 0..batteries.len() - n {
        extra += batteries[i] as i64;
    }

    let mut live: Vec<i32> = Vec::with_capacity(n);
    for i in batteries.len() - n..batteries.len() {
        live.push(batteries[i]);
    }

    for i in 0..(n - 1) {
        if extra < (i + 1) as i64 * (live[i + 1] - live[i]) as i64 {
            return live[i] as i64 + extra / (i + 1) as i64;
        }

        extra -= (i + 1) as i64 * (live[i + 1] - live[i]) as i64;
    }

    return live[n - 1] as i64 + extra / n as i64;
}
