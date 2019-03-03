using MYBAR.CustomControls;
using MYBAR.Services;
using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace MYBAR.View.Artikuj
{
    /// <summary>
    /// Interaction logic for ArtikullHistory.xaml
    /// </summary>
    public partial class ArtikullHistory : UserControl
    {
        public ArtikullHistory()
        {
            InitializeComponent();

            LoadCategory();
        }

        private void LoadCategory()
        {
            foreach (var item in FatureService.getMenuCategories())
            {
                TreeViewItem t = new TreeViewItem { Header = item.Name };
                t.MouseLeftButtonUp += (s, e) =>
                {

                    if (t.Items.Count == 0)
                    {
                        LoadCategoryItems(item.Id, t);
                        t.ExpandSubtree();
                    }

                };

                tree.Items.Add(t);
            }
        }

        private void LoadCategoryItems(int id,TreeViewItem t)
        {
            foreach (var item in FatureService.getMenuItemsForFatureHyrje(id))
            {


                Run r = new Run(item.Asortimenti);
                Hyperlink node = new Hyperlink(r);
                node.Click += (s, e) =>
                {
                    RaportContainer.Content = new LoadingAnimation();

                    Thread th = new Thread(() =>
                    {
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                         (ThreadStart)delegate ()
                         {

                             ReportViewer V = new ReportViewer(RaporteService.getArtikullHistory(item.Productid, item.Asortimenti,StartDate.getDateTime(),EndDate.getDateTime()));
                             RaportContainer.Content = V;
                         }
                       );


                    });

                    th.Start();
                    
                };
               

                t.Items.Add(node);

            } 
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            StartDate.Data.SelectedDate = startDate;
            EndDate.Data.SelectedDate = endDate;
        }
    }
}
