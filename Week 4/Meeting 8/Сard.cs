using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_8
{
    class Card : IComparable<Card>
    {//------------------------------------------------------------------------
        public readonly struct CardValue
        {//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            internal char Sign  { get; }
            internal int Weight { get; }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            internal CardValue(int value)
            {
                Weight = value;
                switch (value)
                {
                    case 06: Sign = '6'; break;
                    case 07: Sign = '7'; break;
                    case 08: Sign = '8'; break;
                    case 09: Sign = '9'; break;
                    case 10: Sign = '⑩'; break; //❿⑩
                    case 11: Sign = 'J'; break;
                    case 12: Sign = 'Q'; break;
                    case 13: Sign = 'K'; break;
                    case 14: Sign = 'T'; break;
                    default: Sign = ' '; break;
                }
            }
        }//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //---------------------------------------------------------------------
        public char Suit { get; private set; }
        public CardValue Value { get; private set; }
        //---------------------------------------------------------------------
        public Card(int suit, int value)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            if (0 > suit || suit > 3) suit = rand.Next(4);
            switch (suit)
            {
                case 0: Suit = '♠'; break;
                case 1: Suit = '♥'; break;
                case 2: Suit = '♣'; break;
                case 3: Suit = '♦'; break;
            }

            if (6 > value || value > 14) value = rand.Next(6, 15);
            Value = new CardValue(value);
        }
        //---------------------------------------------------------------------
        public int CompareTo(Card card)
        {
            return this.Value.Weight < card.Value.Weight ? -1 : 
                   this.Value.Weight > card.Value.Weight ?  1 : 0;
        }
        //---------------------------------------------------------------------
        public void Print(int between)
        {
            int left = Console.CursorLeft, top = Console.CursorTop, i = 0;
            void PrintLine(string text, int count = 1)
            {
                Console.SetCursorPosition(left, top + i++);
                Console.Write(text);
            }

            PrintLine( "┏━━━━━━━━━┓");
            PrintLine($"┃ {Suit}{Value.Sign}".PadRight(10) + '┃');
            PrintLine( '┃' + "".PadLeft(9) + '┃', 2);
            PrintLine( "┃".PadRight(5) + Suit + "┃".PadLeft(5));
            PrintLine( '┃' + "".PadLeft(9) + '┃', 2);
            PrintLine( "┃".PadRight(7) + $"{Suit}{Value.Sign} ┃");
            PrintLine( "┗━━━━━━━━━┛");

            Console.SetCursorPosition(left + 11 + between - 11, top);
        }
    }//------------------------------------------------------------------------
}
