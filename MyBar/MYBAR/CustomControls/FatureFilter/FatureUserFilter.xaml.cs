using MYBAR.Interface;
using System.Collections.Generic;
using System.Windows.Controls;
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
