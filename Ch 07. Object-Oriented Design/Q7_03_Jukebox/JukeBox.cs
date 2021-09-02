using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_03_Jukebox
{
	public class JukeBox
	{
		private CDPlayer cdPlayer;
		private User user;
		private HashSet<CD> cdCollection;
		private SongSelector ts;

		public JukeBox(CDPlayer cdPlayer, User user, HashSet<CD> cdCollection,
					   SongSelector ts)
		{
			this.cdPlayer = cdPlayer;
			this.user = user;
			this.cdCollection = cdCollection;
			this.ts = ts;
		}

		public Song GetCurrentSong() { return ts.GetCurrentSong(); }
		public void SetUser(User u) { this.user = u; }
	}
}
