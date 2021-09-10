using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_04_Deadlock_Free_Class
{
    public class LockNode
    {

        private IList<LockNode> children;
        private int lockId;
        private object myLock;
        private int maxLocks;

        public LockNode(int id, int max)
        {
            lockId = id;
            children = new List<LockNode>();
            maxLocks = max;
        }

        /* Join "this" to "node", checking to make sure that it doesn't create a cycle */
        public void joinTo(LockNode node)
        {
            children.Add(node);
        }

        public void remove(LockNode node)
        {
            children.Remove(node);
        }

        /* Check for a cycle by doing a depth-first-search. */
        public bool hasCycle(Dictionary<int, bool> touchedNodes)
        {
            VisitState[] visited = new VisitState[maxLocks];
            for (int i = 0; i < maxLocks; i++)
            {
                visited[i] = VisitState.FRESH;
            }
            return hasCycle(visited, touchedNodes);
        }

        private bool hasCycle(VisitState[] visited, Dictionary<int, bool> touchedNodes)
        {
            if (touchedNodes.ContainsKey(lockId))
            {
                touchedNodes[lockId] = true;
            }

            if (visited[lockId] == VisitState.VISITING)
            {
                return true;
            }
            else if (visited[lockId] == VisitState.FRESH)
            {
                visited[lockId] = VisitState.VISITING;
                foreach (LockNode n in children)
                {
                    if (n.hasCycle(visited, touchedNodes))
                    {
                        return true;
                    }
                }
                visited[lockId] = VisitState.VISITED;
            }
            return false;
        }

        public object getLock()
        {
            if (myLock == null)
            {
                myLock = new object();
            }
            return myLock;
        }

        public int getId()
        {
            return lockId;
        }
    }
}
