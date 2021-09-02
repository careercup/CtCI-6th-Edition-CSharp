using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{

	public class Message
	{
		private string content;
		private DateTime date;
		public Message(string content, DateTime date)
		{
			this.content = content;
			this.date = date;
		}

		public string GetContent()
		{
			return content;
		}

		public DateTime GetDate()
		{
			return date;
		}
	}
}
