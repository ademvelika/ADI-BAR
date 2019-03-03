using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Artikuj;
using MYBAR.Model.FatureModel;
using MYBAR.Raports;
using MYBAR.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MYBAR.View.KerkoDialog
{
    /// <summary>
    /// Interaction logic for MinimumQuantityArtikuj.xaml
    /// </summary>
    public partial class MinimumQuantityArtikuj : Window
    {

        public List<ArtikullListRow> list;
        public List<AnullimFatureModel> anullimet;
        public AnullimFatureModel selecteditem;
        public string UserId;
        public MinimumQuantityArtikuj(string userid)
        {
            InitializeComponent();
            UserId = userid;
            list = ArtikullService.getMenuItemsInMinimumQuantity();
            anullimet = FatureService.getOrderForCancellation();
           

                if (anullimet.Count > 0)
                {
                    AnullimeTab.Background = Brushes.OrangeRed;
                 
                }
                Lista.ItemsSource = list;
                KerkesaPerAnullimList.ItemsSource = anullimet;
               
            
            
        }

        private void BejFurnizim_Click(object sender, RoutedEventArgs e)
        {
            FatureHyrje f = new FatureHyrje();
            foreach (var item in list)
            {

                f.ReferenceFatureRows.Add(new Model.FatureRow {Productid=item.ProduktId,ProductOnlineId=item.OnlineProductid,CMIM=item.Cmimi,Asortimenti=item.Asortimenti });

            }
            Close();
            Dependency.FromMinimumListArtikujtToFatureHyrje(f);

           
        }

        private void KerkesaPerAnullimList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {

                AnullimFatureModel f = (AnullimFatureModel)KerkesaPerAnullimList.SelectedItem;
                selecteditem = f;
                BuildFaturePreview(f.NrFature);
                Anullo.Visibility = Visibility.Visible;
            }

            catch
            {

            }
        }

        public void BuildFaturePreview(int orderid)
        {
            var fature = FatureService.getFaturePreview(orderid);
            FatureBuilder builder = new FatureBuilder(fature);
            FaturaShow.Document = builder.getFaturePermbledheseReceipment("");
         
        }

        private void Anullo_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
              
           
                    OrderForCancellationService.DeleteOrderForCancellation(new OrderForCancellationModel { Id = selecteditem.NrFature, OrderId = selecteditem.NrFature });
                    FinanceService.CalculateXhiroDitore();
                    KerkesaPerAnullimList.ItemsSource = FatureService.getOrderForCancellation();
                    Anullo.Visibility = Visibility.Hidden;
                    FaturaShow.Document = null;
                
                
            }
            catch
            {

            }

        }

        private void Dil_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
