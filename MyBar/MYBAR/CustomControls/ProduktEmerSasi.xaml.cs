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

namespace MYBAR.CustomControls
{
    /// <summary>
    /// Interaction logic for ProduktEmerCmim.xaml
    /// </summary>
    public partial class ProduktEmerSasi : UserControl
    {
        public ProduktEmerSasi(string name,object  sasi)
        {
            InitializeComponent();

            Emer.Content = name;
            Sasi.Content = sasi;
            
        }
    }
}
