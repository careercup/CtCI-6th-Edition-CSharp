using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_08_Othello
{
    public class Q7_08_Othello : Question
    {
        public override void Run()
        {
            Game game = Game.GetInstance();
            game.GetBoard().Initialize();
            game.GetBoard().PrintBoard();
            Automator automator = Automator.GetInstance();
            while (!automator.IsOver() && automator.PlayRandom())
            {
            }
            automator.PrintScores();
        }
    }
}
