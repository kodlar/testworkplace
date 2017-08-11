using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Model.MetaPageCategory.json
{
    public class MetaTags
    {
        public MetaTag MetaTag { get; set; }
        public Og Og { get; set; }
        public Twitter Twitter { get; set; }
        public Segmentify Segmentify { get; set; }
    }

}
