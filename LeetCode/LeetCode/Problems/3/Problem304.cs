namespace LeetCode.Problems
{
    public class Problem304
    {
        public class NumMatrix
        {
            private readonly int[][] _matrix;
            private readonly int[] _rowsSum;
            private readonly int[] _columnsSum;
            private readonly int _rowsCount;
            private readonly int _columnsCount;

            public NumMatrix(int[][] matrix)
            {
                _rowsCount = matrix.Length;
                _columnsCount = matrix[0].Length;
                _rowsSum = new int[_rowsCount];
                _columnsSum = new int[_columnsCount];
                for (var i = 0; i < _rowsCount; i++)
                for (var j = 0; j < _columnsCount; j++)
                {
                    _rowsSum[i] += matrix[i][j];
                    _columnsSum[j] += matrix[i][j];
                }

                _matrix = matrix;
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                var sum = 0;

                var sumRowsOrigin = row2 - row1 < _rowsCount / 2;
                var sumColumnsOrigin = col2 - col1 < _columnsCount / 2;

                if (sumRowsOrigin || sumColumnsOrigin)
                    if (sumRowsOrigin && sumColumnsOrigin)
                        if (_rowsCount - (row2 - row1) < _columnsCount - (col2 - col1))
                            sum = GetSumByRows(row1, col1, row2, col2);
                        else
                            sum = GetSumByColumns(row1, col1, row2, col2);
                    else if (sumRowsOrigin)
                        sum = GetSumByRows(row1, col1, row2, col2);
                    else
                        sum = GetSumByColumns(row1, col1, row2, col2);
                else
                    for (var i = row1; i <= row2; i++)
                    for (var j = col1; j <= col2; j++)
                        sum += _matrix[i][j];

                return sum;
            }

            private int GetSumByColumns(int row1, int col1, int row2, int col2)
            {
                var sum = 0;
                for (var j = col1; j <= col2; j++)
                    sum += _columnsSum[j];

                // divide unnecessary columns
                for (var j = col1; j <= col2; j++)
                {
                    for (var i = 0; i < row1; i++)
                        sum -= _matrix[i][j];
                    for (var i = row2 + 1; i < _rowsCount; i++)
                        sum -= _matrix[i][j];
                }

                return sum;
            }

            private int GetSumByRows(int row1, int col1, int row2, int col2)
            {
                var sum = 0;
                for (var i = row1; i <= row2; i++)
                    sum += _rowsSum[i];

                // divide unnecessary rows
                for (var i = row1; i <= row2; i++)
                {
                    for (var j = 0; j < col1; j++)
                        sum -= _matrix[i][j];
                    for (var j = col2 + 1; j < _columnsCount; j++)
                        sum -= _matrix[i][j];
                }

                return sum;
            }
        }
    }
}