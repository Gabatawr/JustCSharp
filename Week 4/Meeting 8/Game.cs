using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_8
{
    
    class Game
    {
        private Player[] _players;
        private Queue<Card> _cardDeck;
        public Game(params Player[] players)
        {
            _players = players.Length < 2 ? new[] {players[0], new Player()} : players;

            Card[] defCardDeck = new Card[36];
            for (var i = 0; i < _cardDeck.Count; i++)
            {
                for (var suit = 0; suit < 4; suit++)
                {
                    for (var value = 0; value < 9; value++)
                    {

                    }
                }
            }
            

        }
    }
}
