using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Description
/*
 * Тема: Наследование, Интерфейсы.
 * Цель: Закрепить у слушателей практические навыки и теоретические знания для работы с классами, объектами, свойствами.
 *       Научиться создавать иерархии классов.
 */
#endregion

namespace Meeting_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team
            (   new Worker(), new Worker(), 
                new Worker(), new Worker(), 
                new TeamLeader()
            );

            House house = new House
            (
                new Plan
                (
                    new Basement(0),
                    new Walls   (1),
                    new Walls   (1),
                    new Walls   (1),
                    new Walls   (1),
                    new Door    (2),
                    new Window  (3),
                    new Window  (3),
                    new Window  (3),
                    new Window  (3),
                    new Roof    (4)
                )
            );

            house.Build(team);

            Console.Read();
        }
    }
}
