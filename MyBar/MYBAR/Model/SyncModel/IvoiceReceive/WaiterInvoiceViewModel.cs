using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.IvoiceReceive
{
    public class WaiterInvoiceViewModel
    {
        public int Id { get; set; }
        public int  POS_Id {get;set;}
        public int Place_Id { get; set; }
        public string User_Id { get; set; }
        public List<WaiterInvoiceMenuItemViewModel> Items { get; set; }
        public WaiterInvoiceViewModel()
        {
            Items = new List<WaiterInvoiceMenuItemViewModel>();
        }

    }
}
