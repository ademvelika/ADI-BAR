using MYBAR.CustomControls;
using MYBAR.Helper;
using MYBAR.Model.Artikuj;
using MYBAR.Model.FatureModel;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MYBAR.View.Artikuj
{
    /// <summary>
    /// Interaction logic for KorrigjimInventariView.xaml
    /// </summary>
    public partial class KorrigjimInventariView : UserControl
    {
        private string SearchTerm;
        private int SearchNumber;
        private List<KorrigjimInventariModel> searchList;
        private int Index;
        LoadingDialog load;
        public KorrigjimInventariView()
        {
            InitializeComponent();



        }


        private void search()
        {
            List<KorrigjimInventariModel> list = (List<KorrigjimInventariModel>)KorrigjimList.ItemsSource;

            KorrigjimList.SelectedItems.Clear();
            searchList.Clear();
            SearchNumber = 0;
            Index = 0;
            SearchTerm = SearchBox.Text;
            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].Emri.ToLower().Contains(SearchBox.Text.ToLower()))
                {
                    SearchNumber++;
                    
                    searchList.Add(list[i]);

                }
                Number.Text = SearchNumber.ToString();
                FindPrevious.IsEnabled = searchList.Count > 0;


                
            }
            Indeks.Text = Index.ToString();
            if (searchList.Count > 0)
            {
                KorrigjimList.ScrollIntoView(searchList[Index]);
                KorrigjimList.SelectedItem = searchList[Index];
                Indeks.Text = (Index + 1).ToString();
            }
        }
        private void SearchBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                search();
                }



            }
        

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            KorrigjimList.ItemsSource = ArtikullService.getKorrigjimInventariList();

            searchList = new List<KorrigjimInventariModel>();
            Index = 0;
            SearchTerm = "";
        }

        private void FindNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SearchTerm != SearchBox.Text)
            {
                search();
                
                
            }

           
            if (Index+1 < searchList.Count)
            {
                Indeks.Text = (Index + 2).ToString();
                Index++;
                
                KorrigjimList.ScrollIntoView(searchList[Index]);
                KorrigjimList.SelectedItem = searchList[Index];
                
            }
            
    

        }

        private void FindPrevious_Click(object sender, RoutedEventArgs e)
        {
            
            if (Index-1 >= 0 && Index-1 < searchList.Count)
            {
                Indeks.Text = (Index).ToString();

                Index--;
                
                KorrigjimList.ScrollIntoView(searchList[Index]);
                KorrigjimList.SelectedItem = searchList[Index];
                
            }
        }

        private void KorrigjoInventar_Click(object sender, RoutedEventArgs e)
        {

           load  = new LoadingDialog();
            List<KorrigjimInventariModel> list = (List<KorrigjimInventariModel>)KorrigjimList.ItemsSource;

            var m = (MainWindow)App.Current.MainWindow;
            Thread th = new Thread(()=>Save(list,m.UserId));

            th.Start();


            load.ShowDialog();
              
        }

        public void Save(List<KorrigjimInventariModel> list,string userid)
        {
            var HyrjeList = list.Where(x => x.Diferenca != 0).ToList();
           // var DaljeList = list.Where(x => x.Diferenca < 0).ToList();

            bool ok=true;

            FatureHyrje fh = null;
            if (HyrjeList.Count > 0)
            {
                fh = new FatureHyrje();
                fh.OrderDate = DateTime.Now;
                fh.OrderNumber = "korrigjim_Inventari=>" + DateTime.Now.ToShortDateString();
                fh.PLACEID = RegisterData.Place_Id;
                fh.User_Id = userid;

                foreach (var item in HyrjeList)
                {
                    fh.ReferenceFatureRows.Add(new Model.FatureRow { Productid = item.ProduktId, ProductOnlineId = item.OnlineProduktId, Sasi = item.Diferenca, Cmim = item.LastBuyPrice });
                }

            }
          

            if (fh != null)
            {
                var response = fh.SyncWithServer();

                if (response == 0)
                {
                    MessageBox.Show(Messages.NO_INTERNET_MESSAGE);
                    load.Close();
                    return;
                }
                fh.FatureOnlineId = response;



              ok = fh.SaveFromKorrigjim(userid);

                 }


            //dalje only commented 
            //if (DaljeList.Count > 0)
            //{
            //   ok=ok&& FatureService.SaveDaljeOnly(DaljeList, userid);

            //}

            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart)delegate ()
                        {
                            

                            if (ok)
                            {
                                MessageBox.Show("Suskes !");
                            }
                            else
                            {
                                MessageBox.Show("Dicka shkoi gabim");
                            }

                            load.Close();

                            KorrigjimList.ItemsSource = ArtikullService.getKorrigjimInventariList();
                        }
                        );

        }
    }
}
