using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    internal class NagtiveNumberException : Exception
    {
        public NagtiveNumberException(string message) : base(message)
        { 
            Console.WriteLine(message);
        }
         
    }
    [Serializable]
    internal class EmptyString : Exception
    {
        public EmptyString(string? message) : base(message)
        {
        }
    }
    [Serializable]
    internal class NotExist : Exception
    {
        public NotExist(string? message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
    [Serializable]
    internal class AlredyExist : Exception
    {
        public AlredyExist(string? message) : base(message)
        {
            Console.WriteLine(message);
        }
    }

}
