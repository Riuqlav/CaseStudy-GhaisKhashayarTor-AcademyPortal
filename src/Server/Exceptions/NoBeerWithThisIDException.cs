using System.Runtime.Serialization;

namespace CaseStudy.Server.Exceptions
{
    [Serializable]
    internal class NoBeerWithThisIDException : Exception
    {
        private long id;

        public NoBeerWithThisIDException()
        {
        }

        public NoBeerWithThisIDException(long id)
        {
            this.id = id;
        }

        public NoBeerWithThisIDException(string? message) : base(message)
        {
        }

        public NoBeerWithThisIDException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoBeerWithThisIDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}