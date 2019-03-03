using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.StartUp
{
  public  class MenuCategoryStartViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Media_Id { get; set; }
        public bool IsCategoryActive { get; set; }
        public int Place_Id { get; set; }
        public List<MenuItemSyncViewModel> MenuItems { get; set; }
    }
}
