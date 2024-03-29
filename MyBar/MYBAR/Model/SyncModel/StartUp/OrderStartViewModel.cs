﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.StartUp
{
  public   class OrderStartViewModel
    {

        public int Id { get; set; }
        public int Local_Id { get; set; }
        public DateTime OperationTime { get; set; }
        public int OrderStatus_Id { get; set; }
        public bool IsFiscal { get; set; }
        public int Table_Id { get; set; }
        public string User_Id { get; set; }
        public int POS_Id { get; set; }

        public List<OrderDetailsStartViewModel> OrderDetails { get; set; }
    }
}
