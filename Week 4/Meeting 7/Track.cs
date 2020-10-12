using System;
using System.Threading;


namespace Meeting_7
{
    class Track
    {//------------------------------------------------------------------------
        private Car[] _cars;
        //---------------------------------------------------------------------
        public Track(params Car[] cars)
        {
            _cars = cars;
            foreach (var car in _cars)
            {
                EDrive += car.Drive;
                EReSpeed += car.ReSpeed;
            }
        }
        //---------------------------------------------------------------------
        public delegate void Drive(int millisecond);
        public event Drive EDrive;
        //--------------------------------------------------------------------------------------------------------------
        public delegate void ReSpeed();
        public event ReSpeed EReSpeed;
        //---------------------------------------------------------------------
        public void Race()
        {
            Console.CursorVisible = false;
            bool loop = true;
            while (loop)
            {
                EReSpeed?.Invoke();
                EDrive?.Invoke(10);

                Info();

                foreach (var car in _cars)
                {
                    if (loop) loop = !car.Finish();
                    if (!loop)
                    {
                        Console.SetCursorPosition(30, 0);
                        Console.Write("finished!");
                        Console.Read();
                        break;
                    }
                }
            }
            Console.CursorVisible = true;
        }
        //---------------------------------------------------------------------
        public void Info()
        {
            int top = Console.CursorTop;
            if (top != 0)
            {
                for (int i = 1; i <= _cars.Length; i++)
                {
                    Console.SetCursorPosition(0, top - i);
                    Console.Write("".PadRight(128, ' '));
                }
                Console.SetCursorPosition(0, top - _cars.Length);
            }

            Array.Sort(_cars);
            for (var i = 0; i < _cars.Length; i++)
            {
                Console.WriteLine((i + 1 < 10 ? "0" : "") 
                                  + $"{i + 1}: "
                                  + _cars[i].Model.PadRight(8) 
                                  + $"\t{_cars[i].Speed}km/h\t{Math.Round(_cars[i].Distance)}km"); 
            }

            Thread.Sleep(100);
        }
    }//------------------------------------------------------------------------
}
