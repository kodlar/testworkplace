using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlatform.Model.MetaPageCategory
{
    public class DbEntity
    {
        public int  RowId { get; set; }
        public int  PageId { get; set; }

        public int CategoryId { get; set; }

        public int LanguageId { get; set; }

        public string Properties { get; set; }
    }
}
