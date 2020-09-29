using System;


namespace Meeting_2
{
    class Train
    {//-------------------------------------------------------
        private string _name;
        private int    _number;

        private double _curSpeed;
        private double _maxSpeed;

        private double _curFuel;
        private double _maxFuel;

        private int    _carriages;

        private string _firstStation;
        private int    _countStation;
        private string _lastStation;

        private static string DepoStation;
        private static string ;
        //----------------------------------------------------
        public void Go()
        {

        }

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

        public void AddCarriage(int num)
        {
            _carriages += num;
        }

        public void DelCarriage(int num)
        {
            if  (_carriages <= num) _carriages = 0;
            else _carriages -= num;
        }
    }//-------------------------------------------------------
}
