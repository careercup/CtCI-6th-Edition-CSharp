using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_10_Minesweeper
{
    public class Q7_10_Minesweeper : Question
    {
        public override void Run()
        {
            Game game = new Game(7, 7, 3);
            game.Initialize();
            game.Start();
        }
    }
}
