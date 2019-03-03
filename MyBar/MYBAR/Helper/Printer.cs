using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MYBAR.Helper
{
   public class Printer
    {


        public static void PrintFlowDocument(Dictionary<string,FlowDocument> documents,bool inkase)
        {


            foreach (var item in documents)
            {



                // Create a PrintDialog
                PrintDialog printDlg = new PrintDialog();

                //printDlg.ShowDialog();
                // Create a FlowDocument dynamically.

                 if(item.Key!="NONE")
                {
                    printDlg.PrintQueue = new System.Printing.PrintQueue(new System.Printing.PrintServer(), item.Key);
                }


                // Create IDocumentPaginatorSource from FlowDocument
                IDocumentPaginatorSource idpSource = item.Value;




                try
                {
                    // Call PrintDocument method to send document to printer
                    printDlg.PrintDocument(idpSource.DocumentPaginator, "Fature");
                }
                catch
                {

                }
            }
           

            //TestFature t = new TestFature();

            //t.PrintReceipt();


        }

        public static void PrintFlowDocumentOneCopy(FlowDocument document)
        {
            // Create a PrintDialog
            PrintDialog printDlg = new PrintDialog();

            //printDlg.ShowDialog();
            // Create a FlowDocument dynamically.



            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = document;
          

            try
            {
                // Call PrintDocument method to send document to printer
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Fature");
            }
            catch
            {

            }


            //TestFature t = new TestFature();

            //t.PrintReceipt();


        }
    }
}
