using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Artikuj;
using MYBAR.Model.FatureModel;
using MYBAR.Model.SyncModel;
using MYBAR.Model.SyncModel.IvoiceReceive;
using MYBAR.Model.SyncModel.StartUp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MYBAR.Services
{
    public class FatureService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<MenuCategories> getMenuCategories()
        {





            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {


                    return db.MenuCategories.Where(x => x.IsItemActive == true).AsNoTracking().ToList();


                }


            }

            catch (Exception e)
            {

                List<MenuCategories> l = new List<MenuCategories>();
                l.Add(new MenuCategories { Id = 0, Name = "empty" });
                return l;

            }
        }
        public static List<FatureRow> getMenuItems(int menuCategoriesId)
        {

            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {



                   var simplelist= db.MenuItems.Where(x => x.MenuCategory_Id == menuCategoriesId && x.IsItemActive == true&&x.MenuItemTypeId==Constants.SIMPLE).
                        Select(x=>new FatureRow
                        { Productid=x.Id,
                            ProductOnlineId =x.OnlineId,
                            Asortimenti =x.Name,Cmim=x.Price,Cmimi=x.Price.ToString(),
                            TypeId=x.MenuItemTypeId,
                            CategoryId=x.MenuCategories.Id,
                            PrinterName=x.MenuCategories.Printer,
                            Njesi=x.Unit.Name
                        }).OrderBy(x=>x.Asortimenti)
                            .ToList();


                    var composedList = db.MenuItems.Where(x => x.MenuCategory_Id == menuCategoriesId && x.IsItemActive == true && x.MenuItemTypeId == Constants.COMPOSED).
                             Select(x => new FatureRowComposed
                             {
                                 Productid = x.Id,
                                 ProductOnlineId = x.OnlineId,
                                 Asortimenti = x.Name,
                                 Cmim = x.Price,
                                 CategoryId = x.MenuCategories.Id,
                                 PrinterName = x.MenuCategories.Printer,
                                 Cmimi = x.Price.ToString(),
                                 TypeId = x.MenuItemTypeId,
                                 Njesi = x.Unit.Name,
                                 Ingredients = x.ComposedItems1.Select(z => new FatureRow { Productid = z.ChildId, ProductOnlineId = z.MenuItems.OnlineId, Asortimenti = z.MenuItems.Name, Sasi = z.quantity, TypeId = z.MenuItems.MenuItemTypeId }).ToList()

                             }).OrderBy(x => x.Asortimenti)
                       .ToList();
                    simplelist=   simplelist.Concat(composedList).ToList();

                    return simplelist;
                }

            }

            catch
            {

                return new List<FatureRow>();
            }
        }

        public static List<FatureRow> getMenuItemsByStartName(string name)
        {

            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {



                    var simplelist = db.MenuItems.Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.IsItemActive == true && x.MenuItemTypeId == Constants.SIMPLE).
                       Select(x => new FatureRow
                       {
                           Productid = x.Id,
                           ProductOnlineId = x.OnlineId,
                           Asortimenti = x.Name,
                           Cmim = x.Price,
                           CategoryId = x.MenuCategories.Id,
                           PrinterName = x.MenuCategories.Printer,
                           Cmimi = x.Price.ToString(),
                           TypeId=x.MenuItemTypeId,
                           Njesi = x.Unit.Name

                       }).AsNoTracking()
                           .ToList();


                    var composedList = db.MenuItems.Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.IsItemActive == true && x.MenuItemTypeId == Constants.COMPOSED).
                             Select(x => new FatureRowComposed
                             {
                                 Productid = x.Id,
                                 ProductOnlineId = x.OnlineId,
                                 Asortimenti = x.Name,
                                 Cmim = x.Price,
                                 CategoryId = x.MenuCategories.Id,
                                 PrinterName = x.MenuCategories.Printer,
                                 Cmimi = x.Price.ToString(),
                                 TypeId=x.MenuItemTypeId,
                                 Njesi = x.Unit.Name,
                                 Ingredients = x.ComposedItems1.Select(z => new FatureRow { Productid = z.ChildId, ProductOnlineId = z.MenuItems.OnlineId, Asortimenti = z.MenuItems.Name, Sasi = z.quantity , TypeId = z.MenuItems.MenuItemTypeId }).ToList()

                             })
                       .ToList();
                    simplelist = simplelist.Concat(composedList).ToList();

                    return simplelist;
                }

            }

            catch
            {

                return new List<FatureRow>();
            }
        }

        public static List<FatureRow> getALLMenuItems()
        {
            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {



                    var simplelist = db.MenuItems.Where(x => x.IsItemActive == true && x.MenuItemTypeId == Constants.SIMPLE).
                       Select(x => new FatureRow
                       {
                           Productid = x.Id,
                           ProductOnlineId = x.OnlineId,
                           Asortimenti = x.Name,
                           Cmim = x.Price,
                           CategoryId = x.MenuCategories.Id,
                           PrinterName = x.MenuCategories.Printer,
                           Cmimi = x.Price.ToString(),
                           TypeId = x.MenuItemTypeId,
                           Njesi = x.Unit.Name

                       }).AsNoTracking()
                           .ToList();


                    var composedList = db.MenuItems.Where(x => x.IsItemActive == true && x.MenuItemTypeId == Constants.COMPOSED).
                             Select(x => new FatureRowComposed
                             {
                                 Productid = x.Id,
                                 ProductOnlineId = x.OnlineId,
                                 Asortimenti = x.Name,
                                 Cmim = x.Price,
                                 CategoryId = x.MenuCategories.Id,
                                 PrinterName = x.MenuCategories.Printer,
                                 Cmimi = x.Price.ToString(),
                                 TypeId = x.MenuItemTypeId,
                                 Njesi = x.Unit.Name,
                                 Ingredients = x.ComposedItems1.Select(z => new FatureRow { Productid = z.ChildId, ProductOnlineId = z.MenuItems.OnlineId, Asortimenti = z.MenuItems.Name, Sasi = z.quantity, TypeId = z.MenuItems.MenuItemTypeId }).ToList()

                             })
                       .ToList();
                    simplelist = simplelist.Concat(composedList).ToList();

                    return simplelist;
                }

            }

            catch
            {

                return new List<FatureRow>();
            }
        }

        //get ingriedents of ComposedItems
        public static List<FatureRow> getComposedItemsIngredients(int parentid)
        {
            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {



                    return db.ComposedItems.Where(x =>x.ParentId==parentid).Select(z => new FatureRow { Productid = z.ChildId, ProductOnlineId = z.MenuItems.OnlineId, Asortimenti = z.MenuItems.Name, Sasi = z.quantity, TypeId = z.MenuItems.MenuItemTypeId }).ToList();
                }

            }

            catch
            {

                return new List<FatureRow>();
            }
        }
        public static List<FatureRow> getMenuItemsForFatureHyrje(int categoryid)
        {
            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {



                    return db.MenuItems.Where(x => x.MenuCategory_Id == categoryid && x.IsItemActive == true&&x.MenuItemTypeId!=Constants.COMPOSED).Select(x => new FatureRow { Productid = x.Id, SasiStatus = x.LastBalance.LastQuantity, Asortimenti = x.Name, Cmimi = "0", Cmim = x.LastBalance.LastPrice, ProductOnlineId = x.OnlineId,Njesi=x.Unit.Name }).ToList();
                }

            }

            catch
            {

                return new List<FatureRow>();
            }
        }


        public static bool SaveFatureNew(FatureNew f)
        {

           // MainWindow M = (MainWindow)App.Current.MainWindow;
            using (TransactionScope ts = new TransactionScope())
            {

                try
                {

                    using (BPDBEntities db = new BPDBEntities())
                    {


                        Orders o = new Orders();

                        o.Table_Id = f.TavolineId;
                        o.OperationTime = DateTime.Now;
                        //cojme daten e fatures qe do dergohet te njejte me ate qe ruhet ne databazen lokale
                        f.OrderDate = o.OperationTime;
                        o.User_Id = f.User_Id;
                        o.OrderStatus_Id = 9;
                        o.FiscalCash = f.Fiscal_Cash;
                        List<OrderDetails> orderdetails = new List<OrderDetails>();
                        var date = DateTime.Now;
                        foreach (var fr in f.FatureRows)
                        {

                            OrderDetails t = new OrderDetails();
                            t.MenuItem_Id = fr.Productid;
                            t.SalePrice = fr.Cmim;
                            t.Quantity = fr.Sasi;
                            t.Data = date;
                            orderdetails.Add(t);


                        }

                        o.OrderDetails = orderdetails;






                        //-==-----------------------------


                        OrderSessions ossession = new OrderSessions();
                        ossession.User_Id = f.User_Id;
                        ossession.Table_Id = f.TavolineId;

                        o.OrderSessions.Add(ossession);






                        db.Orders.Add(o);


                        //add fature dalje to database

                        Goods_Dispatch_Note fatureDalje = new Goods_Dispatch_Note();
                        fatureDalje.OrderDate = DateTime.Now;
                        fatureDalje.OrderNumber = "mynumber";
                        fatureDalje.UserId = f.User_Id;

                        foreach (var ar in f.FatureRows)
                        {

                            foreach (var item in ar.getProdukteDalje())
                            {


                                Goods_Dispatch_Note_Details fdrow = new Goods_Dispatch_Note_Details();
                                fdrow.MenuItemId = item.Productid;
                                

                                //cmimi i llogaritur ne lastbalance[ cmimi mesatar];

                                LastBalance lastbalance = db.LastBalance.Where(x => x.MenuItemId == item.Productid).FirstOrDefault();
                                fdrow.Price = lastbalance.LastPrice;

                                Balance b = new Balance();

                                b.Date = DateTime.Now;
                                int sasi;
                                if (ar.TypeId == Constants.COMPOSED)
                                {
                                    sasi = ar.Sasi * item.Sasi;
                                }
                                else
                                {
                                    sasi = ar.Sasi;
                                }
                                fdrow.Quantity = sasi;

                                b.QuantityState = lastbalance.LastQuantity - sasi;
                                b.Price = lastbalance.LastPrice * lastbalance.LastQuantity - lastbalance.LastPrice * sasi;//edit now
                                b.MenuItemId = item.Productid;
                                //update last quantity
                                lastbalance.LastQuantity = b.QuantityState;


                                fatureDalje.Goods_Dispatch_Note_Details.Add(fdrow);
                                db.Balance.Add(b);

                            }
                            

                            db.SaveChanges();
                        }

                        //shto ne gjendjen e  balances

                        db.Goods_Dispatch_Note.Add(fatureDalje);




                        db.SaveChanges();
                        f.FatureId = o.Id;
                        //set to dalje orderid
                        fatureDalje.OrderId = o.Id;
                        db.SaveChanges();
                       ts.Complete();


                        return true;
                    }

                }

                catch (Exception e)
                {
                    e.Message.ToString();
                
                    return false;
                }

            }




        }

        /// <summary>
        /// Anullim Fature,kthehen gjendjet ne magazine
        /// </summary>
        /// <param name="tavid"></param>
        /// <returns></returns>
        public static bool AnulloFature(int OrderId)
        {

            using (TransactionScope ts = new TransactionScope())
            {

                try
                {

                    using (BPDBEntities db = new BPDBEntities())
                    {

                        Orders o = db.Orders.Where(x => x.Id == OrderId).FirstOrDefault();


                        o.OrderStatus_Id = 13;


                        foreach (var item in o.OrderDetails)
                        {

                            if (item.MenuItems.MenuItemTypeId == Constants.COMPOSED)
                            {

                                foreach (var ingriedents in item.MenuItems.ComposedItems1)
                                {


                                    //cmimi i llogaritur ne lastbalance[ cmimi mesatar];

                                    LastBalance lastbalance = db.LastBalance.Where(x => x.MenuItemId == ingriedents.ChildId).FirstOrDefault();


                                    Balance b = new Balance();

                                    b.Date = DateTime.Now;
                                    b.QuantityState = lastbalance.LastQuantity + item.Quantity*ingriedents.quantity;
                                    b.Price = lastbalance.LastPrice * lastbalance.LastQuantity + lastbalance.LastPrice * item.Quantity*ingriedents.quantity;
                                    b.MenuItemId = ingriedents.ChildId;
                                    //update last quantity
                                    lastbalance.LastQuantity = b.QuantityState;



                                    db.Balance.Add(b);

                                    db.SaveChanges();
                                }

                            }

                            else
                            {

                                //cmimi i llogaritur ne lastbalance[ cmimi mesatar];

                                LastBalance lastbalance = db.LastBalance.Where(x => x.MenuItemId == item.MenuItem_Id).FirstOrDefault();


                                Balance b = new Balance();

                                b.Date = DateTime.Now;
                                b.QuantityState = lastbalance.LastQuantity + item.Quantity;
                                b.Price = lastbalance.LastPrice * lastbalance.LastQuantity + lastbalance.LastPrice * item.Quantity;
                                b.MenuItemId = item.MenuItem_Id;
                                //update last quantity
                                lastbalance.LastQuantity = b.QuantityState;



                                db.Balance.Add(b);

                                db.SaveChanges();
                            }

                        }




                        db.SaveChanges();


                        
                        ts.Complete();


                        return true;
                    }

                }

                catch (Exception e)
                {
                   log.Error("Fail to Cancel Order "+ e.Message.ToString());
                 
                    return false;
                }

            }

        }
        public static FatureEdit getFatureOfTable(int tavid)
        {



            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    FatureEdit fedit = new FatureEdit();

                    decimal sum = 0;
                    var oss = db.OrderSessions.Where(x => x.Table_Id == tavid).FirstOrDefault();
                    if (oss == null)
                    {
                        return null;
                    }

                    Orders o = db.Orders.Where(x => x.Id == oss.Order_Id).FirstOrDefault();

                    fedit.FatureId = o.Id;
                    fedit.TavolineId = tavid;
                    fedit.Fiscal_Cash = o.FiscalCash;
                    fedit.TavolineNumber = o.Tables.Number;
                    foreach (var od in o.OrderDetails.GroupBy(x => new { x.MenuItem_Id, x.SalePrice, x.MenuItems.Name }).Select(x => new FatureRow { Productid = x.Key.MenuItem_Id, Sasi = x.ToList().Sum(y => y.Quantity), Cmim = x.Key.SalePrice, Cmimi = x.Key.SalePrice.ToString("#0.00"), Asortimenti = x.Key.Name }))
                    {

                        // sum += od.Quantity * od.SalePrice;

                        //var existed = fedit.FatureRows.Where(x => x.Productid == od.MenuItem_Id).FirstOrDefault();
                        //if (existed != null)
                        //{
                        //    existed.Sasi += od.Quantity;
                        //}

                        //else
                        //{
                        //    fedit.FatureRows.Add(new FatureRow { Productid = od.MenuItem_Id, Sasi = od.Quantity, Cmim = od.SalePrice, Cmimi = od.SalePrice.ToString("#0.00"), Asortimenti = od.MenuItems.Name, Date = od.Data });

                        //}

                        sum += od.Sasi * od.Cmim;

                        fedit.FatureRows.Add(od);
                    }


                    fedit.Total = sum;
                    //add a fraction
                    IEnumerable<FatureRow> obsCollection = (IEnumerable<FatureRow>)fedit.FatureRows;
                    var list = new List<FatureRow>(obsCollection);
                    fedit.Fraction = ktheFatureTeNdareSipasKohes(list).Count+1;

                    return fedit;

                }
            }

            catch (Exception ex)
            {

                ex.Message.ToString();

                return null;
            }

        }

        /// <summary>
        /// Get fature where nothing is syncing
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public static NewOrderViewModel getFatureByIdForTransferToServer(int orderid)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {



                    var fat = db.Orders.Where(x => x.Id == orderid).FirstOrDefault();

                    NewOrderViewModel f = new NewOrderViewModel();
                    f.Local_Id = fat.Id;
                    f.OperationTime = fat.OperationTime;
                    f.User_Id = fat.User_Id;
                    f.Table_Id = fat.Tables.OnLineId;
                    f.OrderStatus_Id = 9;
                    f.IsFiscal = fat.FiscalCash;
                    f.POS_Id = RegisterData.POS_Id;
                    f.Items = fat.OrderDetails.Select(x => new OrderDetailViewModel { Id = x.MenuItems.OnlineId, Count = x.Quantity, SalePrice = x.SalePrice }).ToList();


                    return f;


                }

            }

            catch (Exception ex)
            {

                return new NewOrderViewModel();


            }



        }
        public static NewOrderViewModel getFatureByIdForTransferToServerUpdate(int orderid, List<int> olineid)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {



                    var fat = db.Orders.Where(x => x.Id == orderid).FirstOrDefault();

                    NewOrderViewModel f = new NewOrderViewModel();
                    f.Local_Id = fat.Id;
                    f.OperationTime = fat.OperationTime;
                    f.User_Id = fat.User_Id;
                    f.Table_Id = fat.Tables.OnLineId;
                    f.OrderStatus_Id = 9;
                    f.Items = fat.OrderDetails.Where(x => olineid.Any(y => y == x.MenuItems.OnlineId)).Select(x => new OrderDetailViewModel { Id = x.MenuItems.OnlineId, Count = x.Quantity, SalePrice = x.SalePrice }).ToList();


                    return f;


                }

            }

            catch (Exception ex)
            {

                return new NewOrderViewModel();


            }



        }
        public static bool UpdateOpenTable(FatureEdit fedit)
        {

            using (TransactionScope ts = new TransactionScope())
            {

                try
                {



                    using (BPDBEntities DB = new BPDBEntities())
                    {


                        //UPDATE CHANGED PRODUCTS 

                        var dalje = DB.Goods_Dispatch_Note.Where(x => x.OrderId == fedit.FatureId).FirstOrDefault();

                        var date = DateTime.Now;
                        foreach (FatureRow r in fedit.NewFatureRow)
                        {


                            //FatureRow OldRowOfProduct = fedit.FatureRows.Where(x => x.Productid == r.Productid).FirstOrDefault();
                            //if (OldRowOfProduct != null)
                            //{



                            //    var row = DB.OrderDetails.Where(x => x.Order_Id == fedit.FatureId && x.MenuItem_Id == r.Productid).FirstOrDefault();
                            //    row.Quantity = r.Sasi + OldRowOfProduct.Sasi;

                            //    DB.SaveChanges();
                            //}
                            //else
                            {
                                OrderDetails od = new OrderDetails();
                                od.Order_Id = fedit.FatureId;


                                od.MenuItem_Id = r.Productid;
                                od.Quantity = r.Sasi;
                                od.SalePrice = r.Cmim;
                                od.Data = date;
                                DB.OrderDetails.Add(od);

                            }

                            foreach (var item in r.getProdukteDalje())
                            {

                                //zbresim sasine e artikujve te shitur
                                LastBalance lastbalance = DB.LastBalance.Where(x => x.MenuItemId == item.Productid).FirstOrDefault();



                                int sasi;
                                if (r.TypeId == Constants.COMPOSED)
                                {
                                    sasi = r.Sasi * item.Sasi;
                                }
                                else
                                {
                                    sasi = item.Sasi;
                                }

                                Balance b = new Balance();

                            b.Date = DateTime.Now;
                            b.QuantityState = lastbalance.LastQuantity - sasi;
                            b.Price = lastbalance.LastPrice * lastbalance.LastQuantity - lastbalance.LastPrice * sasi;
                            b.MenuItemId = item.Productid;
                            //update last quantity
                            lastbalance.LastQuantity = b.QuantityState;



                            DB.Balance.Add(b);

                            //edit faturedalje

                         
                            if(dalje != null){

                                    var daljedetail = new Goods_Dispatch_Note_Details { MenuItemId = item.Productid, Quantity = sasi, Price = lastbalance.LastPrice };
                                    dalje.Goods_Dispatch_Note_Details.Add(daljedetail);
                                }
                               
                            }
                         
                            DB.SaveChanges();


                        }


                        DB.SaveChanges();



                        ts.Complete();
                    }

                    return true;

                }
                catch (Exception ex)
                {

                 
                    log.Error("Fail to update open Table"+ex.Message.ToString());
                    return false;

                }



            }
        }

        public static bool ClosePorosiInTable(int tavid)
        {


            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    using (BPDBEntities db = new BPDBEntities())
                    {

                        OrderSessions temp = db.OrderSessions.Where(x => x.Table_Id == tavid).FirstOrDefault();

                        var statusorder = db.Orders.Where(x => x.Id == temp.Order_Id).FirstOrDefault();

                        statusorder.OrderStatus_Id = 10; //hardcoded


                        db.OrderSessions.Remove(temp);

                        db.SaveChanges();

                        ts.Complete();

                        return true;

                    }

                }

                catch (Exception ex)
                {
                    log.Error(ex.Message + ":" + ex.InnerException.ToString());
                    return false;


                }

            }
        }

        //get fatura by date and user
        public static List<FatureList> getMyFatura(DateTime d, DateTime d2, string userid,List<bool> types)
        {




            try
            {


                using (BPDBEntities db = new BPDBEntities())
                {

                    if (userid == "ALL")
                        return db.Orders.Where(x => (x.OperationTime) >= d && (x.OperationTime) <= d2&&types.Contains(x.FiscalCash)).Select(x => new FatureList { NrFature = x.Id, Data = x.OperationTime, Tavolina = x.Tables.Number,Fiskale=x.FiscalCash, Total = x.OrderDetails.Select(y => y.Quantity * y.SalePrice).Sum(), Statusi = x.OrderStatus.StatusName,Kamarieri=x.AspNetUsers.UserDatas.FirstOrDefault().FirstName }).OrderByDescending(x=>x.NrFature).ToList();

                   
                    else
                    
                    return db.Orders.Where(x => x.User_Id.Equals(userid) && x.OperationTime >= d && x.OperationTime <= d2 && types.Contains(x.FiscalCash)).Select(x => new FatureList { NrFature = x.Id, Data = x.OperationTime, Fiskale = x.FiscalCash, Tavolina = x.Tables.Number, Total = x.OrderDetails.Select(y => y.Quantity * y.SalePrice).Sum(), Statusi = x.OrderStatus.StatusName, Kamarieri = x.AspNetUsers.UserDatas.FirstOrDefault().FirstName }).OrderByDescending(x => x.NrFature).ToList();
                    


                }


            }

            catch (Exception ex)
            {

                return new List<FatureList>();

            }
        }
        //get fatura betewen two order numbers
        /// <summary>
        /// get my fatura betwwen two fatura numbers,start is start number and end is end number
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
            public static List<FatureList> getMyFatura(int start,int end, List<bool> types)
        {


            try
            {


                using (BPDBEntities db = new BPDBEntities())
                {

                 
                        return db.Orders.Where(x => x.Id >= start && x.Id <= end&& types.Contains(x.FiscalCash)).Select(x => new FatureList { NrFature = x.Id, Data = x.OperationTime, Tavolina = x.Tables.Number, Total = x.OrderDetails.Select(y => y.Quantity * y.SalePrice).Sum(), Statusi = x.OrderStatus.StatusName,Fiskale=x.FiscalCash, Kamarieri = x.AspNetUsers.UserDatas.FirstOrDefault().FirstName }).OrderByDescending(x => x.NrFature).ToList();
                    


                }


            }

            catch (Exception ex)
            {

                return new List<FatureList>();

            }

        }
        //get fatura for anullim to administrator
        public static List<AnullimFatureModel> getOrderForCancellation()
        {




            try
            {


                using (BPDBEntities db = new BPDBEntities())
                {

                    var faturaforcancel = db.OrderForCancellation.Select(x => x.OrderId).ToList();
                    
                        return db.Orders.Where(x =>faturaforcancel.Contains(x.Id)).Select(x => new AnullimFatureModel { NrFature = x.Id, Data = x.OperationTime, Tavolina = x.Tables.Number, Total = x.OrderDetails.Select(y => y.Quantity * y.SalePrice).Sum(), Statusi = x.OrderStatus.StatusName,Kamarieri=x.AspNetUsers.UserDatas.FirstOrDefault().FirstName }).ToList();


                 


                }


            }

            catch 
            {

                return new List<AnullimFatureModel>();

            }
        }

        public static FaturePreview getFaturePreview(int orderid)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {


                    FaturePreview f = db.Orders.Where(x => x.Id == orderid).Select(x => new FaturePreview { Data = x.OperationTime, Id = orderid, TavolineNr = x.Table_Id,UserName=x.AspNetUsers.UserDatas.FirstOrDefault().FirstName, FatureBody = x.OrderDetails.Select(y => new FatureRow { Productid = y.MenuItem_Id, Cmim = y.SalePrice, Sasi = y.Quantity, Asortimenti = y.MenuItems.Name,Date=y.Data }).ToList() }).FirstOrDefault();

                    f.TavolineNr = db.Tables.Where(h => h.Id == f.TavolineNr).Select(h => h.Number).FirstOrDefault();

                    return f;
                }

            }

            catch (Exception e)
            {
                return new FaturePreview();

            }
        }

        public static FaturePreview getFaturePreviewPermbledhese(int orderid)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {


                    FaturePreview f = db.Orders.Where(x => x.Id == orderid).
                        Select(x => new FaturePreview
                        {
                            Data = x.OperationTime,
                            Id = orderid,
                            TavolineNr = x.Table_Id,
                            UserName = x.AspNetUsers.UserDatas.FirstOrDefault().FirstName,
                            FatureBody = x.OrderDetails
                            .GroupBy(s => new {s.MenuItem_Id, s.MenuItems.Name, s.SalePrice }).
                            Select(y => new FatureRow
                            {
                                Productid = y.Key.MenuItem_Id,
                                Cmim = y.Key.SalePrice,
                                Sasi = y.ToList().Sum(c => c.Quantity),
                                Asortimenti = y.Key.Name,
                                Njesi=db.OrderDetails.Where(h=>h.Order_Id==orderid&&h.MenuItem_Id==y.Key.MenuItem_Id).FirstOrDefault().MenuItems.Unit.Name
                            }).ToList()
                        }).FirstOrDefault();

                    f.TavolineNr = db.Tables.Where(h => h.Id == f.TavolineNr).Select(h => h.Number).FirstOrDefault();

                    return f;
                }

            }

            catch (Exception e)
            {
                return new FaturePreview();

            }
        }

        //funksinet e fatures se hyrjes per inventar

        public static bool SaveFatureHyrje(FatureHyrje fat)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {

                    MainWindow m = (MainWindow)App.Current.MainWindow;
                    using (BPDBEntities db = new BPDBEntities())
                    {

                        Goods_Received_Note faturehyrje = new Goods_Received_Note();
                        faturehyrje.OrderDate = DateTime.Now;
                        faturehyrje.OrderNumber = fat.OrderNumber;
                        faturehyrje.UserId = m.UserId;
                        faturehyrje.Online_Id = fat.FatureOnlineId;

                        foreach (var item in fat.FatureRows)
                        {

                            faturehyrje.Goods_Received_Note_Details.Add(new Goods_Received_Note_Details { MenuItemId = item.Productid, Quantity = item.Sasi, Price = item.Cmim });

                        }

                        db.Goods_Received_Note.Add(faturehyrje);

                        db.SaveChanges();

                        //financial operation
                        InsertNewItemBalanceFatureHyrje(fat.FatureRows, db);

                        db.SaveChanges();
                        ts.Complete();
                        return true;
                    }

                }

                catch (Exception e)
                {

                    
                    log.Error("Failed to Save fature hyrje locally" + e.Message.ToString());
                    return false;

                }


            }
        }
        public static bool SaveFatureHyrjeFromKorrigjim(FatureHyrje fat,string userid)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {

                 
                    using (BPDBEntities db = new BPDBEntities())
                    {

                        Goods_Received_Note faturehyrje = new Goods_Received_Note();
                        faturehyrje.OrderDate = DateTime.Now;
                        faturehyrje.OrderNumber = fat.OrderNumber;
                        faturehyrje.UserId = userid;
                        faturehyrje.Online_Id = fat.FatureOnlineId;

                        foreach (var item in fat.FatureRows)
                        {

                            faturehyrje.Goods_Received_Note_Details.Add(new Goods_Received_Note_Details { MenuItemId = item.Productid, Quantity = item.Sasi, Price = item.Cmim });

                        }

                        db.Goods_Received_Note.Add(faturehyrje);

                        db.SaveChanges();

                        //financial operation
                        InsertNewItemBalanceFatureHyrje(fat.FatureRows, db);

                        db.SaveChanges();
                        ts.Complete();
                        return true;
                    }

                }

                catch (Exception e)
                {


                    log.Error("Failed to Save fature hyrje locally" + e.Message.ToString());
                    return false;

                }


            }
        }

        public static FatureHyrje PrepareFatureHyrjeFromServer(InvoiceSyncViewModel model)
        {

            using (BPDBEntities db = new BPDBEntities())
            {


                if (db.Goods_Received_Note.Where(x => x.Online_Id == model.Id).Any())
                    return null;

                FatureHyrje newFature = new FatureHyrje();

            newFature.FatureOnlineId = model.Id;
            newFature.OrderDate = model.Date;
            newFature.OrderNumber = "onlineInvoice" + model.Id;
            newFature.User_Id = model.User_Id;

            var OnlineIds = model.InvoiceDetails.Select(x => x.Id).ToList();



                foreach (var item in model.InvoiceDetails)
                {
                    var productReal = db.MenuItems.Where(x => x.OnlineId == item.MenuItem_Id).SingleOrDefault();
                    try
                    {


                        var id = productReal.Id;
                    



                    var row = new FatureRow
                    {
                        Productid = id,
                        Sasi = item.Quantity,
                        Cmim = item.BuyPrice
                    };
                    newFature.ReferenceFatureRows.Add(row);
                }
                    catch (Exception e)
                    {

                    }
                }


                return newFature;

            }


                


        }
      


        public static bool SaveFatureHyrjeFromServer(FatureHyrje fat)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {

                    
                    using (BPDBEntities db = new BPDBEntities())
                    {

                        Goods_Received_Note faturehyrje = new Goods_Received_Note();
                        faturehyrje.OrderDate = fat.OrderDate;
                        faturehyrje.OrderNumber = fat.OrderNumber;
                        faturehyrje.UserId = fat.User_Id;
                        faturehyrje.Online_Id = fat.FatureOnlineId;

                        foreach (var item in fat.FatureRows)
                        {

                            faturehyrje.Goods_Received_Note_Details.Add(new Goods_Received_Note_Details { MenuItemId = item.Productid, Quantity = item.Sasi, Price = item.Cmim });

                        }

                        db.Goods_Received_Note.Add(faturehyrje);

                        db.SaveChanges();

                        //financial operation
                        InsertNewItemBalanceFatureHyrjeFromServer(fat.FatureRows, db,fat.OrderDate);

                        db.SaveChanges();
                        ts.Complete();
                        return true;
                    }

                }

                catch (Exception e)
                {
                    log.Error("Fail to Save Fature Hyrje from Server " + e.Message.ToString());
                 
                    return false;

                }


            }
        }

        public static FatureHyrjeEdit getFatureHyrje(int orderid)
        {

            try
            {
                FatureHyrjeEdit f = new FatureHyrjeEdit();

                using (BPDBEntities db = new BPDBEntities())
                {


                    Goods_Received_Note receivedfature = db.Goods_Received_Note.Where(x => x.Id == orderid).FirstOrDefault();

                    f.FatureId = receivedfature.Id;
                    f.OrderDate = receivedfature.OrderDate;
                    f.OrderNumber = receivedfature.OrderNumber;
                    foreach (var item in receivedfature.Goods_Received_Note_Details)
                    {

                        //get two copies or editing ,compare old with new collecion with changes
                        f.ReferenceFatureRows.Add(new FatureRow { Productid = item.MenuItemId, Asortimenti = item.MenuItems.Name, Cmim = item.Price, Sasi = item.Quantity ,Njesi=item.MenuItems.Unit.Name});
                        f.NewFatureRow.Add(new FatureRow { Productid = item.MenuItemId, Asortimenti = item.MenuItems.Name, Cmim = item.Price, Sasi = item.Quantity , Njesi = item.MenuItems.Unit.Name });
                    }

                    return f;
                }


            }

            catch (Exception e)
            {
                return new FatureHyrjeEdit();

            }
        }
        //edit fature hyrje
        public static bool UpdateFatureHyrje(FatureBase fat)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    ObservableCollection<FatureRow> DeleteList = new ObservableCollection<FatureRow>();
                    ObservableCollection<FatureRow> InsertList = new ObservableCollection<FatureRow>();
                    ObservableCollection<FatureRow> UpdateList = new ObservableCollection<FatureRow>();

                    MainWindow m = (MainWindow)App.Current.MainWindow;
                    using (BPDBEntities db = new BPDBEntities())
                    {

                        Goods_Received_Note grn = db.Goods_Received_Note.Where(x => x.Id == fat.FatureId).FirstOrDefault();
                        grn.LastUpdateDate = DateTime.Now;
                        grn.OrderNumber = fat.OrderNumber;
                        //*******************************************************************
                        //get list of new product and insert into balance 
                        foreach (var item in fat.NewFatureRow)
                        {

                            if (!fat.FatureRows.Where(x => x.Productid == item.Productid).Any())
                            {
                                InsertList.Add(item);
                                grn.Goods_Received_Note_Details.Add(new Goods_Received_Note_Details { MenuItemId = item.Productid, Quantity = item.Sasi, Price = item.Cmim });
                            }

                        }


                        //insertnew product in balance
                        InsertNewItemBalanceFatureHyrje(InsertList, db);


                        //*******************************************************************
                        //calculate updated and deleted rows

                        foreach (var item in fat.FatureRows)
                        {

                            FatureRow newrow = fat.NewFatureRow.Where(x => x.Productid == item.Productid).FirstOrDefault();
                            //nese ekziston artikulli dhe ndryshon sasi
                            if (newrow != null)
                            {
                                if (newrow.Sasi - item.Sasi != 0)
                                {
                                    //update item, and updatebalance with right value


                                    Goods_Received_Note_Details gdupdate = db.Goods_Received_Note_Details.Where(x => x.MenuItemId == item.Productid && x.GRNId == fat.FatureId).FirstOrDefault();
                                    gdupdate.Price = newrow.Cmim;
                                    gdupdate.Quantity = (newrow.Sasi);
                                    //change row quantity
                                    newrow.Sasi = newrow.Sasi - item.Sasi;
                                    db.SaveChanges();
                                    UpdateList.Add(newrow);

                                }
                            }
                            else
                            {

                                //delete lineitem,not implemented
                                Goods_Received_Note_Details deletedrow = db.Goods_Received_Note_Details.Where(x => x.MenuItemId == item.Productid && x.GRNId == fat.FatureId).FirstOrDefault();
                                db.Goods_Received_Note_Details.Remove(deletedrow);
                                db.SaveChanges();
                                item.Sasi = item.Sasi * -1;
                                DeleteList.Add(item);
                            }

                        }


                        InsertNewItemBalanceFatureHyrje(UpdateList, db);
                        InsertNewItemBalanceFatureHyrje(DeleteList, db);


                        db.SaveChanges();
                        ts.Complete();
                        return true;
                    }

                }

                catch (Exception e)
                {

                 
                    return false;

                }

            }

        }

        public static bool DeleteFatureHyrje(FatureBase fat)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {

                    MainWindow m = (MainWindow)App.Current.MainWindow;
                    using (BPDBEntities db = new BPDBEntities())
                    {

                        Goods_Received_Note fordelete = db.Goods_Received_Note.Where(x => x.Id == fat.FatureId).FirstOrDefault();

                        db.Goods_Received_Note.Remove(fordelete);


                        foreach (var item in fat.FatureRows)
                        {
                            LastBalance l = db.LastBalance.Where(x => x.MenuItemId == item.Productid).FirstOrDefault();

                            Balance b = new Balance();
                            b.QuantityState = l.LastQuantity - item.Sasi;
                            b.Price = l.LastQuantity * l.LastPrice - item.Sasi * item.Cmim;
                            b.Date = DateTime.Now;
                            db.Balance.Add(b);
                            l.LastQuantity = b.QuantityState;
                            l.LastPrice = b.Price / b.QuantityState;
                            db.SaveChanges();

                        }

                        db.SaveChanges();
                        ts.Complete();
                        return true;
                    }

                }

                catch (Exception e)
                {

                   

                    log.Error("Fail to delete fature hyrje ! "+e.Message.ToString());
                    return false;

                }

            }


        }
        public static void InsertNewItemBalanceFatureHyrje(ObservableCollection<FatureRow> list, BPDBEntities db)
        {


            foreach (var item in list)
            {
                LastBalance lastrecord = db.LastBalance.Where(x => x.MenuItemId == item.Productid).FirstOrDefault();

                Balance b = new Balance();
                b.Date = DateTime.Now;
                b.MenuItemId = item.Productid;
                b.Price = item.Cmim * item.Sasi + lastrecord.LastPrice * lastrecord.LastQuantity;
                b.QuantityState = lastrecord.LastQuantity + item.Sasi;


                //llogaritet cmimi per dalje[fature dalje behet me cmim mesatar]


                //price i Balance eshte vlera totatle sasi*cmim,ndesa price ne lastbalance eshte cmimi mesatar per daljen e atij produkti

                //nese sasia e hyrjes eshte zero atehere behet overide cmimi i blerjes
                if (item.Sasi == 0)
                {
                    lastrecord.LastPrice = item.Cmim;
                }
                else
                {
                    if (item.Cmim != lastrecord.LastPrice)
                    {
                        if(b.QuantityState!=0)
                        lastrecord.LastPrice = (b.Price / b.QuantityState);

                        db.SaveChanges();
                    }
                    lastrecord.LastQuantity = b.QuantityState;
                }

                
                db.SaveChanges();
                db.Balance.Add(b);

            }

        }

        public static void InsertNewItemBalanceFatureHyrjeFromServer(ObservableCollection<FatureRow> list, BPDBEntities db,DateTime time)
        {


            foreach (var item in list)
            {
                LastBalance lastrecord = db.LastBalance.Where(x => x.MenuItemId == item.Productid).FirstOrDefault();

                Balance b = new Balance();
                b.Date = time;
                b.MenuItemId = item.Productid;
                b.Price = item.Cmim * item.Sasi + lastrecord.LastPrice * lastrecord.LastQuantity;
                b.QuantityState = lastrecord.LastQuantity + item.Sasi;


                //llogaritet cmimi per dalje[fature dalje behet me cmim mesatar]
                //price i Balance eshte vlera totatle sasi*cmim,ndesa price ne lastbalance eshte cmimi mesatar per daljen e atij produkti
                if (item.Cmim != lastrecord.LastPrice)
                {
                    if(b.QuantityState!=0)
                    lastrecord.LastPrice = (b.Price / b.QuantityState);

                    db.SaveChanges();
                }

                lastrecord.LastQuantity = b.QuantityState;
                db.SaveChanges();
                db.Balance.Add(b);

            }

        }

        public static int InsertOrdersFromServerInStartup(OrderStartViewModel model)
        {





           

                try
                {

                    using (BPDBEntities db = new BPDBEntities())
                    {

                        var localTable = db.Tables.Where(x => x.OnLineId == model.Table_Id).SingleOrDefault();
                        Orders o = new Orders();

                        o.Table_Id = localTable.Id;
                        o.OperationTime = model.OperationTime;
                        o.User_Id = model.User_Id;
                        o.OrderStatus_Id = model.OrderStatus_Id;
                        o.FiscalCash = model.IsFiscal;
                        o.POS_ID = model.POS_Id;
                        List<OrderDetails> orderdetails = new List<OrderDetails>();
                        var OnlineIds = model.OrderDetails.Select(x => x.MenuItem_Id).ToList();
                        var productReallist = db.MenuItems.Where(x => OnlineIds.Contains(x.OnlineId)).ToList();
                    var data = DateTime.Now;
                        foreach (var fr in model.OrderDetails)
                        {
                            var productRealid = db.MenuItems.Where(x => x.OnlineId == fr.MenuItem_Id).SingleOrDefault().Id;
                            OrderDetails t = new OrderDetails();
                            t.MenuItem_Id = productRealid;
                            t.SalePrice = fr.SalePrice;
                            t.Quantity = fr.Quantity;
                            t.Data = data;
                            orderdetails.Add(t);


                        }

                        o.OrderDetails = orderdetails;






                        //-==-----------------------------





                        //add fature dalje to database

                        Goods_Dispatch_Note fatureDalje = new Goods_Dispatch_Note();
                       fatureDalje.OrderDate = model.OperationTime;

                        fatureDalje.OrderNumber = "mynumber";
                        fatureDalje.UserId = model.User_Id;
                        foreach (var item in model.OrderDetails)
                        {

                            

                            

                        Goods_Dispatch_Note_Details fdrow = new Goods_Dispatch_Note_Details();
                        var myar=db.MenuItems.Where(x => x.OnlineId == item.MenuItem_Id).SingleOrDefault();
                        var productRealid = myar.Id;

                        //nese eshte i perbere
                        if (myar.MenuItemTypeId==Constants.COMPOSED)
                        {
                            

                            foreach (var ing in myar.ComposedItems1)
                            {
                                Goods_Dispatch_Note_Details fdrow1 = new Goods_Dispatch_Note_Details();
                                fdrow1.MenuItemId = ing.ChildId;
                                fdrow1.Quantity = item.Quantity*ing.quantity;

                                //cmimi i llogaritur ne lastbalance[ cmimi mesatar];

                                LastBalance lastbalance = db.LastBalance.Where(x => x.MenuItemId == ing.ChildId).FirstOrDefault();
                                fdrow1.Price = lastbalance.LastPrice;

                                Balance b = new Balance();

                                b.Date = model.OperationTime;
                                b.QuantityState = lastbalance.LastQuantity - item.Quantity*ing.quantity;
                                b.Price = lastbalance.LastPrice * lastbalance.LastQuantity - lastbalance.LastPrice *ing.quantity*item.Quantity;//edit now
                                b.MenuItemId = ing.ChildId;
                                //update last quantity
                                lastbalance.LastQuantity = b.QuantityState;

                                fatureDalje.Goods_Dispatch_Note_Details.Add(fdrow1);
                                db.Balance.Add(b);
                            }




                        }
                        else
                        {

                            
                            fdrow.MenuItemId = productRealid;
                            fdrow.Quantity = item.Quantity;

                            //cmimi i llogaritur ne lastbalance[ cmimi mesatar];

                            LastBalance lastbalance = db.LastBalance.Where(x => x.MenuItemId == productRealid).FirstOrDefault();
                            fdrow.Price = lastbalance.LastPrice;

                            Balance b = new Balance();

                            b.Date = model.OperationTime;
                            b.QuantityState = lastbalance.LastQuantity - item.Quantity;
                            b.Price = lastbalance.LastPrice * lastbalance.LastQuantity - lastbalance.LastPrice * item.Quantity;//edit now
                            b.MenuItemId = productRealid;
                            //update last quantity
                            lastbalance.LastQuantity = b.QuantityState;

                            fatureDalje.Goods_Dispatch_Note_Details.Add(fdrow);

                            db.Balance.Add(b);
                        }
                        

                    }
                        db.Goods_Dispatch_Note.Add(fatureDalje);


                    db.Orders.Add(o);
                        //shto ne gjendjen e  balances


                        db.SaveChanges();

                    var id = o.Id;

 
                        return id;
                    }
                   
                }

                catch (Exception e)
                {
                  log.Error("Fail to Insert Order from Server in Startup !"+  e.Message.ToString());
                  
                    return 0;
                }

            
        }

        //get list of non collapsed fatura
        public static CollectViewModel GetNonCollapsedOrderByUser(string userid)
        {
            try
            {
                CollectViewModel v = new CollectViewModel();
              
                using (BPDBEntities db = new BPDBEntities())
                {

                 v.Orders=  db.Orders.Where(x => x.OrderStatus_Id == 10 && x.User_Id == userid).Select(x => new LocalOrderViewModel { Local_Id = x.Id, Table_Id = x.Tables.OnLineId }).ToList();
                    return v;
                }

            }

            catch (Exception e)
            {

                return new CollectViewModel();

            }
        }

        public static void STARTIDORDER(int START)
        {
            try
            {
                CollectViewModel v = new CollectViewModel();

                using (BPDBEntities db = new BPDBEntities())
                {

                    db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('[Orders]', RESEED, " + START + ");");
                }

            }

            catch (Exception e)
            {

                log.Error("Fail to set identity number table order ! " + e.Message.ToString());

            }
        }


        //save and close  an order in table 
        public static bool SaveAndClose(FatureNew f, int TableId )
        {

            return SaveFatureNew(f) && ClosePorosiInTable(TableId);
        }

        //save only dalje for korrigjim inventari

        public static bool SaveDaljeOnly(List<KorrigjimInventariModel> list,string userid)
        {

            try
            {

                
                CollectViewModel v = new CollectViewModel();

                using (BPDBEntities db = new BPDBEntities())
                {

                    Goods_Dispatch_Note dalje = new Goods_Dispatch_Note();
                    dalje.OrderDate = DateTime.Now;
                    dalje.UserId = userid;

                    dalje.OrderId = -1;
                    dalje.OrderNumber = "korrigjiminvantari";
                    foreach (var item in list)
                    {
                        dalje.Goods_Dispatch_Note_Details.Add(
                            new Goods_Dispatch_Note_Details
                            {
                                MenuItemId = item.ProduktId,
                                Quantity=item.Diferenca*-1,
                                Price=item.LastBuyPrice
                            });


                        LastBalance lastrecord = db.LastBalance.Where(x => x.MenuItemId == item.ProduktId).FirstOrDefault();

                        Balance b = new Balance();
                        b.Date = DateTime.Now;
                        b.MenuItemId = item.ProduktId;
                        b.Price = item.Cmimi * item.Diferenca + lastrecord.LastPrice * lastrecord.LastQuantity;
                        b.QuantityState = lastrecord.LastQuantity + item.Diferenca;


                        //llogaritet cmimi per dalje[fature dalje behet me cmim mesatar]
                        //price i Balance eshte vlera totatle sasi*cmim,ndesa price ne lastbalance eshte cmimi mesatar per daljen e atij produkti
                     

                        lastrecord.LastQuantity = b.QuantityState;
                        db.SaveChanges();
                        db.Balance.Add(b);
                    }

                    db.Goods_Dispatch_Note.Add(dalje);
                    db.SaveChanges();
                    return true;
                }

            }

            catch (Exception e)
            {

                log.Error("Fail to set identity number table order ! " + e.Message.ToString());
                return false;
            }
        }



        public static List<List<FatureRow>> ktheFatureTeNdareSipasKohes(List<FatureRow> list)
        {

      return list.OrderBy(u=>u.Date)
     .GroupBy(u => u.Date)
     .Select(grp => grp.ToList())
     .ToList();

       

        }
        public static Dictionary<string,List<FatureRow>> ktheProdukteSipasPrinterave(List<FatureRow> list)
        {

            var d = new Dictionary<string, List<FatureRow>>();
            
    return list
           .GroupBy(u => u.PrinterName)
           //.Select(grp => grp.ToList())
           .ToDictionary(g=>g.Key??"NONE",g=>g.ToList());


           



        }


    }


    

}
