using MYBAR.CustomControls;
using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Artikuj;
using MYBAR.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MYBAR.View.Artikuj
{
    /// <summary>
    /// Interaction logic for ArtikujList.xaml
    /// </summary>
    public partial class ArtikujList : UserControl
    {

        private int CategoryId { get; set; }
        private Button LastCategoryButtonClicked { get; set; }
        private ArtikullListRow CurrentArtikull { get; set; }
        private List<ComboBoxData> CategoryList;
        private List<ComboBoxData> TipetList;
        private List<ComboBoxData> UnitList;



        private LoadingDialog dialog;
        public ArtikujList()
        {
            InitializeComponent();




        }

        public void LoadComboCategory()
        {
            CategoryList = ArtikullService.getMenuCategoriesCombo().Where(x => x.DataValueOpt != "ALL").ToList();
            CategoryCombo.ItemsSource = CategoryList;
            if (CategoryCombo.Items.Count > 0)
                CategoryCombo.SelectedIndex = 0;
        }

        private void AddTextBoxSelectTextEvent()
        {
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewMouseLeftButtonDownEvent,
      new MouseButtonEventHandler(SelectivelyHandleMouseButton), true);
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotKeyboardFocusEvent,
              new RoutedEventHandler(SelectAllText), true);
        }

        private void LoadGrupet()
        {
            var list = FatureService.getMenuCategories();
            foreach (var t in list)
            {

                AddCategoryButton(t.Id, t.Name, t.CategoryImage);
            }
        }

        private void Kerko_Click(object sender, RoutedEventArgs e)
        {

            LoadDataSearched(KerkoText.Text, CategoryId);


        }

        private void LoadDataSearched(string text, int categoryId)
        {
            ListArtikujContainer.ItemsSource = ArtikullService.getAllArtikujByCategoryAndByStartName(categoryId, text);
        }

        public void ChangeSaveGUIButton()
        {

            string content = "";
            if (CurrentArtikull.ProduktId == -1)
            {
                content = "Shto";

            }

            else
            {
                content = "Modifiko";

            }
            ShtoProduktBtn.Content = content;
        }



        private void LoadDataAsync(int catid)
        {


            Dispatcher.BeginInvoke(new ThreadStart(() => BackgroundWorker.getAllArtikujAsync(ListArtikujContainer, catid)));

        }

        private void KerkoText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                LoadDataSearched(KerkoText.Text, CategoryId);
            }
        }

        private void ShtoKategori_Click(object sender, RoutedEventArgs e)
        {

            KategoriView k = new KategoriView(new MenuCategoriesNewModel());
            k.ShowDialog();

            if (k.kategorimodel.IsSaved)
            {
                AddCategoryButton(k.kategorimodel.Id, k.kategorimodel.Name, k.kategorimodel.Image);
                LoadComboCategory();
            }
        }


        public void AddCategoryButton(int Id, string Name, byte[] Image)
        {
            //create a category button
            Button b = new Button();
            b.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            DockPanel panel = new DockPanel();
            TextBlock textcategory = new TextBlock(new Run(Name));
            panel.Children.Add(textcategory);
            Image imagecategory = new Image();
            imagecategory.HorizontalAlignment = HorizontalAlignment.Right;
            imagecategory.Source = ImageConverter.LoadImage(Image);
            DockPanel.SetDock(imagecategory, Dock.Right);
            panel.Children.Add(imagecategory);
            b.Content = panel;

            //create a tool tip for category
            ToolTip tooltip = new ToolTip();
            tooltip.Content = new TextBlock(new Run("Right Click per editim !"));
            b.ToolTip = tooltip;

            //create context menu for edit

            ContextMenu c = new ContextMenu();
            MenuItem edit = new MenuItem { Header = "Modifiko" };
            edit.Click += (s, e) =>
            {
                KategoriView katview = new KategoriView(ArtikullService.getMenuCategorie(Id));
                katview.ShowDialog();
                //if saved update automatically image and text in GUI[imagecategory and textcategory]
                if (katview.kategorimodel.IsSaved)
                {
                    textcategory.Text = katview.kategorimodel.Name;
                    imagecategory.Source = ImageConverter.LoadImage(katview.kategorimodel.Image);

                }
                if (katview.kategorimodel.IsDeleted)
                {
                    Grupet.Children.Remove(b);
                }
            };
            c.Items.Add(edit);

            b.ContextMenu = c;


            //tuple as Tag with two parameters ,id and name of menucategories
            b.Tag = Tuple.Create(Id, Name);
            BrushConverter bc = new BrushConverter();

            b.Click += (s, e) =>
            {


                LoadDataAsync(Id);
                CategoryId = Id;

               // CancelUpdate_Click(null, null);


            };

            Grupet.Children.Add(b);

        }

        private void ShtoProduktBtn_Click(object sender, RoutedEventArgs e)
        {

            //validate field
            if (!ValidateFields())
            {
                return;
            }

            if (CurrentArtikull.ProduktId == -1)
            {
                //add new 

                addNewMenuItem();
            }
            else
            {
                //update exist

                UpdateMenuItem();

            }




        }

        public void addNewMenuItem()
        {

            try
            {
                var tempcatidonline = ((ComboBoxData)CategoryCombo.SelectedItem).DataValueOnline;
                var tempcatidlocal = ((ComboBoxData)CategoryCombo.SelectedItem).DataValue;
                var tempemer = EmerProduktiNew.Text;
                var tempcmim = Convert.ToDecimal(CmimProduktiNew.Text);
                var tempsasimin = Convert.ToInt32(SasiaMinimale.Text);
                var tempTipiId = ((ComboBoxData)TipiCombo.SelectedItem).DataValue;
                var tempUnitId = ((ComboBoxData)NjesiaCombo.SelectedItem).DataValue;
                var tempUnitName = ((ComboBoxData)NjesiaCombo.SelectedItem).DisplayValue;
                CurrentArtikull.Asortimenti = tempemer;
                CurrentArtikull.Cmimi = tempcmim;
                CurrentArtikull.Sasi = 0;
                CurrentArtikull.SasiaMinimale = tempsasimin;
                CurrentArtikull.CategoryId = tempcatidlocal;
                CurrentArtikull.CategoryOnlineId = tempcatidonline;
                CurrentArtikull.UnitId = tempUnitId;
                CurrentArtikull.TypeId = tempTipiId;
                CurrentArtikull.UnitName = tempUnitName;
                Thread addthread = new Thread(() =>
                  {
                  // ArtikullListRow newartikull = new ArtikullListRow { Asortimenti = tempemer, Cmimi =tempcmim , Sasi = 0, SasiaMinimale =tempsasimin , CategoryId =tempcatidlocal , CategoryOnlineId =tempcatidonline  };

                





                      Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                           (ThreadStart)delegate ()
                           {


                             
                           //add agin
                          
                               if (!CurrentArtikull.Save())
                               {

                                   CloseLoading();
                                   return;
                               }

                               ObservableCollection<ArtikullListRow> l = (ObservableCollection<ArtikullListRow>)ListArtikujContainer.ItemsSource;
                               l.Add(CurrentArtikull);
                               CancelUpdate_Click(null, null);
                               CloseLoading();
                           }
                                         );
                  });

                addthread.Start();
                ShowLoading();

            }

            catch
            {
                CloseLoading();
            }
           




        }

        public void UpdateMenuItem()
        {

            GetReadyArtikullRowForUpdate();

            Thread editTh = new Thread(() =>
              {
             
                  CurrentArtikull.Update();


                  Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                       (ThreadStart)delegate ()
                       {

                           ListArtikujContainer.Items.Refresh();

                           CancelUpdate_Click(null, null);
                           CloseLoading();

                       }
                                     );
                 
              });

            editTh.Start();
            ShowLoading();
           
        }

        private void ListArtikujContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {


            try
            {
                CurrentArtikull = (ArtikullListRow)ListArtikujContainer.SelectedItem;

                BindToGUI(CurrentArtikull);
                ChangeSaveGUIButton();
                CancelUpdate.Visibility = Visibility.Visible;
                ArtikullRiGrid.Visibility = Visibility.Visible;
                DeleteProduct.Visibility = Visibility.Visible;
               


            }


            catch
            {

            }

        }

        private void BindToGUI(ArtikullListRow r)
        {
            EmerProduktiNew.Text = r.Asortimenti;
            SasiaMinimale.Text = r.SasiaMinimale.ToString();
            CmimProduktiNew.Text = r.Cmimi.ToString("#0.00");
            CategoryCombo.SelectedItem = CategoryList.Where(x => x.DataValue == r.CategoryId).FirstOrDefault();
            TipiCombo.SelectedItem = TipetList.Where(x => x.DataValue == r.TypeId).FirstOrDefault();
            NjesiaCombo.SelectedItem= UnitList.Where(x => x.DataValue == r.UnitId).FirstOrDefault();
            IngredientDataGrid.ItemsSource = r.GetIngredientList();
        }
        

        public void GetReadyArtikullRowForUpdate()
        {

            CurrentArtikull.Asortimenti = EmerProduktiNew.Text;
            CurrentArtikull.Cmimi = Convert.ToDecimal(CmimProduktiNew.Text);
            CurrentArtikull.SasiaMinimale = Convert.ToInt32(SasiaMinimale.Text);
            CurrentArtikull.CategoryId = CategoryId = ((ComboBoxData)CategoryCombo.SelectedItem).DataValue;
            CurrentArtikull.CategoryOnlineId = ((ComboBoxData)CategoryCombo.SelectedItem).DataValueOnline;
            CurrentArtikull.UnitId= ((ComboBoxData)NjesiaCombo.SelectedItem).DataValue;
            CurrentArtikull.TypeId= ((ComboBoxData)TipiCombo.SelectedItem).DataValue;
            CurrentArtikull.UnitName= ((ComboBoxData)NjesiaCombo.SelectedItem).DisplayValue;
        }

        private void CancelUpdate_Click(object sender, RoutedEventArgs e)
        {

            CancelUpdate.Visibility = Visibility.Collapsed;
            DeleteProduct.Visibility = Visibility.Collapsed;
            CurrentArtikull = new ArtikullListRowSimple();
            CurrentArtikull.CategoryId = CategoryId;
            CurrentArtikull.TypeId = Constants.SIMPLE;
            CurrentArtikull.UnitId = 4;
            ChangeSaveGUIButton();
            TipiCombo.IsEnabled = true;
            BindToGUI(CurrentArtikull);
        }



        private static void SelectivelyHandleMouseButton(object sender, MouseButtonEventArgs e)
        {
            var textbox = (sender as TextBox);
            if (textbox != null && !textbox.IsKeyboardFocusWithin)
            {
                if (e.OriginalSource.GetType().Name == "TextBoxView")
                {
                    e.Handled = true;
                    textbox.Focus();
                }
            }
        }

        private static void SelectAllText(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)
                textBox.SelectAll();
        }

        private bool ValidateFields()
        {
            StringBuilder s = new StringBuilder();
            bool returnedvalue = true;
            decimal a;
            if (String.IsNullOrEmpty(EmerProduktiNew.Text))
            {
                s.AppendLine("Emri i Produktit nuk mund te jete bosh !");
                returnedvalue = returnedvalue && false;

            }

            try
            {
                Convert.ToDecimal(CmimProduktiNew.Text);
            }
            catch
            {

                s.AppendLine("Cmimi  i Produktit duhet te jete numer !");
                returnedvalue = returnedvalue && false;
            }


            try
            {
                if (CurrentArtikull.GetType() == typeof(ArtikullListRowComposed) && CurrentArtikull.GetIngredientList().Count == 0)
                {


                    s.AppendLine("Duhet te kete te pakten nje perberes ne liste ! ");
                    returnedvalue = returnedvalue && false;
                }
            }
            catch
            {

            }


            if (CategoryCombo.SelectedItem == null)
            {
                s.AppendLine("Nuk ka asnje kategori produktesh !");
                returnedvalue = returnedvalue && false;
            }


            if (!returnedvalue)
                MessageBox.Show(s.ToString());
            return returnedvalue;
        }

        private void AllProducts_Click(object sender, RoutedEventArgs e)
        {
            CategoryId = -1;
            LoadDataAsync(CategoryId);
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {


            Thread deleteTh = new Thread(() =>
              {

                  


                  if (ArtikullService.DeleteProduct(CurrentArtikull))
                  {

                      Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                       (ThreadStart)delegate ()
                       {

                           ObservableCollection<ArtikullListRow> l = (ObservableCollection<ArtikullListRow>)ListArtikujContainer.ItemsSource;
                           l.Remove(CurrentArtikull);
                           CancelUpdate_Click(null, null);
                           CloseLoading();

                       }
                                     );
                     
                  }

              });

            deleteTh.Start();
            ShowLoading();

          
        }


        public void ShowLoading()
        {
            dialog = new LoadingDialog();

            dialog.ShowDialog();
        }

        public void CloseLoading()
        {

            dialog.Close();
        }

        private void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {


            String PATH;

            //chose destination to create file
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                PATH = openFileDialog.SelectedPath;

            }
            else
            {
                return;
            }

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Cells[1, 1].Value = "Nr";
            workSheet.Cells[1, 2].Value = "Artikulli";
            workSheet.Cells[1, 3].Value = "Cmimi Shitjes";
            workSheet.Cells[1, 4].Value = "Kategoria";
            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var item in ArtikullService.GetArtikujForExcelExport()) 
            {
                workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                workSheet.Cells[recordIndex, 2].Value = item.Asortimenti;
                workSheet.Cells[recordIndex, 3].Value = item.Cmimi;
                workSheet.Cells[recordIndex, 4].Value = item.Kategoria;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();

            string filename = "ListArtikujsh.xlsx";

            try
            {
                FileStream objFileStrm = File.Create(@"" + PATH +"\\"+ filename);
                objFileStrm.Close();

                //Write content to excel file    
                File.WriteAllBytes(@"" + PATH +"\\"+filename, excel.GetAsByteArray());

                MessageBox.Show("Sukses !");
            }
            catch
            {

                MessageBox.Show("Dicka shkoi gabim");
            }
            


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            CurrentArtikull = new ArtikullListRowSimple();
            LoadGrupet();
            ListArtikujContainer.ItemsSource = new ObservableCollection<ArtikullListRow>();
            //Load comboBox categoriees,EXCEPT ALL option
            LoadComboCategory();

            AddTextBoxSelectTextEvent();
            LastCategoryButtonClicked = new Button();


            KerkoText.Focus();




            TipetList = ArtikullService.getMenuItemsTypes();
            TipiCombo.ItemsSource = TipetList; 
            TipiCombo.SelectedIndex = 0;
            UnitList= ArtikullService.getMenuItemsUnits();
            NjesiaCombo.ItemsSource = UnitList;
            NjesiaCombo.SelectedIndex = 3;
            EmerProduktiNew.Text = "";
            SasiaMinimale.Text = CurrentArtikull.SasiaMinimale.ToString();
            CmimProduktiNew.Text = CurrentArtikull.Cmimi.ToString("#0.00");

        }

        private void TipiCombo_Selected(object sender, RoutedEventArgs e)
        {
            var selectedTipi =(ComboBoxData) TipiCombo.SelectedItem;
        
            if (selectedTipi != null)
            {
                if (selectedTipi.DataValue ==Constants.COMPOSED)
                {

                    
                    RecepturaPanel.Visibility = Visibility.Visible;


                    if (CurrentArtikull.GetType() == typeof(ArtikullListRowSimple))
                    {
                       CurrentArtikull= CurrentArtikull.switchType();
                        IngredientDataGrid.ItemsSource = CurrentArtikull.GetIngredientList();
                    }
                }
                else
                {
                    RecepturaPanel.Visibility = Visibility.Collapsed;
                    if (CurrentArtikull.GetType() == typeof(ArtikullListRowComposed))
                       CurrentArtikull= CurrentArtikull.switchType();

                }



                //enable and disable cmimi,field

                if (selectedTipi.DataValue == Constants.INGRIEDENT)
                {
                    CmimProduktiNew.IsEnabled = false;

                }
                else
                {
                    CmimProduktiNew.IsEnabled = true;
                }
                if (selectedTipi.DataValue == Constants.COMPOSED)
                {
                    SasiaMinimale.IsEnabled = false;

                }
                else
                {
                    SasiaMinimale.IsEnabled = true;
                }



            }

        }

        private void AddToIngredientList_Click(object sender, RoutedEventArgs e)
        {


            try
            {
               
                var selecteditem = (ArtikullListRow)ListArtikujContainer.SelectedItem;

                if (CurrentArtikull.ProduktId == selecteditem.ProduktId)
                {
                    MessageBox.Show("Nuk mund te shtosh si perberes produktin qe po modifikon !");
                    return;
                }
                    var cloneObject = selecteditem.Clone();
                cloneObject.Sasi = 0;
                CurrentArtikull.AddChild(cloneObject);
               

            }
            catch(Exception ex)
            {

            }
        }

        private void IngredientDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridColumn column = IngredientDataGrid.CurrentColumn;

            DataGridColumnHeader columnHeader = GetColumnHeaderFromColumn(column);


            if (IngredientDataGrid.Items.Count > 0)
            {
                if (columnHeader.Content.ToString() == "Asortimenti")
                {

                    var f = (ArtikullListRow)IngredientDataGrid.SelectedItem;
                    CurrentArtikull.GetIngredientList().Remove(f);
                    

                }
            }
        }
        //dublicate with fletehyrje ,create a class with this function
        private DataGridColumnHeader GetColumnHeaderFromColumn(DataGridColumn column)
        {
            // dataGrid is the name of your DataGrid. In this case Name="dgBooks"
            List<DataGridColumnHeader> columnHeaders = GetVisualChildCollection<DataGridColumnHeader>(IngredientDataGrid);
            foreach (DataGridColumnHeader columnHeader in columnHeaders)
            {
                if (columnHeader.Column == column)
                {
                    return columnHeader;
                }
            }
            return null;
        }

        public List<T> GetVisualChildCollection<T>(object parent) where T : Visual
        {
            List<T> visualCollection = new List<T>();
            GetVisualChildCollection(parent as DependencyObject, visualCollection);
            return visualCollection;
        }

        private void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : Visual
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }

        
    }
}
