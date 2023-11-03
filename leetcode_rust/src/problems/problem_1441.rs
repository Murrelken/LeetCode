pub fn build_array(target: Vec<i32>, n: i32) -> Vec<String> {
    let mut target_i = 0;
    let mut result = Vec::new();
    let push = "Push";
    let pop = "Pop";
    for i in 1..=n {
        if target_i == target.len() {
            break;
        }
        result.push(String::from(push));
        if target[target_i] == i {
            target_i += 1;
        } else {
            result.push(String::from(pop));
        }
    }
    result
}
