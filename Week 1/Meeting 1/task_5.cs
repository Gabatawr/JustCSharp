using System;

#region Description
/*
 * Дано целое число N > 0, найти число, полученное при прочтении числа N справа налево.
 * Например, если было введено число 345, то программа должна вывести число 543.
 */
#endregion

namespace Meeting_1
{
    partial class Program
    {
        static int ReversInt(int num)
        {
            String str = num.ToString();
            char[] arr = new char[str.Length];

            for (int i = str.Length - 1, j = 0; i >= 0; --i, ++j) arr[j] = str[i];

            str = new string(arr);
            return int.Parse(str);
        }
    }
}
