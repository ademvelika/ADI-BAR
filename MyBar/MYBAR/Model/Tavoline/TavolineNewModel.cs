using MYBAR.Helper;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Tavoline
{
    class TavolineNewModel : TavolineModel
    {

        public TavolineNewModel()
        {
            DeleteButtonVisibility = System.Windows.Visibility.Hidden;
        }
        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Save()
        {





            OnlineId = 0; ;
            return TavolinaService.AddTable(this);
        }
    }
}
