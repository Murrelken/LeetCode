using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem46
    {
        public IList<IList<int>> Permute(int[] nums) 
        {
            var result = new List<IList<int>>();

            Helper(new List<int>(), nums.ToList(), result);

            return result;
        }

        private static void Helper(List<int> tempList, List<int> availableNums, List<IList<int>> result)
        {
            if (availableNums.Count == 0)
                result.Add(tempList.ToList());
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