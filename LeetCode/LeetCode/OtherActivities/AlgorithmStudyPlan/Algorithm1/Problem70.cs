namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem70
    {
        public int ClimbStairs(int n)
        {
            if (n <= 3)
                return n;
            
            // initially for n =2
            var previous = 2;
            // initially for n = 3
            var current = 3;

            for (var i = 4; i <= n; i++)
            {
                var tempCurrent = current + previous;
                previous = current;
                current = tempCurrent;
            }

            return current;
        }
    }
}