using MYBAR.Helper;
using MYBAR.Model.SyncModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYBAR.Model
{
    public abstract class TavolineModel
    {

        public int Id { get; set; }

        public int OnlineId { get; set; }
        public int Number { get; set; }
        public bool IsItemActive { get; set; }
        public Visibility DeleteButtonVisibility { get; set; }
        public abstract bool Save();

        public abstract bool Delete();

        public WaiterTableViewModel getServerModel()
        {

            return new WaiterTableViewModel {Id=OnlineId, Number = Number, IsActive = true ,Place_Id=RegisterData.Place_Id,POS_Id=RegisterData.POS_Id };
        }
        public void NoInternetMesage()
        {
            MessageBox.Show("Tavoline me te njetin emer ose  kontrolloni internetin !");
        }
    }
}
