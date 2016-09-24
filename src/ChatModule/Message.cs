using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileModule;

namespace ChatModule
{
    public class MessageBase : IMessage
    {
        public int Id { get; set; }
        public IAccount Sender { get; set; }
        public IAccount Receiver { get; set; }
        public MessageType ContentType { get; set; }
        public string Content { get; set; }
        public DateTime Since { get; set; }
    }
}
