
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MYBAR.Model.Xhiro
{
   public class TurnetRowModel
    {

        public int NumerFaturash { get; set; }

        public int NrProduktesh { get; set; }
      
        public decimal Fiscal_Orders_Total_Sum { get; set; }
        public decimal Total { get; set; }
        public DateTime Data { get; set; }
        public decimal Cash { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
        public decimal Tips { get; set; }
        public SolidColorBrush RowBackground { get; set; }
    }
}
