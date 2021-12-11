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

                if (currSr != y - 1 && image[currSr + 1][currSc] == image[currSr][currSc] &&
                    !hash.Contains((currSr + 1, currSc)))
                {
                    remainingItems.Add((currSr + 1, currSc));
                    hash.Add((currSr + 1, currSc));
                }

                if (currSc != 0 && image[currSr][currSc - 1] == image[currSr][currSc] &&
                    !hash.Contains((currSr, currSc - 1)))
                {
                    remainingItems.Add((currSr, currSc - 1));
                    hash.Add((currSr, currSc - 1));
                }

                if (currSc != x - 1 && image[currSr][currSc + 1] == image[currSr][currSc] &&
                    !hash.Contains((currSr, currSc + 1)))
                {
                    remainingItems.Add((currSr, currSc + 1));
                    hash.Add((currSr, currSc + 1));
                }

                image[currSr][currSc] = newColor;
            }

            return image;
        }

        public int[][] FloodFillRecursive(int[][] image, int sr, int sc, int newColor)
        {
            var initialColor = image[sr][sc];
            if (initialColor != newColor)
            {
                int y = image.Length, x = image[0].Length;
                RecursiveCall(image, sr, sc, initialColor, newColor, x, y);
            }
            return image;
        }

        private static void RecursiveCall(int[][] image, int sr, int sc, int initialColor, int newColor, int x, int y)
        {
            if (image[sr][sc] != initialColor) return;

            image[sr][sc] = newColor;

            if (sr != 0)
                RecursiveCall(image, sr - 1, sc, initialColor, newColor, x, y);
            if (sr != y - 1)
                RecursiveCall(image, sr + 1, sc, initialColor, newColor, x, y);

            if (sc != 0)
                RecursiveCall(image, sr, sc - 1, initialColor, newColor, x, y);
            if (sc != x - 1)
                RecursiveCall(image, sr, sc + 1, initialColor, newColor, x, y);
        }
    }
}