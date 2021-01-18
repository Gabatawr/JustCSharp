using System;
using System.Collections.Generic;

namespace H6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do {
                Console.Write("\n N: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (1 > n || 1_000_000_000 < n);


            List<List<int>> arrM = new();
            arrM.Add(new List<int>() { 1 });

            for (int i = 2; i <= n; i++)
            {
                for (int j = 0; j <= arrM.Count; j++)
                {
                    bool isAdd = false;
                    for (int k = 0; k <= arrM[j].Count; k++)
                    {
                        if (i % arrM[j][k] == 0) 
                            break;

                        if (k == arrM[j].Count - 1)
                        {
                            isAdd = true;
                            arrM[j].Add(i);
                            break;
                        }
                    }

                    if (isAdd == false && j == arrM.Count - 1)
                    {
                        arrM.Add(new List<int>() { i });
                        break;
                    }
                    else if (isAdd) break;
                }
            }

            for (int j = 0; j < arrM.Count; j++)
            {
                Console.Write("\n" + (j + 1) + ": ");
                Console.Write(string.Join(", ", arrM[j]));
            }

            Console.ReadKey();
        }
    }
}
