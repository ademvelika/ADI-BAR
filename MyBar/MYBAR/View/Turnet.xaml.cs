using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Xhiro;
using MYBAR.Raports;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for Turnet.xaml
    /// </summary>
    public partial class Turnet : UserControl
    {
        public Turnet()
        {
            InitializeComponent();

            DateStart.SelectedDate = DateTime.Now;
            DateEnd.SelectedDate = DateTime.Now;
            LoadUsers();
        }

        private void LoadUsers()
        {
            List<User> l = UserService.GetUsers();


            foreach (var item in l.ToList())
            {
                Button b = new Button();
                b.Content = item.UserName;
                b.FontSize = 20;
                b.Height = 40;

                b.Click += (s, e) =>
                {
                    var list = FinanceService.MerTurnet(DateStart.SelectedDate ?? DateTime.Now, DateEnd.SelectedDate ?? DateTime.Now,item.ID);
                    BindToWindow(list);

                };

                Perdoruesit.Children.Add(b);

            }

        }


    private void AllUsers_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var list = FinanceService.MerTurnet(DateStart.SelectedDate ?? DateTime.Now, DateEnd.SelectedDate ?? DateTime.Now, "ALL");
            BindToWindow(list);
    }

      
      private void   BindToWindow(List<TurnetRowModel> list )
        {

            foreach (var item in list)
            {
                if (item.Data.Date == DateTime.Now.Date)
                {
                    item.RowBackground = Brushes.AliceBlue;
                }
            }

            TurnetGrid.ItemsSource = list;
            if(RegisterData.ShowAllBillTypes)
            Total.Text = list.Sum(x => x.Total).ToString("#,#0.00");
            else
            {
                Total.Text = list.Sum(x => x.Fiscal_Orders_Total_Sum).ToString("#,#0.00");
            }
        }

        private void PrintoTurn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            var row = TurnetGrid.SelectedItem as TurnetRowModel;
            if (row != null)
            {



                var model = FinanceService.getReportDataRePrint(row.Id);
                XhiroDitoreBuilder builder = new XhiroDitoreBuilder(model, row.UserName);

                Printer.PrintFlowDocumentOneCopy(builder.Document);

            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if(RegisterData.ShowAllBillTypes==false)
            TurnetGrid.Columns[4].Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
