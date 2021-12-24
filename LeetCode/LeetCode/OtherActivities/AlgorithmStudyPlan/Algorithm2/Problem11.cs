using System;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem11
    {
        public int MaxArea(int[] height)
        {
            int i = 0,
                j = height.Length - 1,
                left = 0,
                right = height.Length - 1,
                area = Math.Min(height[left], height[right]) * right;

            while (i < j)
            {
                if (height[left] < height[right])
                {
                    i++;
                    if (height[i] > height[left])
                    {
                        var newArea = Math.Min(height[i], height[right]) * (right - i);
                        if (newArea > area)
                        {
                            area = newArea;
                        }
                        left = i;
                    }
                }
                else
                {
                    j--;
                    if (height[j] > height[right])
                    {
                        var newArea = Math.Min(height[j], height[left]) * (j - left);
                        if (newArea > area)
                        {
                            area = newArea;
                        }
                        right = j;
                    }
                }
            }

            return area;
        }
    }
}