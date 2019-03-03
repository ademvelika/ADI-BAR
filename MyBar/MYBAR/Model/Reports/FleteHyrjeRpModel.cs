using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Reports
{
    public class FleteHyrjeRpModel
    {
        public DateTime Data { get; set; }
        public string NrFature { get; set; }

        public List<FatureRow> FatureBody  {get;set;}

    }
}
