pub fn search_matrix(matrix: Vec<Vec<i32>>, target: i32) -> bool {
    let height = matrix.len();
    let width = matrix[0].len();
    let mut left = 0usize;
    let mut right = height * width - 1;

    while right - left > 1 {
        let mid = (right + left) / 2;
        let mid_el = matrix[mid / width][mid % width];
        if mid_el == target {
            return true;
        }
        if mid_el > target { right = mid; } else { left = mid; }
    }

    if matrix[left / width][left % width] == target || matrix[right / width][right % width] == target {
        true
    } else {
        false
    }
}
