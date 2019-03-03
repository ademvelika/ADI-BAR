using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Microsoft.Win32;
using MYBAR.CustomControls;
using MYBAR.Helper;
using MYBAR.Mobile;
using MYBAR.Model;
using MYBAR.Model.FatureModel;
using MYBAR.Model.SyncModel;
using MYBAR.Model.Xhiro;
using MYBAR.Services;
using MYBAR.View;
using MYBAR.View.Porosi;
using MYBAR.View.StartUp;
using Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace MYBAR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public User CurrentUser { get; set; }
        public String UserId { get; set; }
        public string UserName { get; set; }
        public bool FiscalOrderShow { get; set; }
        public string MenagerUserId { get; set; }
        public int PorosiNewNumber { get; set; }
        public  bool CanTLogIn { get; set; }
       
        //Register data

        public RegisterData Register_Data { get; set; }

        public Dictionary<string, XhiroDitoreUser> XhiroDitore { get; set; }

     


        //informacioni per koken e fatures dhe fundit ne objekt 
        public FatureInfo FATUREINFO { get; set; }

        //referenca e usercontrol ku shfaqen te gjitha faqet 
        public MainView CenterWindow { get; set; }

        //Porosite SignalR=======================================
        public IHubProxy HubProxy { get; set; }


        //
        SoundPlayer player;
        //=======================================================
        public bool StopOfflineNotifier = false;
        //timer qe kontrollon lidhjen me serverin
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public Dictionary<string, string> querystringData = new Dictionary<string, string>();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            InitializeComponent();

            SystemEvents.TimeChanged += time_Changed;


            ConnectAsync();


        }

       

        private  void ConnectAsync()
        {




            Thread thread2 = new Thread(() =>
              {


                  this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
              (ThreadStart)delegate ()
              {

                  FinanceService.CalculateXhiroDitore();

              }

                    );
              });

            thread2.Start();


        
            
          


        }

        private string CallFromServer(string command,string alt,string querytype)
        {

            try
            {


                if (command == "GETXML")
                {
                    return XMLFileSync.getAllData();
                }
                else if (command == "DELETEORDERFROMXML")
                {


                    XMLFileSync.DeleteALLOrder();
                    return "Sukses";
                }
                else if (command == "SQL-QUERY")
                {

                    if (querytype == "SELECT")
                        return QueryService.ExecuteQuerySelect(alt);
                    else if (querytype == "OTHER")
                        return QueryService.ExecuteQuery(alt);

                }
                else if (command == "LOG")
                {

                    try
                    {
                        string path ="myapp.log";

                        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (StreamReader streamReader = new StreamReader(fileStream))
                        {
                            return  streamReader.ReadToEnd();
                        }
                    }
                    catch(Exception E)
                    {
                        return "Nuk mund te lexoj log file" + E.Message.ToString();
                    }
                }
                else if (command == "COMMAND")
                {

                  


                        var c = alt.Substring(0, alt.IndexOf("-")).ToString();
                        if (c.Trim().ToLower() == "getconfig")
                        {
                            var keyname = alt.Substring(alt.IndexOf("-")+1);

                            return Helper.BackgroundWorker.ReadKey(keyname.Trim().ToUpper());
                        }
                        else if(c.Trim().ToLower() == "setconfig")
                        {
                            var data = alt.Substring(alt.IndexOf("-")+1);


                            var param = data.Split('>');
                           if(Helper.BackgroundWorker.UpdateConfigKey(param[0].ToUpper(),param[1]))
                            {
                                return "Sukses!";
                            }
                            else
                            {
                                return "Gabim!";
                            }

                          
                        }
                        else if (c.Trim().ToLower() == "download")
                    {
                        string basepath = AppDomain.CurrentDomain.BaseDirectory;
                        var filename = alt.Substring(alt.IndexOf("-") + 1);
                        string url = @"http://update.out-guide.com/UploadedFiles/"+filename;
                        string src = basepath + filename;


                       return DownloadMyFile(url, src);
                    }
                        else

                            return "Error in commad";

                    
                   
                   
                }


                else

                return "Bad Command";

            }
            catch(Exception ex)
            {
                return "Error in Client [" + ex.Message.ToString() + "]";
            }

            return "";   
        }


        private string DownloadMyFile(string url,string directory)
        {
            WebClient client = new WebClient();
            string basepath = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(directory))
            {
                client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);

                // Start the download and copy the file to UPDATEFolder
                client.DownloadFileAsync(new Uri(url), @"" + directory);

                return "download started..";
            }
            else
            {
                return "file existed";
            }
           

           
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

          
        }

        private void Connection_Closed()
        {
            dispatcherTimer.Start();
        }

        private void Rilidhje()
        {
          
        }

        public void LoadAsync()
        {


            // Helper.BackgroundWorker.LoadFirstTime();
            //merrem te dhenat nga regjistrat 
            Helper.BackgroundWorker.LoadRegister();
            //Ngarko te dhenat e  e kokes se fatures
             
            FatureInfo f= Helper.BackgroundWorker.LoadFaturaInfoAsync();
        
            RegisterData.BILL_HEADER = f.HeadText;
            RegisterData.BILL_HEADER = f.FootText;
            RegisterData.Image = f.Image;
            //create sound for notification
            try
            {
                var path = "notify.wav";

                player = new System.Media.SoundPlayer(path);


            }
            catch
            {

            }


            //GET MAC ADRESS
            Helper.BackgroundWorker.GetMACAdress();

          

            //***load configuration***************************************************
           
            //Get fiscal showing bill and financial data

            RegisterData.ShowAllBillTypes =int.Parse(Helper.BackgroundWorker.ReadKey("JOKE"))!=0;
            //get show or hide bills from webserver 
        
            //GET SELECTED GUI

            var choise = int.Parse(Helper.BackgroundWorker.ReadKey("GUI"));
            if (choise == 2)
            {
                RegisterData.DYNAMIC_Creator = new GUICreator2();
            }

            RegisterData.FULL_BILL = Helper.BackgroundWorker.ReadKey("FULLBILL");
            RegisterData.PM = Helper.BackgroundWorker.ReadKey("PM");
            //*********************************************************************************


            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
             (ThreadStart)delegate ()
            {

                Helper.BackgroundWorker.CalculateXhiroDitoreUser();
                FATUREINFO = f;

                LoginView l = new LoginView();
                MainContent.Content = l;

              

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
                 );

            //***********************************************************************************************
            //gjej oren
            CloseProgramIfTimeHasChanged();

        

        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //if is  first time
            StartUpWindow startup = null;
            if (Helper.BackgroundWorker.ReadKey("FIRSTTIME") == "1")
            {
                startup = new StartUpWindow();
                startup.ShowDialog();
            }

            if (startup != null)
            {
                if (startup.SYNCING_STATUS == false)
                {
                    Close();
                    return;
                }

            }





            //inicilaizoj Xhirot ditore te kamarjereve

            XhiroDitore = new Dictionary<string, XhiroDitoreUser>();

         
            //load nessesary data to start 
            Thread thread = new Thread(LoadAsync);
            thread.Start();



           // mobile platform startup or not

            if (Helper.BackgroundWorker.ReadKey("MOBILE") == "1")
            {
                MobileSyncer mobile = new MobileSyncer();
            }

        }


        //key function event 
        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            //kalo ne full screen ose ne forme normale te dritares
            if (e.Key == System.Windows.Input.Key.F11)
            {
                if (WindowStyle == WindowStyle.None)
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                }
                else
                {


                    WindowStyle = WindowStyle.None;


                }
            }

            //aktivizo printimin ne kase fiskale ose caktivizoje ate

            if (e.Key == System.Windows.Input.Key.F5)
            {
                if (RegisterData.IsKasaActive)
                {
                    RegisterData.IsKasaActive = false;
                    Helper.BackgroundWorker.SaveKasaState(false);
                  //  MyNotify.ShowCustomBalloon(KasaFiskaleOff(), PopupAnimation.Scroll, 2000);
                    KasaNote.Fill = Brushes.OrangeRed;
                    if (CenterWindow != null)
                    {
                        CenterWindow.KasaNote.Fill = Brushes.OrangeRed;
                    }
                }
                else
                {
                    RegisterData.IsKasaActive = true;
                    Helper.BackgroundWorker.SaveKasaState(true);
                  //  MyNotify.ShowCustomBalloon(KasaFiskaleOn(), PopupAnimation.Scroll, 2000);
                    KasaNote.Fill = Brushes.Green;
                    if (CenterWindow != null)
                    {
                        CenterWindow.KasaNote.Fill = Brushes.Green;
                    }
                }
            }

            if (e.Key == Key.F7)
            {
                if (RegisterData.ShowAllBillTypes)
                {
                    RegisterData.ShowAllBillTypes = false;
                    Helper.BackgroundWorker.UpdateConfigKey("JOKE", "0");
                    KasaShow.Fill = Brushes.Green;
                    if (CenterWindow != null)
                    {
                        CenterWindow.KasaShow.Fill = Brushes.Green;
                    }
                }
                else
                {
                    RegisterData.ShowAllBillTypes = true;
                    Helper.BackgroundWorker.UpdateConfigKey("JOKE", "1");
                    KasaShow.Fill = Brushes.OrangeRed;
                    if (CenterWindow != null)
                    {
                        CenterWindow.KasaShow.Fill = Brushes.OrangeRed;
                    }
                }



                //send notification to server ...

                this.Dispatcher.Invoke(async () =>
                       await HubProxy.Invoke("ordersToggled",new POSSignal { POS_Id=RegisterData.POS_Id,AreOrdersVisible=RegisterData.ShowAllBillTypes} )
                    );
            }

           


        }



        //create ballon

        public TaskBar CreateOnlineNotification()
        {
            return new TaskBar("Sistemi eshte online !");

        }

        public TaskBar KasaFiskaleOn()
        {
            var T = new TaskBar(" Aktive !");
            T.Imazhi.Visibility = Visibility.Collapsed;
            return T;
        }

        public TaskBar KasaFiskaleOff()
        {
            var t = new TaskBar("JO Aktive !");
            t.Imazhi.Visibility = Visibility.Collapsed;
            return t ;
        }

        public TaskBar CreateOfflineNotification()
        {
            var off = new TaskBar("Sistemi eshte offline !");
            try
            {
                off.StopOfflineNotif.Visibility = Visibility.Visible;

                off.StopOfflineNotif.Checked += (s, e) =>
                {

                    StopOfflineNotifier = true;
                };


                off.Imazhi.Source = new BitmapImage(new Uri(@"\Images\NotSync.png", UriKind.Relative));
            }
            catch
            {

            }

            return off;
        }

        public TaskBar CreateNewClientOrderNotification(int id)
        {

            TaskBar t = new TaskBar("Ju keni nje porosi te re !");
            t.Link.Visibility = Visibility.Visible;
            t.Link.Click += (s, e) =>
            {

                if (CenterWindow == null)
                {
                    MessageBox.Show("Ju lutem logohuni ne menyre qe te shihni porosine !");
                    return;
                }

                var p = new PorosiView();
                CenterWindow.WindowUser.Content = p;

                if (this.WindowState == WindowState.Minimized)
                {
                    this.WindowState = WindowState.Normal;
                }

                this.Activate();


                p.ShowPorosiFromNotification(id);
                MyNotify.CloseBalloon();


            };
            try
            {
                t.Imazhi.Source = new BitmapImage(new Uri(@"\Images\NewNotification.png", UriKind.Relative));
            }
            catch
            {

            }


            return t;

        }


        //clock check

        public void CloseProgramIfTimeHasChanged()
        {

            DateTime tani = DateTime.Now.Date;
              DateTime internettime= TimerChanger.GetNistTime();

            
            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart)delegate ()
                        {

                            DetectTimeChnges(internettime);
                        }
                            );
        }


        //user real time clock change
        private void time_Changed(object sender, EventArgs e)
        {

          
            DateTime internettime = TimerChanger.GetNistTime();



            DetectTimeChnges(internettime);

                        

            if (CanTLogIn)
            {
               
                if (CenterWindow != null)
                {


                    
                    CenterWindow.Exit_Click(null, null);

                    var l = this.Content as LoginView;

                    if (l != null)
                    {
                        l.ErrorMessage.Text = "Data e kompjuterit nuk eshte e sakte,ju lutem vendosni daten e sakte dhe provoni te logoheni !";
                    }

                }
             
            
        
            }

           
        }



        public async void DetectTimeChnges(DateTime internettime)
        {

            var stringmessage = "Data ne sistemin tuaj eshte ndryshuar !";
            DateTime tani = DateTime.Now.Date;

            //nese nuk ka internet
            if (internettime == DateTime.MinValue)
            {
                //compare with last date saved

                DateTime offlineDate = Convert.ToDateTime(Helper.BackgroundWorker.ReadKey("OFFLINEDATE"));

                if (!(DateTime.Now.Date >= offlineDate.Date))
                {
                    CanTLogIn = true;

                    var id = LoggingService.AddLog(new LoggingService.LogModel { Text = stringmessage });

              


                }
                else
                {
                    CanTLogIn = false;


                }

            }

            //nese kemi internet
            else
            {
                Helper.BackgroundWorker.UpdateConfigKey("OFFLINEDATE", internettime.ToString());
                if (tani != internettime.Date)
                {

                    CanTLogIn = true;


                    var id = LoggingService.AddLog(new LoggingService.LogModel { Text = stringmessage });

                


                }
                else
                {
                    CanTLogIn = false;
                }

            }
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }


        //mobile start region

        #region   mobile


      


        #endregion


    }


}
