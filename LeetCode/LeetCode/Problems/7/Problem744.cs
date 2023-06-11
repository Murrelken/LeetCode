namespace LeetCode.Problems;

public class Problem744
{
    public char NextGreatestLetter(char[] l, char t)
    {
        foreach (var t1 in l)
            if (t1 > t)
                return t1;

        return l[0];
    }
}