using Microsoft.Reporting.WinForms;
using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Reports;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Services
{
   public  class RaporteService
    {

       

        public static ReportData getInventarRaport()
        {

            ReportData data = new ReportData {RaportPath= "MYBAR.Raports.Inventar.rdlc",DataSource="DataSet1" };
            try
            {
                using(BPDBEntities db=new BPDBEntities())
                {

                  data.Data=  db.MenuItems.Where(x=>x.MenuItemTypeId!=Constants.COMPOSED).Select(x => new InventarModel { Asortimenti = x.Name, Sasia = x.LastBalance.LastQuantity, Cmimi=x.LastBalance.LastPrice ,Vlera=x.LastBalance.LastPrice*x.LastBalance.LastQuantity,Kategoria=x.MenuCategories.Name,Njesia=x.Unit.Name}).AsNoTracking().OrderBy(y=>y.Asortimenti).ToList();
                }


                data.addParameter("Data", DateTime.Now.Date.ToShortDateString());
                return data;

            }

            catch(Exception EX)
            {
                return data;
            }
        }

        public static ReportData getInventarRaportByDate(DateTime datainventar)
        {

            var dateonly = datainventar.Date;


            ReportData data = new ReportData { RaportPath = "MYBAR.Raports.Inventar.rdlc", DataSource = "DataSet1" };
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    data.Data = db.MenuItems.Select(x => new InventarModel { Asortimenti = x.Name, Sasia = x.Balance.Where(y=>DbFunctions.TruncateTime(y.Date)<=dateonly).OrderByDescending(y=>y.Date).Select(y => y.QuantityState).FirstOrDefault(), Cmimi = x.Balance.Where(y => DbFunctions.TruncateTime(y.Date) <= dateonly).OrderByDescending(y => y.Date).Select( y =>   y.QuantityState!=0?y.Price/y.QuantityState:0).FirstOrDefault(),  Kategoria = x.MenuCategories.Name }).AsNoTracking().OrderBy(y => y.Asortimenti).ToList();
                }


                data.addParameter("Data", datainventar.ToShortDateString());
                return data;

            }

            catch (Exception EX)
            {
                return data;
            }
        }


        public static ReportData getXhiroDitoreRaport(string userid)
        {
            ReportData data = new ReportData { RaportPath = "MYBAR.Raports.XhiroDitore.rdlc", DataSource = "DataSet1" };
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    data.Data = db.getXhiroDitore(userid).Select(x => new XhiroDitoreRow { Emer = x.Asortimenti, Cmim = x.Cmim ?? 0, Nr = x.Nr ?? 0, Total = x.Total??0 }).ToList();
                }

                
                data.addParameter("Username","adem");
             
                return data;

            }

            catch (Exception EX)
            {
                return data;
            }
        }

        public static ReportData getFleteHyrjeRaport(int orderid)
        {
            ReportData data = new ReportData { RaportPath = "MYBAR.Raports.FleteHyrjeReport.rdlc", DataSource = "DataSet1" };
            try
            {
                var m = (MainWindow)App.Current.MainWindow;
                using (BPDBEntities db = new BPDBEntities())
                {
                    var fh = db.Goods_Received_Note.Where(x => x.Id == orderid).Select(x => new FleteHyrjeRpModel { Data = x.OrderDate, NrFature = x.OrderNumber, FatureBody = x.Goods_Received_Note_Details.Select(y => new FatureRow { Asortimenti = y.MenuItems.Name, Cmim = y.Price, Sasi = y.Quantity }).ToList() }).FirstOrDefault();

                    data.Data = fh.FatureBody;

                   data.addParameter("Data", fh.Data.ToString());
                   data.addParameter ("Kodi", fh.NrFature);
                    data.addParameter("Menaxher", m.UserName);

                }

                return data;

            }

            catch (Exception EX)
            {
                return data;
            }

        }

        public static ReportData getArtikullHistory(int MenuItemId,string artikullname,DateTime startDate,DateTime endDate)
        {

            ReportData data = new ReportData { RaportPath = "MYBAR.Raports.ArtikullHistory.rdlc", DataSource = "DataSet1" };
            try
            {
                var m = (MainWindow)App.Current.MainWindow;
                using (BPDBEntities db = new BPDBEntities())
                {
                    var list = db.ArtikullHistory(MenuItemId).Select(x => new ArtikullHistoryModelReport { Type = x.tipi, Quanity = x.Quantity, Price = x.Price, OrderDate = x.OrderDate }).Where(x=>x.OrderDate>=startDate&&x.OrderDate<=endDate).OrderBy(y => y.OrderDate).ToList();
                    data.Data = list;

                    data.addParameter("Artikull", artikullname);
                    

                }

                return data;

            }

            catch (Exception EX)
            {
                return data;
            }
        }

     
    }
}
