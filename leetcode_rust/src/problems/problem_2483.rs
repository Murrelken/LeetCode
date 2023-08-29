pub fn best_closing_time(customers: String) -> i32 {
    let start = customers.chars().filter(|c| *c == 'Y').count();
    let mut temp_penalty = start;
    let mut min = start;
    let mut result_index = 0;

    for (i, c) in customers.chars().enumerate() {
        match c {
            'Y' => {
                temp_penalty -= 1;
                if temp_penalty < min {
                    min = temp_penalty;
                    result_index = i + 1;
                }
            }
            'N' => {
                temp_penalty += 1;
            }
            _ => {}
        }
    }

    result_index as i32
}
