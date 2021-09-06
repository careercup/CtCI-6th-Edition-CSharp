using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network
{
	// 步驟1: 簡化問題 - 忽略數百萬使用者
	// BFS: O(k^q)
	// 雙向 BFS:O(k^q/2+k^q/2) = O(k^q/2) (較快)
	// k: 朋友數
	// q: 長度
	public class Q9_02_Social_NetworkA : Question
    {
		public static LinkedList<Person> FindPathBFS(Dictionary<int, Person> people, int source, int destination)
		{
			Queue<PathNode> toVisit = new Queue<PathNode>();
			HashSet<int> visited = new HashSet<int>();
			toVisit.Enqueue(new PathNode(people[source], null));
			visited.Add(source);
			while (toVisit.Count>0)
			{
				PathNode node = toVisit.Dequeue();
				Person person = node.GetPerson();
				if (person.GetID() == destination)
				{
					return node.Collapse(false);
				}

				/* Search friends. */
				IList<int> friends = person.GetFriends();
				foreach (int friendId in friends)
				{
					if (!visited.Contains(friendId))
					{
						visited.Add(friendId);
						Person friend = people[friendId];
						toVisit.Enqueue(new PathNode(friend, node));
					}
				}
			}
			return null;
		}

		public override void Run()
        {
			int nPeople = 11;
			Dictionary<int, Person> people = new Dictionary<int, Person>();
			for (int c = 0; c < nPeople; c++)
			{
				Person p = new Person(c);
				people[c]= p;
			}

			int[][] edges = { 
				new int[] { 1, 4 },
				new int[] { 1, 2 },
				new int[] { 1, 3 },
				new int[] { 3, 2 },
				new int[] { 4, 6 },
				new int[] { 3, 7 },
				new int[] { 6, 9 },
				new int[] { 9, 10 },
				new int[] { 5, 10 },
				new int[] { 2, 5 },
				new int[] { 3, 7 } 
			};

			foreach (int[] edge in edges)
			{
				Person source = people[edge[0]];
				source.AddFriend(edge[1]);

				Person destination = people[edge[1]];
				destination.AddFriend(edge[0]);
			}

			int i = 1;
			int j = 10;
			LinkedList<Person> path1 = FindPathBFS(people, i, j);
			Q9_02_Social_Network_Tester.PrintPeople(path1);
		}
    }
}
