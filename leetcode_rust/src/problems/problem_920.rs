pub fn num_music_playlists(n: i32, goal: i32, k: i32) -> i32 {
    let mut factorial: Vec<i64> = Vec::new();
    let mut inv_factorial: Vec<i64> = Vec::new();
    // Pre-calculate factorials and inverse factorials
    precalculate_factorials(n, &mut factorial, &mut inv_factorial);
    // Initialize variables for calculation
    let mut sign = 1;
    let mut answer = 0;
    // Loop from 'n' down to 'k'
    for i in (k..n+1).rev() {
        // Calculate temporary result for this iteration
        let mut temp = power((i - k) as i64, (goal - k) as i64);
        temp = (temp * inv_factorial[(n - i) as usize]) % MOD;
        temp = (temp * inv_factorial[(i - k) as usize]) % MOD;
        // Add or subtract temporary result to/from answer
        answer = (answer + sign * temp + MOD) % MOD;
        // Flip sign for next iteration
        sign *= -1;
    }
    // Final result is n! * answer, all under modulo
    ((factorial[n as usize] * answer) % MOD) as i32
}

const MOD: i64 = 1000000007;

// Function to calculate power under modulo MOD
fn power(mut base: i64, mut exponent: i64) -> i64 {
    let mut result = 1;
    // Loop until exponent is not zero
    while exponent > 0 {
        // If exponent is odd, multiply result with base
        if exponent & 1 == 1 {
            result = (result * base) % MOD;
        }
        // Divide the exponent by 2 and square the base
        exponent >>= 1;
        base = (base * base) % MOD;
    }
    return result;
}

// Function to pre-calculate factorials and inverse factorials
fn precalculate_factorials(n: i32, factorial: &mut Vec<i64>, inv_factorial: &mut Vec<i64>) {
    factorial.push(1);
    inv_factorial.push(1);
    // Calculate factorials and inverse factorials for each number up to 'n'
    for i in 1..n + 1 {
        factorial.push((factorial[(i - 1) as usize] * i as i64) % MOD);
        // Inverse factorial calculated using Fermat's Little Theorem
        inv_factorial.push(power(factorial[i as usize], MOD - 2));
    }
}
