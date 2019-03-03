using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.UserModel
{
    public class UserModel
    {

        public string ID { get; set; }
        public string Name { get; set; }

        public string RoleId { get; set; }


        public bool Update()
        {
            return UserService.UpdateUserLocaly(this);
        }

        public bool Save()
        {
            return UserService.AddUser(this);
        }

    }
}
