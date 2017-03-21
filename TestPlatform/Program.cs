using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DateTime date = new DateTime();
            date = DateTime.Now;
           
            //2016-01-10T10:00:00+01:00
            //Console.WriteLine(date.ToString("yyyy-MM-ddTHH:mmzzz"));


            string format = "yyyy-MM-ddTHH:mmzzz";

            DateTimeOffset outputDate = new DateTimeOffset(date);
            
          //  Console.WriteLine(outputDate.ToString(format));

            var syndicationItem =
                   new SyndicationItem
                   {                    
                       PublishDate = date
        };
       

            Console.WriteLine(syndicationItem.PublishDate);
            Console.ReadKey();

        }
    }
}
