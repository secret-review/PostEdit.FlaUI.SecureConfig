using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEdit
{
    public static class Config
    {
        public static SshSettings Ssh { get; set; }

        public static string ConnectionString { get; set; }
    }
}
