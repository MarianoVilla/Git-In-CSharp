using codecrafters_git.src;
using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;


if (args is null || args.Length == 0)
{
    PrintHelp();
    return;
}

string Command = args[0];

switch (Command)
{
    case "init": GitInit(); break;
    case "cat-file": GitCatFile(args); break;
    default: throw new ArgumentException($"Unknown command {Command}");
}

void GitInit()
{
    Directory.CreateDirectory(Const.GIT_PATH_DIR_GIT);
    Directory.CreateDirectory(Const.GIT_PATH_DIR_OBJECTS);
    Directory.CreateDirectory(Const.GIT_PATH_DIR_REFS);
    File.WriteAllText(Const.GIT_PATH_FILE_HEAD, "ref: refs/heads/main\n");
    Console.WriteLine("Initialized git directory");
}
void GitCatFile(string[] args)
{
    if (args is null || args.Length < 3)
    {
        Console.WriteLine("Expected args: -p -> pretty-print file, <sha> -> sha1 of the object");
        return;
    }
    var Sha1 = args[2];
    if (Sha1.Length != 40)
    {
        Console.WriteLine($"Invalid SHA-1: {Sha1}");
        return;
    }
    var ObjectDir = Path.Combine(Const.GIT_PATH_DIR_OBJECTS, Sha1[..2]);
    var ObjectFullPath = Path.Combine(ObjectDir, Sha1[2..]);
    if (!File.Exists(ObjectFullPath))
    {
        Console.WriteLine($"Found not file at: {ObjectFullPath}");
        return;
    }

    var CompressedFileBytes = File.ReadAllBytes(ObjectFullPath);

    var ParsedObject = GitObject.ParseObject(CompressedFileBytes);
    Console.WriteLine(ParsedObject.Content);
}

#region Utils
void PrintHelp()
{
    Console.WriteLine("Please provide a command!");
}
#endregion