using System.Collections.Generic;

namespace Chapter09
{ 
    public class Machine
    {
        public Dictionary<int, Person> People { get; set; }
        public int MachineID { get; set; }

        public Machine()
        {
            People = new Dictionary<int, Person>();    
        }
    }
}

