using System.Collections.Generic;
using System.Linq;

public class Problem1845
{
    public class SeatManager
    {
        private int _last = 0;
        private readonly SortedSet<int> _freeSeats = new SortedSet<int>();
        public SeatManager(int n)
        {
        }

        public int Reserve()
        {
            if (!_freeSeats.Any())
                return ++_last;
            else
            {
                var num = _freeSeats.Min;
                _freeSeats.Remove(num);
                return num;
            }
        }

        public void Unreserve(int seatNumber)
        {
            if (seatNumber == _last)
                _last--;
            else
                _freeSeats.Add(seatNumber);
        }
    }
}