using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem77
    {
        public IList<IList<int>> Combine(int maxNumber, int resultsLength)
        {
            var result = new List<IList<int>>();

            Helper(maxNumber, resultsLength, 1, new List<int>(), result);

            return result;
        }

        private void Helper(int n, int k, int i, List<int> l, List<IList<int>> res)
        {
            if (l.Count == k)
                res.Add(l.ToList());
            else
                for (var j = i; j <= n; j++)
                {
                    l.Add(j);

                    Helper(n, k, j + 1, l, res);

                    l.RemoveAt(l.Count - 1);
                }
        }
    }
}