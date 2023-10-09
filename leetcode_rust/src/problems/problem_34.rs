pub fn search_range(nums: Vec<i32>, target: i32) -> Vec<i32> {
    let mut res = vec![-1, -1];

    if nums.len() == 0 {
        return res;
    }

    let mut left = 0usize;
    let mut right = nums.len() - 1;

    while left < right {
        let mid = (right + left) / 2;
        if nums[mid] < target {
            left = mid + 1
        } else {
            right = mid;
        }
    }

    if nums[left] == target {
        res[0] = left as i32;
    } else {
        return res;
    }

    left = 0;
    right = nums.len() - 1;

    while left < right {
        let mid = (right + left) / 2;

        if nums[mid] > target {
            right = mid - 1;
        } else {
            if left == mid {
                if nums[mid + 1] == target {
                    left += 1;
                }
                break;
            }
            left = mid;
        }
    }

    res[1] = left as i32;

    res
}
