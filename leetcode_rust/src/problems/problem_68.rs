use std::collections::VecDeque;
use std::iter::repeat;

pub fn full_justify(words: Vec<String>, max_width: i32) -> Vec<String> {
    let mut temp_queue: VecDeque<String> = VecDeque::new();
    let mut result = Vec::new();
    let mut temp = 0;

    for (i, x) in words.iter().enumerate() {
        let cur_x_len = x.len() as i32;
        if temp + cur_x_len <= max_width {
            temp_queue.push_back(x.clone());
            temp += cur_x_len + 1;
        } else {
            let temp_queue_words_count = temp_queue.len() as i32;
            if temp_queue_words_count == 1 {
                let mut temp_res_str = temp_queue.pop_front().unwrap().clone();
                let spaces: String = repeat(' ').take(max_width as usize - temp_res_str.len()).collect();
                temp_res_str.push_str(&spaces);
                result.push(temp_res_str);
            } else {
                let remaining_space = max_width - (temp - temp_queue_words_count);
                let avg = remaining_space / (temp_queue_words_count - 1);
                let mut remaining_single_spaces = remaining_space % (temp_queue_words_count - 1);
                let mut temp_res_str = temp_queue.pop_front().unwrap().clone();
                let rest = temp_queue.iter()
                    .fold(String::new(), |a, b| {
                        let additional = {
                            if remaining_single_spaces > 0 {
                                remaining_single_spaces -= 1;
                                1
                            } else {
                                0
                            }
                        };
                        let spaces: String = repeat(' ').take((avg + additional) as usize).collect();
                        a + &spaces + b
                    });
                temp_res_str.push_str(&rest);
                temp_queue.clear();
                result.push(temp_res_str);
            }

            temp_queue.push_back(x.clone());
            temp = cur_x_len + 1;
        }

        if i == words.len() - 1 {
            let mut temp_res_str = temp_queue.pop_front().unwrap().clone();
            let rest = temp_queue.iter().fold(String::new(), |a, b| format!("{} {}", a, b));
            let spaces: String = repeat(' ').take((max_width - (temp - 1)) as usize).collect();
            temp_res_str.push_str(&rest);
            temp_res_str.push_str(&spaces);
            result.push(temp_res_str);
        }
    }

    result
}
