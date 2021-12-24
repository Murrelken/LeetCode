using System.Collections.Generic;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem438
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();
            var dic = new Dictionary<char, short>();
            for (var index = 0; index < p.Length; index++)
            {
                if (dic.ContainsKey(p[index]))
                    dic[p[index]]++;
                else
                    dic.Add(p[index], 1);
            }

            short begin, end;
            begin = end = 0;

            while (end < s.Length)
            {
                if (dic.ContainsKey(s[end]))
                {
                    if (dic[s[end]] == 1)
                        dic.Remove(s[end]);
                    else
                        dic[s[end]]--;

                    end++;

                    if (dic.Count == 0)
                    {
                        if (dic.ContainsKey(s[begin]))
                        {
                            dic[s[begin]]++;
                        }
                        else
                        {
                            dic.Add(s[begin], 1);
                        }
                        result.Add(begin);
                        begin++;
                    }
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
                        if (dic.ContainsKey(s[begin]))
                        {
                            dic[s[begin]]++;
                        }
                        else
                        {
                            dic.Add(s[begin], 1);
                        }

                        begin++;
                    }
                }
            }

            return result;
        }
    }
}