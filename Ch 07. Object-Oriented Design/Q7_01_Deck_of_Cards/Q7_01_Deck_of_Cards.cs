using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{
    public class Q7_01_Deck_of_Cards : Question
    {
        public override void Run()
        {
			int numHands = 5;

			BlackJackGameAutomator automator = new BlackJackGameAutomator(numHands);
			automator.InitializeDeck();
			bool success = automator.DealInitial();
			if (!success)
			{
				Console.WriteLine("Error. Out of cards.");
			}
			else
			{
				Console.WriteLine("-- Initial --");
				automator.PrintHandsAndScore();
				IList<int> blackjacks = automator.GetBlackJacks();
				if (blackjacks.Count > 0)
				{
					Console.Write("Blackjack at ");
					foreach (int i in blackjacks)
					{
						Console.Write(i + ", ");
					}
					Console.WriteLine("");
				}
				else
				{
					success = automator.PlayAllHands();
					if (!success)
					{
						Console.WriteLine("Error. Out of cards.");
					}
					else
					{
						Console.WriteLine("\n-- Completed Game --");
						automator.PrintHandsAndScore();
						IList<int> winners = automator.GetWinners();
						if (winners.Count > 0)
						{
							Console.Write("Winners: ");
							foreach (int i in winners)
							{
								Console.Write(i + ", ");
							}
							Console.WriteLine("");
						}
						else
						{
							Console.WriteLine("Draw. All players have busted.");
						}
					}
				}
			}
		}
    }
}
