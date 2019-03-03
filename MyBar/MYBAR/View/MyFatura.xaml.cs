using MYBAR.Helper;
using MYBAR.Interface;
using MYBAR.Model;
using MYBAR.Raports;
using MYBAR.Services;
using MYBAR.View.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for MyFatura.xaml
    /// </summary>
    public partial class MyFatura : UserControl
    {
        private int Index = 0;
        private List<FlowDocument> documentref;
        private FaturaFilterInterface filter;
        public MyFatura(FaturaFilterInterface flt)
        {
            InitializeComponent();
            FilterGUI.Content = flt;
            filter = flt;
            LoadMyFatura();
        }

        private void LoadMyFatura()
        {


            var list = filter.getFaturat();

            FaturaList.ItemsSource = list;          
            Totali.Text = list.Where(x => x.Statusi != "Cancelled").Sum(x => x.Total).ToString("#,#0.00");
           
        }

        private void FaturaList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {

                FatureList f = (FatureList)FaturaList.SelectedItem;

                BuildFaturePreview(f.NrFature);
            }

            catch
            {

            }

        }

        public void BuildFaturePreview(int orderid)
        {
            Index = 0;
            ProgresNumber.Content = (Index + 1).ToString();
            FatureBuilder builder = new FatureBuilder(FatureService.getFaturePreview(orderid));
            documentref = builder.getFatureReceipmentAccordTime();
            FaturaShow.Document = documentref[0];
            TotalProgres.Content = documentref.Count;
        }


        public void printSelectedDocument()
        {
           // Printer.PrintFlowDocument(documentref,false);
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            printSelectedDocument();
        }

        private void Filtro_Click(object sender, RoutedEventArgs e)
        {
            LoadMyFatura();
        }

        private void Anullo_Fature_Click(object sender, RoutedEventArgs e)
        {


            try
            {

                FatureList f = (FatureList)FaturaList.SelectedItem;
                if (f.Statusi.Equals("Closed"))
                {

                    if (OrderForCancellationService.IsRequestedForCancel(f.NrFature))

                    {
                        MessageBox.Show("Eshte bere nje kerkese per anullim per kete fature !");
                        return;
                    }





                    AnulloFature anulloDialog = new AnulloFature();

                    anulloDialog.ShowDialog();
                    string notes = anulloDialog.ArsyejaText.Text;
                    if (anulloDialog.IsCancel)
                    {


                        OrderForCancellationService.addOrderForCancellation(new OrderForCancellationModel { OrderId = f.NrFature, Data = DateTime.Now });
                     
                    }

                }
                else if (f.Statusi == "Cancelled")
                {
                    MessageBox.Show("Kjo Fature Eshte e Anulluar Tashme !");
                }
                else if (f.Statusi == "Pending")
                {
                    MessageBox.Show("Duhet te mbyllesh njehere tavolinen me kete fature dhe pastaj te beni kerkese per anullim !");

                }

            }
            catch(Exception ex)
            {

               
            }


        }

        private void Pas_Click(object sender, RoutedEventArgs e)
        {
            if (documentref !=null)
            {

                if (Index >= 1)
                {
                    Index--;
                    ProgresNumber.Content = (Index + 1);
                    FaturaShow.Document = documentref[Index];

                }

            }
        }

        private void Para_Click(object sender, RoutedEventArgs e)
        {

            if (documentref != null)
            {
                if (Index + 1 < documentref.Count)
                {
                    Index++;
                    ProgresNumber.Content = (Index + 1);
                    FaturaShow.Document = documentref[Index];
                }
            }
        }

        private void FaturaShow_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.P && Keyboard.Modifiers == ModifierKeys.Control)
                e.Handled = true;
        }
    }
}
