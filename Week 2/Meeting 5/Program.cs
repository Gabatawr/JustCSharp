using System;
using System.Threading;

using Angar;

#region Description

/*
 * Тема: Обработка исключительных ситуаций. Перегрузка операторов.
 * Цель: Совершенствование навыков применения объектно-ориентированного подхода в программировании с использованием средств C#,
 *       создания пользовательских типов, использования средств обработки исключительных ситуаций и перегрузки операторов. 
 */

#endregion

namespace Meeting_5
{
    class Program
    {
        //static void Mix(ref Tank[] arr)
        //{
        //    Random rand = new Random();
        //    for (int i = arr.Length - 1; i >= 1; i--)
        //    {
        //        int j = rand.Next(i + 1);

        //        Tank temp = (Tank)arr[j]?.Clone();
        //        arr[j] = (Tank)arr[i]?.Clone();
        //        arr[i] = (Tank)temp?.Clone();
        //    }
        //}
        static void CursorStartLine()
        {
            int top = Console.CursorTop;

            Console.SetCursorPosition(0, top - 1);
            Console.Write("".PadRight(128, ' '));

            Console.SetCursorPosition(0, top);
            Console.Write("".PadRight(128, ' '));

            Console.SetCursorPosition(0, top - 1);
        }

        static void Main()
        {
            Console.Write(" Enter the number of teams".PadRight(40, ' ') + ": ");
            int countTeam = int.Parse(Console.ReadLine() ?? string.Empty);
            //-----------------------------------------------------------------
            Console.Write(" Enter the number of tanks in the team".PadRight(40, ' ') + ": ");
            int countTank = int.Parse(Console.ReadLine() ?? string.Empty);
            //-----------------------------------------------------------------
            int[] count = new int[countTeam];
            for (var i = 0; i < count.Length; i++) count[i] = countTank;
            //-----------------------------------------------------------------
            Console.Write((" Enter " + countTeam + " models").PadRight(40, ' ') + ": ");
            string[] arrModel = Console.ReadLine().Split(new[] { ' ', ',', ';', '.' }, StringSplitOptions.RemoveEmptyEntries);
            //-----------------------------------------------------------------
            Tank[][] array = new Tank[countTeam][];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = new Tank[countTank];
                for (int j = 0; j < countTank; j++)
                    array[i][j] = new Tank(arrModel[i]);
            }
            //-----------------------------------------------------------------

            int countMin = countTank;
            while (countTeam > 1)
            {
                Console.Write("\n\n" + (" Battle ".PadLeft(23, '-')).PadRight(39, '-'));
                for (int i = 0; i < countMin; i++)
                {
                    Tank[] winners = new Tank[countTeam];
                    int cw = 0; // Количество победителей
                    winners[cw] = (Tank)array[0][i].Clone();

                    // Боевое столкновение, сохранение списка победителей
                    for (int j = 1; j < countTeam; j++)
                    {
                        for (int k = 0; k <= cw; k++)
                        {
                            Console.Write((i == 0 && j == 1 ? "\n" : "\n\n" + "".PadLeft(39, '-') + '\n'));
                            int result = winners[k] * array[j][i]; // Бой

                            Console.Write(winners[k] + "\n" + array[j][i]);
                            Thread.Sleep(900); CursorStartLine(); Thread.Sleep(300);

                            Console.Write(winners[k] + "\n" + array[j][i]);
                            Thread.Sleep(600); CursorStartLine(); Thread.Sleep(200);

                            Console.Write(winners[k] + "\n" + array[j][i]);
                            Thread.Sleep(300); CursorStartLine(); Thread.Sleep(100);

                            if (result != 0)
                            {
                                if (result > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;   Console.Write(winners[k]);
                                                                                  Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green; Console.Write(array[j][i]);
                                    Console.ForegroundColor = ConsoleColor.White;

                                    if (cw > 0)
                                    {
                                        winners = new Tank[countTeam];
                                        cw = 0;
                                    }
                                    winners[cw] = (Tank)array[j][i].Clone();
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green; Console.Write(winners[k]);
                                                                                  Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;   Console.Write(array[j][i]);
                                    Console.ForegroundColor = ConsoleColor.White;

                                    break;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green; Console.Write(winners[k]);
                                                                              Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green; Console.Write(array[j][i]);
                                Console.ForegroundColor = ConsoleColor.White;

                                winners[++cw] = (Tank)array[j][i].Clone();
                                break;
                            }
                        }
                    }

                    // Обнуление уничтоженной техники
                    for (int j = 0; j < countTeam; j++)
                    {
                        bool check = false;
                        foreach (var winner in winners)
                        {
                            if (winner == null) break;
                            if (array[j][i].Equals(winner))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (!check) array[j][i] = null;
                    }
                }

                // Удаляем уничтоженные танки
                int countTeamTmp = countTeam;
                Tank[][] arrTmp = new Tank[countTeam][];
                for (int i = 0; i < countTeamTmp; i++)
                {
                    int countNull = 0;
                    for (int j = 0; j < array[i].Length; j++)
                        if (array[i][j] == null) countNull++;

                    if (countNull != array[i].Length)
                    {
                        arrTmp[i] = new Tank[array[i].Length - countNull];
                        for (int j = 0, k = 0; j < array[i].Length; j++)
                            if (array[i][j] != null) arrTmp[i][k++] = (Tank)array[i][j].Clone();
                    }
                    else countTeam--;
                }
                array = arrTmp;

                // Удаляем пустые команды
                arrTmp = new Tank[countTeam][];
                if (countTeamTmp != countTeam)
                {
                    for (int i = 0, k = 0; i < countTeamTmp; i++)
                    {
                        if (array[i] != null)
                        {
                            arrTmp[k] = new Tank[array[i].Length];
                            for (int j = 0; j < array[i].Length; j++)
                                arrTmp[k][j] = (Tank)array[i][j].Clone();
                            k++;
                        }
                    }
                    array = arrTmp;
                }

                // Подсчет минимального кол-ва танков в команде
                countMin = countTank;
                for (int i = 0; i < countTeam; i++)
                    if (array[i].Length < countMin) countMin = array[i].Length;

                // Вывод списка выживших
                Console.Write("\n\n\n" + (" Alive ".PadLeft(23, '-')).PadRight(39, '-') + '\n');
                for (int i = 0; i < countTeam; i++)
                {
                    for (int j = 0; j < array[i].Length; j++) Console.WriteLine(array[i][j]);
                    if (i != countTeam - 1) Console.Write("\n" + "".PadLeft(39, '-') + '\n');
                }

                Console.Write("\n\n 'Enter' to next battle..\n\n");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            }
            //-----------------------------------------------------------------
            Console.Read();
        }
    }
}
