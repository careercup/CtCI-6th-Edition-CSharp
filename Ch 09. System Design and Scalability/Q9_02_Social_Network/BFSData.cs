using System.Collections.Generic;

namespace Chapter09
{
    public class BFSData 
    {
        public Queue<PathNode> ToVisit {get; set;}
        public Dictionary<int, PathNode> Visited {get; set;}

        public BFSData(Person root) {
            ToVisit = new Queue<PathNode>();
            Visited = new Dictionary<int, PathNode>();

            PathNode sourcePath = new PathNode(root, null);
            ToVisit.Enqueue(sourcePath);
            Visited.Add(root.Id, sourcePath);	
        }
       
        public bool IsFinished() {
            return ToVisit.Count == 0;
        }
    }

}


