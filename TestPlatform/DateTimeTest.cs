using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform
{
    public class DateTimeTest
    {
        public void WriteProperFormat()
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
