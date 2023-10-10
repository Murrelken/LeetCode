using System;

namespace LeetCode.Problems;

public class Problem2024
{
    public int MaxConsecutiveAnswers(string answerKey, int k)
    {
        var max = 0;
        var startIndex = 0;
        var current = 0;
        var tempK = k;
        var i = 0;

        //longest T
        while (i < answerKey.Length)
        {
            if (answerKey[i] == 'T')
            {
                current++;
                i++;
            }
            else
            {
                if (tempK > 0)
                {
                    tempK--;
                    current++;
                    i++;
                }
                else
                {
                    max = Math.Max(max, current);
                    if (answerKey[startIndex] == 'F')
                    {
                        startIndex++;
                        if (current > 0)
                            current--;
                        if (tempK < k)
                            tempK++;
                    }
                    else
                    {
                        while (startIndex < answerKey.Length && answerKey[startIndex] == 'T')
                        {
                            startIndex++;
                            current--;
                        }
                    }
                }
            }
        }

        max = Math.Max(max, current);

        startIndex = 0;
        current = 0;
        tempK = k;
        i = 0;

        //longest F
        while (i < answerKey.Length)
        {
            if (answerKey[i] == 'F')
            {
                current++;
                i++;
            }
            else
            {
                if (tempK > 0)
                {
                    tempK--;
                    current++;
                    i++;
                }
                else
                {
                    max = Math.Max(max, current);
                    if (answerKey[startIndex] == 'T')
                    {
                        startIndex++;
                        if (current > 0)
                            current--;
                        if (tempK < k)
                            tempK++;
                    }
                    else
                    {
                        while (startIndex < answerKey.Length && answerKey[startIndex] == 'F')
                        {
                            startIndex++;
                            current--;
                        }
                    }
                }
            }
        }

        max = Math.Max(max, current);

        return max;
    }
}