pub fn decode_at_index(s: String, mut k: i32) -> String {
    let mut length: i64 = 0;
    let mut i = 0;
    let bytes = s.as_bytes();

    while length < k as i64 {
        if bytes[i].is_ascii_digit() {
            length *= (bytes[i] as char).to_digit(10).unwrap() as i64;
        } else {
            length += 1;
        }
        i += 1;
    }

    for j in (0..i).rev() {
        if bytes[j].is_ascii_digit() {
            length /= (bytes[j] as char).to_digit(10).unwrap() as i64;
            k = (k as i64 % length) as i32;
        } else {
            if k == 0 || k as i64 == length {
                return (bytes[j] as char).to_string();
            }
            length -= 1;
        }
    }

    String::from("")
}
