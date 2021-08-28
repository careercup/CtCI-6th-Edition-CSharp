using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_07_Build_Order.EdgeRemovalA
{
	public class Project
	{
		private IList<Project> children = new List<Project>();
		private Dictionary<string, Project> map = new Dictionary<string, Project>();
		private string name;
		private int dependencies = 0;

		public Project(string n)
		{
			name = n;
		}

		public string GetName()
		{
			return name;
		}

		public void AddNeighbor(Project node)
		{
			if (!map.ContainsKey(node.GetName()))
			{
				children.Add(node);
				map[node.GetName()]=node;
				node.IncrementDependencies();
			}
		}

		public void IncrementDependencies()
		{
			dependencies++;
		}

		public IList<Project> GetChildren()
		{
			return children;
		}

		public void DecrementDependencies()
		{
			dependencies--;
		}

		public int GetNumberDependencies()
		{
			return dependencies;
		}
	}
}
