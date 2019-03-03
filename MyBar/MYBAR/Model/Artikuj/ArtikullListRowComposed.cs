using MYBAR.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace MYBAR.Model.Artikuj
{
    public  class ArtikullListRowComposed : ArtikullListRow
    {

        public ObservableCollection<ArtikullListRow> IngriedentList;

        public ArtikullListRowComposed()
        {
            IngriedentList = new ObservableCollection<ArtikullListRow>();
        }
        public override void AddChild(ArtikullListRow a)
        {
            
            IngriedentList.Add(a);
        }

        public override ObservableCollection<ArtikullListRow> GetIngredientList()
        {
            return IngriedentList;
        }

        public override bool Save()
        {

       

            return ArtikullService.InsertNewProductComposed(this);
        }

        public override ArtikullListRow switchType()
        {
            ArtikullListRowSimple s = new ArtikullListRowSimple
            {
                ProduktId = ProduktId,
                OnlineProductid = OnlineProductid,
                CategoryId = CategoryId,
                CategoryOnlineId = CategoryOnlineId,
                Asortimenti = Asortimenti,
                Sasi = Sasi,
                SasiaMinimale = SasiaMinimale,
                Cmimi = Cmimi,
                TypeId = TypeId,
                UnitId = UnitId,
                IsItemActive = IsItemActive,
                UnitName=UnitName
            };

            return s;
        }

        public override void Update()
        {
            ArtikullService.UpdateProductComposed(this);
        }


        public override ArtikullListRow Clone()
        {
            return (ArtikullListRow)switchType();
        }

    }
}
