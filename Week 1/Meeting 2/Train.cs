using System;
using System.Threading;


namespace Meeting_2
{
    class Train
    {//-------------------------------------------------------
        private readonly string _name           = "Unknown Train";
        private readonly int    _number;

        private          double _curSpeed;
        private          double _maxSpeed       = 200;

        private          double _curFuel;
        private          double _maxFuel        = 1000;

        private          int    _carriageCount;

        private static   string _depotStation   = "Depot";
        //----------------------------------------------------
        public Train() {}
        public Train(string name, int number) : this()
        {
            _name = name;
            _number = number;
        }
        public Train(string name, int number, int carriages) : this(name, number)
        {
            _carriageCount = carriages;
        }
        //----------------------------------------------------
        public void Go(ref double fuelBarrel)
        {
            AddCarriage(1);

            var rand = new Random();
            int counter = 0;
            while (true)
            {
                if (counter % 25 == 0) AddCarriage(rand.Next(5));

                _curSpeed = _maxSpeed * (1 - ((double)_carriageCount / 150));

                if (_curSpeed <= 10)
                {
                    Console.WriteLine(" Not enough power! Train STOP!");
                    break;
                }

                Console.Write(' ' + ToString() + "; " +
                                  "carriage[" + ($"{_carriageCount}").PadLeft(3,'0') + $"]; " +
                                  "speed[" + ($"{Math.Round(_curSpeed)}").PadLeft(3, '0') + $"]; " +
                                  "fuel[" + ($"{Math.Round(_curFuel)}").PadLeft(4, '0') + $"]; \r");

                _curFuel -= (double)_carriageCount / 10;

                if (_curFuel <= 10)
                {
                    Console.Write(" Need refueling".PadRight(64,' ') + '\r');
                    Thread.Sleep(1000);

                    if (fuelBarrel <= 0)
                    {
                        Console.WriteLine(" No fuel! Train STOP!");
                        break;
                    }
                    else
                    {
                        FillUp(ref fuelBarrel);
                        Console.Write(" Filled".PadRight(64,' ') + '\r');
                        Thread.Sleep(1000);
                    }
                }
                Thread.Sleep(20);
                counter++;
            }
        }
        //----------------------------------------------------
        public void FillUp(ref double fuelBarrel)
        {
            double needFuel = _maxFuel - _curFuel;

            bool isLow = needFuel - fuelBarrel >= 0;
            if (isLow)
            {
                _curFuel += fuelBarrel;
                fuelBarrel = 0;
            }
            else
            {
                fuelBarrel -= needFuel;
                _curFuel += needFuel;
            }
        }
        //----------------------------------------------------
        public void AddCarriage(int count)
        {
            _carriageCount += count;
        }

        public void DelCarriage(int count)
        {
            if  (_carriageCount <= count) _carriageCount = 0;
            else _carriageCount -= count;
        }
        //----------------------------------------------------
        public override string ToString()
        {
            return $"Train {_name}[{_number}]";
        }
    }//-------------------------------------------------------
}
