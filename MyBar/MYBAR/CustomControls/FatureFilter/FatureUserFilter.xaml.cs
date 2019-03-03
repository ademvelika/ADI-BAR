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
    /// Interaction logic for FatureUserFilter.xaml
    /// </summary>
    public partial class FatureUserFilter : UserControl,FaturaFilterInterface
    {
        public FatureUserFilter()
        {
            InitializeComponent();

            FinishClock.Ora.SetPM();
            FinishClock.Ora.SetHour(11);
            FinishClock.Ora.SetMinutes(59);


        }

        public List<FatureList> getFaturat()
        {
            var condition = new List<bool>();
            condition.Add(true);
            if (RegisterData.ShowAllBillTypes)
            {
                condition.Add(false);
            }

            return FatureService.getMyFatura(StartClock.getDateTime(), FinishClock.getDateTime(), ((MainWindow)App.Current.MainWindow).UserId,condition);
        }
    }
}
