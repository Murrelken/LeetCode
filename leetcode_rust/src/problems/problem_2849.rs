pub fn is_reachable_at_time(sx: i32, sy: i32, fx: i32, fy: i32, t: i32) -> bool {
    let x_diff = sx.abs_diff(fx);
    let y_diff = sy.abs_diff(fy);

    if x_diff == 0 && y_diff == 0 {
        t != 1
    } else {
        x_diff.max(y_diff) <= t as u32
    }
}

pub fn is_reachable_at_time_leetcode_ver(sx: i32, sy: i32, fx: i32, fy: i32, t: i32) -> bool {
    let x_diff = (sx - fx).abs();
    let y_diff = (sy - fy).abs();

    if x_diff == 0 && y_diff == 0 {
        t != 1
    } else {
        x_diff.max(y_diff) <= t
    }
}
