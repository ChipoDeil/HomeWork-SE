using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    internal class Message : IMessage
    {
        public Guid MessageId { get; }

        public string Text { get; set; }

        public Guid SenderId { get; }

        public DateTimeOffset SentOn { get; }

        public Message(Guid messageId, string text, Guid senderId, DateTimeOffset sentOn) {
            MessageId = messageId;
            Text = text;
            SenderId = senderId;
            SentOn = sentOn;
        }
    }
}
