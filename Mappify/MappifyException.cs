namespace Mappify
{
    public class MappifyException : Exception
    {
        public MappifyException()
        {
        }

        public MappifyException(string details)
            : base(details)
        {
        }

        public MappifyException(string details, Exception innerException)
            : base(details, innerException)
        {
        }
    }
}