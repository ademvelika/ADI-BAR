using Microsoft.AspNet.Identity;
using MYBAR.Helper;
using MYBAR.Services;
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

namespace MYBAR.View.Perdorues
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : UserControl
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Ndrysho_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MainWindow m = (MainWindow)App.Current.MainWindow;
                var users = UserService.GetUsers();
                var user = users.Where(x => x.ID == m.UserId).Single();
                PasswordHasher pwd = new PasswordHasher();
                if ((Passwordnew.Password == "") || (OldPassword.Password == "")||(Passwordnewverify.Password==""))
                {
                    MessageBox.Show("Asnje nga fushat nuk duhet te jete bosh !");
                    return;
                }

                if (Passwordnew.Password != Passwordnewverify.Password)
                {
                    MessageBox.Show("Fjalekalimet e reja nuk jane njelloj !");
                    return;
                }

                var isok = pwd.VerifyHashedPassword(user.Password, OldPassword.Password);
                if (isok == PasswordVerificationResult.Failed)
                {
                    MessageBox.Show("Fjalekalimi aktual nuk eshte i sakte !");
                }
                else
                {
                    var newpashash = pwd.HashPassword(Passwordnew.Password);

                    bool ok = true;

                    if (ok)
                    {
                        UserService.UpdatePassword(m.UserId, newpashash);
                        MessageBox.Show("Fjalekalimi u ndryshua me sukses !");
                        OldPassword.Password = "";
                        Passwordnewverify.Password = "";
                        Passwordnew.Password = "";
                    }
                    else
                    {
                        MessageBox.Show("Fjalekalimi  nuk u ndryshua, interneti eshte i nevojshem per te ndryshuar fjalekalimin !");
                    }

                }

            }
            catch(Exception ex)
            {

            
        }
        }
    }
}
