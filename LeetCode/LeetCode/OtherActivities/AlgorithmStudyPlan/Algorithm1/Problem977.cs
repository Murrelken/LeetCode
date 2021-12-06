using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem977
    {
        public int[] SortedSquares(int[] nums)
        {
            var newArr = new int[nums.Length];
            var i = nums.Length - 1;
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    newArr[i] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    newArr[i] = nums[right] * nums[right];
                    right--;
                }

                i--;
            }
            
            return newArr;
        }
    }
}