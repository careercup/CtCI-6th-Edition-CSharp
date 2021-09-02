using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_05_Online_Book_Reader
{
	public class Library
	{

		private Dictionary<int, Book> books;

		public Book addBook(int id, string details)
		{
			if (books.ContainsKey(id))
			{
				return null;
			}
			Book book = new Book(id, details);
			books[id]= book;
			return book;
		}

		public bool remove(Book b)
		{
			return remove(b.GetID());
		}

		public bool remove(int id)
		{
			if (!books.ContainsKey(id))
			{
				return false;
			}
			books.Remove(id);
			return true;
		}

		public Book find(int id)
		{
			return books[id];
		}
	}
}
