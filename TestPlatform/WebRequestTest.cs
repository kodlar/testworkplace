using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform
{
    public class WebRequestTest
    {
        public void AmpContentUpdatePingTest()
        {
            string testUrl = "http://www.fanatik.com.tr/amp/2017/03/31/ozet-besiktas-genclerbirligi-mac-sonucu-3-0-1285968";

            WebRequest wrGETURL = WebRequest.Create(testUrl);
            
            HttpWebResponse response = (HttpWebResponse)wrGETURL.GetResponse();

            string ampLinkParam = "fanatik.com.tr/amp/2017/03/31/ozet-besiktas-genclerbirligi-mac-sonucu-3-0-1285968";

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                
              
                string ampUrl = string.Concat("https://cdn.ampproject.org/c/s/", ampLinkParam);
                Console.WriteLine(ampUrl);
                WebRequest ampLinkUpdatePing = WebRequest.Create(ampUrl);

                try
                {
                    HttpWebResponse ampResponse = (HttpWebResponse)ampLinkUpdatePing.GetResponse();

                    if (ampResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine("Amp linki ping edilmiştir.");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    string ampUrl = string.Concat("https://cdn.ampproject.org/i/s/", ampLinkParam);
                    Console.WriteLine(ampUrl);
                    WebRequest ampLinkRemovePing = WebRequest.Create(ampUrl);

                    try
                    {
                        HttpWebResponse ampResponse = (HttpWebResponse)ampLinkRemovePing.GetResponse();

                        if (ampResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Console.WriteLine("Content ampcache linkten kaldırılmıştır! ");
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
               
            }

            //geleni yazdırmak istersek aşağıdaki kodu kullanabiliriz
            /*
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            

            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Console.WriteLine("{0}:{1}", i, sLine);
            }
            */
            Console.ReadLine();
        }


        public void Source()
        {
            //https://support.microsoft.com/en-us/help/307023/how-to-make-a-get-request-by-using-visual-c
        }
    }
}
