using MYBAR.Model;
using MYBAR.Model.UserModel;
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

namespace MYBAR.CustomControls.UsersRow
{
    /// <summary>
    /// Interaction logic for UserLine.xaml
    /// </summary>
    public partial class UserLine : UserControl
    {
         protected UserModel Model;
       
        protected static List<ComboBoxData> ROLES =new List<ComboBoxData> {new  ComboBoxData { DataValueOpt = "1a5ed259-c156-4746-ba37-446176b7b72a", DisplayValue = "Kamarier" } , new ComboBoxData { DataValueOpt = "cf99e260-64b7-41d9-b693-099caa9893b5", DisplayValue = "Menaxher" } };
        public UserLine()
        {
            InitializeComponent();
        }

        public UserLine(string name, string role, string Id)
        {

            InitializeComponent();
            Model = new UserModel();
            UserName.Text = name;

            Model.ID = Id;
            Model.Name = name;
            Model.RoleId = role;
            RoleCombo.ItemsSource = ROLES;
          
            
        }

        protected virtual void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RoleCombo.SelectedIndex= ROLES.IndexOf(ROLES.Where(x => x.DataValueOpt==Model.RoleId).FirstOrDefault());
        }


       

        public virtual void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Model.Update())
            {

                MessageBox.Show("Modifikimi u krye me sukses !");

            };
        }

        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            Model.Name = UserName.Text;
        }

        private void RoleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.RoleId = ((ComboBoxData)RoleCombo.SelectedItem).DataValueOpt;
        }
    }
}
