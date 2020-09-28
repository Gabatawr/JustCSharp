using System;

#region Description
/*
 * Ввести с клавиатуры номер трамвайного билета (6-значное число) и проверить является ли данный билет счастливым
 * (если на билете напечатано шестизначное число, и сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым).
 */
#endregion

namespace Meeting_1
{
    partial class Program
    {
        static bool IsLucky()
        {
            int counter = 0;
            int[] array = new int[6];

            Console.Write("000000\b\b\b\b\b\b");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter) break;

                if (Char.IsDigit(key.KeyChar) && counter < 6)
                {
                    Console.Write(key.KeyChar);
                    array[counter] = Convert.ToInt32(key.KeyChar);
                    counter++;
                }
                else if (key.Key == ConsoleKey.Backspace && counter > 0)
                {
                    Console.Write("\b0\b");
                    counter--;
                    array[counter] = 0;
                }
            }

            return array[0] + array[1] + array[2] == array[3] + array[4] + array[5];
        }
    }
}
