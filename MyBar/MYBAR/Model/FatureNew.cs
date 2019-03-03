using MYBAR.Helper;
using MYBAR.Raports;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MYBAR.Model
{
    public  class FatureNew : FatureBase
    {

        /// <summary>
        /// Tavoline Id,Tavoline Online Id
        /// </summary>
        /// <param name="tavid"></param>
        /// <param name="onlineTavId"></param>
        public FatureNew(int tavid,int onlineTavId)
        {
            TavolineId = tavid;
            TaVolineOnlineId = onlineTavId;
            ReferenceFatureRows = FatureRows;
            Fraction = 1;
            User_Id = RegisterData.UserId;
        }

        public override bool CanCloseOrSaveTable()
        {
            if (FatureRows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public override bool CloseTable()
        {
            //new method save and close

            //check if fisal is on
            if (RegisterData.IsKasaActive)
            {
                Fiscal_Cash = true;
            }
            bool issaved = FatureService.SaveAndClose(this, TavolineId);

            if (issaved)
            {
                //add total to xhiro gloabl object
                BackgroundWorker.AddFatureTotalToXhiroTotale(GetTotal());
                string UserName = ((MainWindow)App.Current.MainWindow).UserName;
              

                Thread t = new Thread(() =>
                {

                    if (RegisterData.IsKasaActive)
                    {
                        KasaFiskale k = new KasaFiskale(this);
                        k.SaveFile();
                    }

                    FatureBuilder builder = new FatureBuilder(getNewFaturePreview());
                    Printer.PrintFlowDocument(builder.getFatureReceipmentForPrinting(UserName), RegisterData.IsKasaActive);

                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();




                //close table in server
                
                
           
        }
            return issaved;
        }

        public override bool Save()
        {



            //add function for syncing
            if (RegisterData.IsKasaActive)
            {
                Fiscal_Cash = true;
            }
                bool issaved= FatureService.SaveFatureNew(this);

            if (issaved)
            {
                //add total to xhiro gloabl object
                BackgroundWorker.AddFatureTotalToXhiroTotale(GetTotal());

                string UserName = ((MainWindow)App.Current.MainWindow).UserName;
                Thread t = new Thread(() =>
                  {
                     
                      if (RegisterData.IsKasaActive)
                      {
                 
                      KasaFiskale k = new KasaFiskale(this);
                      k.SaveFile();
                      }
                      FatureBuilder builder = new FatureBuilder(getNewFaturePreview());
                      Printer.PrintFlowDocument(builder.getFatureReceipmentForPrinting(UserName), RegisterData.IsKasaActive);

                  });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();


                //Sync with server
             SyncWithServer();

            }

            return issaved;

        }


        public override int  SyncWithServer()
        {

            
          

            return 1;
        }

        public FaturePreview getNewFaturePreview()
        {

            FaturePreview p = new FaturePreview();
            p.Id = FatureId;
            p.UserId = this.User_Id;
            p.TavolineNr = TavolineNumber;
            IEnumerable<FatureRow> obsCollection = (IEnumerable<FatureRow>)ReferenceFatureRows;

            p.FatureBody = new List<FatureRow>(obsCollection);
            p.Data = DateTime.Now;
            p.Fraction = Fraction;


            return p;

        }
    }
}
