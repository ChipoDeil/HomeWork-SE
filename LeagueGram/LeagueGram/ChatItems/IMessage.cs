using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueGram
{
    public interface IMessage
    {

        Guid MessageId { get; }
        string Text { get; set; }
        Guid SenderId { get; }
        DateTimeOffset SentOn { get; }

    }
}
