using MYBAR.CustomControls;
using MYBAR.CustomControls.FatureFilter;
using MYBAR.Helper;
using MYBAR.Model.SyncModel;
using MYBAR.Model.UserRights;
using MYBAR.View.Artikuj;
using MYBAR.View.Inventar;
using MYBAR.View.KerkoDialog;
using MYBAR.View.Other;
using MYBAR.View.Perdorues;
using MYBAR.View.Porosi;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {


        private Button LastClickedButton = new Button();
        public MainView()
        {
            InitializeComponent();
          
            //SET REFERENCE OF MAIN WINDOWS
            MainWindow M = (MainWindow)App.Current.MainWindow;
            M.CenterWindow = this;
            Dependency.MAIN_VIEW = this;

            //set default values to controllers
            PorosiNumber.Text = M.PorosiNewNumber.ToString();
            DataInventarit.SelectedDate = DateTime.Now.Date;

            //set gui rights
            RightsToGUI();

            //nese ka artikuj nen vler en minimale shfaqen

            if (M.CurrentUser.getMyRights().NotifyForMinimumAArtikuj)
            {
                Thread th = new Thread(LoadMinumumArtikuj);
                th.Start();
            }
          


        }

        private void LoadMinumumArtikuj()
        {

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
              (ThreadStart)delegate ()
                {
                    MinimumQuantityArtikuj dialog = new MinimumQuantityArtikuj(((MainWindow)App.Current.MainWindow).UserId);
                    if (dialog.anullimet.Count > 0 || dialog.list.Count > 0)
                    {
                        dialog.ShowDialog();
                    }
                }
);
            
        }

        public void RightsToGUI()
        {
            MainWindow M = (MainWindow)App.Current.MainWindow;
            Rights r = M.CurrentUser.getMyRights();
            Raporte.Visibility = r.XhiroDitorePerdorues;
            ListaArtikuve.Visibility = r.ListaArtikuve;
            FaturaKonfig.Visibility = r.FaturaKonfig;
            KonfigurimeMenu.Visibility = r.KonfigurimeMenu;
            ArtikujMenu.Visibility = r.ArtikujMenu;
            RaporteMenu.Visibility = r.Raportemenu;
            FaturaMenu.Visibility = r.FaturaMenu;
            Raporte.Visibility = r.RaporteButton;
            Notifications.Visibility = r.RaporteButton;
            Users.Visibility = r.RaporteButton;
            //Faturat.Visibility = r.FaturaBtn;
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Content = new LoginView();
            MainWindow M = (MainWindow)App.Current.MainWindow;
            M.UserId = "";
        }

        private void Tavolina_Click(object sender, RoutedEventArgs e)
        {

            SetBackGroundSelectedButton(sender);

            PrepareEvent(WindowType.Tavolina);


        }

        public void GoToTableMenu()
        {
            Tavolina_Click(null, null);
        }

        private void Faturat_Click(object sender, RoutedEventArgs e)
        {
            SetBackGroundSelectedButton(sender);
            PrepareEvent(WindowType.Fatura);
        }



        private void Raporte_Click(object sender, RoutedEventArgs e)
        {
            SetBackGroundSelectedButton(sender);
            PrepareEvent(WindowType.Raporte);
        }

        private void FaturaKonfig_Click(object sender, RoutedEventArgs e)
        {
            FatureDetailsView fdetail = new FatureDetailsView();
            AddToWindow(fdetail);
        }

        private void ListaArtikuve_Click(object sender, RoutedEventArgs e)
        {
            PrepareEvent(WindowType.ListaArtikuj);
        }

        public void Furnizim_Click(object sender, RoutedEventArgs e)
        {

            PrepareEvent(WindowType.Furnizim);

        }


        public void GoToFatureHyrjeFromExternal()
        {
            WindowUser.Content = new FleteHyrje();
        }

        private void InventarRaport_Click(object sender, RoutedEventArgs e)
        {
           

            PrepareEvent(WindowType.Inventar);

        }

        private void Xhiroditore_Click_1(object sender, RoutedEventArgs e)
        {




            Fitimi f = new Fitimi();
            AddToWindow(f);
        }

        private void MbyllTurnin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow M = (MainWindow)App.Current.MainWindow;
            MbyllTurnin t = new View.MbyllTurnin(BackgroundWorker.getXhiroDitore().XhiroReale,BackgroundWorker.getXhiroDitore().XhiroKaseFiskale, M.UserId);
            t.ShowDialog();

            Tavolina_Click(null, null);
        }

        private void Turnet_Click(object sender, RoutedEventArgs e)
        {


            AddToWindow(new Turnet());
        }

        private void SHITJETAr_Click(object sender, RoutedEventArgs e)
        {

            PrepareEvent(WindowType.Shitjet);

        }


        public void SetBackGroundSelectedButton(object button)
        {

            if (button == null)
                return;
            LastClickedButton.BorderThickness = new Thickness(0);
            var btn = button as Button;
            btn.BorderThickness = new Thickness(2);
            LastClickedButton = btn;
        }


        public void AddToWindow(UserControl c)
        {

            WindowUser.Content = c;
         
        }

        public void PrepareEvent(WindowType t)
        {


            WindowUser.Content = new Loading();
            Thread thread = new Thread(() => AddAsync(t));
            thread.Start();
        }

        public void AddAsync(WindowType t)
        {

            UserControl u = null;
            //SLLEP FOR TESTING


            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            (ThreadStart)delegate ()
            {

                switch (t)
                {
                    case WindowType.Tavolina:
                        u = new Tavolinat();
                        break;
                    case WindowType.Inventar:
                        u = new ReportViewer(Services.RaporteService.getInventarRaportByDate(DataInventarit.SelectedDate??DateTime.Now));
                        break;
                    case WindowType.Fatura:
                        u = new MyFatura(new FatureUserFilter());
                        break;
                    case WindowType.Raporte:
                        u = new ShitjetArtikuj();
                        break;
                    case WindowType.ListaArtikuj:
                        u = new ArtikujList();
                        break;
                    case WindowType.Furnizim:
                        u = new FleteHyrje();
                        break;
                    case WindowType.Shitjet:
                        u = new ShitjetArtikuj();
                        break;
                    case WindowType.Tutorial:
                        //u = new WebBroswer();
                        u = new About();
                        break;
                    case WindowType.Porosi:
                        u = new PorosiView();
                        break;

                    default:
                        u = new UserControl();

                        break;

                }
                WindowUser.Content = u;
              
            }
);


        }

        public enum WindowType
        {
            Inventar,
            Tavolina,
            Fatura,
            Raporte,
            ListaArtikuj,
            Furnizim,
            Shitjet,
            Tutorial,
            Porosi
        }

        private void Tutorial_Click(object sender, RoutedEventArgs e)
        {
            SetBackGroundSelectedButton(sender);
            PrepareEvent(WindowType.Tutorial);
        }

        private void PorositeOnline_Click(object sender, RoutedEventArgs e)
        {
            SetBackGroundSelectedButton(sender);
            ((MainWindow)App.Current.MainWindow).PorosiNewNumber = 0;
            PorosiNumber.Text = "0";
            WindowUser.Content = new PorosiView();
            
        }

        private void ArtikullHitory_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content = new ArtikullHistory();
        }

        private void KasaConfig_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content = new Settings();
        }

        private void Lista_e_Faturave_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content = new MyFatura(new FatureAdminFilter());
        }

        private void ExelImport_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content = new ExcelImport();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GoToTableMenu();
            //messagebar for kasa
            if (RegisterData.IsKasaActive)
            {
                KasaNote.Fill = Brushes.Green;
                
            }
            else
            {
                KasaNote.Fill = Brushes.OrangeRed;
            }

            if (RegisterData.ShowAllBillTypes)
            {
                KasaShow.Fill = Brushes.OrangeRed;
            }
            else
            {
                KasaShow.Fill = Brushes.Green;
            }
        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            MinimumQuantityArtikuj dialog = new MinimumQuantityArtikuj(((MainWindow)App.Current.MainWindow).UserId);
            dialog.ShowDialog();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content = new ChangePassword();
        }

        private void KorrigjimInventari_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content = new KorrigjimInventariView();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content = new UserView();
        }

        private void MyTest_Click(object sender, RoutedEventArgs e)
        {
            //CollectViewModel c = new CollectViewModel();

            //c.Orders.Add(new LocalOrderViewModel { Local_Id = 17300, Table_Id = 123 });


            //SyncingWorker.TestKorrogjo(c);

         //   SyncingWorker.SyncOrderNoAsync(new NewOrderViewModel());
        }

        private void TeTjera_Click(object sender, RoutedEventArgs e)
        {
            WindowUser.Content =new  OtherConfigView();
        }
    }
}
