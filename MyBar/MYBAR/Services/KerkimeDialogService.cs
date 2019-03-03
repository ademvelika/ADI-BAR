using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Services
{
    public class KerkimeDialogService
    {


        public static List<FatureHyrjeSerarchRow> getFatureHyrjeSearchList(DateTime startdate,DateTime enddate,string word="")
        {

            using(BPDBEntities DB=new BPDBEntities())
            {
                if(word=="")
                return DB.Goods_Received_Note.Where(x=>DbFunctions.TruncateTime( x.OrderDate)>=DbFunctions.TruncateTime(startdate)&&DbFunctions.TruncateTime(x.OrderDate)<=DbFunctions.TruncateTime(enddate)).Select(x => new FatureHyrjeSerarchRow {Id=x.Id, Numer = x.Id, KodFature = x.OrderNumber, Data = x.OrderDate,Total=x.Goods_Received_Note_Details.Sum(u=>u.Price*u.Quantity) }).OrderByDescending(y=>y.Data).ToList();
                else
                    return DB.Goods_Received_Note.Where(x=>x.OrderNumber.StartsWith(word)).Select(x => new FatureHyrjeSerarchRow { Id = x.Id, Numer = x.Id, KodFature = x.OrderNumber, Data = x.OrderDate, Total = x.Goods_Received_Note_Details.Sum(u => u.Price * u.Quantity) }).OrderByDescending(y => y.Data).ToList();
            }
        }
        public static List<ArtikujSearchRow> getArtikujSearchList(string searchword="")
        {

            using (
                BPDBEntities DB = new BPDBEntities())
            {
                if(searchword=="")
                return DB.MenuItems.Select(x => new ArtikujSearchRow { Id = x.Id, Asortimenti=x.Name }).ToList();
                else
                    return DB.MenuItems.Where(x=>x.Name.StartsWith(searchword)).Select(x => new ArtikujSearchRow { Id = x.Id, Asortimenti = x.Name }).ToList();
            }
        }





        //Id attribute is required because on double click in row ,id geted to display data

        public class FatureHyrjeSerarchRow
        {

            public int Id { get; set; }
            public int Numer { get; set; }
            public string KodFature { get; set; }

            public DateTime Data { get; set; }
            public decimal Total { get; set; }

        }

        public class ArtikujSearchRow
        {
            public int Id { get; set; }
            public string Asortimenti { get; set; }
           
        }
    }
}
