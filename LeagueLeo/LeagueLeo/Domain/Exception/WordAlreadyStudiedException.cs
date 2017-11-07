using System;

namespace LeagueLeo.Domain.Exception
{
    [Serializable()]
    public class WordAlreadyStudiedException : System.Exception
    {
        public WordAlreadyStudiedException(Guid wordId) : base($"Word with id {wordId} already studied")
        {
        }
        public WordAlreadyStudiedException()
        {
        }

        public WordAlreadyStudiedException(string message) : base(message)
        {
        }

        public WordAlreadyStudiedException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected WordAlreadyStudiedException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        {
        }
    }
}
