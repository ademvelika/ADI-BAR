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
using System.Windows.Shapes;

namespace MYBAR.View.Dialog
{
    /// <summary>
    /// Interaction logic for TurnInfo.xaml
    /// </summary>
    public partial class TurnInfo : Window
    {
        public TurnInfo(decimal xhiro,decimal paratnexhep,decimal bakshishe)
        {
            InitializeComponent();

            Xhiroja.Content = xhiro.ToString("#,#0.00");
            Parate.Content = paratnexhep.ToString("#,#0.00");
            Bakshiset.Content = bakshishe.ToString("#,#0.00");
        }
    }
}
