using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Model.MetaPageCategory.json
{
    public class Web
    {
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string YandexMetrikaId { get; set; }
        public BlueKai BlueKai { get; set; }
        public List<string> Comscore { get; set; }
        public string GemiusId { get; set; }
        public string GemiusDetayId { get; set; }
        public string MetaTagsHtml { get; set; }
        public MetaTags MetaTags { get; set; }
        public GoogleAnalytics GoogleAnalytics { get; set; }
    }
}
