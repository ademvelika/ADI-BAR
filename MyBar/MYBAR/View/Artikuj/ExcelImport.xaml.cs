using Microsoft.Win32;
using MYBAR.CustomControls;
using MYBAR.Helper;
using MYBAR.Model.Artikuj;
using MYBAR.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace MYBAR.View.Artikuj
{
    /// <summary>
    /// Interaction logic for ExcelImport.xaml
    /// </summary>
    public partial class ExcelImport : UserControl
    {

        private LoadingDialog loadDiag;
        ObservableCollection<ArtikullImportRow> list = new ObservableCollection<ArtikullImportRow>();
        public ExcelImport()
        {
            InitializeComponent();

            createDescription();
        }

        private void createDescription()
        {

            StringBuilder s = new StringBuilder();
         
            foreach (var item in ArtikullService.getMenuCategoriesCombo().Where(x=>x.DataValueOpt!="ALL"))
            {

                 s.AppendLine( "(" + item.DisplayValue + ")->" + item.DataValue + "; ");
            }

            CatetegoryDesctription.Text = s.ToString();
        }

        private void Chose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                Path.Text = openfile.FileName;

                ViewData.ItemsSource = list;
                loadDiag = new LoadingDialog();
                Thread th = new Thread(() => LoadFileIntoGrid(openfile.FileName));
                th.Start();
                loadDiag.ShowDialog();
               

            }
        }


        private void LoadFileIntoGrid(string filename)
        {

        
            ExcelPackage package;
            ExcelWorksheet workSheet;
            try
            {
            package = new ExcelPackage(new System.IO.FileInfo(filename));
            workSheet= package.Workbook.Worksheets.First();

            }
            catch
            {

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                  (ThreadStart)delegate ()
                  {

                      list.Clear();
                      ViewData.ItemsSource = list; //table.DefaultView;
                     loadDiag.Close();


                  }
                     );
                MessageBox.Show("File eshte duke u perdorur nga nje program tjeter ose eshte i korruptuar !");

                return;
            }








            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];





                var color = Brushes.MediumAquamarine;
                decimal test=0;
                bool eshtenumer = decimal.TryParse(row[rowNumber, 2].Text, out test);

                if (!eshtenumer)
                {
                    color = Brushes.Crimson;
                }
                ArtikullImportRow artikullrow = new ArtikullImportRow { Emertim = row[rowNumber, 1].Text, Cmim = row[rowNumber, 2].Text, Kategori = row[rowNumber, 3].Text,CmimError=color };

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {
                        list.Add(artikullrow);
                    }
                       );
            }

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                   (ThreadStart)delegate ()
                   {


                      
                      loadDiag.Close();


                   }
                      );

        }


      

        public class ArtikullImportRow
        {
  

            public string Emertim { get; set; }
            public string Cmim { get; set; }
            public string Kategori { get; set; }
            public int TypeId { get; set; }
            public int UnitId { get; set; }
            public SolidColorBrush CmimError { get; set; }


            
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {

          

            Thread th = new Thread(importAsync);
            th.Start();
            loadDiag = new LoadingDialog();
            loadDiag.Show();

        }

        private void importAsync()
        {

            bool inserted = false;

            try
            {
                var importlist = list.Select(x => new ArtikullListRowSimple { Asortimenti = x.Emertim, Cmimi = Convert.ToDecimal(x.Cmim), CategoryId = Convert.ToInt32(x.Kategori),UnitId=4,TypeId=Constants.SIMPLE }).ToList();
            
                 
                //remove dublicates,importatnt step
                removeExisting(importlist);



                var kategoritelist = FatureService.getMenuCategories().Where(x => x.IsItemActive == true).ToList();


                foreach (var item in importlist)
                {
                    //find a online category id for your product
                    
                    //send to server and wait to get id

                    

                        inserted = ArtikullService.InsertNewProduct(item);

                        //remove from list insertd artikull
                        //var nospacename = Regex.Replace(item.Asortimenti, @"\s", "");
                        //var originallistitem = list.Where(x => Regex.Replace(x.Emertim, @"\s", "") == nospacename).FirstOrDefault();
                        //if(originallistitem!=null)
                        //  list.Remove(originallistitem);
                    

                }

                inserted = true;
            
            }

            catch(Exception ex)
            {
                ex.ToString();
            }


            //  bool inserted = ArtikullService.ImportArtikujExcel(importlist);


            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                   (ThreadStart)delegate ()
                   {


                       ViewData.Items.Refresh();
                       loadDiag.Close();
                       if (inserted)
                       {
                           MessageBox.Show("Importi u krye me sukses !");
                       }
                       else
                       {
                           MessageBox.Show("Upss , dicka shkoi gabim,jo te gjitha produktet mund te jen importuar  !");
                       }

                   });
        }


        private void removeExisting(List<ArtikullListRowSimple> list)
        {

            var allproduktelist = ArtikullService.getAllArtikuj();

            for (int i = list.Count-1; i>=0; i--)
            
            {

                string importname = list[i].Asortimenti;

                //remova all whitespaces
                 importname= Regex.Replace(importname, @"\s", "");

                bool exist = allproduktelist.Where(x => Regex.Replace(x.Asortimenti, @"\s", "") == importname).Any();

                if (exist)
                {
                    list.RemoveAt(i);
                }
            }



        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (PopupInfo.IsOpen)
            {
                PopupInfo.IsOpen = false;
            }
            else
            {
                PopupInfo.IsOpen = true;
            }
        }
    }
}
