using System.Collections.Generic;

namespace Chapter09
{
    public class Server
    {
        Dictionary<int, Machine> _machines = new Dictionary<int, Machine>();
        Dictionary<int, int> _personToMachineMap = new Dictionary<int, int>();

        public Machine GetMachineWithId(int machineId)
        {
            if (_machines.ContainsKey(machineId)) 
                return _machines[machineId];

            return null;
        }

        public int GetMachineIdForUser(int personId)
        {
            if (_personToMachineMap.ContainsKey(personId))
                return _personToMachineMap[personId];
            
            return -1;
        }

        public Person GetPersonWithId(int personId)
        {
            var machineId = GetMachineIdForUser(personId);
            if (machineId == -1)
                return null;

            Machine machine = GetMachineWithId(machineId);
            if (machine == null)
                return null;
    
            return machine.People[personId];
        }
    }
}
