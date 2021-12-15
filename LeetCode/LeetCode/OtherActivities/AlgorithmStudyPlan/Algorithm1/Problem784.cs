using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem784
    {
        public IList<string> LetterCasePermutation(string s)
        {
            var inputAsArray = s.ToArray();
            var charsCount = 0;

            for (var i = 0; i < s.Length; i++)
                if (char.IsLetter(s[i]))
                    charsCount++;

            if (charsCount == 0)
                return new[] { s };

            var combinationsCount = 1 << charsCount;

            var result = new char[combinationsCount][];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new char[s.Length];
                inputAsArray.CopyTo(result[i], 0);
            }

            var step = 1;

            for (var i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                    continue;

                for (var j = 0; j < combinationsCount; j++)
                {
                    var x = j / step % 2;
                    result[j][i] = x == 1
                        ? char.ToUpper(s[i])
                        : char.ToLower(s[i]);
                }

                step *= 2;
            }

            var letterCasePermutations = result
                .Select(x => new string(x))
                .ToArray();

            return letterCasePermutations;
        }
    }
}