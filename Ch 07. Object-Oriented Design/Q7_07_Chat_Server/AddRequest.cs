using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{
	public class AddRequest
	{
		private User fromUser;
		private User toUser;
		private DateTime date;
		public RequestStatus status { get; set; }

		public AddRequest(User from, User to, DateTime date)
		{
			fromUser = from;
			toUser = to;
			this.date = date;
			status = RequestStatus.Unread;
		}

		public RequestStatus GetStatus()
		{
			return status;
		}

		public User GetFromUser()
		{
			return fromUser;
		}

		public User getToUser()
		{
			return toUser;
		}

		public DateTime getDate()
		{
			return date;
		}
	}
}
