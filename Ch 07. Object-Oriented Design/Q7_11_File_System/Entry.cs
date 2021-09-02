using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_11_File_System
{
	public abstract class Entry
	{
		protected Directory parent;
		protected DateTime created;
		protected DateTime lastUpdated;
		protected DateTime lastAccessed;
		protected string name;

		public Entry(string n, Directory p)
		{
			name = n;
			parent = p;
			created = DateTime.Now;
		}

		public bool Delete()
		{
			if (parent == null)
			{
				return false;
			}
			return parent.DeleteEntry(this);
		}

		public abstract int Size();

		public string GetFullPath()
		{
			if (parent == null)
			{
				return name;
			}
			else
			{
				return parent.GetFullPath() + "/" + name;
			}
		}

		public DateTime GetCreationTime()
		{
			return created;
		}

		public DateTime GetLastUpdatedTime()
		{
			return lastUpdated;
		}

		public DateTime GetLastAccessedTime()
		{
			return lastAccessed;
		}

		public void ChangeName(string n)
		{
			name = n;
		}

		public string GetName()
		{
			return name;
		}
	}
}
