pub fn is_valid(s: String) -> bool {
    let mut openings = Vec::new();

    for x in s.chars() {
        if x == '(' || x == '[' || x == '{' {
            openings.push(x);
        } else {
            if let Some(op) = openings.pop() {
                if x == ')' && op != '(' || x == ']' && op != '[' || x == '}' && op != '{' {
                    return false;
                }
            } else {
                return false;
            }
        }
    }

    openings.is_empty()
}
