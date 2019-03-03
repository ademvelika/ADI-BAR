using MYBAR.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MYBAR.CustomControls.UsersRow
{
   public class UserAdder:UserLine
    {


     
        public override void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Model.Save())
            {
                 
                MessageBox.Show("Perdoruesi u shtua me sukses !");
                Update.IsEnabled = false;
            };
        }

        protected override void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Model = new UserModel();
            RoleCombo.ItemsSource = ROLES;
            RoleCombo.SelectedIndex = 0;

            Update.Content = "Ruaj";
            Update.Background = Brushes.LightSlateGray;
            Update.Foreground = Brushes.White;
        }
    }
}
