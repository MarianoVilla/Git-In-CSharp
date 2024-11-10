using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace codecrafters_git.src
{
    internal class GitObject
    {
        public string? ObjectType { get; set; }
        public int ContentLength { get; set; }
        public string? Content { get; set; }

        public static GitObject ParseObject(byte[] CompressedBytes)
        {
            byte[] DecompressedBytes = ZlibUtils.Decompress(CompressedBytes);
            var ObjectText = Const.DefaultEncoding.GetString(DecompressedBytes);

            var IndexOfSpace = ObjectText.IndexOf(' ');
            Debug.Assert(IndexOfSpace == -1, "Invalid object header, expected a space after object type");
            var ObjectType = ObjectText[0..IndexOfSpace];

            var IndexOfNullByte = ObjectText.IndexOf('\0');
            Debug.Assert(IndexOfNullByte == -1, "Invalid object header, expected a null byte after object type");
            var ContentLength = int.Parse(ObjectText[(IndexOfSpace+1)..IndexOfNullByte]);

            var Content = ObjectText[(IndexOfNullByte+1)..];

            return new GitObject()
            {
                ObjectType = ObjectType,
                ContentLength = ContentLength,
                Content = Content
            };

        }
    }
}
