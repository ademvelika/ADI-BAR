
using MYBAR.Model.FatureModel;
using MYBAR.View;
using MYBAR.View.Inventar;
using MYBAR.View.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MYBAR.Helper
{
   public static class Dependency
    {

        public static FleteHyrje FATURE_HYRJE;
        public static MainView MAIN_VIEW;
        public static POSView POS;


        public static void setTotalFatureHyrje()
        {

            if (FATURE_HYRJE != null)
                FATURE_HYRJE.Total.Text = FATURE_HYRJE.faturehyrje.GetTotal().ToString("#,#0.00");
        }

        public static void setTotalPosView()
        {
            if (POS != null)
            {
                POS.CalculateTotal();
            }
        }

        public static void FromMinimumListArtikujtToFatureHyrje(FatureHyrje fh)
        {


            MAIN_VIEW.GoToFatureHyrjeFromExternal();

            FleteHyrje fhview = MAIN_VIEW.WindowUser.Content as FleteHyrje;
          
            fhview.getModelExtrenal(fh);


        }


    }
}
