using MYBAR.Helper;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Tavoline
{
    public class TavolineEditModel : TavolineModel
    {

        public TavolineEditModel()
        {
            DeleteButtonVisibility = System.Windows.Visibility.Visible;
        }
        public override bool Delete()
        {
            IsItemActive = false;
            
          
            return TavolinaService.DeleteTable(this);
        }

        public override bool Save()
        {

           
            return TavolinaService.EditTable(this);
        }
    }
}
