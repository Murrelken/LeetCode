namespace LeetCode.Problems
{
    public class Problem1332
    {
        public int RemovePalindromeSub(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            return IsPalindrome(s) ? 1 : 2;
        }

        private bool IsPalindrome(string s)
        {
            for (var i = 0; i < s.Length; i++)
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            return true;
        }
    }
}