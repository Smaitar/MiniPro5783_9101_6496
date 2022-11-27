using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
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

        public NagtiveNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            return { "{0}", "bla bla bla bla ma sheba lach" };

        }
    }

    [Serializable]
    internal class emptyString : System.Exception
    {

        public emptyString()
        {

        }

        public emptyString(string? message) : base(message)
        {

        }

        public emptyString(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        public emptyString(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            return "bla bla bla bla ma sheba lach" ;

        }
    }
}
