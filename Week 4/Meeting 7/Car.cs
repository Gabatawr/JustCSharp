using System;

namespace Meeting_7
{
    abstract class Car : IComparable<Car>
    {//------------------------------------------------------------------------
        public static readonly Random Rand = new Random();
        //---------------------------------------------------------------------
        public string Model { get; protected set; }
        public int Speed { get; protected set; }
        public double Distance { get; protected set; }
        //---------------------------------------------------------------------
        protected readonly int _maxSpeed;
        protected readonly double _range;
        //---------------------------------------------------------------------
        protected Car(string model, int maxSpeed, double range)
        {
            Model = model;
            _maxSpeed = maxSpeed;
            _range = range;
        }
        //---------------------------------------------------------------------
        public void ReSpeed()
        {
            int oldSpeed = Speed, factor = (int)(oldSpeed * (_range / 100));

            if (Speed <= 10)
            {
                factor = _maxSpeed / 10;
                do {
                    Speed = Rand.Next(oldSpeed, oldSpeed + factor);
                } while (0 >= Speed || Speed >= _maxSpeed);
            }
            else if (Speed >= _maxSpeed - _maxSpeed / 10)
            {
                do {
                    Speed = Rand.Next(oldSpeed - factor, oldSpeed);
                } while (0 >= Speed || Speed >= _maxSpeed);
            }
            else
            {
                do {
                    Speed = Rand.Next(oldSpeed - factor, oldSpeed + factor) + oldSpeed / 15;
                } while (0 >= Speed || Speed >= _maxSpeed);
            }
        }
        //---------------------------------------------------------------------
        public void Drive(int millisecond)
        {
            double second = millisecond / 1000D;
            Distance += Speed * 1000 / 3600D * second;
        }
        //---------------------------------------------------------------------
        public bool Finish()
        {
            return Distance >= 100;
        }
        //---------------------------------------------------------------------
        public int CompareTo(Car other)
        {
            return this.Distance < other.Distance ? 1 : this.Distance > other.Distance ? -1 : 0;
        }
        //---------------------------------------------------------------------
    }
}
