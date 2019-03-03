using MYBAR.Helper;
using MYBAR.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            List<ComboBoxData> droplist = new List<ComboBoxData>();
            droplist.Add(new ComboBoxData { DataValueOpt = "AED", DisplayValue = "AED" });
            droplist.Add(new ComboBoxData { DataValueOpt = "BNT", DisplayValue = "BNT" });
            droplist.Add(new ComboBoxData { DataValueOpt = "BNT-SC-Link", DisplayValue = "BNT (SC Link)" });
            droplist.Add(new ComboBoxData { DataValueOpt = "BNT-SUPERCASH", DisplayValue = "BNT(SUPERCASH)" });
            droplist.Add(new ComboBoxData { DataValueOpt = "IVA", DisplayValue = "IVA" });
            droplist.Add(new ComboBoxData { DataValueOpt = "NOK", DisplayValue = "NOK" });
            

            TipetEKasave.ItemsSource = droplist;
            
            
            var selected= droplist.Where(x => x.DataValueOpt == RegisterData.KasaType).FirstOrDefault();
            TipetEKasave.SelectedIndex = droplist.IndexOf(selected);
            PathString.Text = RegisterData.KasaPath;
        }

        private void BroswerFolder_Click(object sender, RoutedEventArgs e)
        {

           System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();
           

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


             PathString.Text=openFileDialog.SelectedPath;

            }
        }

        private void Ruaj_Click(object sender, RoutedEventArgs e)
        {

            RegisterData.KasaPath = PathString.Text;
            RegisterData.KasaType = ((ComboBoxData)TipetEKasave.SelectedItem).DataValueOpt;
            BackgroundWorker.UpdateSettings();

            MessageBox.Show("Konfigurimet u ruajten me sukses !");
        }
    }
}
