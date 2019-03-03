using MYBAR.CustomControls;
using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Porosi;
using MYBAR.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MYBAR.View.Porosi
{
    /// <summary>
    /// Interaction logic for Porosi.xaml
    /// </summary>
    public partial class PorosiView : UserControl
    {
        private LoadingDialog dialog;
        private ClientOrderModel selectedOrder { get; set; }
        private List<ClientOrderDetailsModel> selectedOrderDetail { get; set; }
        public PorosiView()
        {
            InitializeComponent();

            dialog = new LoadingDialog();

            Thread th = new Thread(LoadPorosi);
            th.Start();
            dialog.ShowDialog();

            LoadFreeTables();

        }


        private void LoadFreeTables()
        {

            List<ComboBoxData> l = TavolinaService.getFreeTables(0);

            FreeTable.ItemsSource = l;

        }
        private void LoadPorosi()
        {

             var list= SyncingWorker.getAllClientPorosi().OrderByDescending(x=>x.Order_Time);
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                 (ThreadStart)delegate ()
                 {
                     PorositeDG.ItemsSource = list;
                     dialog.Close();
                 }
                    );

           
        }


        public void ShowPorosiFromNotification(int id)
        {

            var list = PorositeDG.ItemsSource.Cast<ClientOrderModel>().ToList();
            PorositeDG.SelectedItem = list.Where(x => x.Id == id).FirstOrDefault();

            PorositeDG_MouseLeftButtonDown(null, null);
        }

        private void PorositeDG_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

           selectedOrder = (ClientOrderModel)PorositeDG.SelectedItem;

            if(selectedOrder!=null)
            {
                selectedOrderDetail= SyncingWorker.getClientPorosiDetails(selectedOrder.Id).ToList();
               
                PorosiBody.ItemsSource = selectedOrderDetail;

                Total.Text = selectedOrderDetail.Sum(x => x.Quantity * x.SalePrice).ToString("#0,#0.00");

            }

            
        }

        private void Aprovo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow M = (MainWindow)App.Current.MainWindow;
            if (M.UserId == M.MenagerUserId)
            {
                MessageBox.Show("Ju nuk keni te drejta qe te aprovoni porosi");

                return;
            }


            int tavolineid, OnlineTavolineId;

            var selectedtable = (ComboBoxData)FreeTable.SelectedItem;

            if (selectedtable == null)
            {
                MessageBox.Show("Duhet te zgjidhni nje tavoline per porosine !");

                return;
            }
            
            tavolineid = selectedtable.DataValue;
            OnlineTavolineId = selectedtable.DataValueOnline;


            FatureNew newfature = new FatureNew(tavolineid,OnlineTavolineId);
           
            

            var list = ArtikullService.getMenuItemsWithOnlineId(selectedOrderDetail.Select(x => x.MenuItem_Id).ToList());

            foreach (var item in selectedOrderDetail)
            {

                var temp = list.Where(x => x.ProductOnlineId == item.MenuItem_Id).SingleOrDefault();

                newfature.ReferenceFatureRows.Add(new FatureRow {Productid=temp.Productid,ProductOnlineId=item.MenuItem_Id,Sasi=item.Quantity,Cmim=item.SalePrice });

            }
            //get response from server and save locally

            if(SyncingWorker.ChangeStatusClientOrder(new Model.SyncModel.UpdateClientOrderViewModel { ClientOrder_Id = selectedOrder.Id, OrderStatus_Id = 14 }).Result)
            {
                newfature.Save();
            }
            else
            {
                MessageBox.Show("Kjo porosi eshte perpunuar njehere,rifrekoni dritaren per te pare ndryshimet");
            }
           
    

        }

        private void Refuzo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = (MainWindow)App.Current.MainWindow;
            if (M.UserId == M.MenagerUserId)
            {
                MessageBox.Show("Ju nuk keni te drejta qe te refuzoni porosi");

                return;
            }


            if (selectedOrder != null)
            {
                if (SyncingWorker.ChangeStatusClientOrder(new Model.SyncModel.UpdateClientOrderViewModel { ClientOrder_Id = selectedOrder.Id, OrderStatus_Id = 13 }).Result)
                {
                    MessageBox.Show("Porosia u anullua !");
                }
                else
                {
                    MessageBox.Show("Kjo porosi eshte perpunuar njehere,rifrekoni dritaren per te pare ndryshimet");
                }

            }

        }
    }
}
