namespace LeetCode.Problems
{
    public class Problem867
    {
        public int[][] Transpose(int[][] matrix)
        {
            var height = matrix.Length;
            var width = matrix[0].Length;

            if (height == width)
            {
                for (var i = 0; i < height; i++)
                for (var j = i + 1; j < height; j++)
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);

                return matrix;
            }

            var result = new int[width][];
            for (var i = 0; i < result.Length; i++)
                result[i] = new int[height];

            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                result[j][i] = matrix[i][j];


            return result;
        }
    }
}