use std::collections::HashSet;

pub fn can_cross(stones: Vec<i32>) -> bool {
    req(0, 0, &stones, &mut HashSet::new())
}

fn req(prev_jump: i32, current: usize, stones: &Vec<i32>, dp: &mut HashSet<(usize, i32)>) -> bool {
    if current == stones.len() - 1 {
        return true;
    }
    if dp.contains(&(current, prev_jump)) {
        return false;
    }

    let min_jump = stones[current] + prev_jump - 1;
    let max_jump = stones[current] + prev_jump + 1;

    let mut result = false;

    for (i, stone) in stones[current + 1..].iter().enumerate() {
        let stone = *stone;
        if stone < min_jump {
            continue;
        }
        if stone > max_jump {
            break;
        }

        result = result || req(stone - stones[current], current + 1 + i, stones, dp);
    }

    if !result {
        dp.insert((current, prev_jump));
    }
    result
}
