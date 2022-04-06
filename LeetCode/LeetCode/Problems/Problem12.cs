using System;
using System.Text;

namespace LeetCode.Problems
{
    public class Problem12
    {
        public string IntToRoman(int num)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 4; i++)
            {
                if (num == 0)
                    break;

                if (i == 3)
                {
                    var thousandsSb = new StringBuilder();
                    for (var j = 0; j < num; j++)
                    {
                        thousandsSb.Append('M');
                    }

                    sb.Insert(0, thousandsSb.ToString());
                }
                else
                {
                    var digit = num % 10;
                    num /= 10;

                    switch (i)
                    {
                        case 0:
                            sb.Insert(0, Helper('I', 'V', 'X', digit));
                            break;
                        case 1:
                            sb.Insert(0, Helper('X', 'L', 'C', digit));
                            break;
                        case 2:
                            sb.Insert(0, Helper('C', 'D', 'M', digit));
                            break;
                    }
                }
            }

            return sb.ToString();
        }

        private string Helper(char one, char five, char ten, int digit)
        {
            var sb = new StringBuilder();
            switch (digit)
            {
                case 0:
                    break;
                case <= 3:
                {
                    for (var i = 0; i < digit; i++)
                    {
                        sb.Append(one);
                    }

                    break;
                }
                case 4:
                    sb.Append(one);
                    sb.Append(five);
                    break;
                case 5:
                    sb.Append(five);
                    break;
                case 6 or 7 or 8:
                {
                    sb.Append(five);
                    for (var i = 5; i < digit; i++)
                    {
                        sb.Append(one);
                    }
                    break;
                }
                case 9:
                    sb.Append(one);
                    sb.Append(ten);
                    break;
                case 10:
                    sb.Append(ten);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return sb.ToString();
        }
    }
}