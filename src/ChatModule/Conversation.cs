using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileModule;

namespace ChatModule
{
    public class Conversation: IConversation
    {
        public int Id { get; set; }
        public IAccount User { get; set; }
        public IRoom Chatroom { get; set; }
        public MessageType ContentType { get; set; }
        public string Content { get; set; }
        public DateTime Since { get; set; }
    }
}
