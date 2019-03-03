using MYBAR.Model.SyncModel.IvoiceReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
  public   class SyncViewModel
    {
        public List<Tuple<SyncDetail, UserSyncViewModel>> Users { get; set; }
        public List<Tuple<SyncDetail, MenuCategorySyncViewModel>> MenuCategories { get; set; }
        public List<Tuple<SyncDetail, MenuItemSyncViewModel>> MenuItems { get; set; }
        public List<Tuple<SyncDetail, WaiterTableViewModel>> Tables { get; set; }
        public List<Tuple<SyncDetail, InvoiceSyncViewModel>> Invoices { get; set; }
        public List<Tuple<SyncDetail, POSSyncViewModel>> POSes { get; set; }
        public  List<Tuple<SyncDetail, OrderSyncViewModel>> Orders  {get;set;}

    }
}
