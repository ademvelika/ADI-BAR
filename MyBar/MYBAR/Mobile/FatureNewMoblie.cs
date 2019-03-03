using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Raports;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MYBAR.Mobile
{
   public  class FatureNewMoblie:FatureNew
    {

        public string User_Name { get; set; }
        public string mobileid { get; set; }
        public FatureNewMoblie(int tavid, int onlineTavId) : base(tavid, onlineTavId)
        {
        }


        public override bool Save()
        {




            bool issaved = FatureService.SaveFatureNew(this);

            if (issaved)
            {
                //add total to xhiro gloabl object
                BackgroundWorker.AddFatureTotalToXhiroTotaleFromMobile(GetTotal(),User_Id,Fiscal_Cash);

             
                Thread t = new Thread(() =>
                {

                    if (Fiscal_Cash)
                    {
                        KasaFiskale k = new KasaFiskale(this);
                        k.SaveFile();
                    }
                    FatureBuilder builder = new FatureBuilder(getNewFaturePreview());
                    Printer.PrintFlowDocument(builder.getFatureReceipmentForPrinting(User_Name), RegisterData.IsKasaActive);

                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();


                //Sync with server
                SyncWithServer();

            }

            return issaved;
        }

        public override bool CloseTable()
        {

            //new method save and close
            bool issaved = FatureService.SaveAndClose(this, TavolineId);

            if (issaved)
            {
                //add total to xhiro gloabl object
                BackgroundWorker.AddFatureTotalToXhiroTotaleFromMobile(GetTotal(),User_Id,Fiscal_Cash);
              

                Thread t = new Thread(() =>
                {

                    if (Fiscal_Cash)
                    {
                        KasaFiskale k = new KasaFiskale(this);
                        k.SaveFile();
                    }

                    FatureBuilder builder = new FatureBuilder(getNewFaturePreview());
                    Printer.PrintFlowDocument(builder.getFatureReceipmentForPrinting(User_Name), RegisterData.IsKasaActive);

                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();




                //close table in server

                SyncingWorker.SaveAndClose(getSyncedOrder(), TaVolineOnlineId, FatureId);

            }
            return issaved;
        }


    }
}
