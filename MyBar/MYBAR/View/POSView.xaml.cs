using MYBAR.CustomControls;
using MYBAR.CustomControls.POS;
using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Raports;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MYBAR.View.POS
{
    /// <summary>
    /// Interaction logic for POS.xaml
    /// </summary>
    public partial class POSView : UserControl
    {

        public FatureBase fatura;

        private FatureGrid SelectedGrid;
        public POSView(FatureBase fat)
        {
            InitializeComponent();

            fatura = fat;


            FreeTable.IsEnabled = fatura.TavolinaDropDownEnabled;

           if(fatura.TavolinaDropDownEnabled==false)
            {
                SelectedGrid = MYGRIDOPEN;
                MYGRID.IsEnabled = false;
               
            }
            else
            {
                SelectedGrid = MYGRID;
            }
        
               
            
            MYGRID.ParentGUI = this;
            MYGRID.ItemsSource = fatura.FatureRows;
            MYGRID.LoadFirstTime(fatura.FatureRows);

            MYGRIDOPEN.ParentGUI = this;
            MYGRIDOPEN.ItemsSource = fatura.NewFatureRow;
            MYGRIDOPEN.Head.Visibility = Visibility.Collapsed;
            CalculateTotal();
        }


        private void LoadFreeTables()
        {

            List<ComboBoxData> l = TavolinaService.getFreeTables(fatura.TavolineId);

            FreeTable.ItemsSource = l;
            FreeTable.DisplayMemberPath = "DisplayValue";
            FreeTable.SelectedIndex = l.IndexOf(l.Where(x => x.DataValue == fatura.TavolineId).FirstOrDefault());
        }

        public void LoadArtikujt(int id)
        {

            Artikujt.Children.Clear();

            //  var back = App.Current.Resources["shiritibackgroud"] as LinearGradientBrush;
            loadArikujIntoGUI(FatureService.getMenuItems(id));
        }


        private void loadArikujIntoGUI(List<FatureRow> list)
        {
            foreach (var item in list)
            {


                Button prod = new Button();
                prod.FontSize = 8;
                prod.Margin = new Thickness(2);
                prod.Height = 100;
                prod.Width = 120;
               
                StackPanel stack = new StackPanel();
                //stack.HorizontalAlignment = HorizontalAlignment.Center;
                stack.VerticalAlignment = VerticalAlignment.Center;
                TextBlock text = new TextBlock { Text = item.Asortimenti,FontSize=15,FontWeight=FontWeights.SemiBold, TextWrapping = TextWrapping.Wrap, TextAlignment = TextAlignment.Left, Margin=new Thickness(0,0,0,0) };
                TextBlock cmim = new TextBlock { Text = ((int)item.Cmim).ToString(), Margin = new Thickness(10, 5, 0, 0), FontWeight = FontWeights.Regular, FontSize = 12, TextWrapping = TextWrapping.Wrap, TextAlignment = TextAlignment.Right };
                stack.Children.Add(text);
                stack.Children.Add(cmim);


                prod.Content = stack;
                prod.Background = Brushes.White;
                prod.Click += (s, e) =>
                {



                    //getIfexit

                    var inlistitem = SelectedGrid.getProductInList(item.Productid);

                    if (inlistitem == null)
                    {
                        item.SASI = 1;
                        fatura.ReferenceFatureRows.Add(item);


                    }
                    else
                    {
                        inlistitem.SASI++;
                    }



                    CalculateTotal();



                };
                Artikujt.Children.Add(prod);


            }
        }

        /// <summary>
        /// 
        /// get model if exist,or null rather
        /// </summary>

    

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            //set instance to static class
            Dependency.POS = this;

            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewMouseLeftButtonDownEvent,
            new MouseButtonEventHandler(SelectivelyHandleMouseButton), true);
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotKeyboardFocusEvent,
              new RoutedEventHandler(SelectAllText), true);


            BrushConverter bc = new BrushConverter();
            //var backborder = App.Current.Resources["shiritibackgroud"] as LinearGradientBrush;
            var back = (Brush)bc.ConvertFrom("#57bc90");
            var list = FatureService.getMenuCategories();
            foreach (var t in list)
            {

                Border border = new Border();
                
                Button b = new Button();
                b.Padding = new Thickness(2, 10, 2, 10);
                b.Content = t.Name;
                b.FontSize = 22;
                b.Margin = new Thickness(1, 1, 1, 1);
                b.FontWeight = FontWeights.Bold;
                b.FontFamily = new FontFamily("Bookman");
                b.Background = back;
                b.Foreground = Brushes.White;
                b.HorizontalContentAlignment = HorizontalAlignment.Left;
                //tuple as Tag with two parameters ,id and name of menucategories
                b.Tag = Tuple.Create(t.Id, t.Name);

                b.Click += (s,ev) =>
                {



                    LoadArtikujt(t.Id);

                };

                border.Child = b;
                Grupet.Children.Add(border);
               
            }

            if (list.Count > 0)
            {
                LoadArtikujt(list[0].Id);

            }
            LoadFreeTables();

            //set one reference for all object types

        }

      

        public void CalculateTotal()
        {
            decimal sum = 0;
            sum = fatura.GetTotal();
            Total.Content = sum.ToString("#,#0.00");
        }

       

        private void Printo_Click(object sender, RoutedEventArgs e)
        {
            var d =new LoadingDialog();
            d.ShowDialog();
        }

        private void FreeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var itemselected = FreeTable.SelectedItem as ComboBoxData;
            fatura.TaVolineOnlineId = itemselected.DataValueOnline;
            fatura.TavolineId = itemselected.DataValue;
        }

        private void Ruaj_Click(object sender, RoutedEventArgs e)
        {
            if (fatura.CanCloseOrSaveTable())
            {

                fatura.Save();

                CloseTable();
            }
            else
            {
                MessageBox.Show("Duhet te shtoni te pakten nje produkt ne liste !");
            }
        }

        private void CloseTable()
        {



            MainWindow m = (MainWindow)App.Current.MainWindow;
            m.CenterWindow.WindowUser.Content = new Tavolinat();
        }

        private void Dil_Click(object sender, RoutedEventArgs e)
        {

            CloseTable();
        }

        private void MbyllFature_Click(object sender, RoutedEventArgs e)
        {

            if (fatura.CanCloseOrSaveTable())
            {
                fatura.CloseTable();

                CloseTable();
            }
            else
            {
                MessageBox.Show("Duhet te shtoni te pakten nje produkt ne liste !");
            }
        }

        private void FaturePermbledhese_Click(object sender, RoutedEventArgs e)
        {
            if (fatura.GetType() == typeof(FatureEdit))
            {
                MainWindow main = (MainWindow)App.Current.MainWindow;
               
                if (RegisterData.PM == "1")
                    MbyllFature_Click(null, null);
                FatureBuilder builder = new FatureBuilder(FatureService.getFaturePreviewPermbledhese(fatura.FatureId));
                Printer.PrintFlowDocumentOneCopy(builder.getFaturePermbledheseReceipment(main.UserName));
               
            }
        }

        private void FastSearch_KeyUp(object sender, KeyEventArgs e)
        {

            string name = FastSearch.Text;
            Artikujt.Children.Clear();
            Thread th = new Thread(() =>
            {
                var list = FatureService.getMenuItemsByStartName(name);



                Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                         (ThreadStart)delegate ()
                         {

                             if (name != "")
                                 loadArikujIntoGUI(list);
                         }
                         );
            });

            if (e.Key != Key.CapsLock)
                th.Start();
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

    }
}
