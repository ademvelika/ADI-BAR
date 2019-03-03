using MYBAR.View.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYBAR.Model
{
   public  class GUICreator2:GUICreator
    {


        public override FrameworkElement getFatureGUI(FatureBase fat)
        {
            return new POSView(fat);
        }
    }
}
