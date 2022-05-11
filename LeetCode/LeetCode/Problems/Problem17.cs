using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    public class Problem17
    {
        private IList<string> res = new List<string>();
        private Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>();

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits)) return res;

            dict.Add('2', new List<char>() { 'a', 'b', 'c' });
            dict.Add('3', new List<char>() { 'd', 'e', 'f' });
            dict.Add('4', new List<char>() { 'g', 'h', 'i' });
            dict.Add('5', new List<char>() { 'j', 'k', 'l' });
            dict.Add('6', new List<char>() { 'm', 'n', 'o' });
            dict.Add('7', new List<char>() { 'p', 'q', 'r', 's' });
            dict.Add('8', new List<char>() { 't', 'u', 'v' });
            dict.Add('9', new List<char>() { 'w', 'x', 'y', 'z' });

            Helper(digits, 0, new StringBuilder());

            return res;
        }

        private void Helper(string digits, int i, StringBuilder cur)
        {
            if (i == digits.Length)
                res.Add(cur.ToString());
            else
                foreach (var item in dict[digits[i]])
                {
                    cur.Append(item);

                    Helper(digits, i + 1, cur);

                    cur.Remove(cur.Length - 1, 1);
                }
        }
    }
}