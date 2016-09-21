using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssistModule.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Generate Secure Hash Password
        /// </summary>
        /// <returns></returns>
        public static byte[] ToSecureHash(this string source)
        {
            return getSecureHash(source, Assistant.RandomBytes(64));
        }
        /// <summary>
        /// Generate Secure Hash Password
        /// </summary>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static byte[] ToSecureHash(this string source, byte[] salt)
        {
            return getSecureHash(source, salt);
        }

        /// <summary>
        /// Verify String Password
        /// </summary>
        /// <param name="secureHash">Secure Hash, Byte array</param>
        /// <returns></returns>
        public static bool VerifyPassword(this string source, byte[] secureHash)
        {
            if (secureHash == null)
                throw new Exception("Secure hash cannot be NULL");
            if (secureHash.Length != 128)
                throw new Exception("Secure hash must be 128 length, given " + secureHash.Length);

            // Extract Salt
            byte[] salt = secureHash.Skip(64).ToArray();

            // Initialize password
            byte[] userHash = source.ToSecureHash(salt);

            return secureHash.SequenceEqual(userHash);
        }

        private static byte[] getSecureHash(string password, byte[] salt)
        {
            // Plain text extraction
            byte[] text = Encoding.UTF8.GetBytes(password);

            // Initiate SHA2 512 bit
            HMACSHA512 sha = new HMACSHA512(salt);
            // Computing hash function
            byte[] hash = sha.ComputeHash(text);

            // Initialize encode data 
            byte[] encode = new byte[128];

            // Injecting salt and hash password to Encode data
            Buffer.BlockCopy(hash, 0, encode, 0, 64);
            Buffer.BlockCopy(salt, 0, salt, 64, 64);

            return encode;
        }
    }
}
