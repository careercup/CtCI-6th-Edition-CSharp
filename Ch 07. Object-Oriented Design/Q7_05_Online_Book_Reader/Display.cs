using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_05_Online_Book_Reader
{
	public class Display
	{
		private Book activeBook;
		private User activeUser;
		private int pageNumber = 0;

		public void DisplayUser(User user)
		{
			activeUser = user;
			RefreshUsername();
		}

		public void DisplayBook(Book book)
		{
			pageNumber = 0;
			activeBook = book;

			RefreshTitle();
			RefreshDetails();
			RefreshPage();
		}

		public void RefreshUsername()
		{
			/* updates username display */
		}

		public void RefreshTitle()
		{
			/* updates title display */
		}

		public void RefreshDetails()
		{
			/* updates details display */
		}

		public void RefreshPage()
		{
			/* updated page display */
		}

		public void TurnPageForward()
		{
			pageNumber++;
			RefreshPage();
		}

		public void TurnPageBackward()
		{
			pageNumber--;
			RefreshPage();
		}
	}
}
