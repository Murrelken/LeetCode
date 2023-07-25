using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.HelperClasses;

public static class MatrixCreator
{
    public static IList<IList<T>> MatrixFromStr<T>(this string str)
    {
        var strArrays = str.Split(']');

        var res = new T[strArrays.Length - 1][];

        for (var i = 0; i < strArrays.Length - 1; i++)
        {
            var remove = strArrays[i]
                .Replace('[', ' ')
                .Skip(i == 0 ? 1 : 2)
                .ToArray();
            var newStr = new string(remove);
            res[i] = newStr
                .Split(',')
                .Select(x => (T)Convert.ChangeType(x, typeof(T)))
                .ToArray();
        }

        return res;
    }
}