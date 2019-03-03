using Microsoft.Win32;
using MYBAR.Helper;
using MYBAR.Model.FatureModel;
using MYBAR.Raports;
using MYBAR.Services;
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

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for FatureDetailsView.xaml
    /// </summary>
    public partial class FatureDetailsView : UserControl
    {

        private byte[] imageBytes;
        public FatureDetailsView()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            FatureInfo f = FatureInfoService.getInfo();

            KokaText.Text = f.HeadText;
            FundText.Text = f.FootText;

            imageBytes = f.Image;
            ImageSource i = (ImageConverter.LoadImage(f.Image));
            FatureImage.Source = i;

            if (f.Image != null)
            {
                KokaText.IsEnabled = false;
            }

            if(RegisterData.SHOW_PRICE.ToString() == "1")
            {
                Switch.IsChecked = true;
            }
            else
            {
                Switch.IsChecked = false;
            }

            if (RegisterData.FULL_BILL == "1")
            {
                FULLBILLSWITCH.IsChecked = true;
            }
            else
            {
                FULLBILLSWITCH.IsChecked = false;
            }
        }

        private void RuajFatureInfo_Click(object sender, RoutedEventArgs e)
        {
           if( FatureInfoService.UpdateInfo(KokaText.Text, FundText.Text, imageBytes))
            {

               
                RegisterData.BILL_HEADER = KokaText.Text;
                RegisterData.BILL_FOOTER = FundText.Text;
                RegisterData.Image = imageBytes;
                if (Switch.IsChecked == true)
                {
                    BackgroundWorker.SaveNumberOfCopies(1);
                    RegisterData.SHOW_PRICE = 1;
                }
                else
                {
                    BackgroundWorker.SaveNumberOfCopies(0);
                    RegisterData.SHOW_PRICE = 0;
                }

                if (FULLBILLSWITCH.IsChecked == true)
                {
                    BackgroundWorker.UpdateConfigKey("FULLBILL", "1");
                    RegisterData.FULL_BILL = "1";
                }
                else
                {
                    BackgroundWorker.UpdateConfigKey("FULLBILL", "0");
                    RegisterData.FULL_BILL = "0";
                }
                MessageBox.Show("Te dhenat u ruajten me sukses !");
                  
            }
            else
            {
                MessageBox.Show("Upss , dicka shkoi gabim !");
            }



         
        }

        private void PreviewFatureInfo_Click(object sender, RoutedEventArgs e)
        {


            DocReader.Document = FatureBuilder.getPreviewFature(KokaText.Text,FundText.Text,ImageConverter.LoadImage(imageBytes));
        }

        private void ImageChoser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

               imageBytes= File.ReadAllBytes(openFileDialog.FileName);

                ImageSource image = ImageConverter.LoadImage(imageBytes);
                FatureImage.Source = image;

                KokaText.IsEnabled = false;

            }
               
        }


        //function convert bytearray to BitmapImage
 

        private void CleanImage_Click(object sender, RoutedEventArgs e)
        {
            imageBytes = null;
            FatureImage.Source = null;
            KokaText.IsEnabled = true;
        }
    }
}
