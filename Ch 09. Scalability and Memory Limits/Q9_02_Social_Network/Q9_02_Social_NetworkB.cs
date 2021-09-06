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
	public class Q9_02_Social_NetworkB : Question
    {
		public static LinkedList<Person> FindPathBiBFS(Dictionary<int, Person> people, int source, int destination)
		{
			BFSData sourceData = new BFSData(people[source]);
			BFSData destData = new BFSData(people[destination]);

			while (!sourceData.IsFinished() && !destData.IsFinished())
			{
				/* Search out from source. */
				Person collision = SearchLevel(people, sourceData, destData);
				if (collision != null)
				{
					return MergePaths(sourceData, destData, collision.GetID());
				}

				/* Search out from destination. */
				collision = SearchLevel(people, destData, sourceData);
				if (collision != null)
				{
					return MergePaths(sourceData, destData, collision.GetID());
				}
			}
			return null;
		}

		/* Search one level and return collision, if any. */
		public static Person SearchLevel(Dictionary<int, Person> people, BFSData primary, BFSData secondary)
		{
			/* We only want to search one level at a time. Count how many nodes are currently in the primary's
			 * level and only do that many nodes. We'll continue to add nodes to the end. */
			int count = primary.ToVisit.Count;
			for (int i = 0; i < count; i++)
			{
				/* Pull out first node. */
				PathNode pathNode = primary.ToVisit.Dequeue();
				int personId = pathNode.GetPerson().GetID();

				/* Check if it's already been visited. */
				if (secondary.Visited.ContainsKey(personId))
				{
					return pathNode.GetPerson();
				}

				/* Add friends to queue. */
				Person person = pathNode.GetPerson();
				IList<int> friends = person.GetFriends();
				foreach (int friendId in friends)
				{
					if (!primary.Visited.ContainsKey(friendId))
					{
						Person friend = people[friendId];
						PathNode next = new PathNode(friend, pathNode);
						primary.Visited[friendId]=next;
						primary.ToVisit.Enqueue(next);
					}
				}
			}
			return null;
		}

		public static LinkedList<Person> MergePaths(BFSData bfs1, BFSData bfs2, int connection)
		{
			PathNode end1 = bfs1.Visited[connection]; // end1 -> source
			PathNode end2 = bfs2.Visited[connection]; // end2 -> dest
			LinkedList<Person> pathOne = end1.Collapse(false); // forward: source -> connection
			LinkedList<Person> pathTwo = end2.Collapse(true); // reverse: connection -> dest
			pathTwo.RemoveFirst(); // remove connection
             // add second path
            foreach (var path in pathTwo)
            {
				pathOne.AddLast(path);

			}
			return pathOne;
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

			int[][] edges = new int[][]{ 
				new int[]{ 1, 4 },
				new int[]{ 1, 2 },
				new int[]{ 1, 3 },
				new int[]{ 3, 2 },
				new int[]{ 4, 6 },
				new int[]{ 3, 7 },
				new int[]{ 6, 9 },
				new int[]{ 9, 10 },
				new int[]{ 5, 10 },
				new int[]{ 2, 5 },
				new int[]{ 3, 7 } 
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
			LinkedList<Person> path1 = FindPathBiBFS(people, i, j);
			Q9_02_Social_Network_Tester.PrintPeople(path1);
		}
    }
}
