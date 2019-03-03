using MYBAR.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using MYBAR.Model;
using MYBAR.Services;
using MYBAR.Helper;

namespace MYBAR.CustomControls.FatureFilter
{
    /// <summary>
    /// Interaction logic for FatureAdminFilter.xaml
    /// </summary>
    public partial class FatureAdminFilter : UserControl,FaturaFilterInterface
    {

        
        public FatureAdminFilter()
        {
            InitializeComponent();
          
          
            UserCombo.ItemsSource= UserService.GetUsersCombo();

            UserCombo.SelectedIndex = 0;

            //set time,date and clock

            FinishClock.Ora.SetPM();
            FinishClock.Ora.SetHour(11);
            FinishClock.Ora.SetMinutes(59);

        }

        public List<FatureList> getFaturat()
        {
            //add condition for fiscal or not fiscal order
            var condition = new List<bool>();
            condition.Add(true);
            if (RegisterData.ShowAllBillTypes)
            {
                condition.Add(false);
            }

            var sd = StartClock.getDateTime();
            var fd = FinishClock.getDateTime();
            if (!(bool)Switch.IsChecked)
                return FatureService.getMyFatura(StartClock.getDateTime(), FinishClock.getDateTime(), ((ComboBoxData)UserCombo.SelectedItem).DataValueOpt, condition);
            else
                return FatureService.getMyFatura(int.Parse(OrderNumberStart.Text), int.Parse(OrderNumberFinish.Text),condition);
        }

        

        private void IntervalCheck_Checked(object sender, RoutedEventArgs e)
        {
            OrderNumberStart.IsEnabled = true;
            OrderNumberFinish.IsEnabled = true;
        }

        private void IntervalCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            OrderNumberStart.IsEnabled = false;
            OrderNumberFinish.IsEnabled = false;
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            if (Switch.IsChecked ?? false)
            {
                IntervalCheck_Checked(null, null);
            }
            else
            {
                IntervalCheck_Unchecked(null, null);
            }
        }
    }
}
