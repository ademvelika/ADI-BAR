using MYBAR.Model.Xhiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Reports
{
    public class XhiroDitoreModel
    {

        public TurnetRowModel Turni { get; set; }

        public List<FaturePreview> CancelOrders { get; set; }
        public List<FaturePreview> RequestedForCancelOrders { get; set; }
        public List<XhiroDitoreRow> Detajet {get;set; }


        public XhiroDitoreModel()
        {
            CancelOrders = new List<FaturePreview>();
            RequestedForCancelOrders = new List<FaturePreview>();
        }
    }
}
