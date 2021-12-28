using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem47
    {
        private static HashSet<string> _hash;

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var result = new List<IList<int>>();

            _hash = new HashSet<string>();
            Helper(new List<int>(), nums.ToList(), result);

            return result;
        }

        private static void Helper(List<int> tempList, List<int> availableNums, List<IList<int>> result)
        {
            if (availableNums.Count == 0)
            {
                var str = string.Join('_', tempList);
                if (!_hash.Contains(str))
                {
                    result.Add(tempList.ToList());
                    _hash.Add(str);
                }
            }
            else
            {
                for (var i = 0; i < availableNums.Count; i++)
                {
                    var item = availableNums[i];
                    tempList.Add(item);

                    availableNums.RemoveAt(i);
                    Helper(tempList, availableNums, result);
                    availableNums.Insert(i, item);

                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
    }
}