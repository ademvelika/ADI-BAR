﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.StartUp
{
   public  class RequestAccessViewModel
    {
        public Guid POSKey { get; set; }
        public string MacAddress { get; set; }
    }
}
