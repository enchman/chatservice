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

        public static bool VerifyToken(this byte[] source, byte[] compare)
        {
            HMACMD5 md5 = new HMACMD5(KeyContext.SemiKey);
            byte[] token = md5.ComputeHash(source);
            return source.SequenceEqual(compare);
        }
    }
}
