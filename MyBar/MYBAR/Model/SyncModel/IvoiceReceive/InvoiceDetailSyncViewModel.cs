using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.IvoiceReceive
{
   public class InvoiceDetailSyncViewModel
    {

        public int Id { get; set; }
        public int Quantity { get; set; }

        public decimal BuyPrice { get; set; }
        public int MenuItem_Id { get; set; }
        public int Invoice_Id { get; set; }
    }
}
