using System;
using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem1146
{
    public class SnapshotArray
    {
        private List<Dictionary<int, int>> snaps = new();
        private int i = 0;

        public SnapshotArray(int length)
        {
            snaps.Add(new Dictionary<int, int>());
        }

        public void Set(int index, int val)
        {
            if (snaps[i].ContainsKey(index))
                snaps[i][index] = val;
            else
                snaps[i].Add(index, val);
        }

        public int Snap()
        {
            snaps.Add(new Dictionary<int, int>());
            return i++;
        }

        public int Get(int index, int snap_id)
        {
            while (true)
            {
                if (snap_id < 0) return 0;
                if (snaps[snap_id].ContainsKey(index))
                    return snaps[snap_id][index];
                snap_id--;
            }
        }
    }
}