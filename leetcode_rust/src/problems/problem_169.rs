pub fn majority_element(nums: Vec<i32>) -> i32 {
    let mut major = i32::MAX;
    let mut count = 1;

    for num in nums {
        if num == major {
            count += 1;
        } else {
            count -= 1;
            if count == 0 {
                major = num;
                count = 1;
            }
        }
    }

    major
}
