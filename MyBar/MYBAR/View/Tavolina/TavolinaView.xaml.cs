using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Tavoline;
using MYBAR.Services;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MYBAR.View.Tavolina
{
    /// <summary>
    /// Interaction logic for TavolinaView.xaml
    /// </summary>
    public partial class TavolinaView : Window
    {

        private TavolineModel model;
        public TavolinaView()
        {

            InitializeComponent();

            model = new TavolineNewModel();

            FshijBtn.Visibility = model.DeleteButtonVisibility;
        }

        public TavolinaView(int id)
        {
            InitializeComponent();
            model = TavolinaService.GetTable(id);
            FshijBtn.Visibility = model.DeleteButtonVisibility;
            if(model.DeleteButtonVisibility==Visibility.Visible)
            {
                RangeTab.Visibility = Visibility.Hidden;
            }
            
            NumriTavolines.Text = model.Number.ToString();
        }

        private void RuajBtn_Click(object sender, RoutedEventArgs e)
        {
            int tavolinanr = 0;

            Int32.TryParse(NumriTavolines.Text, out tavolinanr);

            if (tavolinanr == 0)
            {
                MessageBox.Show("Numri i tavolines duhet te jete Numer !");
                return;
            }
            model.Number = tavolinanr;



            Thread th = new Thread(() =>
              {

                  bool ok = true;
                  if (model.Save())
                  {
                      ok = true;
                  }
                  else
                  {
                      ok = false;
                  }

                  Dispatcher.BeginInvoke(DispatcherPriority.Normal,
       (ThreadStart)delegate ()
       {

           if (ok)
           {
               Loading.Visibility = Visibility.Hidden;
               Meesage.Content = "Sukses!";
               Meesage.Foreground = Brushes.Green;
               Close();
           }
           else
           {
               Loading.Visibility = Visibility.Hidden;
               Meesage.Content = "Dicka shkoi gabim!";
               Meesage.Foreground = Brushes.Red;
               RuajBtn.IsEnabled = true;
           }

       }
          );


              });

            Loading.Visibility = Visibility.Visible;
            RuajBtn.IsEnabled = false;
            th.Start();
              
              }
        
              
         


        private void FshijBtn_Click(object sender, RoutedEventArgs e)
        {
            if (model.Delete())
            {

                MessageBox.Show("U fshij Me sukses");
               
            }
            Close();
        }

        public void NoInternetMesage()
        {
            MessageBox.Show("Check Connection !");
        }

        private void RuajBtn2_Click(object sender, RoutedEventArgs e)
        {
            int tavolinastart=0, tavolinaend=0;
            int.TryParse(NumriTavolinesStart.Text, out tavolinastart);
            int.TryParse(NumriTavolinesFinish.Text, out tavolinaend);
            if(tavolinastart+tavolinaend==0)
            { 
                MessageBox.Show("Numri i tavolinave  duhet te jete numer !");
                return;
            }

            Thread th = new Thread(() =>
              {
                  bool ok = true;
                  for (int i = tavolinastart; i <= tavolinaend; i++)
                  {
                      var tav = new TavolineNewModel { IsItemActive = true, Number = i };
                     ok=ok&& tav.Save();
                  }

                  Dispatcher.BeginInvoke(DispatcherPriority.Normal,
(ThreadStart)delegate ()
{

if (ok)
{
    Loading2.Visibility = Visibility.Hidden;
    Meesage2.Content = "Sukses!";
    Meesage2.Foreground = Brushes.Green;
    Close();
}
else
{
    Loading2.Visibility = Visibility.Hidden;
    Meesage2.Content = "Dicka shkoi gabim jo te gjitha tavolinat jane ruajtur!";
    Meesage2.Foreground = Brushes.Red;
    RuajBtn2.IsEnabled = true;
}

}
);



              });


            Loading2.Visibility = Visibility.Visible;
            RuajBtn2.IsEnabled = false;
            th.Start();


        }
    }
}
