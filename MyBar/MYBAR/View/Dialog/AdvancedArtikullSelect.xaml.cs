using MYBAR.Interface;
using MYBAR.Model;
using MYBAR.Services;
using MYBAR.View.Artikuj;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using static MYBAR.Services.KerkimeDialogService;

namespace MYBAR.View.Dialog
{
    /// <summary>
    /// Interaction logic for AdvancedArtikullSelect.xaml
    /// </summary>
    public partial class AdvancedArtikullSelect : Window
    {

        private ShitjetArtikuj ParentWindow { get; set; }
        public AdvancedArtikullSelect(ShitjetArtikuj s)
        {
            InitializeComponent();

            ParentWindow = s;
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

                Button b = new Button();
                TextBlock text = new TextBlock();
              if(ParentWindow.ArtikujChoseList.Where(x => x.Id == t.Productid).Any())
                {
                    text.Foreground = Brushes.Red;
                }
                text.TextWrapping = TextWrapping.Wrap;
                text.Text = t.Asortimenti;
                text.FontSize = 14;
                text.FontWeight = FontWeights.Bold;
                text.FontFamily = new FontFamily("Arial");
                b.Content = text;
             
                Style style = this.FindResource("ProductStyle") as Style;
                b.Style = style;


                //eventi i klikimit te produikteve
                b.Click += (s, e) =>
                {
                    text.Foreground = Brushes.Red;
                    ArtikujSearchRow a = new ArtikujSearchRow();
                    a.Id = t.Productid;
                    a.Asortimenti = t.Asortimenti;

                    ParentWindow.DoubleClickEventFunction(a);

                };

                //tuple as Tag with two parameters ,id and name of menucategories

                Produktet.Children.Add(b);


            }

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

                             if (name != "")
                                 LoadMenuItemsFromCollection(list);
                         }
                         );
            });

            if (e.Key != Key.CapsLock)
                th.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMenuCategories();
            MainWindow mainWindow =(MainWindow) App.Current.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2+50;
        }
    }
}
