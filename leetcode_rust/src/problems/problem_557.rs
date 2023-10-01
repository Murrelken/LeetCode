pub fn reverse_words(s: String) -> String {
    let mut res: Vec<String> = Vec::new();
    for x in s.split(' ') {
        res.push(x.chars().rev().collect());
    }

    res.join(" ")
}
