pub fn min_cost_connect_points(points: Vec<Vec<i32>>) -> i32 {
    let n = points.len();
    let mut edges: Vec<(i32, usize, usize)> = Vec::new();

    for i in 0..n {
        for j in i + 1..n {
            let cost =
                i32::abs(points[i][0] - points[j][0]) + i32::abs(points[i][1] - points[j][1]);
            edges.push((cost, i, j));
        }
    }

    edges.sort_by(|a, b| a.0.cmp(&b.0));

    let mut parent = vec![0i32; n];
    for i in 0..n {
        parent[i] = i as i32;
    }

    let mut min_cost = 0;
    let mut num_edges = 0;

    for edge in edges {
        let cost = edge.0;
        let i = edge.1;
        let j = edge.2;

        if find(&mut parent, i) != find(&mut parent, j) {
            union(&mut parent, i, j);
            min_cost += cost;
            num_edges += 1;

            if num_edges == n - 1 {
                break;
            }
        }
    }

    return min_cost;
}

fn find(parent: &mut Vec<i32>, i: usize) -> i32 {
    if parent[i] == i as i32 {
        return i as i32;
    }
    parent[i] = find(parent, parent[i] as usize);
    parent[i]
}

fn union(parent: &mut Vec<i32>, i: usize, j: usize) {
    let i_parent = find(parent, i) as usize;
    parent[i_parent] = find(parent, j);
}
