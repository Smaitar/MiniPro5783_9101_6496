using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    internal class NagtiveNumberException : System.Exception
    {

        public NagtiveNumberException()
        {
        }

        public NagtiveNumberException(string? message) : base(message)
        {
        }

        public NagtiveNumberException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected NagtiveNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
