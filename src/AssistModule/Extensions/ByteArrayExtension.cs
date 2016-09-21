using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistModule.Extensions
{
    public static class ByteArrayExtension
    {
        public static void Shuffle(this byte[] source)
        {
            Assistant.Random.NextBytes(source);
        }
    }
}
