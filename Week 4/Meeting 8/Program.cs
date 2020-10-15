using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int size = 18;
            Player[] players = new Player[size];
            for (var i = 0; i < players.Length; i++)
                players[i] = new Player(RandomName.Boy(true));
            
            Game game = new Game(players);
            game.Play();

            Console.Read();
        }
    }
}
