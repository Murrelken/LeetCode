pub fn eliminate_maximum(mut dist: Vec<i32>, speed: Vec<i32>) -> i32 {
    let n = dist.len() as i32;
    for i in 0..(n as usize) {
        let dist_c = dist[i];
        let speed_c = speed[i];
        dist[i] = dist_c / speed_c + if dist_c % speed_c > 0 { 1 } else { 0 };
    }

    dist.sort();

    for i in 0..n {
        if i >= dist[i as usize] {
            return i;
        }
    }

    n
}
