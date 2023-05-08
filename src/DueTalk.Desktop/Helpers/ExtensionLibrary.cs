using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DueTalk.Desktop.Helpers
{
    public static class ExtensionLibrary
    {
        public static EventHandler<string> Print;
        public static void PrintLn(string arg)
        {
            Trace.WriteLine(arg);
            Print?.Invoke(null, arg + Environment.NewLine);
        }
    }
}
