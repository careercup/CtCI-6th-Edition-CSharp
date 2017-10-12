using System.Collections.Generic;
using ctci.Library;

namespace Chapter09
{
    public class QuestionB {
        public static LinkedList<Person> MergePaths(BFSData bfs1, BFSData bfs2, int connection) {
            PathNode end1 = bfs1.Visited[connection]; // end1 -> source
            PathNode end2 = bfs2.Visited[connection]; // end2 -> dest
            LinkedList<Person> pathOne = end1.Collapse(false); // forward: source -> connection
            LinkedList<Person> pathTwo = end2.Collapse(true); // reverse: connection -> dest
            pathTwo.RemoveFirst(); // remove connection
            pathOne.AddAll(pathTwo); // add second path
            return pathOne;
        }
        
        /* Search one level and return collision, if any. */
        public static Person SearchLevel(Dictionary<int, Person> people, BFSData primary, BFSData secondary) {
            /* We only want to search one level at a time. Count how many nodes are currently in the primary's
            * level and only do that many nodes. We'll continue to add nodes to the end. */
            int count = primary.ToVisit.Count; 
            for (int i = 0; i < count; i++) {
                /* Pull out first node. */
                PathNode pathNode = primary.ToVisit.Dequeue();
                int personId = pathNode.Person.Id;
                
                /* Check if it's already been visited. */
                if (secondary.Visited.ContainsKey(personId)) {
                    return pathNode.Person;
                }				
                
                /* Add friends to queue. */
                Person person = pathNode.Person;
                List<int> friends = person.GetFriends();
                foreach (int friendId in friends) {
                    if (!primary.Visited.ContainsKey(friendId)) {
                        Person friend = people[friendId];
                        PathNode next = new PathNode(friend, pathNode);
                        primary.Visited.Add(friendId, next);
                        primary.ToVisit.Enqueue(next);
                    }
                }
            }
            return null;
        }
        public static LinkedList<Person> FindPathBiBFS(Dictionary<int, Person> people, int source, int destination) {
            BFSData sourceData = new BFSData(people[source]);
            BFSData destData = new BFSData(people[destination]);
            
            while (!sourceData.IsFinished() && !destData.IsFinished()) {
                /* Search out from source. */
                Person collision = SearchLevel(people, sourceData, destData);
                if (collision != null) {
                    return MergePaths(sourceData, destData, collision.Id);
                }
                
                /* Search out from destination. */
                collision = SearchLevel(people, destData, sourceData);
                if (collision != null) {
                    return MergePaths(sourceData, destData, collision.Id);
                }
            }
            return null;
        }	
    }
}

