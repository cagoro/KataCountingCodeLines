using System.Linq;
using System.Text.RegularExpressions;

namespace LineCountKata
{
    public class LineCounter
    {
        public int CountLines(string fileContent)
        {
            fileContent = RemoveMultilineComments(fileContent);
            string[] lines = Regex.Split(fileContent, "\r\n");            
            return lines.Count(IsCodeLine);
        }

        private string RemoveMultilineComments(string fileContent)
        {
            foreach (Match match in Regex.Matches(fileContent, @"/\*.*\*/", RegexOptions.Singleline))
            {
                fileContent = fileContent.Replace(match.Value, string.Empty);
            }
            return fileContent;
        }

        private bool IsCodeLine(string line)
        {
            return !string.IsNullOrWhiteSpace(line) 
                && !Regex.IsMatch(line, "^\\s*//");
        }
    }
}
