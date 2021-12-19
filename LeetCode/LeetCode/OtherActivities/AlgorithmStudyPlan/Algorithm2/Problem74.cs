using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem74
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0)
                return false;
            var i = matrix.Length;
            var j = matrix[0].Length;

            var left = 0;
            var right = i * j - 1;
            while (true)
            {
                var mid = (right + left) / 2;
                var midI = mid / j;
                var midJ = mid % j;
                if (matrix[midI][midJ] == target)
                    return true;

                if (left > right)
                    return false;

                if (matrix[midI][midJ] > target)
                {
                    right = mid - 1;
                    
                }
                else
                {
                    left = mid + 1;
                }
            }
        }
    }
}