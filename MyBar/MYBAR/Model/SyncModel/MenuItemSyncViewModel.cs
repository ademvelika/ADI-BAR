using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
    public class MenuItemSyncViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int POS_Id { get; set; }
        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public bool IsItemActive { get; set; }
        public int MenuCategory_Id { get; set; }
        public int Unit_Id { get; set; }
        public int MenuItemType_Id { get; set; }
        public List<ComposedMenuItem> ComposingItems { get; set; }
    }

    public class ComposedMenuItem
    {
     
        public int Parent_Id { get; set; }

    
        public int Child_Id { get; set; }

         

        public int Portion_Quantity { get; set; }
    }

}
