using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Model.MetaPageCategory.json
{
   
    public class RootObject
    {
        public Web Web { get; set; }
        public Mobile Mobile { get; set; }
        public Api Api { get; set; }
    }
}
