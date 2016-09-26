using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AssistModule
{
    public class Assistant
    {
        private static Random rand = new Random();
        private static int tokenSize = 32;

        public static Random Random
        {
            get { return rand; }
        }
        public static int TokenSize
        {
            get { return tokenSize; }
        }

        public static byte[] RandomBytes(int length)
        {
            byte[] raw = new byte[length];
            Random.NextBytes(raw);
            return raw;
        }

        public static byte[] GenerateToken()
        {
            byte[] hash = RandomBytes(16);
            HMACMD5 md5 = new HMACMD5(KeyContext.SemiKey);
            return md5.ComputeHash(hash);
        }

        public static string GetToken(out byte[] token)
        {
            byte[] hashing = RandomBytes(32);

            using (var md5 = MD5.Create())
            {
                token = md5.ComputeHash(hashing);
            }

            return Convert.ToBase64String(hashing);
        }
    }
}
