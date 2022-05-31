namespace LeetCode.Problems
{
    public class Problem59
    {
        public int[][] GenerateMatrix(int n)
        {
            // 0 - right
            // 1 - down
            // 2 - left
            // 3 - up

            var res = new int[n][];
            for (var iii = 0; iii < res.Length; iii++)
                res[iii] = new int[n];

            int left = 0, top = 0, right = n - 1, bot = n - 1, num = 1, step = 0, i = 0, j = 0, max = n * n;

            while (num <= max)
            {
                res[i][j] = num;
                num++;
                
                switch (step)
                {
                    case 0:
                        if (j < right)
                            j++;
                        else
                        {
                            top++;
                            i++;
                            step++;
                        }
                        break;
                    case 1:
                        if (i < bot)
                            i++;
                        else
                        {
                            right--;
                            j--;
                            step++;
                        }
                        break;
                    case 2:
                        if (j > left)
                            j--;
                        else
                        {
                            bot--;
                            i--;
                            step++;
                        }
                        break;
                    case 3:
                        if (i > top)
                            i--;
                        else
                        {
                            left++;
                            j++;
                            step = 0;
                        }
                        break;
                }
            }

            return res;
        }
    }
}