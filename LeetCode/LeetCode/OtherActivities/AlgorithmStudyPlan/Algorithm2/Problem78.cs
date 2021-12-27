using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem78
    {
        private static int _numsLength;
        private static int[] _nums;

        public IList<IList<int>> Subsets(int[] nums)
        {
            _nums = nums;
            _numsLength = nums.Length;
            var result = new List<IList<int>> { new List<int>() };

            if (_numsLength == 0) return result;

            Helper(0, new List<int>(), result);

            return result;
        }

        private static void Helper(int i, List<int> l, List<IList<int>> res)
        {
            for (var j = i; j < _numsLength; j++)
            {
                l.Add(_nums[j]);
                res.Add(l.ToList());

                Helper(j + 1, l, res);

                l.RemoveAt(l.Count - 1);
            }
        }
    }
}