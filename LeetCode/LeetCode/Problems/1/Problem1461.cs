namespace LeetCode.Problems
{
    public class Problem1461
    {
        public bool HasAllCodes(string s, int k)
        {
            var need = 1 << k;
            var hash = new bool[need];
            var allOne = ulong.Parse((need - 1).ToString());

            for (var i = k; i <= s.Length; i++)
            {
                var substring = s.Substring(i - k, k);
                var index = ulong.Parse(substring) & allOne;
                if (hash[index]) continue;
                hash[index] = true;
                need--;
                if (need == 0)
                    return true;
            }

            return false;
        }
    }
}