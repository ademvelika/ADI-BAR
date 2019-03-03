using MYBAR.Helper;
using MYBAR.Model.SyncModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MYBAR.Model
{
    public abstract class FatureBase
    {
        public int TavolineId { get; set; }
        public int TaVolineOnlineId { get; set; }
        public int TavolineNumber { get; set; }
        public int FatureId { get; set; }
        public string User_Id { get; set; }
        public int FatureOnlineId { get; set; }
        public DateTime OrderDate { get; set; }
        public String OrderNumber { get; set; }

        public int Fraction { get; set; }
        public bool Fiscal_Cash { get; set; }
        public ObservableCollection<FatureRow> ReferenceFatureRows { get; set;}
        public ObservableCollection<FatureRow> FatureRows  {get;set; }
        public ObservableCollection<FatureRow> NewFatureRow { get; set; }
        public decimal Total { get; set; }
        public Visibility DeleteOptionVisible { get; set; }
        public String MessageOnSaveUpdate { get; set; }
        public bool TavolinaDropDownEnabled { get; set; }
        public int PLACEID = RegisterData.Place_Id;

        public int MinSizeOfFatureBody { get; set; }
        public FatureBase()
        {

            FatureRows = new ObservableCollection<FatureRow>();
            NewFatureRow = new ObservableCollection<FatureRow>();
            OrderDate = DateTime.Now;
            TavolinaDropDownEnabled = true;
          
            MinSizeOfFatureBody = 350;
        }


        public FatureRow getProductInList(int productid)
        {



            return ReferenceFatureRows.Where(x => x.Productid == productid).FirstOrDefault();
        }


        

        public decimal GetTotal()
        {

            decimal sum = 0;
            foreach(FatureRow row in ReferenceFatureRows)
            {

                sum += row.Sasi * row.Cmim;
            }

            return sum+Total;
        }

  

        public virtual bool Delete()
        {
            return true;
        }
        public abstract bool Save();
        public abstract bool CanCloseOrSaveTable();
        public abstract bool CloseTable();

        public NewOrderViewModel getSyncedOrder()
        {

            NewOrderViewModel model = new NewOrderViewModel();
            model.Local_Id = FatureId;
            model.OperationTime = OrderDate;
            model.OrderStatus_Id = 9;
            model.Table_Id =TaVolineOnlineId;
            model.POS_Id = RegisterData.POS_Id;
            model.IsFiscal = RegisterData.IsKasaActive;
            model.User_Id = User_Id;
            model.Items = ReferenceFatureRows.Select(x => new OrderDetailViewModel { Id = x.ProductOnlineId, Count = x.Sasi, SalePrice = x.Cmim }).ToList();

            return model;
        }

        public virtual int SyncWithServer()
        {

            return 1;
        }

       
    }
}
