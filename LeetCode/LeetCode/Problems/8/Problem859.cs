namespace LeetCode.Problems;

public class Problem859
{
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length != goal.Length)
            return false;

        if (s == goal)
        {
            var arr = new bool[26];
            for (var i = 0; i < s.Length; i++)
            {
                if (arr[s[i] - 'a'])
                    return true;
                arr[s[i] - 'a'] = true;
            }

            return false;
        }
        
        var differences = 0;
        var firstLetterInOrigin = ' ';
        var firstLetterInGoal = ' ';
        var buds = false;

        for (var i = 0; i < s.Length; i++)
        {
            if(s[i]==goal[i])
                continue;

            switch (differences)
            {
                case 0:
                    firstLetterInOrigin = s[i];
                    firstLetterInGoal = goal[i];
                    break;
                case 1 when firstLetterInOrigin == goal[i] && firstLetterInGoal == s[i]:
                    buds = true;
                    break;
                default:
                    return false;
            }

            differences++;
        }

        return buds;
    }
}