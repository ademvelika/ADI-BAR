using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.InventarySyncOnly
{
    public class InventorySync
    {


        public int Id { get; set; }
        public int POS_Id { get; set; }
        public int MenuItem_Id { get; set; }
        public bool IsRemove { get; set; }
        public int Quantity { get; set; }
    }
}
