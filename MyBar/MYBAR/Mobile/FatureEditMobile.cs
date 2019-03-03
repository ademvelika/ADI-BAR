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
   public  class FatureEditMobile:FatureEdit
    {

        public string User_Name { get; set; }
        public string mobileid { get; set; }

        public override bool Save()
        {
            BackgroundWorker.AddFatureTotalToXhiroTotaleFromMobile(NewFatureRow.Sum(x => x.Sasi * x.Cmim),User_Id,Fiscal_Cash);


            bool issaved = FatureService.UpdateOpenTable(this);
            if (issaved)
            {


                Thread t = new Thread(() =>
                {


                    if (Fiscal_Cash)
                    {
                        KasaFiskale k = new KasaFiskale(this);
                        k.SaveFile();
                    }

                    FatureBuilder builder = new FatureBuilder(getNewFaturePreview());
                    Printer.PrintFlowDocument(builder.getFatureReceipmentForPrinting(User_Name), Fiscal_Cash);

                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }

            //syncing with server
            SyncWithServer();
            return issaved;
        }

        public override bool CloseTable()
        {

            bool issaved = true;
            if (ReferenceFatureRows.Count > 0)
            {
                issaved = issaved && Save();
            }


            issaved = issaved && FatureService.ClosePorosiInTable(TavolineId);

            SyncingWorker.CloseTable(FatureId, TaVolineOnlineId);

            return issaved;

        }

    }
}
