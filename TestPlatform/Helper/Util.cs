using System;
using System.Text.RegularExpressions;


namespace TestPlatform.Helper
{
    public class Util
    {
        public static DateTime? UnixTimeStampToDateTime(string unixTimeStamp)
        {
            System.DateTime? dtDateTime = new DateTime();
            
            if (!string.IsNullOrEmpty(unixTimeStamp))
            {
                var matches = Regex.Split(unixTimeStamp, @"(\d{4})(\d{2})(\d{2})T(\d{2})(\d{2})(\d{2})", RegexOptions.Singleline);
                dtDateTime = new DateTime(int.Parse(matches[1]), int.Parse(matches[2]), int.Parse(matches[3]), int.Parse(matches[4]), int.Parse(matches[5]), int.Parse(matches[6]), 0, System.DateTimeKind.Utc);
            }
            else
            {
                dtDateTime = null;
            }
           
            return dtDateTime;
        }
    }
}
