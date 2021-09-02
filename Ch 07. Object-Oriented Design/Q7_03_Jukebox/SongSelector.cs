using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_03_Jukebox
{
	public class SongSelector
	{
		private Song currentSong;
		public SongSelector(Song s) { currentSong = s; }
		public void SetSong(Song s) { currentSong = s; }
		public Song GetCurrentSong() { return currentSong; }
	}
}
