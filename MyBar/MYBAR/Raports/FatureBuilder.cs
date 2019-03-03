using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;


namespace MYBAR.Raports
{


    public class FatureBuilder
    {
        public FlowDocument Document { get; set; }
        private FaturePreview FatureData { get; set; }

        public FatureBuilder(FaturePreview fat)
        {
            FatureData = fat;
        }


        public Dictionary<string,FlowDocument>  getFatureReceipmentForPrinting(string userName)
        {

            Dictionary<string,FlowDocument> listameDoc = new Dictionary<string, FlowDocument>();
            var l = FatureService.ktheProdukteSipasPrinterave(FatureData.FatureBody);

            //IF ONE FULL BILL MODE IS ACTIVE CREATE A FULL BILL TO THE DEFAULT PRINTER
            if (RegisterData.FULL_BILL == "1")
            {
                l["NONE"].AddRange(l.Where(x => x.Key != "NONE").Select(x=>x.Value).FirstOrDefault());
            }


            int COLUMNNUMBER = 2;
            if (RegisterData.SHOW_PRICE == 1)
            {
                COLUMNNUMBER = 3;
            }


            foreach (var part in l)
            {
                FlowDocument document = new FlowDocument();
                document.PageWidth = 290;
                document.FontFamily = new FontFamily("MonoSpaced Sans Serif");

                string head = RegisterData.BILL_HEADER;
                string footer = RegisterData.BILL_FOOTER;
                //image or text in header
                if (RegisterData.Image == null)
                {
                    Paragraph p = new Paragraph(new Run(head));
                    p.FontSize = 18;
                    p.FontWeight = FontWeights.Bold;
                    p.TextAlignment = TextAlignment.Center;
                    document.Blocks.Add(p);

                }
                else
                {

                    Image image = new Image();
                    image.Source = ImageConverter.LoadImage(RegisterData.Image);

                    image.MaxHeight = 50;
                    BlockUIContainer container = new BlockUIContainer(image);


                    document.Blocks.Add(container);
                }

                //shtimi i dates,kamarierit ,tavolones

                Table headtable = new Table();
                headtable.FontSize = 15;
                //add 2 column
                headtable.Columns.Add(new TableColumn());
                headtable.Columns.Add(new TableColumn());

                TableRowGroup headtablerowgr = new TableRowGroup();
                TableRow row1ht = new TableRow();
                row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Kamarieri: " + userName))));
                row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Tavolina:" + FatureData.TavolineNr))));
                TableRow row2ht = new TableRow();

                row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Data:" + FatureData.Data.Date.ToShortDateString()))));
                row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Ora:" + FatureData.Data.ToShortTimeString()))));
                TableRow row3ht = new TableRow();
                var seq = string.Empty;






                row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Nr.Fat: " + FatureData.Id + "_" + FatureData.Fraction))));
                row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Banaku: " + RegisterData.PosName))));
                headtablerowgr.Rows.Add(row1ht);
                headtablerowgr.Rows.Add(row2ht);
                headtablerowgr.Rows.Add(row3ht);
                headtable.RowGroups.Add(headtablerowgr);

                document.Blocks.Add(headtable);
                Table t = new Table();
                // t.TextAlignment = TextAlignment.Center;
                t.BorderBrush = Brushes.Gray;

                for (int i = 0; i < COLUMNNUMBER; i++)
                {
                    t.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
                }

                TableRowGroup gr = new TableRowGroup();

                TableRow r1 = new TableRow();

                r1.FontSize = 14;
                r1.FontWeight = FontWeights.Bold;
                r1.Cells.Add(new TableCell(new Paragraph(new Run("EMRI"))));
                r1.Cells.Add(new TableCell(new Paragraph(new Run("SASIA"))));

                r1.Cells[0].TextAlignment = TextAlignment.Left;
                r1.Cells[1].TextAlignment = TextAlignment.Center;

                if (RegisterData.SHOW_PRICE == 1)
                {
                    r1.Cells.Add(new TableCell(new Paragraph(new Run("CMIMI"))));
                    r1.Cells[2].TextAlignment = TextAlignment.Right;
                }

                gr.Rows.Add(r1);
                foreach (var item in part.Value)
                {
                    TableRow rt = new TableRow();
                    rt.FontSize = 14;
                    rt.FontWeight = FontWeights.Regular;
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Asortimenti))));



