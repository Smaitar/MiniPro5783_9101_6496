using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class NotExist : Exception
    {
        public NotExist(string? message) : base(message)
        {

        }
    }

    [Serializable]
    public class AlredyExist : Exception
    {
        public AlredyExist(string? message) : base(message)
        {

        }
    }
}
