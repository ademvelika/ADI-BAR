using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.FatureModel
{
    public class FatureHyrjeEdit : FatureBase
    {

        public FatureHyrjeEdit()
        {
            ReferenceFatureRows = FatureRows;

            MessageOnSaveUpdate = "Fatura u modifikua me sukses !";

        }
        public override bool CanCloseOrSaveTable()
        {
            throw new NotImplementedException();
        }

        public override bool CloseTable()
        {
            throw new NotImplementedException();
        }

        public override bool Save()
        {
            return FatureService.UpdateFatureHyrje(this);
        }

        public override  bool Delete()
        {

          return  FatureService.DeleteFatureHyrje(this);

        }
    }
}
