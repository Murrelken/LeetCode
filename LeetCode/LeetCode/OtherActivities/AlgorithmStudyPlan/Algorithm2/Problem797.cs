using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem797
    {
        private static int _graphL;
        private static int[][] _graph;
        private static List<IList<int>> _result;
        private static List<int> _tempList;

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            if (graph[0].Length == 0)
                return new List<IList<int>>();

            _graphL = graph.Length - 1;
            _graph = graph;
            _result = new List<IList<int>>();
            _tempList = new List<int> { 0 };

            Halper(0);

            return _result;
        }

        private static void Halper(int i)
        {
            if (i == _graphL)
                _result.Add(_tempList.ToList());
            for (var j = 0; j < _graph[i].Length; j++)
            {
                _tempList.Add(_graph[i][j]);

                Halper(_graph[i][j]);

                _tempList.RemoveAt(_tempList.Count - 1);
            }
        }
    }
}