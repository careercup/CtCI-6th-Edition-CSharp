using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_10_Minesweeper
{
    public class UserPlayResult
    {
        private bool successful;
        private GameState resultingState;
        public UserPlayResult(bool success, GameState state)
        {
            successful = success;
            resultingState = state;
        }

        public bool SuccessfulMove()
        {
            return successful;
        }

        public GameState GetResultingState()
        {
            return resultingState;
        }
    }
}
