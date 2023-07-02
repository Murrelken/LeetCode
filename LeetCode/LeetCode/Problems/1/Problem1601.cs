using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem1601
{
    public int MaximumRequests(int n, int[][] requests)
    {
        var totalCounts = new int[n];
        var res = Req(requests, totalCounts, 0, 0);
        return res;
    }

    private int Req(int[][] requests, int[] totalCounts, int i, int requestsAccepted)
    {
        if (i == requests.Length)
            return totalCounts.All(x => x == 0) ? requestsAccepted : -1;

        var skipRequest = Req(requests, totalCounts, i + 1, requestsAccepted);

        totalCounts[requests[i][0]]--;
        totalCounts[requests[i][1]]++;
        var acceptRequest = Req(requests, totalCounts, i + 1, requestsAccepted + 1);
        totalCounts[requests[i][0]]++;
        totalCounts[requests[i][1]]--;

        return Math.Max(skipRequest, acceptRequest);
    }
}