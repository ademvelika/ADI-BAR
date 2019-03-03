using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.IvoiceReceive
{
   public class InvoiceSyncViewModel
    {
        public int Id { get; set; }
        public int Place_Id { get; set; }
        public DateTime Date { get; set; }

        public string User_Id { get; set; }
        public List<InvoiceDetailSyncViewModel> InvoiceDetails { get; set; }
    }
}
