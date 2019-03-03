using MYBAR.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace MYBAR.View.StartUp
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : Window
    {

        public bool SYNCING_STATUS;
        public StartUpWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //registerlogic,if true

            try
            {

                LoadingAnimate.Visibility = Visibility.Visible;
                LoadingText.Visibility = Visibility.Visible;
                this.Height = 520;
                var str = SerialText.Text;
                Thread th = new Thread(()=>TransferData(str));
                th.Start();

               
            }

            catch
            {
                SYNCING_STATUS = false;
                //MESSAGE

            }



           
            

        }


        private void TransferData(string serialtext)
        {


            var result = true;

            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                   (ThreadStart)delegate ()
                   {

                       if (serialtext=="adiadm")
                       {
                           SYNCING_STATUS = true;                          
                           //final veprime
                           BackgroundWorker.UpdateConfigKey("FIRSTTIME", "0");
                           DateTime data = TimerChanger.GetNistTime();
                           if (data == DateTime.MinValue)
                               BackgroundWorker.UpdateConfigKey("OFFLINEDATE", DateTime.Now.ToString());
                           BackgroundWorker.UpdateConfigKey("OFFLINEDATE", data.ToString());
                           Close();
                       }
                       else
                       {
                           SYNCING_STATUS = false;
                           LoadingAnimate.Visibility = Visibility.Collapsed;
                           this.Height = 450;
                           LoadingText.Text = "UPSss ,dicka shkoi keq ,Seriali juaj nuk eshte i sakte ose lidhja me serverin deshtoi !";
                           LoadingText.Background = Brushes.Red;
                           LoadingText.Foreground = Brushes.White;
                       }

                   }
                              
                         );
        }




    }

}
