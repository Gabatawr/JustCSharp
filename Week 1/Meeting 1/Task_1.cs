using System;

#region Description
/*
 * Написать программу, которая считывает символы с клавиатуры, пока не будет введена точка.
 * Программа должна сосчитать количество введенных пользователем пробелов. 
 */
#endregion

namespace Meeting_1
{
    partial class Program
    {
        static int SpaceCounter()
        {
            int counter = 0;
            int idColor = 0;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == '.' || key.Key == ConsoleKey.Enter) break;
                if (key.KeyChar == ' ')
                {
                    Console.Write('\b');
                    Console.BackgroundColor = (ConsoleColor)idColor++;
                    idColor = idColor == 16 ? 0 : idColor;

                    Console.Write(' ');
                    Console.ResetColor();

                    counter++;
                }
            }
            return counter;
        }
    }
}
