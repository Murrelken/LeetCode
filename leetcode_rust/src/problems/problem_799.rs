pub fn champagne_tower(poured: i32, query_row: i32, query_glass: i32) -> f64 {
    let mut row = vec![poured as f64];
    for r in 0..query_row as usize {
        let mut row_nxt = vec![0f64; r + 2];
        for i in 0..r + 1 {
            if row[i] > 1. {
                let v = (row[i] - 1.) / 2.;
                row_nxt[i] += v;
                row_nxt[i + 1] += v;
            }
        }
        row = row_nxt;
    }

    return 1f64.min(row[query_glass as usize]);
}
