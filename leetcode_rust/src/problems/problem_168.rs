pub fn convert_to_title(mut column_number: i32) -> String {
    let mut res = String::new();

    while column_number > 0 {
        column_number -= 1;
        let char_num = column_number % 26 + 1 + 64;
        res.push(char_num as u8 as char);
        column_number /= 26;
    }

    res.chars().rev().collect()
}
