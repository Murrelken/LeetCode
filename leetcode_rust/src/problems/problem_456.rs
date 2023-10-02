pub fn find132pattern(nums: Vec<i32>) -> bool {
    let mut middle = i32::MIN;
    let mut stack = Vec::new();

    for x in nums.iter().rev() {
        if x < &middle {
            return true;
        }

        while stack.len() > 0 && x > stack.last().unwrap() {
            middle = stack.pop().unwrap();
        }

        stack.push(*x);
    }

    false
}
