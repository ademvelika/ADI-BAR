using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Porosi
{
   public  class ClientOrderModel
    {

        public int Id;
        public string Notes { get; set; }
        public string Order_Status { get; set; }
        public decimal Order_Total { get; set; }

        public DateTime Order_Time { get; set; }

        public string Client_Name { get; set; }
    }
}
