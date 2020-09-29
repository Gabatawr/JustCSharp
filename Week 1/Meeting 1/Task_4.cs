using System;

#region Description
/*
 * Даны целые положительные числа A и B (A < B).
 * Вывести все целые числа от A до B включительно;
 * каждое число должно выводиться на новой строке;
 * при этом каждое число должно выводиться количество раз, равное его значению.
 * Например: если А = 3, а В = 7, то программа должна сформировать в консоли следующий вывод:
 * ---------------
 *  3 3 3
 *  4 4 4 4
 *  5 5 5 5 5
 *  6 6 6 6 6 6
 *  7 7 7 7 7 7 7
 * ---------------
 */
#endregion

namespace Meeting_1
{
    partial class Program
    {
        static void SwapInt(ref int A, ref int B)
        {
            int T = A;
                A = B;
                B = T;
        }
        static void NumPrint(int A, int B)
        {
            if(A > B) SwapInt(ref A, ref B);

            for (int i = A; i <= B; i++, A++)
            {
                if (A <= B)
                {
                    for (int j = 0; j < A; j++) Console.Write(' ' + A.ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}
