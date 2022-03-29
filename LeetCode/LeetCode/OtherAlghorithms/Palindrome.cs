using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherAlghorithms
{
    public class Palindrome
    {
        public bool IsPalindrome(string input)
        {
            var truncated = input
                .ToLower()
                .Where(x => char.IsDigit(x) || char.IsLetter(x))
                .ToArray();

            var halfLength = truncated.Length / 2;
            var charsStack = new Stack<char>();

            for (var i = 0; i < halfLength; i++)
            {
                charsStack.Push(truncated[i]);
            }

            var isPalindrome = true;

            var rightHalfStart = truncated.Length / 2 + truncated.Length % 2;
            for (var i = rightHalfStart; i < truncated.Length; i++)
            {
                if (truncated[i] == charsStack.Pop()) continue;
                isPalindrome = false;
                break;
            }

            return isPalindrome;
        }
    }
}