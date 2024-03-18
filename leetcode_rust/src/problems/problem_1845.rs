use std::cmp::Reverse;
use std::collections::BinaryHeap;

struct SeatManager {
    last: i32,
    free_seats: BinaryHeap<Reverse<i32>>,
}

impl SeatManager {
    fn new(_: i32) -> Self {
        SeatManager {
            last: 0,
            free_seats: BinaryHeap::new(),
        }
    }

    fn reserve(&mut self) -> i32 {
        if self.free_seats.is_empty() {
            self.last += 1;
            self.last
        } else {
            self.free_seats.pop().unwrap().0
        }
    }

    fn unreserve(&mut self, seat_number: i32) {
        if seat_number == self.last {
            self.last -= 1;
        } else {
            self.free_seats.push(Reverse(seat_number));
        }
    }
}
