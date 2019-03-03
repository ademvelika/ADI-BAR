using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYBAR.Model.Artikuj
{
  public  abstract class MenuCategoriesModel
    {

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Online_Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public bool IsSaved { get; set; }
        public bool IsItemActive;
        public string PrinterName { get; set; }

        public Visibility DeleteVisiBilityButton { get; set; }
        public abstract bool Save();
        public abstract bool Delete();
        

        
    }
}
