use std::collections::VecDeque;

pub fn update_matrix(mut mat: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
    const PATHS: [(i32, i32); 4] = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    let m = mat.len();
    let n = mat[0].len();

    let mut queue = VecDeque::new();

    for i in 0..m {
        for j in 0..n {
            if mat[i][j] == 1 {
                mat[i][j] = i32::MAX;
            } else {
                queue.push_back((i, j));
            }
        }
    }

    while let Some(current) = queue.pop_front() {
        let cur_i = current.0;
        let cur_j = current.1;

        for (i_shift, j_shift) in PATHS {
            let new_i = cur_i as i32 + i_shift;
            let new_j = cur_j as i32 + j_shift;

            if new_i < 0 || new_j < 0 {
                continue;
            }

            let new_i = new_i as usize;
            let new_j = new_j as usize;

            if new_i >= m || new_j >= n ||
                mat[new_i][new_j] == 0 ||
                mat[cur_i][cur_j] + 1 >= mat[new_i][new_j] {
                continue;
            }

            mat[new_i][new_j] = mat[cur_i][cur_j] + 1;
            queue.push_back((new_i, new_j));
        }
    }

    mat
}
