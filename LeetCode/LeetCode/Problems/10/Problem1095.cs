public class Problem1095
{
    public int FindInMountainArray(int target, MountainArray mountainArr)
    {
        int length = mountainArr.Length();

        int left = 1;
        int right = length - 2;
        while (left != right)
        {
            int mid = (left + right) / 2;
            if (mountainArr.Get(mid) < mountainArr.Get(mid + 1))
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        int peakIndex = left;

        left = 0;
        right = peakIndex;
        while (left != right)
        {
            int testIndex = (left + right) / 2;
            if (mountainArr.Get(testIndex) < target)
            {
                left = testIndex + 1;
            }
            else
            {
                right = testIndex;
            }
        }

        if (mountainArr.Get(left) == target)
        {
            return left;
        }

        left = peakIndex + 1;
        right = length - 1;
        while (left != right)
        {
            int testIndex = (left + right) / 2;
            if (mountainArr.Get(testIndex) > target)
            {
                left = testIndex + 1;
            }
            else
            {
                right = testIndex;
            }
        }

        if (mountainArr.Get(left) == target)
        {
            return left;
        }

        return -1;
    }

    public interface MountainArray
    {
        public int Get(int index);
        public int Length();
    }
}