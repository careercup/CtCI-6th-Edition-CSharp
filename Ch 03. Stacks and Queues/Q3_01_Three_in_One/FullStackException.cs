using System;
using System.Collections.Generic;
using System.Text;

namespace Ch_03._Stacks_and_Queues.Q3_01_Three_in_One
{
    public class FullStackException : Exception
    {

        private readonly static long serialVersionUID = 1L;

        public FullStackException()
        {
        }

        public FullStackException(string message) : base(message)
        {
        }
    }
}
