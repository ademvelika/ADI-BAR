﻿
using MYBAR.Interface;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;
using static MYBAR.Services.KerkimeDialogService;

namespace MYBAR.View.KerkoDialog
{
    /// <summary>
    /// Interaction logic for KerkoForm.xaml
    /// </summary>
    public partial class KerkoForm : Window
    {

        private dynamic ListaDinamike;
        public dynamic SelectedRow;


        private SearchDialogInterface SearchInterface;
        public int ID { get; set; }

        public KerkoForm(string label, SearchDialogInterface parent,string mesazhihelp="")
        {

            InitializeComponent();
            LabelKryesor.Content = label;
            MesazhiHelp.Text = mesazhihelp;
            
            SearchInterface = parent;

           
        }



        private void mbushdataGriden()
        {



            ListaDinamike = SearchInterface.getListItems(DateFilter.StartClock.getDateTime(),DateFilter.FinishClock.getDateTime(),"");

            


            DynamicDataGrid.ItemsSource = ListaDinamike;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_AutoGeneratedColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Id")
            {
                e.Cancel = true;
            }

        }
        private void DynamicDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            dynamic a = DynamicDataGrid.SelectedItem;

            if (a != null)
            {
                ID = a.Id;
                SelectedRow = a;

                if (SearchInterface.DoubleClickEventFunction(SelectedRow))
                {
                    this.Close();
                }
            }

        }


      

        private void Searchtext_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                searchByKeyWord();
            }
       
    }

        public void searchByKeyWord()
        {

            ListaDinamike = SearchInterface.getListItems(DateFilter.StartClock.getDateTime(), DateFilter.FinishClock.getDateTime(),Searchtext.Text);
            DynamicDataGrid.ItemsSource = ListaDinamike;
            CalculateTotal();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            searchByKeyWord();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            DateFilter.StartClock.Data.SelectedDate = startDate;
            DateFilter.FinishClock.Data.SelectedDate = endDate;
            mbushdataGriden();

            if (SearchInterface.HasTotal())
            {

                try
                {
                    TotalPanel.Visibility = Visibility.Visible;

                    CalculateTotal();
                }
                catch
                {

                }


            }
            else
            {
                advancedsearch.Visibility = Visibility.Hidden;
            }
        }

        public void CalculateTotal()
        {
            if (SearchInterface.HasTotal())
            {
                var temp = (List<FatureHyrjeSerarchRow>)ListaDinamike;
                TotalLabel.Text = temp.Sum(x => x.Total).ToString("#,#0.00");
            }
        }
    }

}
