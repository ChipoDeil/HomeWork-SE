using System;

namespace LeagueLeo.Domain.Exception
{
    [Serializable()]
    public class NotEnoughUnstudiedWordsToStartSprintException : System.Exception
    {
        public NotEnoughUnstudiedWordsToStartSprintException(Guid userId) 
            : base($"User with id {userId} can't start split! Add new words!")
        {
        }
        public NotEnoughUnstudiedWordsToStartSprintException()
        {
        }

        public NotEnoughUnstudiedWordsToStartSprintException(string message) : base(message)
        {
        }

        public NotEnoughUnstudiedWordsToStartSprintException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected NotEnoughUnstudiedWordsToStartSprintException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        {
        }
    }
}
