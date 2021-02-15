using System.Collections.Generic;

namespace Chapter09
{
    public class QuestionA 
    {
        public static LinkedList<Person> FindPathBFS(Dictionary<int, Person> people, int source, int destination) {
            Queue<PathNode> toVisit = new Queue<PathNode>();
            HashSet<int> visited = new HashSet<int>();
            toVisit.Enqueue(new PathNode(people[source], null));
            visited.Add(source);
            while (toVisit.Count > 0) {
                PathNode node = toVisit.Dequeue();
                Person person = node.Person;
                if (person.Id == destination) {
                    return node.Collapse(false);
                }
                
                /* Search friends. */
                List<int> friends = person.GetFriends();
                foreach (int friendId in friends) {
                    if (!visited.Contains(friendId)) {
                        visited.Add(friendId);
                        Person friend = people[friendId];
                        toVisit.Enqueue(new PathNode(friend, node));
                    }
                }
            }
            return null;
        }
    }
}

