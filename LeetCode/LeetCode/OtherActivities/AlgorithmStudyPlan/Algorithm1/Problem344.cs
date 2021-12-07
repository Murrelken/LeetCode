namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem344
    {
        public void ReverseString(char[] s)
        {
            short index = 0;

            while (index < s.Length / 2)
            {
                (s[index], s[s.Length - 1 - index]) = (s[s.Length - 1 - index], s[index]);
                index++;
            }
        }
    }
}