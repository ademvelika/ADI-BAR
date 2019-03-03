using MYBAR.Model.UserRights;
using System.Windows;

namespace MYBAR.Model
{
    public class User
    {
        public string ID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }

        private Rights MyRights { get; set; }

        public User()
        {

           
           
        }
        /// <UserRights>
        /// Merr te drejtat e perdoruesit qe eshte loguar
        /// </UserRights>
        /// <returns></returns>
        public Rights getMyRights()
        {
            if (Role == "Waiter")
            {
                return new KamarierRights();
            }
            else
            {
                return new Rights();
            }
        }




      

    }
}
