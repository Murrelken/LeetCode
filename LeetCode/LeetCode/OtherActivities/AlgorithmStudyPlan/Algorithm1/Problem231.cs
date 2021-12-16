using System.Collections.Generic;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem231
    {
        public bool IsPowerOfTwo(int n)
            => n > 0 && ((n - 1) & n) == 0;
    }
}