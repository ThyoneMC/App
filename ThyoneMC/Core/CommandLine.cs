using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThyoneMC.Core;

namespace ThyoneMC.Core
{
    internal class CommandLine
    {
        public string baseArgs;
        public Process process;

        public CommandLine(Boolean powershell = false, string fileName = "cmd.exe", string baseArgs = "")
        {
            this.baseArgs = baseArgs;
            this.process = new Process();

            process.StartInfo.UseShellExecute = powershell;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = fileName;
        }
        private string argsFromString(params string[] args)
        {
            string argString = MyRegex.argsFromString(args);

            return $"{baseArgs} {argString}";
        }

        public string Execute(params string[] args)
        {
            process.StartInfo.Arguments = argsFromString(args);

            process.Start();
            process.WaitForExit();

            return process.StandardOutput.ReadToEnd();
        }
    }
}
