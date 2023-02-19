namespace BO
{
    [Serializable]
    public class NagtiveNumberException : Exception
    {
        public NagtiveNumberException(string message) : base(message)
        {
        }
        public NagtiveNumberException(Exception innerException, string? message = "") : base(message, innerException)
        {

        }


    }

    [Serializable]
    public class EmptyStringName : Exception
    {
        public EmptyStringName(string? message) : base(message)
        {
        }
        public EmptyStringName(Exception innerException, string? message = "") : base(message, innerException)
        {

        }
    }

    public class EmptyStringAddress : Exception
    {
        public EmptyStringAddress(string? message) : base(message)
        {
        }
        public EmptyStringAddress(Exception innerException, string? message = "") : base(message, innerException)
        {

        }
    }

    public class EmptyStringEmail : Exception
    {
        public EmptyStringEmail(string? message) : base(message)
        {
        }
        public EmptyStringEmail(Exception innerException, string? message = "") : base(message, innerException)
        {

        }
    }

    [Serializable]
    public class NotExist : Exception
    {
        public NotExist(string? message) : base(message)
        {

        }

        public NotExist(Exception innerException, string? message = "") : base(message, innerException)
        {

        }
    }

    [Serializable]
    public class AlredyExist : Exception
    {
        public AlredyExist(string? message) : base(message)
        {

        }

        public AlredyExist(Exception innerException, string? message = "") : base(message, innerException)
        {

        }
    }

}
