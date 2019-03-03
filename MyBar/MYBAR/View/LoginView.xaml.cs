using MYBAR.Helper;
using MYBAR.Model;
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

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {

        private string username;
        private List<User> users;
        public LoginView()
        {

      
            InitializeComponent();
            username = null;
            LoadUsers();
            LoadKeyBoard();
        }

        private void LoadKeyBoard()
        {
            for (int i = 1; i < 10; i++)
            {

              
                Button b = new Button();
                b.Content = i.ToString();

               
                int number = i;
                b.Click += (s, e) =>
                {
                    password.Password += number.ToString();

                };

                KeyBoard.Children.Add(b);
            }

            //add empty button ,number 0 and empty button again
            KeyBoard.Children.Add(new Button());
            Button zerobutton = new Button();
            zerobutton.Content = "0";
            zerobutton.Click += (s, e) =>
            {
                password.Password += "0";
            };
            KeyBoard.Children.Add(zerobutton);
            Button deletechar = new Button { Content = "C" };
            deletechar.Click += (s, e) =>
            {
                if(password.Password.Length>=1)
                password.Password = password.Password.Remove(password.Password.Length - 1);
            };
            KeyBoard.Children.Add(deletechar);
        }

        public void Login()
        {
            try
            {

                if(BlockLogging())
                {
                    ErrorMessage.Text = "Data e kompjuterit nuk eshte e sakte,ju lutem vendosni daten e sakte dhe provoni te logoheni !";
                        return;
                }
                if (username == null)
                    throw new Exception();
                string u = username;
                string pass = password.Password;
                if (UserService.ExistUser(u, pass, users).Result)
                {

                    //open program main window
                    App.Current.MainWindow.Content = new MainView();


                }
                else
                {
                    ErrorMessage.Text = "Wrong Password !";

                   

                }
            }

            catch(Exception ex)
            {

                ErrorMessage.Text = "Please select one user !";
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Login();
        }


        private void LoadUsers()
        {
            //get  list of all users in system
           
            users=UserService.GetUsers();

            foreach (var item in users)
            {
                Button b = new Button();

                b.Content=item.UserName;
                b.Tag = item.ID;
                usertest.Children.Add(b);
                
                b.Click += (s, e) =>
                {

                    username = item.UserName;

                    // password.BorderBrush = Brushes.Red;

                    b.BorderBrush = Brushes.Red;
                    b.BorderThickness = new Thickness(2);
                    password.Visibility = Visibility.Visible;
                    password.Focus();

                    foreach (Button btn in usertest.Children)
                    {
                        if (btn != b)
                        {

                            btn.BorderBrush = Brushes.Transparent;
                        }
                        

                    }

                };

                //get the manager id

                if (item.Role == "Manager")
                {
                    ((MainWindow)App.Current.MainWindow).MenagerUserId = item.ID;
                }
            }

        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                Login();
            }
        }


        public bool BlockLogging()
        {
            return ((MainWindow)App.Current.MainWindow).CanTLogIn;
        }

        private void KeyBoardBtn_Click(object sender, RoutedEventArgs e)
        {


            if (KeyBoard.Visibility == Visibility.Collapsed)
            {
                KeyBoard.Visibility = Visibility.Visible;
                BackgroundWorker.UpdateConfigKey("TOUCHDEVICE", "1");
            }
            else
            {
                KeyBoard.Visibility = Visibility.Collapsed;
                BackgroundWorker.UpdateConfigKey("TOUCHDEVICE", "0");
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //LEXOJME nese konfigurimi i fundit eshte paisje me touch

            string state = BackgroundWorker.ReadKey("TOUCHDEVICE");

            if (state == "0")
            {
                KeyBoard.Visibility = Visibility.Collapsed;
            }
            else
            {
                KeyBoard.Visibility = Visibility.Visible;
            }
        }
    }
}
