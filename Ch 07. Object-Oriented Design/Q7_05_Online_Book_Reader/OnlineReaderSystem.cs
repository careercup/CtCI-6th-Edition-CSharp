using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_05_Online_Book_Reader
{
	public class OnlineReaderSystem
	{
		private Library library;
		private UserManager userManager;
		private Display display;

		private Book activeBook;
		private User activeUser;

		public OnlineReaderSystem()
		{
			userManager = new UserManager();
			library = new Library();
			display = new Display();
		}

		public Library getLibrary()
		{
			return library;
		}

		public UserManager getUserManager()
		{
			return userManager;
		}

		public Display getDisplay()
		{
			return display;
		}

		public Book getActiveBook()
		{
			return activeBook;
		}

		public void setActiveBook(Book book)
		{
			display.DisplayBook(book);
			activeBook = book;
		}

		public User getActiveUser()
		{
			return activeUser;
		}

		public void setActiveUser(User user)
		{
			activeUser = user;
			display.DisplayUser(user);
		}
	}
}
