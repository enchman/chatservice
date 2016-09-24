using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileModule;

namespace ChatModule
{
    public interface IMessage
    {
        int Id { get; set; }
        IAccount Sender { get; set; }
        IAccount Receiver { get; set; }
        MessageType ContentType { get; set; }
        string Content { get; set; }
        DateTime Since { get; }
    }
}
