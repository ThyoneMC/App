using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThyoneMC.Core
{
    internal class MyRegex
    {
        public Regex regex;

        public MyRegex(string pattern, RegexOptions options = RegexOptions.None)
        {
            regex = new Regex(pattern, options);
        }

        public static string argsFromString(string[] args)
        {
            string fullArgs = "";

            foreach (string arg in args)
            {
                fullArgs += $" {arg}";
            }

            return fullArgs;
        }

        public string toString(string message)
        {
            Match match = regex.Match(message);

            if (match.Success)
            {
                return match.Value;
            }

            return "";
        }

        public string[] toMultipleString(string message)
        {
            MatchCollection match = regex.Matches(message);
            string[] stringArgs = { "" };

            foreach (Match result in match)
            {
                if (result.Success)
                {
                    stringArgs.Append(result.Value);
                }
            }

            return stringArgs;
        }
    }
}
