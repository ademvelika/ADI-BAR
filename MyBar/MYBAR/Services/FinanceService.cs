using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Reports;
using MYBAR.Model.SyncModel;
using MYBAR.Model.SyncModel.InventarySyncOnly;
using MYBAR.Model.SyncModel.StartUp;
using MYBAR.Model.Xhiro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;


namespace MYBAR.Services
{
    public class FinanceService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static XhiroDitoreModel getXhiroDitore(string userid)
        {
            try
            {
                XhiroDitoreModel xh = new XhiroDitoreModel();
                using (BPDBEntities db = new BPDBEntities())
                {

                    DateTime sot = DateTime.Now.Date;

                
                    if (RegisterData.ShowAllBillTypes==true)
                    {
                        string sql = @"select s.Name as Emer,s.Price as Cmim,s.Nr as Nr from (select Name,Price+'' as Price ,(select sum(o.Quantity) from OrderDetails o join Orders ol on o.Order_Id = ol.Id  where o.MenuItem_Id = m.Id   and ol.User_Id='" + userid + "' and ol.OrderStatus_Id<>13 and ol.OrderStatus_Id<>15) as Nr  from MenuItems m) s where Nr >= 0";
                        xh.Detajet = db.Database.SqlQuery<XhiroDitoreRow>(sql).ToList();

                    }
                    else
                    {
                        string sql = @"select s.Name as Emer,s.Price as Cmim,s.Nr as Nr from (select Name,Price+'' as Price ,(select sum(o.Quantity) from OrderDetails o join Orders ol on o.Order_Id = ol.Id  where o.MenuItem_Id = m.Id   and ol.User_Id='" + userid + "' and ol.OrderStatus_Id<>13 and ol.OrderStatus_Id<>15 and FiscalCash=1) as Nr  from MenuItems m) s where Nr >= 0";
                        xh.Detajet = db.Database.SqlQuery<XhiroDitoreRow>(sql).ToList();
                    }



                    return xh;
                }

            }

            catch (Exception e)
            {
                return new XhiroDitoreModel();
            }

        }
        public static void CalculateXhiroDitore()
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    var result = db.getXhiroDitoreTotalAllUser().Select(x => new XhiroDitoreUser { UserId = x.UserId, XhiroReale = x.XhiroReale ?? 0, XhiroKaseFiskale = x.XhiroKase ?? 0 }).ToList();

                    MainWindow m = (MainWindow)App.Current.MainWindow;
                    m.XhiroDitore.Clear();
                    foreach (var item in result)
                    {
                        m.XhiroDitore.Add(item.UserId, item);
                    }

