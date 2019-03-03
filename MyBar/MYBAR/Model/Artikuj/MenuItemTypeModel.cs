using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Artikuj
{
    public class MenuItemTypeModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

         public  override string ToString()
        {

            return Name;
        }
    }


    public class MenuItemUnitModel : MenuItemType
    {
        public override string ToString()
        {

            return Name;
        }
    }
}
