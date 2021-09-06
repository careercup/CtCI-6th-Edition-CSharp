using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network
{
	// 步驟2: 處理百萬個使用者
	public class Server
	{
		Dictionary<int, Machine> machines = new Dictionary<int, Machine>();
		Dictionary<int, int> personToMachineMap = new Dictionary<int, int>();

		public Machine GetMachineWithId(int machineID)
		{
			return machines.ContainsKey(machineID) ? machines[machineID] : null;
		}

		public int GetMachineIDForUser(int personID)
		{
			int machineID = personToMachineMap.ContainsKey(personID) ? personToMachineMap[personID] : -1;
			return machineID;
		}

		public Person GetPersonWithID(int personID)
		{
			int machineID = personToMachineMap.ContainsKey(personID) ? personToMachineMap[personID] : -1;
			if (machineID == -1)
			{
				return null;
			}
			Machine machine = GetMachineWithId(machineID);
			if (machine == null)
			{
				return null;
			}
			return machine.GetPersonWithID(personID);
		}
	}
}
