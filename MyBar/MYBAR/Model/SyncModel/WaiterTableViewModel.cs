using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
  public  class WaiterTableViewModel
    {

        public int Id { get; set; }
        public int Number { get; set; }
        public int Place_Id { get; set; }
      
        public int POS_Id { get; set; }
        public bool IsActive { get; set; }
    }
}
