using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel
{
  public  class SyncServer
    {
      
            public int Id { get; set; }
            public int SyncType_Id { get; set; }
            public int Place_Id { get; set; }
            public string Object { get; set; }
            public string Object_Id { get; set; }
            public DateTime Date { get; set; }

        

        public class SyncType
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static class SyncTypes
        {

            public const int INSERT = 1;
            public const int UPDATE = 2;
            public const int DELETE = 3;

        }
    }
}
