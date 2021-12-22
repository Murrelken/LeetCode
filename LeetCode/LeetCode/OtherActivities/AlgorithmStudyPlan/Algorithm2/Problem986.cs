using System;
using System.Collections.Generic;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem986
    {
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            if (firstList.Length == 0 || secondList.Length == 0)
                return Array.Empty<int[]>();
            
            int i = 0, j = 0;
            var result = new List<int[]>();

            while (i < firstList.Length && j < secondList.Length)
            {
                if (firstList[i][0] < secondList[j][0])
                {
                    if (firstList[i][1] < secondList[j][0])
                    {
                        i++;
                    }
                    else if (firstList[i][1] == secondList[j][0])
                    {
                        result.Add(new[] { secondList[j][0], firstList[i][1] });
                        i++;
                    }
                    else if (firstList[i][1] > secondList[j][0])
                    {
                        if (firstList[i][1] < secondList[j][1])
                        {
                            result.Add(new[] { secondList[j][0], firstList[i][1] });
                            i++;
                        } 
                        else if (firstList[i][1] == secondList[j][1])
                        {
                            result.Add(new[] { secondList[j][0], firstList[i][1] });
                            i++;
                            j++;
                        }
                        else
                        {
                            result.Add(new[] { secondList[j][0], secondList[j][1] });
                            j++;
                        }
                    }
                }
                else if(firstList[i][0] > secondList[j][0])
                {
                    if (firstList[i][1] < secondList[j][1])
                    {
                        result.Add(new[] { firstList[i][0], firstList[i][1] });
                        i++;
                    }
                    else if(firstList[i][1] == secondList[j][1])
                    {
                        result.Add(new[] { firstList[i][0], firstList[i][1] });
                        i++;
                        j++;
                    }
                    else if(firstList[i][1] > secondList[j][1])
                    {
                        if (firstList[i][0] > secondList[j][1])
                        {
                            j++;
                        }
                        else if(firstList[i][0] == secondList[j][1])
                        {
                            result.Add(new[] { firstList[i][0], secondList[j][1] });
                            j++;
                        }
                    }
                }
                else
                {
                    if (firstList[i][1] <= secondList[j][1])
                    {
                        result.Add(new[] { firstList[i][0], firstList[i][1] });
                        i++;
                    }
                    else
                    {
                        result.Add(new[] { firstList[i][0], secondList[j][1] });
                        j++;
                    }
                }
            }

            return result.ToArray();
        }
    }
}