using MYBAR.Helper;
using MYBAR.Model.SyncModel.IvoiceReceive;
using MYBAR.Services;
using System;
using System.Collections.ObjectModel;

namespace MYBAR.Model.FatureModel
{
    public class FatureHyrje : FatureBase

        
    {


        public FatureHyrje()
        {
            FatureRows = new ObservableCollection<FatureRow>();
            ReferenceFatureRows = FatureRows;
            DeleteOptionVisible = System.Windows.Visibility.Collapsed;
            MessageOnSaveUpdate = "Fatura u ruajt me sukses !";
        }
        public override bool CanCloseOrSaveTable()
        {
            throw new NotImplementedException();
        }

        public override bool CloseTable()
        {
            throw new NotImplementedException();
        }

        public override bool Save()
        {




           return FatureService.SaveFatureHyrje(this);
        }


        public bool SaveFromKorrigjim(string userid)
        {

                return FatureService.SaveFatureHyrjeFromKorrigjim(this, userid);
           

        }

        public WaiterInvoiceViewModel getServerModel()
        {
            WaiterInvoiceViewModel model = new WaiterInvoiceViewModel { Place_Id = RegisterData.Place_Id,User_Id=RegisterData.UserId,POS_Id=RegisterData.POS_Id };
            foreach (var item in ReferenceFatureRows)
            {

                model.Items.Add(new WaiterInvoiceMenuItemViewModel { Id = item.ProductOnlineId, BuyPrice = item.Cmim, BuyQuantity = item.Sasi });

            }

            return model;
        }


        public override int SyncWithServer()
        {

            return 0;
        }

       
    }
}
