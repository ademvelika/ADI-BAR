using MYBAR.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace MYBAR.CustomControls.POS
{
    /// <summary>
    /// Interaction logic for OrderLine.xaml
    /// </summary>
    public partial class OrderLine : UserControl
    {


        public  FatureGrid Grida { get; set; }

   
        public OrderLine()
        {
            InitializeComponent();
        }




        public  FatureRow GetDataModel()
        {


            return (FatureRow)this.DataContext;

        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (GetDataModel().Sasi == 1)
            //{
            //    //get parent and remove from gui

                
            //    (Grida.RowContainer).Children.Remove(this);
            //    ((ObservableCollection<FatureRow>)Grida.ItemsSource).Remove(GetDataModel());
               
            //}
            //else
            //{
            //    GetDataModel().SASI--;
            //}

            //Grida.CalculateAfterRemove();
        }

        private void Sasia_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //do nothing
        }

        private void RowRemoveBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
                (Grida.RowContainer).Children.Remove(this);
               ((ObservableCollection<FatureRow>)Grida.ItemsSource).Remove(GetDataModel());
                Grida.CalculateAfterRemove();
        }
    }
}
