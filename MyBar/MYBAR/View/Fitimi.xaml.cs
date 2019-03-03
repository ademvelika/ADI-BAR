using MYBAR.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for Fitimi.xaml
    /// </summary>
    public partial class Fitimi : UserControl
    {

        private Tuple<decimal,decimal> ShitjeDalje;
        public Fitimi()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Date2.SelectedDate = DateTime.Now;
            Date1.SelectedDate = DateTime.Now;
            filterAsync(DateTime.Now, DateTime.Now);
           
        }

        private void FiltoBtn_Click(object sender, RoutedEventArgs e)
        {
            filterAsync(Date1.SelectedDate ?? DateTime.Now, Date2.SelectedDate ?? DateTime.Now);

        }

        private void filterAsync(DateTime d1,DateTime d2)
        {
            Thread th = new Thread(() => {


                ShitjeDalje = FinanceService.getBalance(d1, d2);

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
           (ThreadStart)delegate ()
           {
               Shitje.Text = ShitjeDalje.Item1.ToString("#,#0.00");
               Dalje.Text = ShitjeDalje.Item2.ToString("#,#0.00");
               FITIMIIM.Text = (ShitjeDalje.Item1 - ShitjeDalje.Item2).ToString("#,#0.00");
           }
);

            });

            th.Start();
        }
    }
}
