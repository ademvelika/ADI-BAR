using System.Windows;
using System.Windows.Controls;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();

            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            SoftwereVersion.Text = Helper.BackgroundWorker.ReadKey("VERSION");
        }
    }
}
