using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{
	public class UserStatus
	{
		private string message;
		private UserStatusType type;
		public UserStatus(UserStatusType type, string message)
		{
			this.type = type;
			this.message = message;
		}

		public UserStatusType GetStatusType()
		{
			return type;
		}

		public string GetMessage()
		{
			return message;
		}
	}
}
