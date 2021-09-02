using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_03_Jukebox
{
	public class Playlist
	{
		private Song song;
		private Queue<Song> queue;
		public Playlist(Song song, Queue<Song> queue)
		{
			this.song = song;
			this.queue = queue;
		}

		public Song GetNextSongToPlay() { return queue.Peek(); }
		public void QueueUpSong(Song s) { queue.Enqueue(s); }
	}
}
