namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem191
    {
        public int HammingWeight(uint n)
        {
            var count = 0;

            while (n > 0)
            {
                if ((n & 1) == 1) count++;
                n >>= 1;
            }

            return count;
        }
    }
}