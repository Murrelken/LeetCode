namespace LeetCode.Problems
{
    public class Problem258
    {
        public int AddDigits(int num)
        {
            var res = 0;

            while (num > 0)
            {
                var digit = num % 10;
                res += digit;
                res = res >= 10
                    ? 1 + res % 10
                    : res;

                num /= 10;
            }

            return res;
        }
    }
}