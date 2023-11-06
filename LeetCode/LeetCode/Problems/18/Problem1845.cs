using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Problem1845
{
    public class SeatManager
    {
        private int _last = 0;
        private readonly SortedSet<int> _sortedSeats = new SortedSet<int>();
        public SeatManager(int n)
        {
        }

        public int Reserve()
        {
            if (!_sortedSeats.Any())
                return ++_last;
            else
            {
                var num = _sortedSeats.Min;
                _sortedSeats.Remove(num);
                return num;
            }
        }

        public void Unreserve(int seatNumber)
        {
            if (seatNumber == _last)
                _last--;
            else
                _sortedSeats.Add(seatNumber);
        }
    }
}