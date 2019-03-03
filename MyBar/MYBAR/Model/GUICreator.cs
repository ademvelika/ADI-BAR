using MYBAR.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYBAR.Model
{
   public class GUICreator
    {

        public virtual FrameworkElement getFatureGUI(FatureBase fat)
        {

            return new FatureView(fat);
        }

        
    }
}
