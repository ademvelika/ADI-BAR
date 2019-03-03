using MYBAR.CustomControls.UsersRow;
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
using System.Windows.Threading;

namespace MYBAR.View.Perdorues
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

     

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            var users = UserService.GetUsers();
            foreach (var item in users)
            {
                 
                var user = new UserLine(item.UserName, item.RoleId, item.ID);

                UsersContainer.Children.Add(user);
            }

            Dispatcher.BeginInvoke(new Action(() => ResizeColumn()), DispatcherPriority.ContextIdle, null);
         
        }

        private void ResizeColumn()
        {
            var list = new List<FrameworkElement>();
            foreach (UserLine item in UsersContainer.Children)
            {
                list.Add(item.UserName);

            }
            double maxwidth = list.Max(x => x.ActualWidth);
            foreach (UserLine item in UsersContainer.Children)
            {
                item.UserName.Width = maxwidth+30;
               

            }
            UserNameHeader.Width = maxwidth+30;

        }
    }
}
