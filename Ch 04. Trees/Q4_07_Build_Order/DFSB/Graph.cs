using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_07_Build_Order.DFSB
{
    public class Graph
    {
        private IList<Project> nodes = new List<Project>();
        private Dictionary<string, Project> map = new Dictionary<string, Project>();

        public Project GetOrCreateNode(string name)
        {
            if (!map.ContainsKey(name))
            {
                Project node = new Project(name);
                nodes.Add(node);
                map[name] = node;
            }

            return map[name];
        }

        public void AddEdge(string startName, string endName)
        {
            Project start = GetOrCreateNode(startName);
            Project end = GetOrCreateNode(endName);
            start.AddNeighbor(end);
        }

        public IList<Project> GetNodes()
        {
            return nodes;
        }
    }
}
