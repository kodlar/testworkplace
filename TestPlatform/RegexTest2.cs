using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPlatform
{
    public class RegexTest2
    {

        public void Test()
        {
            string html = File.ReadAllText("../../content2.html");            
            string newHtml = string.Empty;

            newHtml = html.Replace("photo_galery", "photo_galery releated");
            newHtml = newHtml.Replace("width: 170px; height: 116px;", "");
            //var matches = Regex.Matches(html, "@(.*[\s+\"\']photo_galery[\s+\"\'].*)", RegexOptions.Multiline);
            int a = 3;
        }
    }
}
