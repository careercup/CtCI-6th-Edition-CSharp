using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_03_Jukebox
{
	public class CDPlayer
	{
		private Playlist p;
		private CD c;

		public CDPlayer(Playlist p) { this.p = p; }
		public CDPlayer(CD c, Playlist p)
		{
			this.p = p;
			this.c = c;
		}

		public CDPlayer(CD c) { this.c = c; }

		public Playlist GetPlaylist() { return p; }
		public void SetPlaylist(Playlist p) { this.p = p; }
		public CD GetCD() { return c; }
		public void SetCD(CD c) { this.c = c; }

		
		public void PlaySong(Song s) { }
	}
}
