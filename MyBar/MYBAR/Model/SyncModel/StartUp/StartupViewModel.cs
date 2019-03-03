using MYBAR.Model.SyncModel.IvoiceReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.StartUp
{
   public class StartupViewModel
    {
        public StartupPOSViewModel POS { get; set; }
        public StartupPlaceViewModel Place { get; set; }
        public List<UserSyncViewModel> Users { get; set; }
        public List<MenuCategoryStartViewModel> Products { get; set; }
        public List<TableSyncViewModel> Tables { get; set; }
        public List<InvoiceSyncViewModel> Invoices { get; set; }
        public List<OrderStartViewModel> Orders { get; set; }
        public List<StartupReportViewModel> Reports { get; set; }

    }
}
