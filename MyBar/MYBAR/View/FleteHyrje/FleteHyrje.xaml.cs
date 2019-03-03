using MYBAR.CustomControls;
using MYBAR.Helper;
using MYBAR.Interface;
using MYBAR.Model;
using MYBAR.Model.FatureModel;
using MYBAR.Services;
using MYBAR.View.KerkoDialog;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System;

namespace MYBAR.View.Inventar
{
    /// <summary>
    /// Interaction logic for FleteHyrje.xaml
    /// </summary>
    public partial class FleteHyrje : UserControl, SearchDialogInterface
    {

        public FatureBase faturehyrje;
        LoadingDialog d;

        public FleteHyrje()
        {
            InitializeComponent();
            faturehyrje = new FatureHyrje();

            GetReadyForm();
        }

        public void getModelExtrenal(FatureHyrje h)
        {
            faturehyrje = h;

            FH.ItemsSource = h.ReferenceFatureRows;
        }


        private void GetReadyForm()
        {
            LoadMenuCategories();

            setGUIElements();
            //save dependency for changes in fatureBody
            Dependency.FATURE_HYRJE = this;

            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewMouseLeftButtonDownEvent,
             new MouseButtonEventHandler(SelectivelyHandleMouseButton), true);
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotKeyboardFocusEvent,
              new RoutedEventHandler(SelectAllText), true);
        }
        private void LoadMenuCategories()
        {

            foreach (var item in FatureService.getMenuCategories())
            {

              Button t = new Button { Content = item.Name,FontSize=14,FontWeight=FontWeights.Bold };
                t.Height = 40;
               
                t.Click += (s, e) =>
                {

                    Dispatcher.Invoke(() =>
                    {
                        LoadMenuItems(item.Id);
                    });
                };

                Grupet.Children.Add(t);

            }


        }



        private void LoadMenuItems(int id)
        {
            Produktet.Children.Clear();
            Produktet.Children.Add(getHeader());
            foreach (var item in FatureService.getMenuItemsForFatureHyrje(id))
            {
                ProduktEmerSasi line = new ProduktEmerSasi(item.Asortimenti, item.SasiStatus);
                line.Emer.FontSize = 14;
                line.Emer.FontWeight = FontWeights.Bold;
                addClickEventToArtikujButton(line, item);


                Produktet.Children.Add(line);


            }


        }

        private ProduktEmerSasi getHeader()
        {

            var header = new ProduktEmerSasi("Asortimenti", "Sasia ne Magazine");
            header.MainContainer.Background = Brushes.White;
         
            header.BorderBrush = Brushes.Black;
            header.Emer.Foreground = Brushes.Black;
            header.Sasi.Foreground = Brushes.Black;
            Thickness margin = header.Margin;
            margin.Top = 0;
            margin.Bottom = 0;
            header.Margin = margin;
            return header;

        }


        private void addClickEventToArtikujButton(ProduktEmerSasi line, FatureRow item)
        {
            line.MainContainer.MouseLeftButtonDown += (s, e) =>
            {

                try
                {
                    FatureRow selecteditem = faturehyrje.getProductInList(item.Productid);
                    if (selecteditem == null)
                        faturehyrje.ReferenceFatureRows.Add(item);
                    else
                    {
                        selecteditem.Sasi += 1;
                        Total.Text = faturehyrje.GetTotal().ToString("#,#0.00");
                        FH.Items.Refresh();
                    }
                }
                catch
                {


                }


            };
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

        private void FH_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {



            DataGridColumn column = FH.CurrentColumn;

            DataGridColumnHeader columnHeader = GetColumnHeaderFromColumn(column);


            if (FH.Items.Count > 0)
            {

                if (columnHeader.Content != null)
                {
                    if (columnHeader.Content.ToString() == "Asortimenti")
                    {

                        FatureRow f = (FatureRow)FH.SelectedItem;
                        faturehyrje.ReferenceFatureRows.Remove(f);
                        Total.Text = faturehyrje.GetTotal().ToString("#,#0.00");

                    }
                }
            }



        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            faturehyrje.OrderNumber = NrFatureLabel.Text;
           
            if (faturehyrje.ReferenceFatureRows.Count > 0)
            {

                Thread thread = new Thread(SaveAsync);
                thread.Start();
                d = new LoadingDialog();
                d.Show();
            }
            else
            {
                MessageBox.Show("Duhet te keni te pakten nje produkt ne faturen e hyrjes !");
            }
        }

        public void SaveAsync()
        {

            //latency for testing
            // Thread.Sleep(2000);

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart)delegate ()
                        {
                          
                          
                            faturehyrje.FatureOnlineId =0;
                            if (faturehyrje.Save())
                            {


                                d.Close();
                                MessageBox.Show(faturehyrje.MessageOnSaveUpdate);
                                New_Click(null, null);



                            }

                        }
                        );




        }

        private void Kerko_Click(object sender, RoutedEventArgs e)
        {
            KerkoForm kerko = new KerkoForm("Nr Fature", this);
            kerko.ShowDialog();

            if (kerko.ID > -1)
            {
                d = new LoadingDialog();
                d.Show();
                Thread th = new Thread(() =>
                  {
                      this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                         (ThreadStart)delegate ()
                         {
                             faturehyrje = FatureService.getFatureHyrje(kerko.ID);
                             //Very important in update mode,
                             //new changed are saved in new collection ,for compare between old rows and new rows 

                             faturehyrje.ReferenceFatureRows = faturehyrje.NewFatureRow;
                             //==============================================================================

                             //set data in gui 
                              Save.Content = "Modifiko";
                             setGUIElements();
                             d.Close();
                         }
                       );

                  });

                th.Start();

            }

        }

        private void SearchArtikullBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchArtikuj();
        }

        private void KerkoArtikullTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                SearchArtikuj();
            }
        }


        public void SearchArtikuj()
        {
            //SearchTabItemContainer.Children.Clear();
            //SearchTabItemContainer.Children.Add(getHeader());
            //foreach (var item in ArtikullService.getAllArtikujByStartName(KerkoArtikullTextBox.Text))
            //{
            //    ProduktEmerSasi line = new ProduktEmerSasi(item.Asortimenti, item.SasiStatus);
            //    addClickEventToArtikujButton(line, item);

            //    SearchTabItemContainer.Children.Add(line);
            //}

            //SearchTabItem.Visibility = Visibility.Visible;
            //Grupet.SelectedIndex = 0;
        }


        private void setGUIElements()
        {
            FH.ItemsSource = faturehyrje.ReferenceFatureRows;
            NrFatureLabel.Text = faturehyrje.OrderNumber;
            DataLabel.Content = faturehyrje.OrderDate;

            PrintInScreen.Visibility = faturehyrje.DeleteOptionVisible;
            //MODIFY FOR ONLY SAVE 
            if (faturehyrje.DeleteOptionVisible == Visibility.Visible)
            {
                DeleteBtn.Visibility = Visibility.Hidden;
                Save.Visibility = Visibility.Hidden;
            }
            else
            {
                DeleteBtn.Visibility = Visibility.Hidden;
                Save.Visibility = Visibility.Visible;
            }

            DirectPrint.Visibility = faturehyrje.DeleteOptionVisible;
            Total.Text = faturehyrje.GetTotal().ToString("#,#0.00");

        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            faturehyrje = new FatureHyrje();
            Save.Content = "Ruaj";
            setGUIElements();
        }





        private DataGridColumnHeader GetColumnHeaderFromColumn(DataGridColumn column)
        {
            // dataGrid is the name of your DataGrid. In this case Name="dgBooks"
            List<DataGridColumnHeader> columnHeaders = GetVisualChildCollection<DataGridColumnHeader>(FH);
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

        private void PrintInScreen_Click(object sender, RoutedEventArgs e)
        {

            MainWindow m = (MainWindow)App.Current.MainWindow;

            ReportViewer r = new ReportViewer(RaporteService.getFleteHyrjeRaport(faturehyrje.FatureId));
            ReportDialog d = new ReportDialog();
            d.RaportContainer.Content = r;
            d.ShowDialog();


        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Jeni te sigurt per fshirjen e fatures ?", "Konfirmim", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (faturehyrje.Delete())
                {
                    MessageBox.Show("Fatura u fshij me Sukses !");
                    New_Click(null, null);
                }
            }
        }

        private void DirectPrint_Click(object sender, RoutedEventArgs e)
        {
            var r = RaporteService.getFleteHyrjeRaport(faturehyrje.FatureId);

            PrintDirect d = new PrintDirect();
            d.Run(r.getLocalReport());

        }

    

        public bool DoubleClickEventFunction(object item)
        {
            //empty,choose fature hyrje and close

            return true;
        }

        public bool HasTotal()
        {
            return true;
        }

        public dynamic getListItems(DateTime startdate, DateTime enddate, string word = "")
        {
           return  KerkimeDialogService.getFatureHyrjeSearchList(startdate,enddate, word);
        }
    }




}
