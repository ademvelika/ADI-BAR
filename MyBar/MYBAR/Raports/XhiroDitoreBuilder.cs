using MYBAR.Helper;
using MYBAR.Model.Reports;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace MYBAR.Raports
{
    public class XhiroDitoreBuilder
    {

        public string username { get; set; }
        public XhiroDitoreModel model;
        public FlowDocument Document { get; set; }
        public XhiroDitoreBuilder(XhiroDitoreModel m, string username)
        {
            model = m;
            this.username = username;
            BuildDocument();
        }


        private void BuildDocument()
        {


            FlowDocument document = new FlowDocument();
            document.FontFamily = new FontFamily("MonoSpaced Sans Serif");
            document.PageWidth = 290;






 
            Paragraph date = new Paragraph(new Run("Data:" + model.Turni.Data.ToString()));
            date.FontSize = 11;
            date.FontWeight = FontWeights.ExtraBold;
            document.Blocks.Add(date);


          

            Paragraph p = new Paragraph(new Run("XH.dit :   " + username));
            p.FontSize = 14;
            p.FontWeight = FontWeights.ExtraBold;
            document.Blocks.Add(p);

            Table tcstart = new Table();
            tcstart.FontFamily = new FontFamily("Arial");
            tcstart.FontSize = 19;
          

            tcstart.BorderThickness = new Thickness(0);

            for (int i = 0; i < 2; i++)
            {
                tcstart.Columns.Add(new TableColumn());
            }

        

            TableRowGroup bodycstart = new TableRowGroup();
  
                TableRow rtcstart = new TableRow();



            //add leke dor

            decimal total = model.Turni.Total;
            if(RegisterData.ShowAllBillTypes==false)
            {
                total = model.Turni.Fiscal_Orders_Total_Sum;
            }
         
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run("Leke Dor"))));
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run(total.ToString("#,#0.00")))));
            rtcstart.Cells[0].TextAlignment = TextAlignment.Left;
            rtcstart.Cells[1].TextAlignment = TextAlignment.Right;
            bodycstart.Rows.Add(rtcstart);


            //add total

            rtcstart = new TableRow();

         
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run(total.ToString("#,#0.00")))));
            rtcstart.Cells[0].TextAlignment = TextAlignment.Left;
            rtcstart.Cells[1].TextAlignment = TextAlignment.Right;
            rtcstart.FontWeight = FontWeights.ExtraBold;
            bodycstart.Rows.Add(rtcstart);


            //add bakshish

            rtcstart = new TableRow();

         
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run("Bakshish"))));
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run(model.Turni.Tips.ToString("#,#0.00")))));
            rtcstart.Cells[0].TextAlignment = TextAlignment.Left;
            rtcstart.Cells[1].TextAlignment = TextAlignment.Right;
            bodycstart.Rows.Add(rtcstart);


            //add nr produktesh

            rtcstart = new TableRow();

            
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run("Nr.Prod"))));
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run(model.Turni.NrProduktesh.ToString("#,#0.00")))));
            rtcstart.Cells[0].TextAlignment = TextAlignment.Left;
            rtcstart.Cells[1].TextAlignment = TextAlignment.Right;
            bodycstart.Rows.Add(rtcstart);

            //add nr fature
            rtcstart = new TableRow();

       
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run("Nr.Fat"))));
            rtcstart.Cells.Add(new TableCell(new Paragraph(new Run(model.Turni.NumerFaturash.ToString("#,#0.00")))));
            rtcstart.Cells[0].TextAlignment = TextAlignment.Left;
            rtcstart.Cells[1].TextAlignment = TextAlignment.Right;
            bodycstart.Rows.Add(rtcstart);

            tcstart.RowGroups.Add(bodycstart);
            document.Blocks.Add(tcstart);
            if(RegisterData.ShowAllBillTypes==false)
            document.Blocks.Add(new Paragraph(new Run("----------------------------------")));

            //Paragraph detaje1 = new Paragraph(new Run("Leke Dor:" + model.Turni.Cash.ToString("#,#0.00")));
            //detaje1.FontWeight = FontWeights.ExtraBold;
            //document.Blocks.Add(detaje1);

            //Paragraph detaje2 = new Paragraph(new Run("Total:" + model.Turni.Total.ToString("#,#0.00")));
            //detaje2.FontWeight = FontWeights.ExtraBold;
            //document.Blocks.Add(detaje2);

            //Paragraph detaje3 = new Paragraph(new Run("Bakshish:" + model.Turni.Tips.ToString("#,#0.00")));
            //detaje3.FontWeight = FontWeights.ExtraBold;
            //document.Blocks.Add(detaje3);

            //Paragraph detaje4 = new Paragraph(new Run("Nr.Prod:" + model.Turni.NrProduktesh.ToString("#,#0.00")));
            //detaje4.FontWeight = FontWeights.ExtraBold;
            //document.Blocks.Add(detaje4);

            //Paragraph detaje5 = new Paragraph(new Run("Nr.Fat:" + model.Turni.NumerFaturash.ToString("#,#0.00")));
            //detaje5.FontWeight = FontWeights.ExtraBold;
            //document.Blocks.Add(detaje5);


            Table t = new Table();
            t.BorderBrush = Brushes.LightGray;

            t.BorderThickness = new Thickness(1);

            for (int i = 0; i < 3; i++)
            {
                t.Columns.Add(new TableColumn());
            }

            TableRowGroup gr = new TableRowGroup();

            gr.Background = Brushes.LightGray;
            TableRowGroup body = new TableRowGroup();

            TableRow r1 = new TableRow();
            r1.FontWeight = FontWeights.Bold;
            r1.Cells.Add(new TableCell(new Paragraph(new Run("EMRI"))));
            r1.Cells.Add(new TableCell(new Paragraph(new Run("SASIA"))));
            r1.Cells.Add(new TableCell(new Paragraph(new Run("CMIMI"))));
            r1.Cells[0].TextAlignment = TextAlignment.Left;
            r1.Cells[1].TextAlignment = TextAlignment.Center;
            r1.Cells[2].TextAlignment = TextAlignment.Right;
            t.RowGroups.Add(gr);
            r1.FontSize = 12;
            gr.Rows.Add(r1);

            foreach (var item in model.Detajet)
            {
                TableRow rt = new TableRow();

                rt.FontSize = 12;
                rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Emer))));
                rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Nr.ToString()))));
                rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Cmim.ToString("#,#0.00")))));
                rt.Cells[0].TextAlignment = TextAlignment.Left;
                rt.Cells[1].TextAlignment = TextAlignment.Center;
                rt.Cells[2].TextAlignment = TextAlignment.Right;



                body.Rows.Add(rt);

            }

            TableRow rline = new TableRow();

            rline.FontWeight = FontWeights.ExtraBold;
            rline.Cells.Add(new TableCell(new Paragraph(new Run(""))));
            rline.Cells[0].ColumnSpan = 3;
            body.Rows.Add(rline);


            TableRow rf = new TableRow();
            rf.FontWeight = FontWeights.Bold;
            rf.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
            rf.Cells.Add(new TableCell(new Paragraph(new Run(""))));
            rf.Cells.Add(new TableCell(new Paragraph(new Run(model.Detajet.Sum(x => x.Nr * x.Cmim).ToString("#0.00")))));
            rf.Cells[2].TextAlignment = TextAlignment.Right;
            body.Rows.Add(rf);


            t.RowGroups.Add(body);
            document.Blocks.Add(t);


            //add requested for cancel fatura**************************************


            if (model.RequestedForCancelOrders.Count > 0)
            {
                document.Blocks.Add(getSeparator());
                Paragraph requestedcancell = new Paragraph(new Run("Kereksa per anullim:"));
                requestedcancell.FontWeight = FontWeights.ExtraBold;
                requestedcancell.TextAlignment = TextAlignment.Left;
                document.Blocks.Add(requestedcancell);

                foreach (var item in model.RequestedForCancelOrders)
                {

                    Paragraph headercancel = new Paragraph(new Run("NR.Fat:  " + item.Id));

                    document.Blocks.Add(headercancel);


                    Table tc = new Table();
                    tc.BorderBrush = Brushes.LightGray;

                    tc.BorderThickness = new Thickness(1);

                    for (int i = 0; i < 3; i++)
                    {
                        tc.Columns.Add(new TableColumn());
                    }

                    TableRowGroup grc = new TableRowGroup();

                    grc.Background = Brushes.LightGray;
                    TableRowGroup bodyc = new TableRowGroup();

                    TableRow r1c = new TableRow();
                    r1c.FontWeight = FontWeights.Bold;
                    r1c.Cells.Add(new TableCell(new Paragraph(new Run("EMRI"))));
                    r1c.Cells.Add(new TableCell(new Paragraph(new Run("SASIA"))));
                    r1c.Cells.Add(new TableCell(new Paragraph(new Run("CMIMI"))));
                    r1c.Cells[0].TextAlignment = TextAlignment.Left;
                    r1c.Cells[1].TextAlignment = TextAlignment.Center;
                    r1c.Cells[2].TextAlignment = TextAlignment.Right;
                    tc.RowGroups.Add(grc);
                    r1c.FontSize = 12;
                    grc.Rows.Add(r1c);

                    foreach (var row in item.FatureBody)
                    {
                        TableRow rtc = new TableRow();

                        rtc.FontSize = 12;
                        rtc.Cells.Add(new TableCell(new Paragraph(new Run(row.Asortimenti))));
                        rtc.Cells.Add(new TableCell(new Paragraph(new Run(row.Sasi.ToString()))));
                        rtc.Cells.Add(new TableCell(new Paragraph(new Run(row.Cmim.ToString("#0.00")))));
                        rtc.Cells[0].TextAlignment = TextAlignment.Left;
                        rtc.Cells[1].TextAlignment = TextAlignment.Center;
                        rtc.Cells[2].TextAlignment = TextAlignment.Right;



                        bodyc.Rows.Add(rtc);

                    }

                    TableRow rlinec = new TableRow();

                    rlinec.FontWeight = FontWeights.ExtraBold;
                    rlinec.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                    rlinec.Cells[0].ColumnSpan = 3;
                    bodyc.Rows.Add(rlinec);


                    TableRow rfc = new TableRow();
                    rfc.FontWeight = FontWeights.Bold;
                    rfc.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
                    rfc.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                    rfc.Cells.Add(new TableCell(new Paragraph(new Run(item.FatureBody.Sum(x => x.Sasi * x.Cmim).ToString("#0.00")))));
                    bodyc.Rows.Add(rfc);


                    tc.RowGroups.Add(bodyc);
                    document.Blocks.Add(tc);
                }



            }




            //faturat e anulluara
            if (model.CancelOrders.Count > 0)
            {
                document.Blocks.Add(getSeparator());
                Paragraph requestedcancell = new Paragraph(new Run("Fatura te Anulluara"));
                requestedcancell.FontWeight = FontWeights.ExtraBold;
                requestedcancell.TextAlignment = TextAlignment.Left;
                document.Blocks.Add(requestedcancell);
                //add header
                Table tc = new Table();
                tc.BorderBrush = Brushes.LightGray;

                tc.BorderThickness = new Thickness(1);

                for (int i = 0; i < 2; i++)
                {
                    tc.Columns.Add(new TableColumn());
                }

                TableRowGroup grc = new TableRowGroup();

                grc.Background = Brushes.LightGray;
                TableRowGroup bodyc = new TableRowGroup();

                TableRow r1c = new TableRow();
                r1c.FontWeight = FontWeights.Bold;
                r1c.Cells.Add(new TableCell(new Paragraph(new Run("Numri"))));

                r1c.Cells.Add(new TableCell(new Paragraph(new Run("Totali"))));
                r1c.Cells[0].TextAlignment = TextAlignment.Left;
                r1c.Cells[1].TextAlignment = TextAlignment.Center;

                tc.RowGroups.Add(grc);
                r1c.FontSize = 12;
                grc.Rows.Add(r1c);
                foreach (var item in model.CancelOrders)
                {




                    TableRow rtc = new TableRow();

                    rtc.FontSize = 12;
                    rtc.Cells.Add(new TableCell(new Paragraph(new Run(item.Id.ToString()))));
                    rtc.Cells.Add(new TableCell(new Paragraph(new Run(item.getTotal().ToString()))));

                    rtc.Cells[0].TextAlignment = TextAlignment.Left;
                    rtc.Cells[1].TextAlignment = TextAlignment.Center;




                    bodyc.Rows.Add(rtc);


                }




                tc.RowGroups.Add(bodyc);
                document.Blocks.Add(tc);
            }
            Document = document;





        }


        public Paragraph getSeparator()
        {
            Paragraph separator = new Paragraph(new Run("= = = = = = = = = = = = = = = = "));

            return separator;
        }


    }
}
