use std::collections::VecDeque;

pub fn minimum_effort_path(heights: Vec<Vec<i32>>) -> i32 {
    let rows = heights.len();
    let columns = heights[0].len();
    let mut visited = vec![vec![i32::MAX; columns]; rows];
    let directions = [(1, 0), (0, 1), (-1, 0), (0, -1)];
    visited[0][0] = 0;

    let mut queue = VecDeque::new();
    queue.push_back((0, 0));

    while queue.len() > 0 {
        let mut len = queue.len();
        while len > 0 {
            len -= 1;
            let (row, col) = queue.pop_front().unwrap();
            for (row_diff, col_diff) in directions {
                let new_row = row as i32 + row_diff;
                let new_col = col as i32 + col_diff;

                if new_row < 0 || new_row == rows as i32 || new_col < 0 || new_col == columns as i32
                {
                    continue;
                }

                let new_row = new_row as usize;
                let new_col = new_col as usize;

                let next_height =
                    visited[row][col].max(i32::abs(heights[new_row][new_col] - heights[row][col]));

                if visited[new_row][new_col] <= next_height {
                    continue;
                }

                visited[new_row][new_col] = next_height;
                queue.push_back((new_row, new_col));
            }
        }
    }

    visited[rows - 1][columns - 1]
}
