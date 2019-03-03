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
    /// Interaction logic for DateOre.xaml
    /// </summary>
    public partial class DateOre : UserControl
    {
        public DateOre()
        {
            InitializeComponent();

            Data.SelectedDate = DateTime.Now;
          

        }

        public DateTime getDateTime()
        {
            DateTime date1 = Data.SelectedDate ?? DateTime.Now.Date;

            string StartDateString = date1.ToShortDateString() + " " + Ora.ToString();
            var finalstart = DateTime.Parse(StartDateString);

            return finalstart;
        }
    }
}
