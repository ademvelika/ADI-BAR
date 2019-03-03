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

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for WebBroswer.xaml
    /// </summary>
    public partial class WebBroswer : UserControl
    {
        public WebBroswer()
        {
            InitializeComponent();

            string path = @System.AppDomain.CurrentDomain.BaseDirectory + "Tutorial.html";
            Broswer.Navigate(path);

        }
    }
}
