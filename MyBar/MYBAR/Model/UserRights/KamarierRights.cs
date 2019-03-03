using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYBAR.Model.UserRights
{
  public  class KamarierRights:Rights
    {


        public KamarierRights()
        {
            XhiroDitorePerdorues = VISIBILITY_COLLAPSED;
            ListaArtikuve = VISIBILITY_COLLAPSED;
            FaturaKonfig = VISIBILITY_COLLAPSED;
            NotifyForMinimumAArtikuj = false;
            KonfigurimeMenu = VISIBILITY_COLLAPSED;
            ArtikujMenu = VISIBILITY_COLLAPSED;
            Raportemenu = VISIBILITY_COLLAPSED; ;
            FaturaMenu = VISIBILITY_COLLAPSED;
            RaporteButton = VISIBILITY_COLLAPSED;
            FaturaBtn = VISIBILITY_TRUE;
        }
    }
}
