using System;

namespace LeetCode.Problems
{
    public class Problem88
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var currentIndex = nums1.Length - 1;
            m--;
            n--;

            while (currentIndex >= 0)
            {
                if (m >= 0 && n >= 0)
                {
                    if (nums1[m] > nums2[n])
                    {
                        nums1[currentIndex] = nums1[m];
                        m--;
                    }
                    else
                    {
                        nums1[currentIndex] = nums2[n];
                        n--;
                    }

                    currentIndex--;
                }
                else if (m >= 0)
                {
                    nums1[currentIndex] = nums1[m];
                    m--;
                    currentIndex--;
                }
                else
                {
                    nums1[currentIndex] = nums2[n];
                    n--;
                    currentIndex--;
                }
            }
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;

            var mostRight = m + n - 1;
            m--;
            n--;

            while (mostRight >= 0)
            {
                if (n >= 0 && m >= 0 && nums1[m] > nums2[n] || n < 0 && m >= 0)
                {
                    nums1[mostRight] = nums1[m];
                    m--;
                }
                else
                {
                    nums1[mostRight] = nums2[n];
                    n--;
                }

                mostRight--;
            }
        }
    }
}