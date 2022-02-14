using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem127
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (beginWord == endWord)
                return 1;

            if (!wordList.Contains(endWord))
                return 0;

            var hash = new HashSet<string>(wordList);
            var que = new Queue<string>();
            que.Enqueue(beginWord);

            var count = 0;
            while (que.Any())
            {
                count++;
                var queCount = que.Count;

                while (queCount > 0)
                {
                    queCount--;

                    var item = que.Dequeue();
                    var currentWord = item;
                
                    if (currentWord == endWord)
                        return count;
                    
                    for (var i = 0; i <= currentWord.Length - 1; i++)
                    {
                        var temp = currentWord.ToCharArray();
                        for (var j = 0; j < 26; j++)
                        {
                            temp[i] = (char)('a' + j);
                            var str = new string(temp);

                            if (hash.Contains(str))
                            {
                                que.Enqueue(str);
                                hash.Remove(str);
                            }
                        }
                    }
                }
            }

            return 0;
        }
    }
}