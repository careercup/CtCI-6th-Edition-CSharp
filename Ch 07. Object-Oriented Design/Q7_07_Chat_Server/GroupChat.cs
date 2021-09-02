using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_07_Chat_Server
{
    public class GroupChat : Conversation
    {
        public void RemoveParticipant(User user)
        {
            participants.Remove(user);
        }

        public void AddParticipant(User user)
        {
            participants.Add(user);
        }
    }
}
