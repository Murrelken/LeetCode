using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem46
    {
        public IList<IList<int>> Permute(int[] nums) 
        {
            var result = new List<IList<int>>();

            Helper(new List<int>(), nums, result);

            return result;
        }

        private static void Helper(List<int> tempList, int[] availableNums, List<IList<int>> result)
        {
            if (availableNums.Length == 0)
                result.Add(tempList.ToList());
            else
            {
                for (var i = 0; i < availableNums.Length; i++)
                {
                    tempList.Add(availableNums[i]);
                    
                    Helper(tempList, availableNums.Where((_, index) => index != i).ToArray(), result);
                    
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
    }
}