using System;
using System.Collections.Generic;
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

namespace MYBAR.View.Dialog
{
    /// <summary>
    /// Interaction logic for AnulloFature.xaml
    /// </summary>
    public partial class AnulloFature : Window
    {

        public bool IsCancel = false;
        public AnulloFature()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ArsyejaText.Text == "")
            {
                MessageBox.Show("Arsyeja nuk mund te jete bosh");
                return;
            }
            IsCancel = true;
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
