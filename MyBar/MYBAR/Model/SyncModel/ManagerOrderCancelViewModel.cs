using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
  public   class ManagerOrderCancelViewModel
    {
        public string User_Id { get; set; }
        public int Order_Local_Id { get; set; }
        public int Place_Id { get; set; }
    }
}
