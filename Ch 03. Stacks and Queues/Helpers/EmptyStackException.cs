using System;
using System.Runtime.Serialization;

namespace Ch_03._Stacks_and_Queues.Helpers
{
    [Serializable]
    internal class EmptyStackException : Exception
    {
        public EmptyStackException()
        {
        }

        public EmptyStackException(string message) : base(message)
        {
        }

        public EmptyStackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyStackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}