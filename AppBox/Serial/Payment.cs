using System;
using System.Runtime.Serialization;


namespace Serial
{
    [Serializable]
    class Payment : ISerializable
    {
        //---------------------------------------------------------------------
        public static bool SumSaver  { get; set; } = false;
        //---------------------------------------------------------------------
        private double _payment      { get; set; }
        private int    _days         { get; set; }
        private double _penaltyOnDay { get; set; }
        private int    _penaltyDays  { get; set; }

        private double _sumNoPenalty { get; set; }
        private double _sumPenalty   { get; set; }
        private double _sumTotal     { get; set; }
        //---------------------------------------------------------------------
        private void _SumCalc()
        {
            _sumNoPenalty = _payment      * _days;
            _sumPenalty   = _penaltyOnDay * _penaltyDays;
            _sumTotal     = _sumNoPenalty + _sumPenalty;
        }
        //---------------------------------------------------------------------
        public Payment(double payment, int days, double penaltyOnDay, int penaltyDays = 0)
        {
            _payment      = payment;
            _days         = days;
            _penaltyOnDay = penaltyOnDay;
            _penaltyDays  = penaltyDays;

            _SumCalc();
        }
        //---------------------------------------------------------------------
        Payment(SerializationInfo info, StreamingContext context)
        {
            bool oldSumSaver = info.GetBoolean(nameof(SumSaver));

            _payment      = info.GetDouble(nameof(_payment)     );
            _days         = info.GetInt32 (nameof(_days)        );
            _penaltyOnDay = info.GetDouble(nameof(_penaltyOnDay));
            _penaltyDays  = info.GetInt32 (nameof(_penaltyDays) );

            if (oldSumSaver)
            {
                _sumNoPenalty = info.GetDouble(nameof(_sumNoPenalty));
                _sumPenalty = info.GetDouble(nameof(_sumPenalty));
                _sumTotal = info.GetDouble(nameof(_sumTotal));
            } 
            else _SumCalc();
        }
        //---------------------------------------------------------------------
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(SumSaver), SumSaver);

            info.AddValue(nameof(_payment)     , _payment     );
            info.AddValue(nameof(_days)        , _days        );
            info.AddValue(nameof(_penaltyOnDay), _penaltyOnDay);
            info.AddValue(nameof(_penaltyDays) , _penaltyDays );

            if (SumSaver)
            {
                info.AddValue(nameof(_sumNoPenalty), _sumNoPenalty);
                info.AddValue(nameof(_sumPenalty), _sumPenalty);
                info.AddValue(nameof(_sumTotal), _sumTotal);
            }
        }
        //---------------------------------------------------------------------
        public override string ToString()
        {
            return $" Payment        : { _payment      }\n" +
                   $" Days           : { _days         }\n" +
                   $" Penalty on day : { _penaltyOnDay }\n" +
                   $" Penalty days   : { _penaltyDays  }\n" +
                   $" Sum no penalty : { _sumNoPenalty }\n" +
                   $" Sum penalty    : { _sumPenalty   }\n" +
                   $" Sum total      : { _sumTotal     }";
        }

        //---------------------------------------------------------------------
    }
}
