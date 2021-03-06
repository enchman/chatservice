﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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

        public static bool VerifyToken(this string source, byte[] token)
        {
            try
            {
                byte[] hash = Convert.FromBase64String(source);
                return hash.VerifyToken(token);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsTokenValid(this string source, byte[] token)
        {
            try
            {
                byte[] clientToken = Convert.FromBase64String(source);
                if (clientToken.Length == Assistant.TokenSize)
                {
                    using (var md5 = MD5.Create())
                    {
                        byte[] clientHash = md5.ComputeHash(clientToken);
                        return token.SequenceEqual(clientHash);
                    }
                }
                
            }
            catch { }
            return false;
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
            Buffer.BlockCopy(salt, 0, encode, 64, 64);

            return encode;
        }
    }
}
