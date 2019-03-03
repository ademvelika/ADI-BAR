using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
  public  class CancelOrderViewModel
    {

        public int Order_LocalId { get; set; }
        public string User_Id { get; set; }
       // public int Place_Id { get; set; }
        public string Notes { get; set; }

        public int POS_Id { get; set; }
    }
}
