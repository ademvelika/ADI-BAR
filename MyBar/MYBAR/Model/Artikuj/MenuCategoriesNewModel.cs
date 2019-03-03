using MYBAR.Helper;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Artikuj
{
    public class MenuCategoriesNewModel : MenuCategoriesModel
    {

        public MenuCategoriesNewModel()
        {

            DeleteVisiBilityButton = System.Windows.Visibility.Hidden;
        }
        public override bool Delete()
        {
            return false;
        }

        public override bool Save()
        {
            IsSaved = true;
         
           
            return ArtikullService.InsertMenuCategories(this);
        }
    }
}
