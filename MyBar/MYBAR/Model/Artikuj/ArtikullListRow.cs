using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Artikuj
{
    public abstract class  ArtikullListRow
    {

        public int ProduktId;
        public int OnlineProductid;
        public int CategoryId;
        public int CategoryOnlineId;
        public string Asortimenti { get; set; }
        public decimal Cmimi { get; set; }
        public int Sasi { get; set; }
        public int SasiaMinimale { get; set; }
        public bool IsItemActive;
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
       

        public abstract bool Save();
        public abstract ObservableCollection<ArtikullListRow> GetIngredientList();
        public abstract void Update();
       public abstract ArtikullListRow switchType();
        public abstract void AddChild(ArtikullListRow a);

        public abstract ArtikullListRow Clone();
        

        


    }
}
