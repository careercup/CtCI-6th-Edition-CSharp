using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_08_Othello
{
    /* A helper class to automate this game. This is just used for testing purposes. */
    public class Automator
    {
        private Player[] players;
        private Player lastPlayer = null;
        public IList<Location> remainingMoves = new List<Location>();
        private static Automator instance;

        private Automator()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Location loc = new Location(i, j);
                    remainingMoves.Add(loc);
                }
            }
        }

        public static Automator GetInstance()
        {
            if (instance == null)
            {
                instance = new Automator();
            }
            return instance;
        }

        public void Initialize(Player[] ps)
        {
            players = ps;
            lastPlayer = players[1];
        }

        public void Shuffle()
        {
            for (int i = 0; i < remainingMoves.Count; i++)
            {
                int t = AssortedMethods.RandomIntInRange(i, remainingMoves.Count - 1);
                Location other = remainingMoves[t];
                Location current = remainingMoves[i];
                remainingMoves[t] = current;
                remainingMoves[i] = other;
            }
        }

        public void RemoveLocation(int r, int c)
        {
            for (int i = 0; i < remainingMoves.Count; i++)
            {
                Location loc = remainingMoves[i];
                if (loc.IsSameAs(r, c))
                {
                    remainingMoves.RemoveAt(i);
                }
            }
        }

        public Location GetLocation(int index)
        {
            return remainingMoves[index];
        }

        public bool PlayRandom()
        {
            Board board = Game.GetInstance().GetBoard();
            Shuffle();
            lastPlayer = lastPlayer == players[0] ? players[1] : players[0];
            string color = lastPlayer.GetColor().ToString();
            for (int i = 0; i < remainingMoves.Count; i++)
            {
                Location loc = remainingMoves[i];
                bool success = lastPlayer.PlayPiece(loc.GetRow(), loc.GetColumn());

                if (success)
                {
                    Console.WriteLine("Success: " + color + " move at (" + loc.GetRow() + ", " + loc.GetColumn() + ")");
                    board.PrintBoard();
                    PrintScores();
                    return true;
                }
            }
            Console.WriteLine("Game over. No moves found for " + color);
            return false;
        }

        public bool IsOver()
        {
            if (players[0].GetScore() == 0 || players[1].GetScore() == 0)
            {
                return true;
            }
            return false;
        }

        public void PrintScores()
        {
            Console.WriteLine("Score: " + players[0].GetColor().ToString() + ": " + players[0].GetScore() + ", " + players[1].GetColor().ToString() + ": " + players[1].GetScore());
        }
    }
}
