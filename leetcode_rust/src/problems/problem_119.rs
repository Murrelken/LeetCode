pub fn get_row(mut row_index: i32) -> Vec<i32> {
    let mut prev = vec![1];

    while row_index > 0 {
        row_index -= 1;

        let mut new = vec![1; prev.len() + 1];

        for i in 1..new.len() - 1 {
            new[i] = prev[i - 1] + prev[i];
        }

        prev = new.clone();
    }

    return prev;
}
