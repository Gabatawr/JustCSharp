﻿using System;
using Gab.Menu;

#region Description
/*
 * Тема: Введение в классы
 * Цель: ■ изучение особенностей создания классов;
 *       ■ изучение полей, конструкторов, статических классов;
 *       ■ приобретение практических навыков работы методами.
 */
#endregion

namespace Meeting_2
{
    class Program
    {
        static void Main()
        {
            Train train = new Train("Probivnoy", 12);
            double fuelBarrel = 10000.0;

            train.Go(ref fuelBarrel);

            Console.Read();
        }
    }
}
