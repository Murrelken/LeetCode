namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem278
    {
        public int FirstBadVersion(int n)
        {
            var left = 0;
            var right = n;
            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (IsBadVersion(mid))
                {
                    right = mid;
                    
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        // condition mock
        public bool IsBadVersion(int version) => version >= 5;
    }
}