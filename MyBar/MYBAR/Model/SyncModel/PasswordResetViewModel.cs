using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
    public class PasswordResetViewModel
    {

        public string User_Id { get; set; }
        public string Old_Password { get; set; }
        public string New_Password { get; set; }
        public  int POS_Id { get; set; }
    }
}
