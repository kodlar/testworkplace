using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using GoogleAnalyticsTracker.Core;
using GoogleAnalyticsTracker.Core.Interface;
using GoogleAnalyticsTracker.Mvc4;
using TestWebApplication.Helper;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {

        private async Task TestTracepage(HttpContextBase context,string pageTitle,string url)
        {

            using (Tracker tracker = new Tracker("UA-3093095-23", "test.fanatik.com.tr"))
            {
                await tracker.TrackPageViewAsync(context, pageTitle, url);
            }
        }

        public ActionResult Index(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                this.TestTracepage(HttpContext, "http://www.milliyet.com.tr", "http://www.milliyet.com.tr");
                return RedirectPermanent(url);
            }

            GaHelper ga = new GaHelper("UA-3093095-23");
            for (int i = 0; i < 100; i++)
            {
                ga.trackPage("test.fanatik.com.tr", i+".asp", "test ediyorum" + i);
            }
            
            
            //ga.trackEvent("cep telefonu","ikinci el", "samsung", "note2");
            return View();
            
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}