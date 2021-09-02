using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_02_Call_Center
{
	/* Represents a call from a user. Calls have a minimum rank and are assigned to the
	 * first employee who can handle that call.
	 */
	public class Call
	{
		/* Minimal rank of employee who can handle this call. */
		private Rank rank;

		/* Person who is calling. */
		private Caller caller;

		/* Employee who is handling call. */
		private Employee handler;

		public Call(Caller c)
		{
			rank = Rank.Responder;
			caller = c;
		}

		/* Set employee who is handling call. */
		public void setHandler(Employee e)
		{
			handler = e;
		}

		/* Play recorded message to the customer. */
		public void reply(string message)
		{
			Console.WriteLine(message);
		}

		public Rank getRank()
		{
			return rank;
		}

		public void setRank(Rank r)
		{
			rank = r;
		}

		public Rank incrementRank()
		{
			if (rank == Rank.Responder)
			{
				rank = Rank.Manager;
			}
			else if (rank == Rank.Manager)
			{
				rank = Rank.Director;
			}
			return rank;
		}

		/* Disconnect call. */
		public void disconnect()
		{
			reply("Thank you for calling");
		}
	}
}
