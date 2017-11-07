using System;

namespace LeagueLeo.Domain.Exception
{
    [Serializable()]
    class UserAlreadyExistsException : System.Exception
    {
        public UserAlreadyExistsException(Guid userId) 
            : base($"User with id {userId} already exists")
        {
        }
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string message) : base(message)
        {
        }

        public UserAlreadyExistsException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected UserAlreadyExistsException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        {
        }
    }
}
