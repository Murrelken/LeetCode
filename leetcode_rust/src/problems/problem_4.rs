pub fn find_median_sorted_arrays(nums1: Vec<i32>, nums2: Vec<i32>) -> f64 {
    let mut res: Vec<i32> = Vec::new();
    let mut l = 0usize;
    let mut r = 0usize;

    while l < nums1.len() || r < nums2.len() {
        if l == nums1.len() {
            res.push(nums2[r]);
            r += 1;
            continue;
        }
        if r == nums2.len() {
            res.push(nums1[l]);
            l += 1;
            continue;
        }

        if nums1[l] < nums2[r] {
            res.push(nums1[l]);
            l += 1;
            continue;
        } else {
            res.push(nums2[r]);
            r += 1;
            continue;
        }
    }

    if res.len() % 2 == 0 {
        (res[res.len() / 2] as f64 + res[res.len() / 2 - 1] as f64) / 2f64
    } else {
        res[res.len() / 2] as f64
    }
}
