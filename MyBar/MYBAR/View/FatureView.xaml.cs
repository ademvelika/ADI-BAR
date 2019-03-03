using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Raports;
using MYBAR.Services;
using MYBAR.View.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for Fature.xaml
    /// </summary>
    public partial class FatureView : UserControl
    {

        public Model.FatureBase fatura;
        public FatureView(Model.FatureBase fat)
        {
            InitializeComponent();

            //set fature model
            fatura = fat;


            //gui rights


            FreeTable.IsEnabled = fatura.TavolinaDropDownEnabled;


            //load data from menu and menu items
            FatureBody.ItemsSource = fatura.FatureRows;
            FatureBody2.ItemsSource = fatura.NewFatureRow;
           

            refresh();
        }
        //focus events
        private void LoadFreeTables()
        {

            List<ComboBoxData> l = TavolinaService.getFreeTables(fatura.TavolineId);

            FreeTable.ItemsSource = l;
            FreeTable.DisplayMemberPath = "DisplayValue";
            FreeTable.SelectedIndex = l.IndexOf(l.Where(x => x.DataValue == fatura.TavolineId).FirstOrDefault());
        }

        public void LoadMenuCategories()
        {

            var list = FatureService.getMenuCategories();
            foreach (var t in list)
            {

                Button b = new Button();
                b.Content = t.Name;
                b.FontSize = 22;


                //tuple as Tag with two parameters ,id and name of menucategories
                b.Tag = Tuple.Create(t.Id, t.Name);
              
                b.Click += (s, e) =>
                {

                    LoadMenuItems(t.Id);




                };
                Grupet.Children.Add(b);
            }

            if (list.Count > 0)
                LoadMenuItems(list[0].Id);

        }

        public void LoadMenuItems(int menuCat)
        {

            Produktet.Children.Clear();


            LoadMenuItemsFromCollection(FatureService.getMenuItems(menuCat));


        }

        private void LoadMenuItemsFromCollection(List<FatureRow> list)
        {

            foreach (var t in list)
            {


                Grid g = new Grid();
                ColumnDefinition d = new ColumnDefinition();
                d.Width = new GridLength(1, GridUnitType.Auto);
                ColumnDefinition d1 = new ColumnDefinition();
                d1.Width = new GridLength(1, GridUnitType.Star);
                ColumnDefinition d2 = new ColumnDefinition();
                d2.Width = new GridLength(1, GridUnitType.Auto);

                g.ColumnDefinitions.Add(d);
                g.ColumnDefinitions.Add(d1);
                g.ColumnDefinitions.Add(d2);

                TextBlock l = new TextBlock();
                l.Text = t.Asortimenti;
                l.Padding = new Thickness(7, 0, 0, 0);
                l.TextWrapping = TextWrapping.Wrap;
                l.FontSize = 22;
                l.FontWeight = FontWeights.Black;
                l.VerticalAlignment = VerticalAlignment.Center;
                Label l2 = new Label();
                l2.Content = t.Cmim.ToString("#,#0.00");
                Grid.SetColumn(l, 0);
                l2.FontSize = 22;
                l2.Padding = new Thickness(0, 0, 7, 0);
                l2.VerticalAlignment = VerticalAlignment.Center;
                l2.FontWeight = FontWeights.Black;
                Grid.SetColumn(l2, 2);
                g.Children.Add(l);
                g.Children.Add(l2);

                l.Foreground = Brushes.White;
                l2.Foreground = Brushes.White;
                Style style = this.FindResource("ProductStyle") as Style;
                g.Style = style;


                //eventi i klikimit te produikteve
                g.MouseLeftButtonDown += (s, e) =>
                {


                    //FatureRow F = new FatureRow();
                    //F.Productid = t.Productid;
                    //F.Sasi = 1;
                    //F.Cmim = t.Cmim;
                    //F.Asortimenti = t.Asortimenti;
                    //F.Cmimi = t.Cmim.ToString("#,#0.00");
                    //F.ProductOnlineId = t.ProductOnlineId;
                    FatureRow frow = fatura.getProductInList(t.Productid);
                    
                    if (frow != null)
                    {
                        frow.Sasi++;


                    }

                    else
                    {
                        t.Sasi = 1;
                        fatura.ReferenceFatureRows.Add(t);

                    }

                    //gui control show hide mbyll fature




                    refresh();
                };

                //tuple as Tag with two parameters ,id and name of menucategories

                Produktet.Children.Add(g);


            }

        }

        private void FatureBody_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {



            if (fatura.GetType() != typeof(FatureEdit))
            {


                FatureRow fr = (FatureRow)FatureBody.SelectedItem;

                if (fr != null)
                {

                    if (fr.Sasi == 1)
                    {
                        fatura.FatureRows.Remove(fr);

                    }
                    else
                    {
                        fr.Sasi--;

                    }

                    refresh();

                }

            }

            //gui




        }

        private void refresh()
        {
            FatureBody.Items.Refresh();
            FatureBody2.Items.Refresh();
            Total.Content = fatura.GetTotal().ToString("#,#0.00");

        }

        private void Ruaj_Click(object sender, RoutedEventArgs e)
        {

            FastSearch.Focus();
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

        private void Dil_Click(object sender, RoutedEventArgs e)
        {

            CloseTable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

        private void CloseTable()
        {



            MainWindow m = (MainWindow)App.Current.MainWindow;
            m.CenterWindow.WindowUser.Content = new Tavolinat();
        }



        private void FatureBody2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FatureRow fr = (FatureRow)FatureBody2.SelectedItem;

            if (fr != null)
            {

                if (fr.Sasi == 1)
                {
                    fatura.ReferenceFatureRows.Remove(fr);

                }
                else
                {
                    fr.Sasi--;

                }

                refresh();
            }
        }

        private void FreeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
            var itemselected = FreeTable.SelectedItem as ComboBoxData;
            fatura.TaVolineOnlineId = itemselected.DataValueOnline;
            fatura.TavolineId = itemselected.DataValue;
        }

        private void FaturePermbledhese_Click(object sender, RoutedEventArgs e)
        {
            if (fatura.GetType()==typeof(FatureEdit))
            {
                MainWindow main = (MainWindow)App.Current.MainWindow;
                if (RegisterData.PM == "1")
                    Button_Click_1(null, null);
                FatureBuilder builder = new FatureBuilder(FatureService.getFaturePreviewPermbledhese(fatura.FatureId));
                Printer.PrintFlowDocumentOneCopy(builder.getFaturePermbledheseReceipment(main.UserName));

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FastSearch.Focus();
            LoadMenuCategories();
            LoadFreeTables();
        }

        private void FastSearch_KeyUp(object sender, KeyEventArgs e)
        {

            string name = FastSearch.Text;
            Produktet.Children.Clear();
            Thread th = new Thread(() =>
            {
                var list = FatureService.getMenuItemsByStartName(name);



                Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                         (ThreadStart)delegate ()
                        {

                            if(name!="")
                         LoadMenuItemsFromCollection(list);
                        }
                         );
            });

            if(e.Key!=Key.CapsLock)
            th.Start();
        }

        private void ScrollViewer_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }

        private void ProductsScroll_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
    }
}
