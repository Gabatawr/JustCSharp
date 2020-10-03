using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Angar
{
    public class Tank : ICloneable
    {//------------------------------------------------------------------------
        public         string Model    { get; }
        public         int    Ammo     { get; private set; }
        public         int    Armor    { get; private set; }
        public         int    Mobility { get; private set; }

        private static Random rand = new Random();
        //---------------------------------------------------------------------
        public Tank()
        {
            Model    = "T0";

            Ammo     = rand.Next(100 + 1);
            Armor    = rand.Next(100 + 1);
            Mobility = rand.Next(100 + 1);
        }
        public Tank(string model) : this()
        {
            Model = model.Length != 0 ? model : throw new ArgumentNullException(nameof(model));
        }
        //---------------------------------------------------------------------
        public static int operator * (Tank T1, Tank T2)
        {
            int balance = 0;

            if (T1.Ammo != T2.Ammo         &&         T1.Ammo < T2.Ammo) ++balance;
            if (T1.Ammo != T2.Ammo         &&         T1.Ammo > T2.Ammo) --balance;

            if (T1.Armor != T2.Armor       &&       T1.Armor < T2.Armor) ++balance;
            if (T1.Armor != T2.Armor       &&       T1.Armor > T2.Armor) --balance;

            if (T1.Mobility != T2.Mobility && T1.Mobility < T2.Mobility) ++balance;
            if (T1.Mobility != T2.Mobility && T1.Mobility > T2.Mobility) --balance;

            return balance;
        }
        //---------------------------------------------------------------------
        public object Clone()
        {
            return new Tank(Model) { Ammo = this.Ammo, Armor = this.Armor, Mobility = this.Mobility };
        }
        //---------------------------------------------------------------------
        public override string ToString()
        {
            return (" Ammo[" + $"{Ammo}".PadLeft(3,'_') + "]," +
                    " Armor["  + $"{Armor}".PadLeft(3, '_') + "]," +
                    " Mobility[" + $"{Mobility}".PadLeft(3, '_') + "]" +
                    " | [" + Model + "]");
        }
        //---------------------------------------------------------------------
        public bool Equals(Tank tank)
        {
            return Model    == tank.Model &&
                   Ammo     == tank.Ammo  &&
                   Armor    == tank.Armor &&
                   Mobility == tank.Mobility;
        }
    }//------------------------------------------------------------------------
}
