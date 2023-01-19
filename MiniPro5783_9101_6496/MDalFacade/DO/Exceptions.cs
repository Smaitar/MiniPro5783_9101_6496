using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    public class NotExist : Exception
    {
        public NotExist(string? message) : base(message){}

    }

    [Serializable]
    public class AlredyExist : Exception
    {
        public AlredyExist(string? message) : base(message)
        {

        }
    }
}
[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}

