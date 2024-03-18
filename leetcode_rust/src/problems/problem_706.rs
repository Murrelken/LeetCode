struct MyHashMap {
    buckets: Vec<Vec<(i32, i32)>>,
    cut: i32,
}

impl MyHashMap {
    fn new() -> Self {
        let mut buckets = Vec::new();
        let cut = 3000;
        for _ in 0..cut {
            buckets.push(Vec::new());
        }
        MyHashMap { buckets, cut }
    }

    fn put(&mut self, key: i32, value: i32) {
        let bucket = &mut self.buckets[(key % self.cut) as usize];
        let i = if let Some(res) = bucket.iter().enumerate().find(|x| x.1 .0 == key) {
            res.0 as i32
        } else {
            -1
        };

        if i != -1 {
            bucket[i as usize].1 = value;
        } else {
            bucket.push((key, value));
        }
    }

    fn get(&self, key: i32) -> i32 {
        if let Some(res) = &self.buckets[(key % self.cut) as usize]
            .iter()
            .find(|x| x.0 == key)
        {
            res.1
        } else {
            -1
        }
    }

    fn remove(&mut self, key: i32) {
        let bucket = &mut self.buckets[(key % self.cut) as usize];
        if let Some(res) = bucket.iter().enumerate().find(|x| x.1 .0 == key) {
            bucket.remove(res.0);
        }
    }
}
