using MYBAR.Helper;
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

namespace MYBAR.View.Other
{
    /// <summary>
    /// Interaction logic for OtherConfigView.xaml
    /// </summary>
    public partial class OtherConfigView : UserControl
    {
        public OtherConfigView()
        {
            InitializeComponent();
        }

        private void GUI1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            GUI1.BorderBrush = Brushes.Red;
            GUI2.BorderBrush = Brushes.Transparent;
            BackgroundWorker.UpdateConfigKey("GUI", "1");
            RegisterData.DYNAMIC_Creator = new Model.GUICreator();


        }

        private void GUI2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GUI2.BorderBrush = Brushes.Red;
            GUI1.BorderBrush = Brushes.Transparent;
            BackgroundWorker.UpdateConfigKey("GUI", "2");
            RegisterData.DYNAMIC_Creator = new Model.GUICreator2();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
             if(RegisterData.DYNAMIC_Creator.GetType() ==typeof(Model.GUICreator))
            {
                GUI1.BorderBrush = Brushes.Red;
            }
            else
            {
                GUI2.BorderBrush = Brushes.Red;
            }


            if (BackgroundWorker.ReadKey("MOBILE") == "1")
            {
                SwitchMobile.IsChecked = true;
            }

            if (RegisterData.PM == "1")
            {
                SwitchPM.IsChecked = true;
            }
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {

            if (SwitchMobile.IsChecked ?? false)
                BackgroundWorker.UpdateConfigKey("MOBILE", "1");
            else
            {
                BackgroundWorker.UpdateConfigKey("MOBILE", "0");
            }

            MessageBox.Show("Ristartoni programin per te pare efektin e konfigurimit !");
        }

        private void SwitchPM_Click(object sender, RoutedEventArgs e)
        {

            if (SwitchPM.IsChecked ?? false)
            {
                BackgroundWorker.UpdateConfigKey("PM", "1");
                RegisterData.PM = "1";
            }
            else
            {
                BackgroundWorker.UpdateConfigKey("PM", "0");
                RegisterData.PM = "0";
            }
        }
    }
}
