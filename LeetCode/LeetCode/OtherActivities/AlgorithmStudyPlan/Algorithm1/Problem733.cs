using System.Collections.Generic;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem733
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var remainingItems = new List<(int sr, int sc)> { (sr, sc) };
            var hash = new HashSet<(int, int)>();
            int y = image.Length, x = image[0].Length;

            for (var i = 0; i < remainingItems.Count; i++)
            {
                var (currSr, currSc) = remainingItems[i];
                if (currSr != 0 && image[currSr - 1][currSc] == image[currSr][currSc] &&
                    !hash.Contains((currSr - 1, currSc)))
                {
                    remainingItems.Add((currSr - 1, currSc));
                    hash.Add((currSr - 1, currSc));
                }
                if(currSr != y - 1 && image[currSr + 1][currSc] == image[currSr][currSc] && !hash.Contains((currSr + 1, currSc)))
                {
                    remainingItems.Add((currSr + 1, currSc));
                    hash.Add((currSr + 1, currSc));
                }
                
                if(currSc != 0 && image[currSr][currSc - 1] == image[currSr][currSc] && !hash.Contains((currSr, currSc - 1)))
                {
                    remainingItems.Add((currSr, currSc - 1));
                    hash.Add((currSr, currSc - 1));
                }
                if(currSc != x - 1 && image[currSr][currSc + 1] == image[currSr][currSc] && !hash.Contains((currSr, currSc + 1)))
                {
                    remainingItems.Add((currSr, currSc + 1));
                    hash.Add((currSr, currSc + 1));
                }

                image[currSr][currSc] = newColor;
            }

            return image;
        }
    }
}