using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_05_Online_Book_Reader
{
	public class Book
	{
		private int bookId;
		private string details;

		public Book(int id, string det)
		{
			bookId = id;
			details = det;
		}

		public void Update() { }

		public int GetID()
		{
			return bookId;
		}

		public void SetID(int id)
		{
			bookId = id;
		}

		public string GetDetails()
		{
			return details;
		}

		public void SetDetails(string details)
		{
			this.details = details;
		}
	}
}
