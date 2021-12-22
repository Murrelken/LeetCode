using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var hashResults = new HashSet<string>();
            var sb = new StringBuilder();

            var n = nums.Length;
            for (var i = 0; i < n; i++)
            {
                var s = new HashSet<int>();
                for (var j = i + 1; j < n; j++)
                {
                    var x = 0 - (nums[i] + nums[j]);
                    if (s.Contains(x))
                    {
                        if (x <= nums[i] && x <= nums[j])
                        {
                            sb.Append(x);
                            sb.Append(' ');
                            if (nums[i] < nums[j])
                            {
                                sb.Append(nums[i]);
                                sb.Append(' ');
                                sb.Append(nums[j]);
                            }
                            else
                            {
                                sb.Append(nums[j]);
                                sb.Append(' ');
                                sb.Append(nums[i]);
                            }
                        }
                        else if (nums[i] <= x && nums[i] <= nums[j])
                        {
                            sb.Append(nums[i]);
                            sb.Append(' ');
                            if (x < nums[j])
                            {
                                sb.Append(x);
                                sb.Append(' ');
                                sb.Append(nums[j]);
                            }
                            else
                            {
                                sb.Append(nums[j]);
                                sb.Append(' ');
                                sb.Append(x);
                            }
                        }
                        else if (nums[j] <= x && nums[j] <= nums[i])
                        {
                            sb.Append(nums[j]);
                            sb.Append(' ');
                            if (x < nums[i])
                            {
                                sb.Append(x);
                                sb.Append(' ');
                                sb.Append(nums[i]);
                            }
                            else
                            {
                                sb.Append(nums[i]);
                                sb.Append(' ');
                                sb.Append(x);
                            }
                        }

                        hashResults.Add(sb.ToString());
                        sb.Clear();
                    }
                    else
                    {
                        s.Add(nums[j]);
                    }
                }
            }

            List<IList<int>> res = hashResults
                .Select(x => (IList<int>)x
                    .Split(' ')
                    .Select(s =>
                        {
                            int.TryParse(s, out var value);
                            return value;
                        }
                    )
                    .ToList())
                .ToList();

            return res;
        }
    }
}