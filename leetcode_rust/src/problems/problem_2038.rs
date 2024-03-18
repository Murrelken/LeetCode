pub fn winner_of_game(colors: String) -> bool {
    let chars: Vec<_> = colors.chars().collect();
    let mut alice_turn = chars[0] == 'A';
    let mut prev = chars[0];
    let mut a_turns = 0;
    let mut b_turns = 0;

    for i in 1..chars.len() - 1 {
        if prev != chars[i] {
            prev = chars[i];
            alice_turn = !alice_turn;
        } else if chars[i + 1] == prev {
            if alice_turn {
                a_turns += 1;
            } else {
                b_turns += 1;
            }
        }
    }

    a_turns > b_turns
}