                    RegisterData.XHIRO_DITORE_USER = m.XhiroDitore;
                }

            }

            catch (Exception e)
            {

            }
        }

        //get all order that are sent for cancellation but are not cancel yet
        public static List<FaturePreview> getOrdersRequestedForCancel(string userid)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    DateTime SOT = DateTime.Now.Date;

                    List<bool> fiscaltype = new List<bool> { true };
                    if (RegisterData.ShowAllBillTypes)
                    {
                        fiscaltype.Add(false);
                    }
                    var ListOfRequestetOrdersId = db.OrderForCancellation.Where(x => DbFunctions.TruncateTime(x.Date) == SOT &&x.Orders.User_Id==userid&&fiscaltype.Contains(x.Orders.FiscalCash)).Select(x => x.OrderId).ToList();

                    var list = db.Orders.Where(x => ListOfRequestetOrdersId.Contains(x.Id) && x.OrderStatus_Id != 15).
                           Select(x => new FaturePreview
                           {
                               Id = x.Id,
                               Data = x.OperationTime,
                               FatureBody = x.OrderDetails.Select(y => new FatureRow
                               {
                                   Asortimenti = y.MenuItems.Name,
                                   Cmim = y.SalePrice,
                                   Sasi = y.Quantity,
                               }).ToList()


                           }).ToList();


                    return list;


                }

            }

            catch (Exception e)
            {
                return new List<FaturePreview>();
            }

        }

        //get all cancelled orders that are confirmed
        public static List<FaturePreview> getCancelledOrders(string userid)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    DateTime SOT = DateTime.Now.Date;

                    List<bool> fiscaltype = new List<bool> { true };
                    if (RegisterData.ShowAllBillTypes)
                    {
                        fiscaltype.Add(false);
                    }

                    var list = db.Orders.Where(x => x.User_Id == userid && DbFunctions.TruncateTime(x.OperationTime) == SOT && x.OrderStatus_Id == 13 && x.OrderStatus_Id != 15&&fiscaltype.Contains(x.FiscalCash))

                          .Select(x => new FaturePreview
                          {
                              Id = x.Id,
                              Data = x.OperationTime,
                              FatureBody = x.OrderDetails.Select(y => new FatureRow
                              {
                                  Asortimenti = y.MenuItems.Name,
                                  Cmim = y.SalePrice,
                                  Sasi = y.Quantity,
                              }).ToList()


                          }).ToList();

                    return list;

                }

            }

            catch (Exception e)
            {
                return new List<FaturePreview>();
            }


        }


        public static int MbyllTurn(string userid, decimal CashTotal, decimal TipsTotalSum)
        {



            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    ObjectParameter Output = new ObjectParameter("id", typeof(Int32));
                    db.mbyllTurn(userid, RegisterData.POS_Id, CashTotal, TipsTotalSum, Output);




                    return int.Parse(Output.Value.ToString());
                }

            }

            catch
            {


                return -1;
            }

        }

        public static void UpdateUnCollapsedOrders(string userid)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    db.Database.ExecuteSqlCommand("update Orders  set OrderStatus_Id=15 where OrderStatus_Id=10  and User_Id ='" + userid + "'");

                }

            }

            catch
            {



            }




        }

        public static List<TurnetRowModel> MerTurnet(DateTime datestart, DateTime dateend, string userid)
        {
            try
            {

               
                using (BPDBEntities db = new BPDBEntities())
                {
                    if (userid == "ALL")
                        return db.Reports.Where(x => DbFunctions.TruncateTime(datestart) <= DbFunctions.TruncateTime(x.Start_Date_Time) && DbFunctions.TruncateTime(dateend) >= DbFunctions.TruncateTime(x.Start_Date_Time)).Select(y => new TurnetRowModel { NumerFaturash = y.Orders_No, NrProduktesh = y.Sold_Items_No, Total = y.Orders_Total_Sum, Cash = y.Cash_Total, Data = y.Date_Time, Tips = y.Tips_Total_Sum, Fiscal_Orders_Total_Sum = y.Fiscal_Orders_Total_Sum,UserName=y.AspNetUsers.UserDatas.FirstOrDefault().FirstName,Id=y.Id}).OrderByDescending(x => x.Data).ToList();

                    return db.Reports.Where(x => x.User_Id == userid && DbFunctions.TruncateTime(datestart) <= DbFunctions.TruncateTime(x.Start_Date_Time) && DbFunctions.TruncateTime(dateend) >= DbFunctions.TruncateTime(x.Start_Date_Time)).Select(y => new TurnetRowModel { NumerFaturash = y.Orders_No, NrProduktesh = y.Sold_Items_No, Total = y.Orders_Total_Sum, Cash = y.Cash_Total, Data = y.Date_Time, Tips = y.Tips_Total_Sum, Fiscal_Orders_Total_Sum = y.Fiscal_Orders_Total_Sum, UserName = y.AspNetUsers.UserDatas.FirstOrDefault().FirstName, Id = y.Id }).OrderByDescending(x => x.Data).ToList();
                }
            }

            catch
            {
                return new List<TurnetRowModel>();
            }
        }


        //mer turnet per syncOnline

        public static NewReportViewModel MerTurnetSync(int id)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    //query per marjen e turnit te fundit te mbyllur

                    NewReportViewModel report = new NewReportViewModel();


                    var lasrtreport = db.Reports.Where(x => x.Id == id).SingleOrDefault();
                    report.Orders_No = lasrtreport.Orders_No;
                    report.Orders_Total_Sum = lasrtreport.Orders_Total_Sum;
                    report.Place_Id = RegisterData.Place_Id;
                    report.Sold_Items_No = lasrtreport.Sold_Items_No;
                    report.Tips_Total_Sum = lasrtreport.Tips_Total_Sum;
                    report.User_Id = lasrtreport.User_Id;
                    report.Fiscal_Orders_Total_Sum = lasrtreport.Fiscal_Orders_Total_Sum;
                    report.Cash_Total = lasrtreport.Cash_Total;
                    report.Date_Time = lasrtreport.Date_Time;
                    report.POS_Id = RegisterData.POS_Id;
                    report.Start_Date_Time = lasrtreport.Start_Date_Time;
                    report.Id = id;
                    report.Local_Id = lasrtreport.Id;
                    return report;

                }

            }

            catch
            {


                return new NewReportViewModel();
            }

        }

        //insert new report in startup 
        public static bool InsertNewReportFromServer(List<StartupReportViewModel> model)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    foreach (var item in model)
                    {
                        Reports r = new Reports();

                        r.Orders_No = item.Orders_No;
                        r.Orders_Total_Sum = item.Orders_Total_Sum;
                        r.Place_Id = 1;
                        r.Sold_Items_No = item.Sold_Items_No;
                        r.Tips_Total_Sum = item.Tips_Total_Sum;
                        r.User_Id = item.User_Id;
                        r.Fiscal_Orders_Total_Sum = item.Fiscal_Orders_Total_Sum;
                        r.Cash_Total = item.Cash_Total;
                        r.Date_Time = item.Date_Time;
                        r.POS_Id = item.POS_Id;
                        r.Start_Date_Time = item.Start_Date_Time;

                        db.Reports.Add(r);


                    }
                    db.SaveChanges();

                    return true;

                }

            }

            catch (Exception exr)
            {
                log.Error("Fail to Insert Report from Server " + exr.Message.ToString());
                return false;

            }

        }

        public static List<InventarModel> GetShitje(DateTime start, DateTime end, string userid, int categoryid, List<Int32> ArtikujtList)
        {


            string cause1 = "";
            string cause2 = "";
            string wherein = "";
            string notZero = "";
            string categoryAndMenuitemsAnd = "";
            if (userid != ComboBoxData.TeGjitha)
            {
                cause1 = " and ol.User_Id='" + userid + "'";
            }
            if (categoryid != 0)
            {
                cause2 = "where mc.Id= " + categoryid;
                categoryAndMenuitemsAnd = " and ";
            }
            else
            {
                categoryAndMenuitemsAnd = "where";
            }

            //if are selected items filter ,create where in clause
            if (ArtikujtList.Count > 0)
            {
                string listid = "";
                foreach (var item in ArtikujtList)
                {
                    listid = listid + item + ",";

                }

                listid = listid.Remove(listid.Length - 1);



                wherein = categoryAndMenuitemsAnd + "  m.Id in(" + listid + ") ";

            }
            else
            {
                notZero = " where s.Nr is not null ";
            }

            var kasafilter = string.Empty;
            if (RegisterData.ShowAllBillTypes == false)
            {
                kasafilter = " and ol.FiscalCash=1";
            }

            string startstr = start.Year + "-" + start.Month + "-" + start.Day + " " + start.ToShortTimeString();
            string endstr = end.Year + "-" + end.Month + "-" + end.Day + " " + end.ToShortTimeString();

            string query = "" +
"select s.Name as Asortimenti,s.Price as Cmimi,isnull(s.Nr,0) as Sasia ,isnull(s.Price*s.Nr,0) as Vlera,s.CatName as Kategoria " +
" from (select m.Name,Price as Price,mc.Name as CatName ,(select sum(o.Quantity)" +
  " from OrderDetails o join Orders ol on o.Order_Id = ol.Id " +
 " where o.MenuItem_Id = m.Id and   ol.OperationTime >='" + startstr + "'  and  ol.OperationTime <='" + endstr + "'  and ol.OrderStatus_Id<>13 "+kasafilter +
    "" + cause1 + ") as Nr " +
   " from MenuItems m join  MenuCategories mc on m.MenuCategory_Id=mc.Id " + cause2 + wherein + "   ) s " + notZero + " order by s.Name " +


"";





            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    return db.Database.SqlQuery<InventarModel>(query).ToList();
                }

            }

            catch
            {


                return new List<InventarModel>();
            }

        }



        public static bool AddInventaryStatic(InventorySync sync)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    var prod = db.MenuItems.Where(x => x.OnlineId == sync.MenuItem_Id).SingleOrDefault();




                    int sh;
                    if (sync.IsRemove)
                    {
                        sh = -1;
                    }
                    else
                    {
                        sh = 1;
                    }


                    if (prod.MenuItemTypeId == Constants.COMPOSED)
                    {
                        foreach (var item in prod.ComposedItems1)
                        {
                            LastBalance lastbalance = db.LastBalance.Where(x => x.MenuItemId == item.ChildId).FirstOrDefault();
                            Balance b = new Balance();




                            b.Date = DateTime.Now;
                            b.QuantityState = lastbalance.LastQuantity + sh * sync.Quantity * item.quantity;
                            b.Price = lastbalance.LastPrice * lastbalance.LastQuantity + sh * lastbalance.LastPrice * sync.Quantity * item.quantity;//edit now
                            b.MenuItemId = item.ChildId;
                            //update last quantity
                            lastbalance.LastQuantity = b.QuantityState;

                            db.Balance.Add(b);
                        }

                    }

                    else
                    {
                        LastBalance lastbalance = db.LastBalance.Where(x => x.MenuItemId == prod.Id).FirstOrDefault();
                        Balance b = new Balance();




                        b.Date = DateTime.Now;
                        b.QuantityState = lastbalance.LastQuantity + sh * sync.Quantity;
                        b.Price = lastbalance.LastPrice * lastbalance.LastQuantity + sh * lastbalance.LastPrice * sync.Quantity;//edit now
                        b.MenuItemId = prod.Id;
                        //update last quantity
                        lastbalance.LastQuantity = b.QuantityState;

                        db.Balance.Add(b);
                    }


                    db.SaveChanges();

                    return true;

                }

            }

            catch (Exception exr)
            {
                log.Error("fail to modify invetary static " + exr.Message.ToString());
                return false;

            }

        }



        public static Tuple<decimal, decimal> getBalance(DateTime D1, DateTime D2)
        {

            using (BPDBEntities db = new BPDBEntities())
            {


                var shitjet = @"select isnull(sum(od.Quantity*od.SalePrice),0) as total

                   from Orders o join OrderDetails od
                   on o.Id=od.Order_Id where CONVERT(date,o.OperationTime) between CONVERT(date,'" + D1.Date.ToShortDateString() + "')  and CONVERT(date,'" + D2.Date.ToShortDateString() + "')";

                decimal shitjetvalue = db.Database.SqlQuery<decimal>(shitjet).First();

                var daljet = @"select isnull(sum(od.Quantity*od.Price),0) as total

                from Goods_Dispatch_Note o join Goods_Dispatch_Note_Details od
                on o.Id=od.GDNId where CONVERT(date,o.OrderDate)   between CONVERT(date,'" + D1.Date.ToShortDateString() + "')  and CONVERT(date,'" + D2.Date.ToShortDateString() + "')";

                decimal daljevalue = db.Database.SqlQuery<decimal>(daljet).First();

                return new Tuple<decimal, decimal>(shitjetvalue, daljevalue);
            }



        }




        public static XhiroDitoreModel getReportDataRePrint(int raportid)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    var turnidata = new XhiroDitoreModel();

                    var turni = db.Reports.Find(raportid);
                    turnidata.Turni = new TurnetRowModel { Fiscal_Orders_Total_Sum = turni.Fiscal_Orders_Total_Sum, Total = turni.Orders_Total_Sum, NumerFaturash = turni.Orders_No, NrProduktesh = turni.Sold_Items_No,Data=turni.Date_Time,Cash=turni.Orders_Total_Sum };
                    var start = turni.Start_Date_Time;
                    var end = turni.Date_Time;
                    var userid = turni.User_Id;
                    string startstr = start.Year + "-" + start.Month + "-" + start.Day + " " + start.ToLongTimeString();
                    string endstr = end.Year + "-" + end.Month + "-" + end.Day + " " + end.ToLongTimeString();
                    string sql = string.Empty;
                    if (RegisterData.ShowAllBillTypes)
                    {
                        sql = @"select s.Name as Emer,s.Price as Cmim,s.Nr as Nr from 
                              (select Name,Price+'' as Price ,(select sum(o.Quantity)
                             from OrderDetails o join Orders ol on o.Order_Id = ol.Id
                             where o.MenuItem_Id = m.Id   and ol.User_Id='" + userid + "' and ol.OrderStatus_Id<>13 and ol.operationtime between '" + startstr + "' and '" + endstr + "') as Nr  from MenuItems m) s where Nr >= 0";
                    }
                    else
                    {
                        sql = @"select s.Name as Emer,s.Price as Cmim,s.Nr as Nr from 
                              (select Name,Price+'' as Price ,(select sum(o.Quantity)
                             from OrderDetails o join Orders ol on o.Order_Id = ol.Id
                             where o.MenuItem_Id = m.Id   and ol.User_Id='" + userid + "' and ol.OrderStatus_Id<>13 and ol.operationtime between '" + startstr + "' and '" + endstr + "' and FiscalCash=1) as Nr  from MenuItems m) s where Nr >= 0";
                    }
                    turnidata.Detajet = db.Database.SqlQuery<XhiroDitoreRow>(sql).ToList();

                    turnidata.CancelOrders = getCancelledOrdersRePrint(userid,start,end);
                    turnidata.RequestedForCancelOrders = getOrdersRequestedForCancelRePrint(userid, start, end);
                    return turnidata;

                }
            }
            catch (Exception ex)
            {
                return new XhiroDitoreModel();
            }
        }
        //merr Porosite e kerkuara per anullim por qe nuk jane anulluar
        public static List<FaturePreview> getOrdersRequestedForCancelRePrint(string userid,DateTime startdate,DateTime enddate)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    DateTime SOT = DateTime.Now.Date;

                    var ListOfRequestetOrdersId = db.OrderForCancellation.Where(x => DbFunctions.TruncateTime(x.Date) == SOT && x.Orders.User_Id == userid).Select(x => x.OrderId).ToList();

                    var list = db.Orders.Where(x => ListOfRequestetOrdersId.Contains(x.Id) && x.OrderStatus_Id != 15 &&x.OperationTime>=startdate&&x.OperationTime<=enddate).
                           Select(x => new FaturePreview
                           {
                               Id = x.Id,
                               Data = x.OperationTime,
                               FatureBody = x.OrderDetails.Select(y => new FatureRow
                               {
                                   Asortimenti = y.MenuItems.Name,
                                   Cmim = y.SalePrice,
                                   Sasi = y.Quantity,
                               }).ToList()


                           }).ToList();


                    return list;


                }

            }

            catch (Exception e)
            {
                return new List<FaturePreview>();
            }

        }
        //merr te gjitha porosite e anulluara te turnit
        public static List<FaturePreview> getCancelledOrdersRePrint(string userid,DateTime startdate,DateTime enddate)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    DateTime SOT = DateTime.Now.Date;

                    var list = db.Orders.Where(x => x.User_Id == userid && DbFunctions.TruncateTime(x.OperationTime) == SOT && x.OrderStatus_Id == 13 && x.OrderStatus_Id != 15 && x.OperationTime >= startdate && x.OperationTime <= enddate)

                          .Select(x => new FaturePreview
                          {
                              Id = x.Id,
                              Data = x.OperationTime,
                              FatureBody = x.OrderDetails.Select(y => new FatureRow
                              {
                                  Asortimenti = y.MenuItems.Name,
                                  Cmim = y.SalePrice,
                                  Sasi = y.Quantity,
                              }).ToList()


                          }).ToList();

                    return list;

                }

            }

            catch (Exception e)
            {
                return new List<FaturePreview>();
            }


        }
    }






}

