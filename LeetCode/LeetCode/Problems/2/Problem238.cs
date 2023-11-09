namespace LeetCode.Problems
{
    public class Problem238
    {
        public int[] ProductExceptSelf(int[] nums)
        {

            int prod = 1;
            var containsZero = false;
            int? firstZeroPose = null;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0 && !containsZero)
                {
                    containsZero = true;
                    firstZeroPose = i;
                    continue;
                }

                prod *= nums[i];
            }

            if (prod == 0)
            {
                for (var i = 0; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                return nums;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (containsZero)
                {
                    if (i == firstZeroPose)
                    {
                        nums[i] = prod;
                    }
                    else
                    {
                        nums[i] = 0;
                    }
                }
                else
                {
                    nums[i] = prod / nums[i];
                }
            }

            return nums;
        }

        public int[] ProductExceptSelfV2(int[] nums)
        {
            var n = nums.Length;
            var result = new int[n];
            var prod = 1;
            var zeroMet = false;
            var firstZeroIndex = -1;

            for (var i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                    if (zeroMet)
                    {
                        result[firstZeroIndex] = 0;
                        break;
                    }
                    else
                    {
                        zeroMet = true;
                        firstZeroIndex = i;
                        result[i] = nums[i];
                        prod = 0;
                    }
                else
                    prod *= nums[i];
            }

            if (prod == 0)
                return result;

            for (var i = 0; i < n; i++)
            {
                result[i] = prod / nums[i];
            }

            return result;
        }
    }
}