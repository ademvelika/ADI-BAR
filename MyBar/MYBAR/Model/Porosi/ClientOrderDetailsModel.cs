using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Porosi
{
   public class ClientOrderDetailsModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }

        public int MenuItem_Id { get; set; }
    }
}
