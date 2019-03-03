using MYBAR.CustomControls;
using MYBAR.Interface;
using MYBAR.Model;
using MYBAR.Model.Reports;
using MYBAR.Services;
using MYBAR.View.Dialog;
using MYBAR.View.KerkoDialog;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using static MYBAR.Services.KerkimeDialogService;

namespace MYBAR.View.Artikuj
{
    /// <summary>
    /// Interaction logic for ShitjetArtikuj.xaml
    /// </summary>
    public partial class ShitjetArtikuj : UserControl,SearchDialogInterface
    {

        public List<ArtikujSearchRow> ArtikujChoseList;
        public ShitjetArtikuj()
        {
            InitializeComponent();

            LoadControllers();


        }

        public void LoadControllers()
        {

            var list = UserService.GetUsersCombo();

            
            PerdoruesiCombo.ItemsSource = list;
            PerdoruesiCombo.SelectedIndex = 0;
            KategoriCombo.ItemsSource = ArtikullService.getMenuCategoriesCombo();
            KategoriCombo.SelectedIndex = 0;

            ArtikujChoseList = new List<ArtikujSearchRow>();

            FinishClock.Ora.SetPM();
            FinishClock.Ora.SetHour(11);
            FinishClock.Ora.SetMinutes(59);
        }

        private void Filtro_Click(object sender, RoutedEventArgs e)
        {
            Loading.Visibility = Visibility.Visible;

            Thread th = new Thread(FilterDataAsync);
            th.Start();

        }

        public void FilterDataAsync()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                 (ThreadStart)delegate ()
                 {
                     var perdoruesi = (ComboBoxData)PerdoruesiCombo.SelectedItem;
                     var category = (ComboBoxData)KategoriCombo.SelectedItem;
                  
                    var list = FinanceService.GetShitje(StartClock.getDateTime(), FinishClock.getDateTime(), perdoruesi.DataValueOpt, category.DataValue, ArtikujChoseList.Select(x=>x.Id).ToList());
                     Result.ItemsSource = list;
                     Totali.Text = list.Sum(x => x.Vlera).ToString("#,#0.00");
                     Loading.Visibility = Visibility.Hidden;
                 }
);
        }

        private void ArtikujSearch_Click(object sender, RoutedEventArgs e)
        {
            //KerkoForm k = new KerkoForm("Artikull",this,"Double Click per te zgjedhur artikujt qe deshironi");
            //k.ShowDialog();

            AdvancedArtikullSelect dialog = new AdvancedArtikullSelect(this);
            //var location = Result.TransformToAncestor(this).Transform(new Point(0, 0));
            ////  dialog.Left = DateFilter.Width / 2;
            ////dialog.Top = 300+DateFilter.Height;
            //dialog.Top = App.Current.MainWindow.Top + DateFilter.Height + 100; ;
            //dialog.Left = App.Current.MainWindow.Left + DateFilter.Width/2;
            dialog.ShowDialog();
        }

       

        public bool DoubleClickEventFunction(object item)
        {

            var row = item as ArtikujSearchRow;
            ArtikullFilterItem a = new ArtikullFilterItem( row.Asortimenti );
          
            if(!ArtikujChoseList.Where(x=>x.Id==row.Id).Any())
            {
                ArtikujChoseList.Add(row);
                ListContainer.Children.Insert(0, a);
                a.RemoveBtn.Click += (s, e) =>
                {

                    ArtikujChoseList.Remove(row);
                    ListContainer.Children.Remove(a);



                };
                return true;
            }
          
           
           
            return false;

        }

        private void Printo_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintTicket.PageMediaSize = new System.Printing.PageMediaSize(System.Printing.PageMediaSizeName.ISOA4);
            printDlg.ShowDialog();

         
            printDlg.PrintVisual(Result, "Shitjet Printing.");



        }

        public bool HasTotal()
        {
           return false;
        }

        public dynamic getListItems(DateTime startdate, DateTime enddate, string word = "")
        {
            return KerkimeDialogService.getArtikujSearchList(word);
        }

        private void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            String PATH;

           

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  

            workSheet.Row(1).Height = 60;
            workSheet.Cells[1, 1].Value = "Shtjet e artikujve " + StartClock.getDateTime().ToString() + "-" + FinishClock.getDateTime().ToString();
            workSheet.Row(3).Height = 20;
            workSheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(3).Style.Font.Bold = true;
        
            workSheet.Cells[3, 1].Value = "Nr";
            workSheet.Cells[3, 2].Value = "Asortimenti";
            workSheet.Cells[3, 3].Value = "Sasia";
            workSheet.Cells[3, 4].Value = "Cmimi";
            workSheet.Cells[3, 5].Value = "Vlera";
            workSheet.Cells[3, 6].Value = "Kategoria";
            //Body of table  
            //  

            List<InventarModel> list = (List<InventarModel>)Result.ItemsSource;
            int recordIndex = 4;
            foreach (var item in list)
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 3).ToString();
                workSheet.Cells[recordIndex, 2].Value = item.Asortimenti.ToString();
                workSheet.Cells[recordIndex, 3].Value = item.Sasia;
                workSheet.Cells[recordIndex, 4].Value = item.Cmimi;
                workSheet.Cells[recordIndex, 5].Value = item.Sasia * item.Cmimi; 
                workSheet.Cells[recordIndex, 6].Value = item.Kategoria;
                recordIndex++;
            }

            workSheet.Cells[recordIndex+1, 5].Value = list.Sum(x => x.Sasia * x.Cmimi).ToString();
          
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            workSheet.Column(5).AutoFit();
            workSheet.Column(6).AutoFit();


            //chose destination to create file
            System.Windows.Forms.SaveFileDialog openFileDialog = new System.Windows.Forms.SaveFileDialog();

            openFileDialog.Filter = "Excel |*.xlsx";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                PATH = openFileDialog.FileName;

            }
            else
            {
                return;
            }

            try
            {
                FileStream objFileStrm = File.Create(@"" + PATH );
                objFileStrm.Close();

                //Write content to excel file    
                File.WriteAllBytes(@"" + PATH, excel.GetAsByteArray());

                MessageBox.Show("Sukses !");
            }
            catch(Exception ex)
            {

                MessageBox.Show("Dicka shkoi gabim");
            }

        }
    }
          
    }


