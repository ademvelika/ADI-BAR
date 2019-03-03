using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
    public class CollectViewModel
    {
        public List<LocalOrderViewModel> Orders { get; set; }

        public CollectViewModel()
            {
            Orders = new List<LocalOrderViewModel>();

            }
    }
}
