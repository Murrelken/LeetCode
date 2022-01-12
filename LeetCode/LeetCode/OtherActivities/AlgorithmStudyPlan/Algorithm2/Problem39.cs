using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem39
    {
        private static int _numsLength;
        private static int[] _nums;
        private static HashSet<string> _hash = new();

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var cut = candidates
                .Where(x => x <= target)
                .ToArray();

            _nums = cut;
            _numsLength = cut.Length;
            List<IList<int>> result = new();

            Helper(target, new List<int>(), result);

            _hash = new HashSet<string>();

            return result;
        }

        private static void Helper(int target, List<int> l, List<IList<int>> result)
        {
            if (target == 0)
            {
                var str = string.Join('_', l);
                if (!_hash.Contains(str))
                {
                    result.Add(l.ToList());
                    _hash.Add(str);
                }

                return;
            }

            if (target < 0)
                return;

            for (int i = 0; i < _numsLength; i++)
            {
                var index = l.BinarySearch(_nums[i]);
                if (index < 0) index = ~index;
                l.Insert(index, _nums[i]);

                Helper(target - _nums[i], l, result);

                l.RemoveAt(index);
            }
        }
    }
}