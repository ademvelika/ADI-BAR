using MYBAR.Helper;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Artikuj
{
    public class MenuCategoriesEditModel : MenuCategoriesModel
    {

        public MenuCategoriesEditModel()
        {
            DeleteVisiBilityButton = System.Windows.Visibility.Visible;
        }

        public override bool Delete()
        {
            

            return ArtikullService.DeleteMenuCategories(this);
        }

       

        public override bool Save()
        {
            IsSaved = true;

          
            return ArtikullService.UpdateMenuCategories(this);
        }
    }
}
