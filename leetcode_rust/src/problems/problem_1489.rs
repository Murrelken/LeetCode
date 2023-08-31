use std::iter::repeat;
use std::mem::swap;

pub fn find_critical_and_pseudo_critical_edges(n: i32, edges: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
    let m = edges.len();
    let mut new_edges: Vec<Vec<i32>> = edges
        .iter()
        .enumerate()
        .map(|(i, x)| Vec::from([x[0], x[1], x[2], i as i32]))
        .collect();

    new_edges.sort_by(|a, b| a[2].cmp(&b[2]));

    // Find MST weight using union-find
    let mut uf_std = UnionFind::new(n);
    let mut std_weight = 0;
    for edge in &new_edges {
        if uf_std.union(edge[0], edge[1]) {
            std_weight += edge[2];
        }
    }

    let mut result = Vec::from([Vec::new(), Vec::new()]);

    // Check each edge for critical and pseudo-critical
    for i in 0..m {
        // Ignore this edge and calculate MST weight
        let mut uf_ignore = UnionFind::new(n);
        let mut ignore_weight = 0;
        for j in 0..m {
            if i != j && uf_ignore.union(new_edges[j][0], new_edges[j][1]) {
                ignore_weight += new_edges[j][2];
            }
        }
        // If the graph is disconnected or the total weight is greater, the edge is critical
        if uf_ignore.max_size < n || ignore_weight > std_weight {
            result[0].push(new_edges[i][3]);
        } else {
            // Force this edge and calculate MST weight
            let mut uf_force = UnionFind::new(n);
            uf_force.union(new_edges[i][0], new_edges[i][1]);
            let mut force_weight = new_edges[i][2];
            for j in 0..m {
                if i != j && uf_force.union(new_edges[j][0], new_edges[j][1]) {
                    force_weight += new_edges[j][2];
                }
            }
            if force_weight == std_weight {
                result[1].push(new_edges[i][3]);
            }
        }
    }

    return result;
}

struct UnionFind {
    parent: Vec<i32>,
    size: Vec<i32>,
    max_size: i32,
}

impl UnionFind {
    fn new(n: i32) -> Self {
        UnionFind {
            parent: (0..n).collect(),
            size: repeat(1).take(n as usize).collect(),
            max_size: 1,
        }
    }

    fn find(&mut self, x: i32) -> i32 {
        let x = x as usize;
        if x != self.parent[x] as usize {
            self.parent[x] = self.find(self.parent[x]);
        }

        self.parent[x]
    }

    fn union(&mut self, x: i32, y: i32) -> bool {
        let mut root_x = self.find(x) as usize;
        let mut root_y = self.find(y) as usize;

        if root_x != root_y {
            if self.size[root_x] < self.size[root_y] {
                swap(&mut root_x, &mut root_y);
            }
            self.parent[root_y] = root_x as i32;
            self.size[root_x] += self.size[root_y];
            self.max_size = self.max_size.max(self.size[root_x]);
            return true;
        }

        false
    }
}
