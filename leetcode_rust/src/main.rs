mod problems {
    pub mod problem_2142;
}

fn main() {
    let input = Vec::from([10, 10, 3, 5]);
    println!("{:?}", input);
    let res = problems::problem_2142::max_run_time(3, input);
    println!("{res}");
}
