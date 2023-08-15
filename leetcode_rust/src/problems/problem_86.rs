use super::list_node::ListNode;

pub fn partition(mut head: Option<Box<ListNode>>, x: i32) -> Option<Box<ListNode>> {
    let mut init_left = ListNode::new(-1);
    let mut init_right = ListNode::new(-1);
    let mut left = &mut init_left;
    let mut right = &mut init_right;

    while let Some(mut node) = head.take() {
        head = node.next.take();
        if node.val < x {
            left.next = Some(node);
            left = left.next.as_mut().unwrap();
        } else {
            right.next = Some(node);
            right = right.next.as_mut().unwrap();
        }
    }

    left.next = init_right.next;
    init_left.next
}
