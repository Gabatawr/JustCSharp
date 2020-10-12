using System;

#region Description
/*
 * Тема: Делегаты и события.
 * Цель: Закрепить у слушателей практические навыки и теоретические знания для работы классами и объектами, свойствами.
 *       Научиться использовать структуры и перечисления. 
 */
#endregion

namespace Meeting_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 50;
            Car[] cars = new Car[size];
            for (int i = 0; i < size; i++)
            {
                switch (Car.Rand.Next(1, 5))
                {
                    case 1:
                        cars[i] = new Roadster();
                        break;

                    case 2:
                        cars[i] = new Sedan();
                        break;

                    case 3:
                        cars[i] = new Truck();
                        break;

                    case 4:
                        cars[i] = new Bus();
                        break;
                }
                
            }
            Track track = new Track(cars);
            track.Race();

            Console.Read();
        }
    }
}
