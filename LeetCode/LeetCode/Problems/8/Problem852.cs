namespace LeetCode.Problems;

public class Problem852
{
    public int PeakIndexInMountainArray(int[] arr)
    {
        var l = 0;
        var r = arr.Length - 1;
        while (true)
        {
            if (l == r) return l;
            if (r - l == 1) return arr[r] > arr[l] ? r : l;

            var mid = (r + l) / 2;

            if (arr[mid] > arr[mid + 1])
                r = mid;
            else
                l = mid;
        }
    }
}