pub fn max_run_time(n: i32, batteries: Vec<i32>) -> i64 {
    let mut batteries = batteries.clone();
    batteries.sort();
    let mut extra = 0i64;

    for i in 0..batteries.len() - n as usize {
        extra += batteries[i] as i64;
    }

    let mut live: Vec<i32> = Vec::with_capacity(n as usize);
    for i in batteries.len() - n as usize..batteries.len() {
        live.push(batteries[i]);
    }

    for i in 0..(n - 1) as usize {
        if extra < (i + 1) as i64 * (live[i + 1] - live[i]) as i64 {
            return live[i] as i64 + extra / (i + 1) as i64;
        }

        extra -= (i + 1) as i64 * (live[i + 1] - live[i]) as i64;
    }

    return live[n as usize - 1] as i64 + extra / n as i64;
}