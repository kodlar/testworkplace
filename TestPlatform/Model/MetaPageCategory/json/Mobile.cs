using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Model.MetaPageCategory.json
{
    public class Mobile
    {
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string YandexMetrikaId { get; set; }
        public BlueKai2 BlueKai { get; set; }
        public List<string> Comscore { get; set; }
        public string GemiusId { get; set; }
        public string GemiusDetayId { get; set; }
        public string MetaTagsHtml { get; set; }
        public MetaTags2 MetaTags { get; set; }
        public GoogleAnalytics2 GoogleAnalytics { get; set; }
    }
}
