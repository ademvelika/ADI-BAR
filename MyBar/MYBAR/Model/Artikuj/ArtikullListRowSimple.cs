using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Artikuj
{
    public class ArtikullListRowSimple : ArtikullListRow
    {



        public ArtikullListRowSimple()
        {
            ProduktId = -1;
            IsItemActive = true;

        }


        public override void AddChild(ArtikullListRow a)
        {
            
        }

        public override ArtikullListRow Clone()
        {
            return (ArtikullListRow)switchType();
        }

        public override ObservableCollection<ArtikullListRow> GetIngredientList()
        {
            return new ObservableCollection<ArtikullListRow>();
        }

        public override bool Save()
        {
            return ArtikullService.InsertNewProduct(this);
        }

        public override ArtikullListRow switchType()
        {
            ArtikullListRowComposed c = new ArtikullListRowComposed
            {
                ProduktId = ProduktId,
                OnlineProductid = OnlineProductid,
                CategoryId = CategoryId,
                CategoryOnlineId = CategoryOnlineId,
                Asortimenti = Asortimenti,
                Sasi = Sasi,
                SasiaMinimale = SasiaMinimale,
                Cmimi = Cmimi,TypeId=TypeId,UnitId=UnitId,
                IsItemActive=IsItemActive,
                UnitName=UnitName,
                  
            };

            return c;
        }

        public override void Update()
        {
            ArtikullService.UpdateProduct(this);
        }
    }
}
