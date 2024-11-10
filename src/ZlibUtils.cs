using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace codecrafters_git.src
{
    public static class ZlibUtils
    {
        public static byte[] Decompress(byte[] CompressedBytes)
        {
            using (var InputStream = new MemoryStream(CompressedBytes))
            using (var OutputStream = new MemoryStream())
            using (var Zlib = new ZLibStream(InputStream, CompressionMode.Decompress))
            {
                Zlib.CopyTo(OutputStream);
                return OutputStream.ToArray();
            }
        }
    }
}
