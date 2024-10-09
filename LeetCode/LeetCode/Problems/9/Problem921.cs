namespace LeetCode.Problems._9;

public class Problem921
{
    public int MinAddToMakeValid(string s)
    {
        var res = 0;
        var currentOpened = 0;
        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    currentOpened++;
                    break;
                case ')':
                    if (currentOpened > 0)
                        currentOpened--;
                    else
                        res++;
                    break;
            }
        }

        return res + currentOpened;
    }
}