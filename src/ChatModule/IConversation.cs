using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileModule;

namespace ChatModule
{
    public interface IConversation
    {
        int Id { get; set; }
        IAccount User { get; set; }
        IRoom Chatroom { get; set; }
        MessageType ContentType { get; set; }
        string Content { get; set; }
        DateTime Since { get; set; }
    }
}
