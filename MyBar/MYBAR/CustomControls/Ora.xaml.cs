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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MYBAR.CustomControls
{
    /// <summary>
    /// Interaction logic for Ora.xaml
    /// </summary>
    public partial class Ora : UserControl
    {

    
        public Ora()
        {
            InitializeComponent();

            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewMouseLeftButtonDownEvent,
             new MouseButtonEventHandler(SelectivelyHandleMouseButton), true);
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotKeyboardFocusEvent,
              new RoutedEventHandler(SelectAllText), true);
        }

        private void OraBox_LostFocus(object sender, RoutedEventArgs e)
        {
            validate((TextBox)sender, 12, 12);
        }

        public void validate(TextBox control,int kufij,int DefaulValue)
        {
            int timenumber;
        if(int.TryParse(control.Text,out timenumber))
            {
                if (timenumber >kufij )
                {
                    timenumber = DefaulValue;
                }
             
                control.Text = timenumber.ToString();

               
            }
        else
            {
                control.Text = DefaulValue.ToString();
            }

           
        }

        private static void SelectivelyHandleMouseButton(object sender, MouseButtonEventArgs e)
        {
            var textbox = (sender as TextBox);
            if (textbox != null && !textbox.IsKeyboardFocusWithin)
            {
                if (e.OriginalSource.GetType().Name == "TextBoxView")
                {
                    e.Handled = true;
                    textbox.Focus();
                }
            }
        }


        private static void SelectAllText(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)

                textBox.SelectAll();
        }


        private void MinutaBox_LostFocus(object sender, RoutedEventArgs e)
        {
            validate((TextBox)sender, 59, 0);
        }

        private void ShtoOre_Click(object sender, RoutedEventArgs e)
        {
            Increment(OraBox, 12);

        }

        private void Increment(TextBox control,int kufij)
        {
            int timenumber;
            if (int.TryParse(control.Text, out timenumber))
            {
                if (timenumber +1> kufij)
                {
                    timenumber = 0;
                }
                timenumber++;
                control.Text = timenumber.ToString();
            }
           
        }

        private void Decrement(TextBox control)
        {
            int timenumber;
            if (int.TryParse(control.Text, out timenumber))
            {
                if (timenumber == 0)
                {
                    timenumber = 0;
                }
                else
                {
                    timenumber--;

                }
                control.Text = timenumber.ToString();
            }

        }

        private void ShtoMinuta_Click(object sender, RoutedEventArgs e)
        {
            Increment(MinutaBox, 60);
        }

        private void AMPM_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (AMPM.Content.ToString() == "AM")
            {
                AMPM.Content = "PM";
            }
            else
            {
                AMPM.Content = "AM";
            }
        }

        public override string ToString()
        {
            return OraBox.Text + ":" + MinutaBox.Text + ":00 " + AMPM.Content.ToString();
        }

        private void ZbritOre_Click(object sender, RoutedEventArgs e)
        {
            Decrement(OraBox);
        }

        private void ZbritMinuta_Click(object sender, RoutedEventArgs e)
        {
            Decrement(MinutaBox);
        }


        public void SetHour(int hour)
        {
            OraBox.Text = hour.ToString();
        }

        public void SetMinutes(int minutes)
        {
            MinutaBox.Text = minutes.ToString();
        }

        public void SetAM()
        {
            AMPM.Content = "AM";
        }

        public void SetPM()
        {
            AMPM.Content = "PM";
        }
    }
}
