using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

#region Description
/*
 * Тема: Основы языка с#
 * Цель: Научиться использовать встроенные типы,
 *       закрепить на практике явное преобразования типов,
 *       работу с операторами ветвления, навыки использования циклов. 
 */
#endregion

namespace Meeting_1
{
    partial class Program
    {
        static void Wait()
        {
            Console.Write("\n Enter to continue..");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }

        static void Main()
        {
            Menu mainMenu = new Menu("Task 1", "Task 2", "Task 3", "Task 4", "Task 5", "Exit");

            bool loop = true;
            while (loop)
            {
                switch (mainMenu.Run())
                {
                    case 1: // Task 1
                        Console.Write(" Task 1\n Enter: ");
                        Console.WriteLine($"\n Number of spaces: {SpaceCounter()}");
                        Wait();
                        break;

                    case 2: // Task 2
                        Console.Write(" Task 2\n Enter: ");
                        Console.WriteLine("\n " + (IsLucky() ? "You have a lucky ticket!" : "Lucky next time.."));
                        Wait();
                        break;

                    case 3: // Task 3
                        Console.Write(" Task 3\n Enter: ");
                        String str = Console.ReadLine();

                        UpperCase(ref str);
                        Console.WriteLine(" To Upper:" + str);
                        LowerCase(ref str);
                        Console.WriteLine(" To Lower:" + str);

                        Wait();
                        break;

                    case 4: // Task 4
                        break;

                    case 5: // Task 5
                        break;

                    case 6:
                        loop = false;
                        break;
                }
            }
            
        }
    }
}
