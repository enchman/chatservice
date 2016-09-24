using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistModule;

namespace ChatService.Models
{
    public class Token
    {
        public const int TokenSize = 32;
        public byte[] Value { get; private set; }

        private Token()
        {
            Renew();
        }
        private Token(byte[] token)
        {
            if (token.Length != TokenSize)
                throw new ArgumentOutOfRangeException("Token must be "+ TokenSize + " length");

            Value = token;
        }

        public Token Create()
        {
            return new Token();
        }

        public void Renew()
        {
            Value = Assistant.RandomBytes(TokenSize);
        }

        public bool Equals(byte[] token)
        {
            return Value.SequenceEqual(token);
        }
    }
}
