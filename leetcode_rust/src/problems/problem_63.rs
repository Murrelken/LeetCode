pub fn unique_paths_with_obstacles(mut obstacle_grid: Vec<Vec<i32>>) -> i32 {
    let m = obstacle_grid.len();
    let n = obstacle_grid[0].len();

    if obstacle_grid[0][0] == 1 {
        return 0;
    }

    obstacle_grid[0][0] = 1;
    for i in 0..m {
        for j in 0..n {
            if obstacle_grid[i][j] == 1 && (i != 0 || j != 0) {
                obstacle_grid[i][j] = 0;
                continue;
            }

            if i > 0 && obstacle_grid[i - 1][j] > 0 {
                obstacle_grid[i][j] += obstacle_grid[i - 1][j];
            }
            if j > 0 && obstacle_grid[i][j - 1] > 0 {
                obstacle_grid[i][j] += obstacle_grid[i][j - 1];
            }
        }
    }

    obstacle_grid[m][n]
}
