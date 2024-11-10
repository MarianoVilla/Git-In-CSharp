using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codecrafters_git.src
{
    public class Const
    {
        public const string GIT_PATH_DIR_GIT = ".git";
        public const string GIT_PATH_DIR_OBJECTS = $"{GIT_PATH_DIR_GIT}/objects";
        public const string GIT_PATH_DIR_REFS = $"{GIT_PATH_DIR_GIT}/refs";
        public const string GIT_PATH_FILE_HEAD = $"{GIT_PATH_DIR_GIT}/HEAD";

        public static readonly Encoding DefaultEncoding = Encoding.UTF8;
    }
}
