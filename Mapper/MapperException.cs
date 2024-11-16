namespace Mapper
{
    public class MapperException : Exception
    {
        public MapperException()
        {
        }

        public MapperException(string details)
            : base(details)
        {
        }

        public MapperException(string details, Exception innerException)
            : base(details, innerException)
        {
        }
    }
}