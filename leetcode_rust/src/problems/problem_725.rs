use crate::structures::list_node::ListNode;

pub fn split_list_to_parts(mut head: Option<Box<ListNode>>, k: i32) -> Vec<Option<Box<ListNode>>> {
    let k = k as usize;
    let len = length(&head);
    let mut result = vec![None; k];

    let avg = len / k;
    let remaining = len % k;

    for i in 0..k {
        let sub_length = avg + if remaining > i { 1 } else { 0 };
        let mut tail: &mut Option<Box<ListNode>> = &mut None;
        for _ in 0..sub_length {
            let mut node = head.unwrap();
            head = node.next;
            node.next = None;
            if let Some(end) = tail {
                end.next = Some(node);
                tail = &mut end.next;
            } else {
                result[i] = Some(node);
                tail = &mut result[i];
            }
        }
    }
    result
}
pub fn length(head: &Option<Box<ListNode>>) -> usize {
    match head {
        None => 0,
        Some(b) => length(&b.next) + 1,
    }
}
