using MYBAR.Model;
using MYBAR.View.POS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MYBAR.CustomControls.POS
{
    /// <summary>
    /// Interaction logic for FatureGrid.xaml
    /// </summary>
    public partial class FatureGrid : UserControl
    {

        public POSView ParentGUI { get; set; }
        public FatureGrid()
        {
            InitializeComponent();


        }

        public void CalculateAfterRemove()
        {
            ParentGUI.CalculateTotal();
        }

        public FatureRow getProductInList(int productid)
        {

            return ((ObservableCollection<FatureRow>)ItemsSource).Where(x => x.Productid == productid).FirstOrDefault();
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(FatureGrid), new PropertyMetadata(new PropertyChangedCallback(OnItemsSourcePropertyChanged)));

        private static void OnItemsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as FatureGrid;
            if (control != null)
                control.OnItemsSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);
        }



        private void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            // Remove handler for oldValue.CollectionChanged
            var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;

            if (null != oldValueINotifyCollectionChanged)
            {
                oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
            }
            // Add handler for newValue.CollectionChanged (if possible)
            var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;
            if (null != newValueINotifyCollectionChanged)
            {
                newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
            }


        }

        void newValueINotifyCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Do your stuff here.


            if (e.NewItems != null)
            {
                var items = new FatureRow[e.NewItems.Count];
                e.NewItems.CopyTo(items, 0);
                foreach (var item in items)
                {
                    OrderLine o = new OrderLine();
                    o.Grida = this;
                    o.DataContext = item;
                    RowContainer.Children.Add(o);
                }
            }


        }

        public void LoadFirstTime(ObservableCollection<FatureRow> l)
        {
            foreach (var item in l)
            {
                OrderLine o = new OrderLine();
                o.Grida = this;
                o.DataContext = item;
                RowContainer.Children.Add(o);
            }



        }



    }  

    
}
