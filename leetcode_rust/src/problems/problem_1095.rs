pub fn find_in_mountain_array(target: i32, mountain_arr: &MountainArray) -> i32 {
    let length = mountain_arr.length();

    let mut left = 1;
    let mut right = length - 2;
    while left != right {
        let mid = (left + right) / 2;
        if mountain_arr.get(mid) < mountain_arr.get(mid + 1) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    let peak_index = left;

    left = 0;
    right = peak_index;
    while left != right {
        let test_index = (left + right) / 2;
        if mountain_arr.get(test_index) < target {
            left = test_index + 1;
        } else {
            right = test_index;
        }
    }

    if mountain_arr.get(left) == target {
        return left;
    }

    left = peak_index + 1;
    right = length - 1;
    while left != right {
        let test_index = (left + right) / 2;
        if mountain_arr.get(test_index) > target {
            left = test_index + 1;
        } else {
            right = test_index;
        }
    }

    if mountain_arr.get(left) == target {
        return left;
    }

    return -1;
}

struct MountainArray;

impl MountainArray {
    fn get(_: i32) -> i32 {
        0
    }
    fn length() -> i32 {
        0
    }
}
