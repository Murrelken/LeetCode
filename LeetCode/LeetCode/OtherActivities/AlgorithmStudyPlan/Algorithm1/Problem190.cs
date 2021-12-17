using System;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem190
    {
        public uint ReverseBits(uint n)
        {
            if (n == 0)
                return 0;

            uint newN = 0;
            var i = 1;

            while (i <= 32)
            {
                if (n == 0)
                {
                    newN <<= 32 - i + 1;
                    break;
                }

                var lastBit = n & 1;
                newN <<= 1;
                n >>= 1;

                if (lastBit == 1)
                {
                    newN++;
                }

                i++;
            }

            return newN;
        }
    }
}