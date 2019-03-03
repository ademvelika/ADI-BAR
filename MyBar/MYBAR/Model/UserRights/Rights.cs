using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYBAR.Model.UserRights
{
   public class Rights
    {

        public const Visibility VISIBILITY_COLLAPSED = Visibility.Collapsed;
        public const Visibility VISIBILITY_TRUE= Visibility.Visible;
        public Visibility XhiroDitorePerdorues { get; set; }
        public Visibility ListaArtikuve { get; set; }
        public Visibility FaturaKonfig { get; set; }

        public Visibility KonfigurimeMenu { get; set; }
        public Visibility ArtikujMenu { get; set; }
        public Visibility Raportemenu { get; set; }
        public Visibility FaturaMenu { get; set; }

        public Visibility RaporteButton { get; set; }
        public bool NotifyForMinimumAArtikuj { get; set; }

        public Visibility FaturaBtn { get; set; }
        
        public Rights()
        {

            XhiroDitorePerdorues = VISIBILITY_TRUE;
            ListaArtikuve = VISIBILITY_TRUE;
            FaturaKonfig = VISIBILITY_TRUE;
            NotifyForMinimumAArtikuj = true;
            KonfigurimeMenu = VISIBILITY_TRUE;
            ArtikujMenu = VISIBILITY_TRUE;
            Raportemenu = VISIBILITY_TRUE;
            FaturaMenu = VISIBILITY_TRUE;
            RaporteButton = VISIBILITY_TRUE;
            FaturaBtn = VISIBILITY_COLLAPSED;
        }

   


    }
}
