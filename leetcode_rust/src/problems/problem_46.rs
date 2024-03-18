pub fn permute(mut nums: Vec<i32>) -> Vec<Vec<i32>> {
    let mut res: Vec<Vec<i32>> = Vec::new();
    req(&mut Vec::new(), &mut res, &mut nums);
    return res;
}

fn req(temp: &mut Vec<i32>, res: &mut Vec<Vec<i32>>, nums: &mut Vec<i32>) {
    if nums.len() == 0 {
        res.push(temp.clone());
    } else {
        for i in 0..nums.len() {
            let item = nums[i];
            temp.push(item);
            nums.remove(i);
            req(temp, res, nums);
            nums.insert(i, item);
            temp.pop();
        }
    }
}
