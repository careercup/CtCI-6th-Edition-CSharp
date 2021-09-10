using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_04_Deadlock_Free_Class
{
	public class LockFactory
	{
		private static LockFactory instance;

		private int numberOfLocks = 5; /* default */
		private LockNode[] locks;

		/* Maps from a process or owner to the order that the owner claimed it would call the locks in */
		private Dictionary<int, LinkedList<LockNode>> lockOrder;

		private LockFactory(int count)
		{
			numberOfLocks = count;
			locks = new LockNode[numberOfLocks];
			lockOrder = new Dictionary<int, LinkedList<LockNode>>();
			for (int i = 0; i < numberOfLocks; i++)
			{
				locks[i] = new LockNode(i, count);
			}
		}

		public static LockFactory getInstance()
		{
			return instance;
		}

		public static LockFactory initialize(int count)
		{
			if (instance == null)
			{
				instance = new LockFactory(count);
			}
			return instance;
		}

		public bool hasCycle(Dictionary<int, bool> touchedNodes, int[] resourcesInOrder)
		{
			/* check for a cycle */
			foreach (int resource in resourcesInOrder)
			{
				if (touchedNodes[resource] == false)
				{
					LockNode n = locks[resource];
					if (n.hasCycle(touchedNodes))
					{
						return true;
					}
				}
			}
			return false;
		}

		/* To prevent deadlocks, force the processes to declare upfront what order they will
		 * need the locks in. Verify that this order does not create a deadlock (a cycle in a directed graph)
		 */
		public bool declare(int ownerId, int[] resourcesInOrder)
		{
			Dictionary<int, bool> touchedNodes = new Dictionary<int, bool>();

			/* add nodes to graph */
			int index = 1;
			touchedNodes[resourcesInOrder[0]] = false;
			for (index = 1; index < resourcesInOrder.Length; index++)
			{
				LockNode prev = locks[resourcesInOrder[index - 1]];
				LockNode curr = locks[resourcesInOrder[index]];
				prev.joinTo(curr);
				touchedNodes[resourcesInOrder[index]] = false;
			}

			/* if we created a cycle, destroy this resource list and return false */
			if (hasCycle(touchedNodes, resourcesInOrder))
			{
				for (int j = 1; j < resourcesInOrder.Length; j++)
				{
					LockNode p = locks[resourcesInOrder[j - 1]];
					LockNode c = locks[resourcesInOrder[j]];
					p.remove(c);
				}
				return false;
			}

			/* No cycles detected. Save the order that was declared, so that we can verify that the
			 * process is really calling the locks in the order it said it would. */
			LinkedList<LockNode> list = new LinkedList<LockNode>();
			for (int i = 0; i < resourcesInOrder.Length; i++)
			{
				LockNode resource = locks[resourcesInOrder[i]];
				list.AddLast(resource);
			}
			lockOrder[ownerId]=list;

			return true;
		}

		/* Get the lock, verifying first that the process is really calling the locks in the order
		 * it said it would. */
		public object getLock(int ownerId, int resourceID)
		{
			LinkedList<LockNode> list = lockOrder.ContainsKey(ownerId) ? lockOrder[ownerId] : null;
			if (list == null)
			{
				return null;
			}

			LockNode head = list.First();
			if (head.getId() == resourceID)
			{
				list.RemoveFirst();
				return head.getLock();
			}
			return null;
		}
	}
}
