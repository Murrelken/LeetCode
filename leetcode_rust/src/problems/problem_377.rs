use std::collections::HashMap;

pub fn combination_sum4(mut nums: Vec<i32>, target: i32) -> i32 {
    nums.sort();
    req(0, &nums, target, &mut HashMap::new())
}

fn req(temp: i32, nums: &Vec<i32>, target: i32, dp: &mut HashMap<i32, i32>) -> i32 {
    if dp.contains_key(&temp) {
        return dp[&temp];
    }
    let mut res = 0;
    if temp > target {
        return -1;
    }

    if temp == target {
        return 1;
    }

    for num in nums {
        let req = req(temp + num, nums, target, dp);
        dp.insert(temp + num, req);
        if req == -1 {
            break;
        } else {
            res += req;
        }
    }

    res
}
