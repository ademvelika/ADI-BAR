using MYBAR.Helper;
using MYBAR.Raports;
using MYBAR.Services;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MYBAR.Model
{
    public class FatureEdit : FatureBase
    {



        public FatureEdit()
        {

            ReferenceFatureRows = NewFatureRow;
            TavolinaDropDownEnabled = false;
            MinSizeOfFatureBody = 0;
            User_Id = RegisterData.UserId;
        }

        public override bool CanCloseOrSaveTable()
        {
            return true;
        }

        public override bool CloseTable()
        {
            bool issaved = true;
            if (ReferenceFatureRows.Count > 0)
            {
             issaved=issaved&&Save();
            }


          issaved=issaved&&FatureService.ClosePorosiInTable(TavolineId);

           

            return issaved;

        }

        //in open table you can always close it     


        public override bool Save()
        {
            //add to xhiro only new items total
            BackgroundWorker.AddFatureTotalToXhiroTotale(NewFatureRow.Sum(x=>x.Sasi*x.Cmim));

            string UserName = ((MainWindow)App.Current.MainWindow).UserName;
            bool issaved= FatureService.UpdateOpenTable(this);
             if (issaved)
            {
                

                Thread t = new Thread(() =>
                {


                    if (RegisterData.IsKasaActive)
                    {
                        KasaFiskale k = new KasaFiskale(this);
                        k.SaveFile();
                    }

                    FatureBuilder builder = new FatureBuilder(getNewFaturePreview());
                    Printer.PrintFlowDocument(builder.getFatureReceipmentForPrinting(UserName), Fiscal_Cash);

                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }

            //syncing with server
            SyncWithServer();
            return issaved;
        }

        public FaturePreview getNewFaturePreview()
        {

            FaturePreview p = new FaturePreview();
            p.Id = FatureId;
            p.UserId = this.User_Id;
            p.TavolineNr = TavolineNumber;
            IEnumerable<FatureRow> obsCollection = (IEnumerable<FatureRow>)NewFatureRow;

            p.FatureBody = new List<FatureRow>(obsCollection);
            p.Data = DateTime.Now;

            p.Fraction = Fraction;

            return p;

        }

        public override int SyncWithServer()
        {


         


            return 1;
        }


    }
}
