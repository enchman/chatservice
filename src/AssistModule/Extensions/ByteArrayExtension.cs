using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AssistModule.Extensions
{
    public static class ByteArrayExtension
    {
        public static void Shuffle(this byte[] source)
        {
            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(source);
            }
        }
    }
}
