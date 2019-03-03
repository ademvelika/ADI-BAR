using Microsoft.Win32;
using MYBAR.Helper;
using MYBAR.Model.Artikuj;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace MYBAR.View.Artikuj
{
    /// <summary>
    /// Interaction logic for KategoriView.xaml
    /// </summary>
    public partial class KategoriView : Window
    {

        public MenuCategoriesModel kategorimodel { get; set; }
        
        public KategoriView()
        {
            kategorimodel = new MenuCategoriesNewModel();
            Fshij.Visibility = kategorimodel.DeleteVisiBilityButton;
        }
        public KategoriView(MenuCategoriesModel k)
        {
            InitializeComponent();

            kategorimodel = k;
            
            Emer.Text = k.Name;
            
            Fshij.Visibility = kategorimodel.DeleteVisiBilityButton;
            ImageViwer.Source = ImageConverter.LoadImage(k.Image);

            if (kategorimodel.PrinterName != null)
            {
                Switch.IsChecked = true;
                cmbPrinterSelection.Visibility = Visibility.Visible;
                cmbPrinterSelection.SelectedIndex = cmbPrinterSelection.Items.IndexOf(kategorimodel.PrinterName);
            }
          

        }

        

        private void Ruaj_Click(object sender, RoutedEventArgs e)
        {

            kategorimodel.Name = Emer.Text;

            if (Switch.IsChecked ?? false)
            {
                kategorimodel.PrinterName = cmbPrinterSelection.SelectedItem.ToString();
            }

            if (kategorimodel.Save())
            {
                kategorimodel.IsSaved = true;
                MessageBox.Show("Te dhenat u ruajten me sukses !");             
            }
            else
            {
                kategorimodel.IsSaved = false;
                MessageBox.Show("Ju duhet ta keni kompjuterin tuaj te lidhur me internetin ne menyre qe te dhenat tuaja te sinkronizohen, ju lutem shikoni lidhjen me internetin dhe me pas provojeni perseri !");
            }

           

            this.Close();

        }

        private void PhotoChosenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                kategorimodel.Image = File.ReadAllBytes(openFileDialog.FileName);

                ImageSource image = ImageConverter.LoadImage(kategorimodel.Image);
                ImageViwer.Source = image;

                

            }
        }

        private void ClearPhoto_Click(object sender, RoutedEventArgs e)
        {
            kategorimodel.Image = null;
            ImageViwer.Source =null;
        }

        private void Fshij_Click(object sender, RoutedEventArgs e)
        {
            if (kategorimodel.Delete())
            {
                kategorimodel.IsDeleted = true;
                MessageBox.Show("Te dhenat u ruajten me sukses !");
            }
            else
            {
                kategorimodel.IsDeleted = false;
                MessageBox.Show("Ju duhet ta keni kompjuterin tuaj te lidhur me internetin ne menyre qe te dhenat tuaja te sinkronizohen, ju lutem shikoni lidhjen me internetin dhe me pas provojeni perseri !");
            }
            Close();
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {

            if (Switch.IsChecked??false)
            {

                cmbPrinterSelection.Visibility = Visibility.Visible;
            }
            else
            {
                cmbPrinterSelection.Visibility = Visibility.Hidden;
            }
        }

       
    }
}
