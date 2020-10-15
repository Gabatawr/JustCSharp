using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_8
{
    class Player
    {//------------------------------------------------------------------------
        public string Name { get; }
        public CardDeck CardDeck;
        //---------------------------------------------------------------------
        public Player(string name)
        {
            Name = name;
            CardDeck = new CardDeck();
        }
        //---------------------------------------------------------------------

    }//------------------------------------------------------------------------
}
