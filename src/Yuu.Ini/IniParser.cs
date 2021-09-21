using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Yuu.Ini
{
    /// <summary>
    /// Provides methods to parse and convert an INI-formated string to object.
    /// </summary>
    public class IniParser
    {
        /// <summary>
        /// Parse and vonvert an INI-formated string to object.
        /// </summary>
        /// <param name="contents">An INI-formated string.</param>
        /// <param name="configuration">An INI parser configuration.</param>
        /// <returns>Returns an INI document node.</returns>
        public static IniDocument Parse(string contents, IniParserConfiguration configuration)
        {
            var ini = new IniDocument(configuration);
            var lines = new List<string>(Regex.Split(contents, configuration.NewLineRegex));

            var shouldRemoveLast = configuration.NewLineAtEndOfFile
                && lines.Count != 0
                && String.IsNullOrWhiteSpace(lines.Last());
            if (shouldRemoveLast)
            {
                lines.RemoveAt(lines.Count - 1);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                var aLine = lines[i];
                Match match;

                match = Regex.Match(aLine, configuration.SectionLineRegex);
                if (match.Success)
                {
                    // Line is section definition
                    ini.AddSection(match.Groups["SectionName"].Value);
                    continue;
                }

                match = Regex.Match(aLine, configuration.ParameterLineRegex);
                if (match.Success)
                {
                    // Line is parameter
                    ini.GetSections().Last().AddParameter(match.Groups["Key"].Value, match.Groups["Value"].Value);
                    continue;
                }

                match = Regex.Match(aLine, configuration.CommentLineRegex);
                if (match.Success)
                {
                    // Line is comment
                    ini.GetSections().Last().AddComment(match.Value);
                    continue;
                }

                throw new ArgumentException($@"The line '{aLine}' is not valid format.");
            }

            return ini;
        }

        /// <summary>
        /// Parse and vonvert an INI-formated string to object.
        /// </summary>
        /// <param name="contents">An INI-formated string.</param>
        /// <returns>Returns an INI document node.</returns>
        public static IniDocument Parse(string contents)
        {
            return IniParser.Parse(contents, new IniParserConfiguration());
        }

        internal static bool VerifyByRegex(string input, string pattern)
        {
            if (!Regex.IsMatch(input, pattern))
            {
                throw new ArgumentException($@"The argument value '{input}' is not valid. Because the value does not match regular expression '{pattern}'.");
            }
            return true;
        }
    }
}
