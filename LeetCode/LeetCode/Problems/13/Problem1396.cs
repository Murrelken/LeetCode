using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem1396
    {
        public class UndergroundSystem
        {
            private Dictionary<int, PendingDrives> _pendingDrives = new();
            private Dictionary<string, ExistingDrives> _existingDrives = new();

            public UndergroundSystem()
            {
            }

            public void CheckIn(int id, string stationName, int t)
            {
                _pendingDrives.Add(id, new PendingDrives(stationName, t));
            }

            public void CheckOut(int id, string stationName, int t)
            {
                var start = _pendingDrives[id];
                _pendingDrives.Remove(id);
                var key = start.StartStationName + "s" + stationName;
                var time = t - start.Time;
                if (_existingDrives.TryGetValue(key, out var existing))
                {
                    existing.Average = (existing.Average * existing.TotalCount + time) / (existing.TotalCount + 1);
                    existing.TotalCount++;
                }
                else
                    _existingDrives.Add(key, new ExistingDrives(time));
            }

            public double GetAverageTime(string startStation, string endStation)
                => _existingDrives[startStation + "s" + endStation].Average;

            private class PendingDrives
            {
                public PendingDrives(string startStationName, int time)
                {
                    StartStationName = startStationName;
                    Time = time;
                }

                public string StartStationName { get; set; }

                public int Time { get; set; }
            }

            private class ExistingDrives
            {
                public ExistingDrives(double average)
                {
                    TotalCount = 1;
                    Average = average;
                }

                public int TotalCount { get; set; }
                
                public double Average { get; set; }
            }
        }
    }
}