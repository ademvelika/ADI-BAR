using MYBAR.Model;
using MYBAR.Services;
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
    /// Interaction logic for Raportet.xaml
    /// </summary>
    public partial class Raportet : UserControl
    {
        public Raportet()
        {
            InitializeComponent();

            LoadUsers();
        }



        private void LoadUsers()
        {
            

      

        }

        public void AddEventItemsOftree(TreeViewItem t, String id, string username)
        {
            t.MouseLeftButtonUp += (s, e) =>
            {

                openReport(id, DateTime.Now.Date, username);

            };

        }

        private void openReport(string userid, DateTime d, string username)
        {
            //var list = FinanceService.getXhiroDitore(userid);
            //XhiroDitoreBuilder xh = new XhiroDitoreBuilder(list,username);

            //XhiroView.Document = xh.Document;

            XhiroView.Content = new ReportViewer(Services.RaporteService.getXhiroDitoreRaport(userid));
        }

        private void Inventari_Click(object sender, RoutedEventArgs e)
        {
            XhiroView.Content = new ReportViewer(Services.RaporteService.getInventarRaport());
        }
    }
}
