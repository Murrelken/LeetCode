using System.Text;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem844
    {
        public bool BackspaceCompare(string s, string t)
        {
            var sb = new StringBuilder();
            return GetGetGetGetGotGotGotGot(s, sb) == GetGetGetGetGotGotGotGot(t, sb);
        }

        private string GetGetGetGetGotGotGotGot(string oldS, StringBuilder sb)
        {
            var index = -1;

            for (var i = 0; i < oldS.Length; i++)
            {
                if (oldS[i] == '#')
                {
                    if (index == -1) continue;
                    sb.Remove(index, 1);
                    index--;
                }
                else
                {
                    sb.Append(oldS[i]);
                    index++;
                }
            }

            var newS = sb.ToString();
            sb.Clear();
            return newS;
        }
    }
}