using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem567
    {
        public bool CheckInclusion(string s1, string s2)
        {
            var dic = new Dictionary<char, byte>();
            for (var index = 0; index < s1.Length; index++)
            {
                if (dic.ContainsKey(s1[index]))
                    dic[s1[index]]++;
                else
                    dic.Add(s1[index], 1);
            }

            short begin, end;
            begin = end = 0;

            while (end < s2.Length)
            {
                if (dic.ContainsKey(s2[end]))
                {
                    if (dic[s2[end]] == 1)
                        dic.Remove(s2[end]);
                    else
                        dic[s2[end]]--;

                    end++;

                    if (dic.Count == 0)
                        return true;
                }
                else
                {
                    if (begin == end)
                    {
                        begin++;
                        end++;
                    }
                    else
                    {
                        if (dic.ContainsKey(s2[begin]))
                        {
                            dic[s2[begin]]++;
                        }
                        else
                        {
                            dic.Add(s2[begin], 1);
                        }

                        begin++;
                    }
                }
            }

            return false;
        }
    }
}