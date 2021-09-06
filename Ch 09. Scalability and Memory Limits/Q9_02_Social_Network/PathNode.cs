using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network
{
	public class PathNode
	{
		private Person person = null;
		private PathNode previousNode = null;
		public PathNode(Person p, PathNode previous)
		{
			person = p;
			previousNode = previous;
		}

		public Person GetPerson()
		{
			return person;
		}

		public LinkedList<Person> Collapse(bool startsWithRoot)
		{
			LinkedList<Person> path = new LinkedList<Person>();
			PathNode node = this;
			while (node != null)
			{
				if (startsWithRoot)
				{
					path.AddLast(node.person);
				}
				else
				{
					path.AddFirst(node.person);
				}
				node = node.previousNode;
			}
			return path;
		}
	}
}
