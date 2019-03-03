using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model
{
   public class FaturePreview
    {

        public int Id { get; set; }
        public List<FatureRow> FatureBody { get; set; }
        public string UserId { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public int TavolineNr { get; set; }
        public string UserName { get; set; }
        public int Fraction { get; set; }
        public FaturePreview()
        {

            
        }

        public decimal getTotal()
        {
            decimal sum = 0;
            foreach (var item in FatureBody)
            {
                sum += item.Sasi * item.Cmim;

            }

            return sum;
        }
    }
}