                    //nese sasia eshte ne mg ose ml pjesetohet me 1000 per te mare ne njesine kg,L
                    if (item.Njesi.Equals("g") || item.Njesi.Equals("ml"))
                    {
                        double sasiBaze =Convert.ToDouble( item.SASI )/ 1000;
                        rt.Cells.Add(new TableCell(new Paragraph(new Run(sasiBaze.ToString()))));
                    }
                    else
                    {
                        rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Sasi.ToString()))));
                    }
                 
                    rt.Cells[0].TextAlignment = TextAlignment.Left;
                    rt.Cells[1].TextAlignment = TextAlignment.Center;
                    if (RegisterData.SHOW_PRICE == 1)
                    {
                        if (item.Njesi.Equals("g") || item.Njesi.Equals("ml"))
                        {

                            double cmiimBaze = Convert.ToDouble(item.Cmim) * 1000;
                            rt.Cells.Add(new TableCell(new Paragraph(new Run(cmiimBaze.ToString("#0.00")))));
                        }
                        else
                        {
                            rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Cmim.ToString("#0.00")))));

                        }
                        rt.Cells[2].TextAlignment = TextAlignment.Right;
                    }
                    gr.Rows.Add(rt);

                }

                TableRow rline = new TableRow();
                rline.FontSize = 14;
                rline.FontWeight = FontWeights.ExtraBold;
                if (RegisterData.SHOW_PRICE == 1)
                {
                    rline.Cells.Add(new TableCell(new Paragraph(new Run("========================="))));
                    rline.Cells[0].ColumnSpan = 3;
                }
              
               
                gr.Rows.Add(rline);

                if (RegisterData.SHOW_PRICE == 1)
                {
                    TableRow rf = new TableRow();
                    rf.FontSize = 14;
                    rf.FontWeight = FontWeights.Bold;
                    rf.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
                    rf.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                    rf.Cells.Add(new TableCell(new Paragraph(new Run(part.Value.Select(x => x.Cmim * x.Sasi).Sum().ToString("#0.00")))));
                    rf.Cells[0].TextAlignment = TextAlignment.Left;
                    rf.Cells[2].TextAlignment = TextAlignment.Right;
                    gr.Rows.Add(rf);
                }


                t.RowGroups.Add(gr);
                document.Blocks.Add(t);


                Paragraph footerparagraph = new Paragraph(new Run(footer));
                footerparagraph.FontSize = 14;
                document.Blocks.Add(footerparagraph);
                document.Blocks.Add(new Paragraph(new Run("")));
                document.Blocks.Add(new Paragraph(new Run("")));

                string printer;
                try
                {
                    printer = part.Key;
                }
                catch
                {
                    printer = "NONE";
                }
              
                listameDoc.Add(printer,document);
                // Document = document;

            }

            return listameDoc;


        }


 

        public FlowDocument getFaturePermbledheseReceipment(string username)
        {
           
            FaturePreview fature = FatureData;

            FlowDocument document = new FlowDocument();
            document.PageWidth = 290;
            document.FontFamily = new FontFamily("MonoSpaced Sans Serif");

            string head = RegisterData.BILL_HEADER;
            string footer = RegisterData.BILL_FOOTER;
            //image or text in header
            if (RegisterData.Image == null)
            {
                Paragraph p = new Paragraph(new Run(head));
                p.FontSize = 18;
                p.FontWeight = FontWeights.Bold;
                p.TextAlignment = TextAlignment.Center;
                document.Blocks.Add(p);

            }
            else
            {

                Image image = new Image();
                image.Source = ImageConverter.LoadImage(RegisterData.Image);

                image.MaxHeight = 50;
                BlockUIContainer container = new BlockUIContainer(image);

                //Paragraph imageparagraph = new Paragraph(container);
                //imageparagraph.TextAlignment = TextAlignment.Center;

                document.Blocks.Add(container);
            }


            //paragrafi i permbledheses 

            Paragraph permbtext = new Paragraph(new Run("Fature permbledhese"));
            permbtext.FontSize = 13;
            permbtext.FontWeight = FontWeights.ExtraBold;
            
            


            document.Blocks.Add(permbtext);
            //shtimi i dates,kamarierit ,tavolones

            Table headtable = new Table();
            headtable.FontSize = 15;
            //add 2 column
            headtable.Columns.Add(new TableColumn());
            headtable.Columns.Add(new TableColumn());

            TableRowGroup headtablerowgr = new TableRowGroup();
            TableRow row1ht = new TableRow();
            row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Kamarieri: " + username))));
            row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Tavolina:" + fature.TavolineNr))));
            TableRow row2ht = new TableRow();

            row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Data:" + DateTime.Now.Date.ToShortDateString()))));
            row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Ora:" +DateTime.Now.ToShortTimeString()))));
            TableRow row3ht = new TableRow();

            row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Nr.Fat: " + fature.Id))));
            row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Banaku: " + RegisterData.PosName))));
            headtablerowgr.Rows.Add(row1ht);
            headtablerowgr.Rows.Add(row2ht);
            headtablerowgr.Rows.Add(row3ht);
            headtable.RowGroups.Add(headtablerowgr);

            document.Blocks.Add(headtable);

            //Paragraph w = new Paragraph(new Run("Kamarieri:" + m.UserName + " " + "Tavolina : ? "));
            //w.FontSize = 11;
            //document.Blocks.Add(w);


            Table t = new Table();
            // t.TextAlignment = TextAlignment.Center;
            t.BorderBrush = Brushes.Gray;

            for (int i = 0; i < 3; i++)
            {
                t.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
            }

            TableRowGroup gr = new TableRowGroup();

            TableRow r1 = new TableRow();

            r1.FontSize = 14;
            r1.FontWeight = FontWeights.Bold;
            r1.Cells.Add(new TableCell(new Paragraph(new Run("EMRI"))));
            r1.Cells.Add(new TableCell(new Paragraph(new Run("SASIA"))));
            r1.Cells.Add(new TableCell(new Paragraph(new Run("CMIMI"))));
            r1.Cells[0].TextAlignment = TextAlignment.Left;
            r1.Cells[1].TextAlignment = TextAlignment.Center;
            r1.Cells[2].TextAlignment = TextAlignment.Right;

            gr.Rows.Add(r1);
            foreach (var item in fature.FatureBody)
            {
                TableRow rt = new TableRow();
                rt.FontSize = 14;
                rt.FontWeight = FontWeights.Regular;
                rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Asortimenti.ToString()))));

                if (item.Njesi.Equals("g") || item.Njesi.Equals("ml"))
                {
                    double sasiBaze = Convert.ToDouble(item.SASI) / 1000;
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(sasiBaze.ToString()))));
                }
                else
                {
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Sasi.ToString()))));
                }



                if (item.Njesi.Equals("g") || item.Njesi.Equals("ml"))
                {

                    double cmiimBaze = Convert.ToDouble( item.Cmim) * 1000;
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(cmiimBaze.ToString("#0.00")))));
                }
                else
                {
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Cmim.ToString("#0.00")))));

                }
                
                rt.Cells[0].TextAlignment = TextAlignment.Left;
                rt.Cells[1].TextAlignment = TextAlignment.Center;
                rt.Cells[2].TextAlignment = TextAlignment.Right;
                gr.Rows.Add(rt);

            }

            TableRow rline = new TableRow();
            rline.FontSize = 14;
            rline.FontWeight = FontWeights.ExtraBold;
            rline.Cells.Add(new TableCell(new Paragraph(new Run("========================="))));
            rline.Cells[0].ColumnSpan = 3;
            gr.Rows.Add(rline);


            TableRow rf = new TableRow();
            rf.FontSize = 14;
            rf.FontWeight = FontWeights.Bold;
            rf.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
            rf.Cells.Add(new TableCell(new Paragraph(new Run(""))));
            rf.Cells.Add(new TableCell(new Paragraph(new Run(fature.getTotal().ToString("#0.00")))));
            rf.Cells[0].TextAlignment = TextAlignment.Left;
            rf.Cells[2].TextAlignment = TextAlignment.Right;
            gr.Rows.Add(rf);


            t.RowGroups.Add(gr);
            document.Blocks.Add(t);


            Paragraph footerparagraph = new Paragraph(new Run(footer));
            footerparagraph.FontSize = 14;
            document.Blocks.Add(footerparagraph);
            document.Blocks.Add(new Paragraph(new Run("")));
            document.Blocks.Add(new Paragraph(new Run("")));


            Document = document;

            return document;

        }
        public static FlowDocument getPreviewFature(string HeadText,string FooterText,ImageSource imagesrc)
        {


            int COLUMNNUMBER = 2;
            if (RegisterData.SHOW_PRICE == 1)
            {
                COLUMNNUMBER = 3;
            }

            FlowDocument document = new FlowDocument();
            document.PageWidth = 290;
            

            string head = HeadText;
            string footer = FooterText;
            //header part,image or text

            if (imagesrc == null)
            {
                Paragraph p = new Paragraph(new Run(head));
                p.TextAlignment = TextAlignment.Center;
                document.Blocks.Add(p);

            }
            else
            {

                Image image = new Image();
                image.Source = imagesrc;
                image.MaxHeight = 50;
                
                BlockUIContainer container = new BlockUIContainer(image);
                
                //Paragraph imageparagraph = new Paragraph(container);
                //imageparagraph.TextAlignment = TextAlignment.Center;
                
                document.Blocks.Add(container);
            }

            //shtimi banakut    
            

            //shtimi i dates,kamarierit ,tavolones

            Table headtable = new Table();
            headtable.FontSize = 11;
            //add 2 column
            headtable.Columns.Add(new TableColumn());
            headtable.Columns.Add(new TableColumn());

            TableRowGroup headtablerowgr = new TableRowGroup();
            TableRow row1ht = new TableRow();
            row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Kamarieri: " + "[emer]"))));
            row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Tavolina:" +"1"))));
            TableRow row2ht = new TableRow();
            row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Data:" + DateTime.Now.ToShortDateString()))));
            row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Ora:" + DateTime.Now.ToShortTimeString()))));

            TableRow row3ht = new TableRow();

            row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Nr.Fat:[numer] " ))));
            row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Banaku: " + RegisterData.PosName))));
            headtablerowgr.Rows.Add(row1ht);
            headtablerowgr.Rows.Add(row2ht);
            headtablerowgr.Rows.Add(row3ht);
            headtable.RowGroups.Add(headtablerowgr);

            document.Blocks.Add(headtable);

            //bodypart
            Table t = new Table();
           
            t.BorderBrush = Brushes.Gray;

            for (int i = 0; i < COLUMNNUMBER; i++)
            {
                t.Columns.Add(new TableColumn());
            }

            TableRowGroup gr = new TableRowGroup();
            TableRow r1 = new TableRow();
            r1.FontSize = 12;
            r1.FontWeight = FontWeights.Bold;
            r1.Cells.Add(new TableCell(new Paragraph(new Run("EMRI"))));
            r1.Cells.Add(new TableCell(new Paragraph(new Run("SASIA"))));
         
            r1.Cells[0].TextAlignment = TextAlignment.Left;
            r1.Cells[1].TextAlignment = TextAlignment.Center;
            if (RegisterData.SHOW_PRICE == 1)
            {
                r1.Cells.Add(new TableCell(new Paragraph(new Run("CMIMI"))));
                r1.Cells[2].TextAlignment = TextAlignment.Right;
            }
       
            gr.Rows.Add(r1);
            for(int i=0;i<3;i++)
            {
                TableRow rt = new TableRow();
                rt.FontSize = 12;
                rt.Cells.Add(new TableCell(new Paragraph(new Run("item"+i))));
                rt.Cells.Add(new TableCell(new Paragraph(new Run(""+i))));
               
                rt.Cells[0].TextAlignment = TextAlignment.Left;
                rt.Cells[1].TextAlignment = TextAlignment.Center;
                if (RegisterData.SHOW_PRICE == 1)
                {
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(i + "0"))));
                    rt.Cells[2].TextAlignment = TextAlignment.Right;
                }
                gr.Rows.Add(rt);

            }

            if (RegisterData.SHOW_PRICE == 1)
            {
                TableRow rline = new TableRow();
                rline.FontSize = 12;
                rline.FontWeight = FontWeights.ExtraBold;
                rline.Cells.Add(new TableCell(new Paragraph(new Run("============================="))));
                rline.Cells[0].ColumnSpan = 3;
                gr.Rows.Add(rline);



                TableRow rf = new TableRow();
                rf.FontSize = 12;
                rf.FontWeight = FontWeights.Bold;
                rf.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
                rf.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                rf.Cells.Add(new TableCell(new Paragraph(new Run("30"))));
                rf.Cells[0].TextAlignment = TextAlignment.Left;
                rf.Cells[2].TextAlignment = TextAlignment.Right;
                gr.Rows.Add(rf);
            }


            t.RowGroups.Add(gr);
            document.Blocks.Add(t);


            Paragraph footerparagraph = new Paragraph(new Run(footer));
            document.Blocks.Add(footerparagraph);
            document.Blocks.Add(new Paragraph(new Run("")));
            document.Blocks.Add(new Paragraph(new Run("")));

            return document;
        }

        public List<FlowDocument> getFatureReceipmentAccordTime()
        {
            List<FlowDocument> listameDoc = new List<FlowDocument>();
          
            int nr = 0;
            
            var l = FatureService.ktheFatureTeNdareSipasKohes(FatureData.FatureBody);
          
            

            foreach (var part in l)
            {

                //merr daten e 1 ose disa rreshtave,data eshtenjelloj,data e grupimit
                var DataNenGrup = part.FirstOrDefault().Date;


                nr++;
              
                FaturePreview fature = FatureData;

                FlowDocument document = new FlowDocument();
                document.PageWidth = 290;
                document.FontFamily = new FontFamily("MonoSpaced Sans Serif");

                string head = RegisterData.BILL_HEADER;
                string footer = RegisterData.BILL_FOOTER;
                //image or text in header
                if (RegisterData.Image == null)
                {
                    Paragraph p = new Paragraph(new Run(head));
                    p.FontSize = 18;
                    p.FontWeight = FontWeights.Bold;
                    p.TextAlignment = TextAlignment.Center;
                    document.Blocks.Add(p);

                }
                else
                {

                    Image image = new Image();
                    image.Source = ImageConverter.LoadImage(RegisterData.Image);

                    image.MaxHeight = 50;
                    BlockUIContainer container = new BlockUIContainer(image);


                    document.Blocks.Add(container);
                }

                //shtimi i dates,kamarierit ,tavolones

                Table headtable = new Table();
                headtable.FontSize = 15;
                //add 2 column
                headtable.Columns.Add(new TableColumn());
                headtable.Columns.Add(new TableColumn());

                TableRowGroup headtablerowgr = new TableRowGroup();
                TableRow row1ht = new TableRow();
                row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Kamarieri: " + fature.UserName))));
                row1ht.Cells.Add(new TableCell(new Paragraph(new Run("Tavolina:" + fature.TavolineNr))));
                TableRow row2ht = new TableRow();

                row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Data:" + DataNenGrup.Date.ToShortDateString()))));
                row2ht.Cells.Add(new TableCell(new Paragraph(new Run("Ora:" +  DataNenGrup.ToShortTimeString()))));
                TableRow row3ht = new TableRow();
                var seq = string.Empty;
               
                    seq = "_" + nr;
                        
                 
                

                row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Nr.Fat: " + fature.Id+seq))));
                row3ht.Cells.Add(new TableCell(new Paragraph(new Run("Banaku: " + RegisterData.PosName))));
                headtablerowgr.Rows.Add(row1ht);
                headtablerowgr.Rows.Add(row2ht);
                headtablerowgr.Rows.Add(row3ht);
                headtable.RowGroups.Add(headtablerowgr);

                document.Blocks.Add(headtable);
                Table t = new Table();
                // t.TextAlignment = TextAlignment.Center;
                t.BorderBrush = Brushes.Gray;

                for (int i = 0; i < 3; i++)
                {
                    t.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
                }

                TableRowGroup gr = new TableRowGroup();

                TableRow r1 = new TableRow();

                r1.FontSize = 14;
                r1.FontWeight = FontWeights.Bold;
                r1.Cells.Add(new TableCell(new Paragraph(new Run("EMRI"))));
                r1.Cells.Add(new TableCell(new Paragraph(new Run("SASIA"))));
                r1.Cells.Add(new TableCell(new Paragraph(new Run("CMIMI"))));
                r1.Cells[0].TextAlignment = TextAlignment.Left;
                r1.Cells[1].TextAlignment = TextAlignment.Center;
                r1.Cells[2].TextAlignment = TextAlignment.Right;

                gr.Rows.Add(r1);
                foreach (var item in part)
                {
                    TableRow rt = new TableRow();
                    rt.FontSize = 14;
                    rt.FontWeight = FontWeights.Regular;
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Asortimenti))));
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Sasi.ToString()))));
                    rt.Cells.Add(new TableCell(new Paragraph(new Run(item.Cmim.ToString("#0.00")))));
                    rt.Cells[0].TextAlignment = TextAlignment.Left;
                    rt.Cells[1].TextAlignment = TextAlignment.Center;
                    rt.Cells[2].TextAlignment = TextAlignment.Right;
                    gr.Rows.Add(rt);

                }

                TableRow rline = new TableRow();
                rline.FontSize = 14;
                rline.FontWeight = FontWeights.ExtraBold;
                rline.Cells.Add(new TableCell(new Paragraph(new Run("========================="))));
                rline.Cells[0].ColumnSpan = 3;
                gr.Rows.Add(rline);


                TableRow rf = new TableRow();
                rf.FontSize = 14;
                rf.FontWeight = FontWeights.Bold;
                rf.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
                rf.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                rf.Cells.Add(new TableCell(new Paragraph(new Run(part.Select(x=>x.Cmim*x.Sasi).Sum().ToString("#0.00")))));
                rf.Cells[0].TextAlignment = TextAlignment.Left;
                rf.Cells[2].TextAlignment = TextAlignment.Right;
                gr.Rows.Add(rf);


                t.RowGroups.Add(gr);
                document.Blocks.Add(t);


                Paragraph footerparagraph = new Paragraph(new Run(footer));
                footerparagraph.FontSize = 14;
                document.Blocks.Add(footerparagraph);
                document.Blocks.Add(new Paragraph(new Run("")));
                document.Blocks.Add(new Paragraph(new Run("")));

                listameDoc.Add(document);
               // Document = document;

            }

          return  listameDoc;

        }
    }
}
