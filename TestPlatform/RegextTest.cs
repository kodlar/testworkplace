using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TestPlatform
{
    public class RegextTest
    {
        public void Test()
        {
            string html = File.ReadAllText("../../content.html");
            string newHtml = string.Empty;
            string newhtmlTag = "<div class=\"clear\"></div>";
            var matches = Regex.Matches(html, @"<\s*div class=\\[^>]*>(.*?)<\s*/\s*div>", RegexOptions.Singleline);
            if (matches.Count.Equals(1))
            {
                newHtml = Regex.Replace(html, @"<\s*div class=\\[^>]*>(.*?)<\s*/\s*div>", newhtmlTag, RegexOptions.Singleline);
            }
            Console.WriteLine(newHtml);
        }
    }
}
