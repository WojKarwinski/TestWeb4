using System.Runtime.Serialization;

namespace StripsREST.Exceptions
{
    [Serializable]
    internal class StripException : Exception
    {
        public StripException()
        {
        }

        public StripException(string? message) : base(message)
        {
        }

        public StripException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StripException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}