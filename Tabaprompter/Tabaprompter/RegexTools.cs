using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Tabaprompter
{
    public static class RegexTools
    {

        internal static List<string> match(string pattern, string text, RegexOptions regexOption)
        {
            List<string> matches = new List<string>();

            Match match = Regex.Match(text, pattern, regexOption);
            if(match.Success)
            {
                for(int i = 1; i < match.Groups.Count; i++)
                {
                    matches.Add(match.Groups[i].Value);
                }
            }
            return matches;
        }

        internal static string[] split(string text, string pattern)
        {
            return Regex.Split(text, pattern);
        }
    }
}
