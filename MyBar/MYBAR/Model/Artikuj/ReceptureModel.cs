using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Artikuj
{
   public  class ReceptureModel
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int ChildId { get; set; }

        public int Quantity { get; set; }
        public string Njesi { get; set; }

    }
}
