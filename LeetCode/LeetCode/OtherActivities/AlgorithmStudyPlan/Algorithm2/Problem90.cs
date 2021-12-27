using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem90
    {
        private static int _numsLength;
        private static int[] _nums;
        private static HashSet<string> _hash;

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            _numsLength = nums.Length;

            var result = new List<IList<int>> { new List<int>() };

            if (_numsLength == 0) return result;

            _nums = nums;
            _hash = new HashSet<string>();

            Helper(0, new List<int>(), result);

            return result;
        }

        private static void Helper(int i, List<int> l, List<IList<int>> res)
        {
            for (var j = i; j < _numsLength; j++)
            {
                var index = l.BinarySearch(_nums[j]);
                if (index < 0) index = ~index;
                l.Insert(index, _nums[j]);

                var str = string.Join('_', l);
                if (!_hash.Contains(str))
                {
                    res.Add(l.ToList());
                    _hash.Add(str);
                }

                Helper(j + 1, l, res);

                l.RemoveAt(index);
            }
        }
    }
}