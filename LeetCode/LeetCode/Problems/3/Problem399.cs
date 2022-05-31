using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem399
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var results = new double[queries.Count];
            var dic = new Dictionary<string, List<Tuple<string, double>>>();
            var pairs = new HashSet<string>();

            for (var i = 0; i < equations.Count; i++)
            {
                if (!dic.ContainsKey(equations[i][0]))
                    dic.Add(equations[i][0], new List<Tuple<string, double>>());

                dic[equations[i][0]].Add(new Tuple<string, double>(equations[i][1], values[i]));

                if (!dic.ContainsKey(equations[i][1]))
                    dic.Add(equations[i][1], new List<Tuple<string, double>>());

                dic[equations[i][1]].Add(new Tuple<string, double>(equations[i][0], 1 / values[i]));

                if (!pairs.Contains(equations[i][0]))
                    pairs.Add(equations[i][0]);

                if (!pairs.Contains(equations[i][1]))
                    pairs.Add(equations[i][1]);
            }

            for (var i = 0; i < queries.Count; i++)
                if (pairs.Contains(queries[i][0]) && pairs.Contains(queries[i][1]))
                    results[i] = DFS(dic, new HashSet<string>(), queries[i][0], queries[i][1], 1);
                else
                    results[i] = -1.0;

            return results;
        }

        private double DFS(Dictionary<string, List<Tuple<string, double>>> dict, HashSet<string> visited, string cur,
            string e, double val)
        {
            if (cur == e)
                return val;

            if (dict.ContainsKey(cur))
                foreach (var item in dict[cur])
                    if (!visited.Contains(item.Item1))
                    {
                        visited.Add(item.Item1);

                        var res = DFS(dict, visited, item.Item1, e, val * item.Item2);

                        if (Math.Abs(res + 1.0) == 0)
                            return res;
                    }

            return -1.0;
        }
    }
}