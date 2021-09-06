using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network
{
	// 步驟2: 處理百萬個使用者
	public class Machine
	{
		public Dictionary<int, Person> Persons { get; private set; } = new Dictionary<int, Person>();
		public int MachineID { get; private set; }

		public Person GetPersonWithID(int personID)
		{
			return Persons[personID];
		}
	}
}
