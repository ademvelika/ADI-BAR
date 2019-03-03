using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.SyncModel.StartUp
{
   public class StartupReportViewModel
    {

        public int Id { get; set; }
        public int Orders_No { get; set; }
        public int Sold_Items_No { get; set; }
     
        public decimal Orders_Total_Sum { get; set; }
     
        public decimal Fiscal_Orders_Total_Sum { get; set; }
     
        public decimal Cash_Total { get; set; }
       
        public decimal Tips_Total_Sum { get; set; }
        public DateTime Date_Time { get; set; }
        public int Place_Id { get; set; }
        public DateTime Start_Date_Time { get; set; }
        public string User_Id { get; set; }
        public int POS_Id { get; set; }
    }
}
