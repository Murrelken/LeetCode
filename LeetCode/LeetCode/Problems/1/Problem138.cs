using System.Collections.Generic;
using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem138
{
    public RandomNode CopyRandomList(RandomNode head)
    {
        var pre_head_result = new RandomNode(0);

        var new_list = new List<RandomNode>();

        var pre_head_result_temp = pre_head_result;
        var temp_head = head;
        while (temp_head != null)
        {
            pre_head_result_temp.next = new RandomNode(temp_head.val);
            pre_head_result_temp = pre_head_result_temp.next;
            new_list.Add(pre_head_result_temp);
            temp_head = temp_head.next;
        }

        var i = 0;
        temp_head = head;
        while (temp_head != null)
        {
            temp_head.val = i++;
            temp_head = temp_head.next;
        }

        temp_head = head;
        while (temp_head != null)
        {
            if (temp_head.random != null)
            {
                new_list[temp_head.val].random = new_list[temp_head.random.val];
            }

            temp_head = temp_head.next;
        }

        return pre_head_result.next;
    }
}