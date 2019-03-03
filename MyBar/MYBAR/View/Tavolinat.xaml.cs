using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Services;
using MYBAR.View.POS;
using MYBAR.View.Tavolina;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for Tavolinat.xaml
    /// </summary>
    public partial class Tavolinat : UserControl
    {

        private List<Int32> busyList = new List<int>();
        public MainWindow MAIN;
        public Tavolinat()
        {
            InitializeComponent();

            MAIN = (MainWindow)App.Current.MainWindow;

            LoadXhiro();
            LoadTavolina();

           
        }

        private void LoadXhiro()
        {
            XhirorealeLabel.Content = BackgroundWorker.getXhiroDitore().XhiroKaseFiskale.ToString("#,#0.00");
            XhiroKaseLabel.Content = BackgroundWorker.getXhiroDitore().XhiroKaseFiskale.ToString("#,#0.00");

            if (MAIN.UserId == MAIN.MenagerUserId)
            {
                AddNewTable.Visibility = Visibility.Visible;
            }
        }



        public int getNextFreePlace()
        {

            int i = 0;
            while (i<11*11)
            {
             if(busyList.IndexOf(i) == -1)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }

            return -1;
        }
        public void LoadTavolina()
        {

            //get UserId

            MainWindow mainwindow = (MainWindow)App.Current.MainWindow;
            String USERID = mainwindow.UserId;




            //dynamic<int,int,int,bool> [id,number,index,open,userid] (id=>table id,number=>nameof table, index=>position in gui ,open=>open or closed table ...element of tavolina variable
            var tavolina = TavolinaService.GetAllTables();

            int nrtavolinaveReale = tavolina.Count;

            var sqrtnumber = Convert.ToInt16(Math.Sqrt(tavolina.Count * 2));

            //static,later implemention
            sqrtnumber = 11;


            TavolinaContainer.Rows = sqrtnumber;
            TavolinaContainer.Columns = sqrtnumber;

            Thickness margin = TavolinaContainer.Margin;
            margin.Left = 2;
            margin.Bottom = 2;



            //build grid with empty label with position as list index

            for (int j = 0; j < sqrtnumber; j++)
            {

                for (int z = 0; z < sqrtnumber; z++)
                {

                    //Border border = new Border();
                    Label b1 = new Label();

                    b1.Content = "";
                    b1.IsEnabled = false;
                    //b1.BorderBrush = Brushes.Black;
                    //b1.BorderThickness = new Thickness(1, 1, 1, 1);


                    Grid g = new Grid();
                    g.Children.Add(b1);
                    g.Tag = new Tuple<int, int, bool,int,int>(0, j * sqrtnumber + z, false,0, 0);

                    TavolinaContainer.Children.Add(g);

                }


            }


         
            int generatedindex=0;

            foreach (var item in tavolina)
            {

                if(item.index!=null)
                busyList.Add((int)item.index);
            }


            //add table[replace blank position in uniformgrid with real table with their posiotion if have one]
            foreach (var item in tavolina)
            {


                Label b = new Label();
                b.Margin = margin;
                b.Content = "" + item.Number;

                b.Tag = item.Id;
                b.HorizontalAlignment = HorizontalAlignment.Center;
                b.VerticalAlignment = VerticalAlignment.Center;
                b.FontFamily = new FontFamily("Arial");

                b.FontSize = 20;
                b.FontWeight = FontWeights.ExtraBold;
                b.Background = Brushes.Transparent;
                //b.Foreground = Brushes.White;

                Border insideborder = new Border { Background = Brushes.White, CornerRadius = new CornerRadius(25) };
                insideborder.Child = b;
                Grid g = new Grid(); //grid table that show in gui

                //create contextmenu for grid


               






                if (item.index == null)
                {

                  generatedindex  = getNextFreePlace();
                    g.Tag = new Tuple<int, int, bool,int,int>(item.Id, generatedindex, item.open,item.OnLineId,item.Number);
                    busyList.Add(generatedindex);
                
                  
                   
                }
                else
                {
                    g.Tag = new Tuple<int, int, bool,int,int>(item.Id, (int)item.index, item.open,item.OnLineId, item.Number);
                 
                }

                Border border = new Border();




                border.Child = insideborder;
                border.MinHeight = 50;
                border.MinWidth = 50;
                // border.HorizontalAlignment = HorizontalAlignment.Center;
                // border.VerticalAlignment = VerticalAlignment.Center;
                border.Style = (Style)FindResource("TavolinaBorder");

                //add and edit button if is adminsitartor
              
             
                AddRightClickEditMenuMenu(g, item.Id);

                //=========================if open color red and attach transfer option
                if (item.open)
                {
                    border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ff4040"));

                    //nese eshte e hapur por jo e zene nga nje tjeter user atehere mund ta transferosh ne tavolinat e lira
                    if (USERID == item.UserId || item.UserId == "")
                    {

                        AddRightClickMenu(g, tavolina);

                    }
                }

                //------------------------------------------------------------------------------------

                g.Children.Add(border);

                //if is my table add event

                if (USERID == item.UserId || item.UserId == "")
                {
                    g.MouseLeftButtonUp += TavolinaClick;

                }
                else
                {
                    b.Content = "[" + b.Content.ToString() + "]";
                }

                //replace object in uniform grid

                

                if (item.index == null)
                {
                    var selectedgrid =(Grid) TavolinaContainer.Children[generatedindex];
                    selectedgrid.Tag = g.Tag;
                    selectedgrid.Children.Clear();
                    selectedgrid.Children.Add(g);

                    //TavolinaContainer.Children.RemoveAt(generatedindex);
                   // TavolinaContainer.Children.Insert(generatedindex, g);
                }
                else
                {
                    var selectedgrid = (Grid)TavolinaContainer.Children[(int)item.index];
                    selectedgrid.Tag = g.Tag;
                    selectedgrid.Children.Clear();
                    selectedgrid.Children.Add(g);

                    //TavolinaContainer.Children.RemoveAt((int)item.index);
                    // TavolinaContainer.Children.Insert((int)item.index, g);
                }

              

            }








        }


        private void AddRightClickMenu(Grid g, dynamic tavolina)
        {

            
            //create opetion
            MenuItem m = new MenuItem { Header = "Transfero" };
      
            //fill all free tables in transfero option
            foreach (var tab in tavolina)
            {
                if (!tab.open)
                {
                    MenuItem minim = new MenuItem { Header = Convert.ToString(tab.Number), Tag = tab.Id };
                    m.Items.Add(minim);



                    //get tableid and go to change order
                    minim.Click += (s, e) =>
                    {
                        Tuple<int, int, bool,int,int> t = (Tuple<int, int, bool,int,int>)g.Tag;
                        int orderid = TavolinaService.TransferTable(t.Item1, (int)minim.Tag);
                        if (orderid!=-1)
                        {
                            
                            ContentControl parentWindow = (ContentControl)LogicalTreeHelper.GetParent(this);
                            parentWindow.Content = new Tavolinat();
                        }
                    };
                }



            }

            g.ContextMenu.Items.Add(m);
        }

        //add edit right click
        private void AddRightClickEditMenuMenu(Grid g, int id)
        {

            ContextMenu cm = new ContextMenu();
            //create opetion
            if (MAIN.UserId == MAIN.MenagerUserId)
            {
                MenuItem m = new MenuItem { Header = "Edito" };

                cm.Items.Add(m);
                m.Click += (s, e) =>
                {

                    TavolinaView t = new TavolinaView(id);
                    t.ShowDialog();
                    ContentControl parentWindow = (ContentControl)LogicalTreeHelper.GetParent(this);
                    parentWindow.Content = new Tavolinat();

                };
            }

        g.ContextMenu = cm;
        }




        private void TavolinaClick(object sender, RoutedEventArgs e)
        {

            MainWindow m = (MainWindow)App.Current.MainWindow;

            //menager can't open an order
            //if(m.UserId==m.MenagerUserId)
            //{
            //    MessageBox.Show("Ju nuk keni te drejte te  kryeni porosi !");

            //    return;
            //}


            Grid g = sender as Grid;
            Tuple<int, int, bool,int,int> t = g.Tag as Tuple<int, int, bool,int,int>;
           //hap tavoline 
;

            //controll if is open table or free table, have a diffrent datamodel
            if (t.Item3)
            {

                FatureEdit porosiopen = FatureService.getFatureOfTable(t.Item1);
                porosiopen.TaVolineOnlineId = t.Item4;
                try
                {

                    Border border = g.Children[0] as Border;
                    Label label = border.Child as Label;

                   // porosiopen.TavolineNumber = Convert.ToInt32(label.Content);
                    
                }
                catch
                {

                }

                // FatureView ft = new FatureView(porosiopen);

                var gui = RegisterData.DYNAMIC_Creator.getFatureGUI(porosiopen);      

                m.CenterWindow.WindowUser.Content = gui;
            }
            else
            {



                int tavid = t.Item5;
                var fnew = new FatureNew(t.Item1, t.Item4);
                fnew.TavolineNumber = tavid;
                // FatureView f = new FatureView(fnew);
                var gui = RegisterData.DYNAMIC_Creator.getFatureGUI(fnew);

                m.CenterWindow.WindowUser.Content = gui;

            }

        }

        void Button_Drop(object sender, MouseButtonEventArgs e)
        {
            Grid aGrid = (Grid)sender;
            DataObject dataObj = new DataObject(aGrid);
            DragDrop.DoDragDrop(aGrid, dataObj, DragDropEffects.Move);
        }



        private void TavolinaContainer_Drop(object sender, DragEventArgs e)
        {
            Grid source = (Grid)e.Data.GetData(typeof(Grid));
            var parent = VisualTreeHelper.GetParent(source);
            var parentAsPanel = parent as Panel;
            //if (parentAsPanel != null)
            //{
            //    parentAsPanel.Children.Remove(source);
            //}
            ////drop the selected item and query the subitem at the same time


            //TavolinaContainer.Children.Add(source);





            Grid destination = (Grid)sender;



            for (int j = 0; j < TavolinaContainer.Children.Count; j++)
            {
                Grid _grid = TavolinaContainer.Children[j] as Grid;
                _grid.AllowDrop = true;
            }

            if (source != destination)
            {


                Grid temp = source;
                int sourceindex = TavolinaContainer.Children.IndexOf(source);
                int destinationindex = TavolinaContainer.Children.IndexOf(destination);



                Tuple<int, int, bool,int,int> t2 = (Tuple<int, int, bool,int,int>)destination.Tag;
                
                Tuple<int, int, bool,int,int> t = (Tuple<int, int, bool,int,int>)source.Tag;
                //if have empty label save it dragged label with empty label and set to zero id of dragged position
                if (t2.Item1 ==0)
                {

                    //up


                    TavolinaService.SaveIndexOfTable(t.Item1, destinationindex);

                   // Console.WriteLine("Tavolina me id -->" + t.Item1 + " u vendos ne pozicionin :" + destinationindex);




                }
                else
                {

                    TavolinaService.SaveIndexOfTable(t.Item1, destinationindex);
                    TavolinaService.SaveIndexOfTable(t2.Item1, sourceindex);
                   // Console.WriteLine("Tavolina me id -->" + t.Item1 + " u vendos ne pozicionin :" + destinationindex);
                   // Console.WriteLine("Tavolina t2 me id -->" + t2.Item1 + " u vendos ne pozicionin :" + sourceindex);
                }

                var sourcegrid = source.Children[0];
                var destinationgrid=destination.Children[0];

                source.Children.Clear();
                destination.Children.Clear();
                source.Children.Add(destinationgrid);
                destination.Children.Add(sourcegrid);

                Tuple<int, int, bool, int,int> sourcecopy = new Tuple<int, int, bool, int,int>(t.Item1, t.Item2, t.Item3, t.Item4,t.Item5);

                Tuple<int, int, bool, int,int> destinationcopy = new Tuple<int, int, bool, int,int>(t2.Item1, t2.Item2, t2.Item3, t2.Item4,t.Item5);

                source.Tag = destinationcopy;
                destination.Tag = sourcecopy;
                //TavolinaContainer.Children.Remove(source);
                //TavolinaContainer.Children.Remove(destination);


                //// TavolinaContainer.Children.Remove(destination);
                //TavolinaContainer.Children.Insert(sourceindex, destination);
                //TavolinaContainer.Children.Insert(destinationindex, source);







            }


        }

        private void ripoziciono_Checked(object sender, RoutedEventArgs e)
        {

      
            foreach (Grid g in TavolinaContainer.Children)
            {

                Tuple<int, int, bool,int,int> t = (Tuple<int, int, bool,int,int>)g.Tag;
                if (t.Item1!=0)
                {

                    g.MouseLeftButtonUp -= TavolinaClick;



                }
                else
                {
                    Label l = g.Children[0] as Label;
                    l.BorderBrush = Brushes.LightGray;
                    l.BorderThickness = new Thickness(0.3);
                }
                g.AllowDrop = true;
                g.MouseLeftButtonDown += Button_Drop;
                g.Drop += TavolinaContainer_Drop;


            }

        }

        private void ripoziciono_Unchecked(object sender, RoutedEventArgs e)
        {



            foreach (Grid g in TavolinaContainer.Children)
            {

                Tuple<int, int, bool, int,int> t = (Tuple<int, int, bool, int,int>)g.Tag;
                if (t.Item1 != 0)
                {
                   
                    g.MouseLeftButtonUp += TavolinaClick;
                }
                else
                {
                    Label l = g.Children[0] as Label;
                    l.BorderBrush = Brushes.Transparent;

                }
                g.MouseLeftButtonDown -= Button_Drop;
                g.Drop -= TavolinaContainer_Drop;



            }

        }

   

        private void AddNewTable_Click(object sender, RoutedEventArgs e)
        {
            TavolinaView t = new TavolinaView();

             t.ShowDialog();

            ((MainWindow)App.Current.MainWindow).CenterWindow.WindowUser.Content = new Tavolinat();


        }

        private void ResetTable_Click(object sender, RoutedEventArgs e)
        {
            TavolinaService.resetPositions();

           

            ((MainWindow)App.Current.MainWindow).CenterWindow.WindowUser.Content = new Tavolinat();

        }

        private void SettingTavolinaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TavolinaSettingPanel.Visibility == Visibility.Hidden)
            {
                TavolinaSettingPanel.Visibility = Visibility.Visible;

            }
            else
            {
                TavolinaSettingPanel.Visibility = Visibility.Hidden;
            }
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
               if(Switch.IsChecked??false)
            {
                ripoziciono_Checked(null, null);
            }
            else
            {
                ripoziciono_Unchecked(null, null);
            }
        }
    }

}
