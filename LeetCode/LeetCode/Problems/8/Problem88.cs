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
    }
}