pub fn get_winner(arr: Vec<i32>, k: i32) -> i32 {
    if k == 1 {
        return arr[0].max(arr[1]);
    }
    if k as usize >= arr.len() {
        return *arr.iter().max().unwrap();
    }

    let mut current_winner = arr[0];
    let mut consecutive_wins = 0;

    for &num in &arr[1..] {
        if current_winner > num {
            consecutive_wins += 1;
        } else {
            current_winner = num;
            consecutive_wins = 1;
        }

        if consecutive_wins == k {
            return current_winner;
        }
    }

    current_winner
}
