using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Artikuj;
using MYBAR.Model.Reports;
using MYBAR.Model.SyncModel;
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
    public class ArtikullService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<ComboBoxData> getMenuCategoriesCombo()
        {




            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {
                    var list = new List<ComboBoxData>();
                    list.Add(ComboBoxData.DefaultOption);


                    list.AddRange(db.MenuCategories.Where(x=>x.IsItemActive==true).Select(x => new ComboBoxData { DataValue = x.Id, DisplayValue = x.Name,DataValueOnline=x.OnlineId }).ToList());

                    return list;

                }


            }

            catch (Exception e)
            {

                List<ComboBoxData> l = new List<ComboBoxData>();

                return l;

            }
        }
        public static ObservableCollection<ArtikullListRow> getAllArtikujByCategory(int catid)
        {
            ObservableCollection<ArtikullListRow> list = new ObservableCollection<ArtikullListRow>();
            
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    
                    if (catid >= 0)
                    {
                        var listsimple=(db.MenuItems.Where(y => y.MenuCategory_Id == catid && y.IsItemActive == true&&y.MenuItemTypeId!=Constants.COMPOSED).Select(x => new ArtikullListRowSimple
                        {
                            ProduktId = x.Id,
                            OnlineProductid = x.OnlineId,
                            CategoryId = x.MenuCategory_Id,
                            Asortimenti = x.Name,
                            Cmimi = x.Price,
                            Sasi = x.LastBalance.LastQuantity,
                            SasiaMinimale = x.MinimumQuantityNotify,
                            CategoryOnlineId = x.MenuCategories.OnlineId,
                            TypeId = x.MenuItemType.Id,
                            TypeName = x.MenuItemType.Name,
                            UnitId = x.UnitId,
                            UnitName = x.Unit.Name
                        }).AsNoTracking().ToList());

                       //marr artikujt e perbere

                       
                        var composedlist = new ObservableCollection<ArtikullListRow>();
                        foreach( var x in db.MenuItems.Where(y => y.MenuCategory_Id == catid && y.IsItemActive == true && y.MenuItemTypeId == Constants.COMPOSED).Include("ComposedItems").AsNoTracking())
                        {
                            var comitem = new ArtikullListRowComposed
                            {
                                ProduktId = x.Id,
                                OnlineProductid = x.OnlineId,
                                CategoryId = x.MenuCategory_Id,
                                Asortimenti = x.Name,
                                Cmimi = x.Price,
                                
                                
                                CategoryOnlineId = x.MenuCategories.OnlineId,
                                TypeId = x.MenuItemType.Id,
                                TypeName = x.MenuItemType.Name,
                                UnitId = x.UnitId,
                                UnitName = x.Unit.Name
                            };

                            var ingriedents = x.ComposedItems1.Select(q => new ArtikullListRowSimple
                            {
                                ProduktId = q.MenuItems.Id,
                                OnlineProductid = q.MenuItems.OnlineId,

                                Asortimenti = q.MenuItems.Name,
                                Cmimi = q.MenuItems.Price,
                                Sasi = q.quantity,


                                TypeId = q.MenuItems.MenuItemTypeId,

                                UnitId = q.MenuItems.UnitId,
                                UnitName = q.MenuItems.Unit.Name
                            }).ToList();

                            comitem.IngriedentList = new ObservableCollection<ArtikullListRow>(ingriedents);

                            composedlist.Add(comitem);
                        }


                        return  new ObservableCollection<ArtikullListRow>( list.Concat(listsimple).Concat(composedlist).ToList());
                    }
                    else
                    {

                        var listsimple = new ObservableCollection<ArtikullListRow>(db.MenuItems.Where(y => y.MenuCategory_Id == catid && y.IsItemActive == true && y.MenuItemTypeId != Constants.COMPOSED).Select(x => new ArtikullListRowSimple
                        {
                            ProduktId = x.Id,
                            OnlineProductid = x.OnlineId,
                            CategoryId = x.MenuCategory_Id,
                            Asortimenti = x.Name,
                            Cmimi = x.Price,
                            Sasi = x.LastBalance.LastQuantity,
                            SasiaMinimale = x.MinimumQuantityNotify,
                            CategoryOnlineId = x.MenuCategories.OnlineId,
                            TypeId = x.MenuItemType.Id,
                            TypeName = x.MenuItemType.Name,
                            UnitId = x.UnitId,
                            UnitName = x.Unit.Name
                        }).AsNoTracking().ToList());

                        //marr artikujt e perbere


                        var composedlist = new ObservableCollection<ArtikullListRow>();
                        foreach (var x in db.MenuItems.Where(y => y.MenuCategory_Id == catid && y.IsItemActive == true && y.MenuItemTypeId == Constants.COMPOSED).AsNoTracking())
                        {
                            var comitem = new ArtikullListRowComposed
                            {
                                ProduktId = x.Id,
                                OnlineProductid = x.OnlineId,
                                CategoryId = x.MenuCategory_Id,
                                Asortimenti = x.Name,
                                Cmimi = x.Price,


                                CategoryOnlineId = x.MenuCategories.OnlineId,
                                TypeId = x.MenuItemType.Id,
                                TypeName = x.MenuItemType.Name,
                                UnitId = x.UnitId,
                                UnitName = x.Unit.Name
                            };

                            var ingriedents = x.ComposedItems1.Select(q => new ArtikullListRowSimple
                            {
                                ProduktId = q.MenuItems.Id,
                                OnlineProductid = q.MenuItems.OnlineId,

                                Asortimenti = q.MenuItems.Name,
                                Cmimi = q.MenuItems.Price,
                                Sasi = q.quantity,


                                TypeId = q.MenuItems.MenuItemTypeId,

                                UnitId = q.MenuItems.UnitId,
                                UnitName = q.MenuItems.Unit.Name
                            }).ToList();

                            comitem.IngriedentList = new ObservableCollection<ArtikullListRow>(ingriedents);

                            composedlist.Add(comitem);
                        }


                        return new ObservableCollection<ArtikullListRow>(list.Concat(listsimple).Concat(composedlist).ToList());
                        ;
                    }

                }
            }
            catch (Exception ex)
            {
                return new ObservableCollection<ArtikullListRow>();
            }
        }
        public static ObservableCollection<ArtikullListRow> getAllArtikujByCategoryAndByStartName(int catid, string searchartikull)
        {


            try
            {

                ObservableCollection<ArtikullListRow> list = new ObservableCollection<ArtikullListRow>();
                using (BPDBEntities db = new BPDBEntities())
                {
                    var listsimple = new ObservableCollection<ArtikullListRow>(db.MenuItems.Where(y =>y.Name.Contains(searchartikull) && y.IsItemActive == true && y.MenuItemTypeId != Constants.COMPOSED).Select(x => new ArtikullListRowSimple
                    {
                        ProduktId = x.Id,
                        OnlineProductid = x.OnlineId,
                        CategoryId = x.MenuCategory_Id,
                        Asortimenti = x.Name,
                        Cmimi = x.Price,
                        Sasi = x.LastBalance.LastQuantity,
                        SasiaMinimale = x.MinimumQuantityNotify,
                        CategoryOnlineId = x.MenuCategories.OnlineId,
                        TypeId = x.MenuItemType.Id,
                        TypeName = x.MenuItemType.Name,
                        UnitId = x.UnitId,
                        UnitName = x.Unit.Name
                    }).AsNoTracking().ToList());

                    //marr artikujt e perbere


                    var composedlist = new ObservableCollection<ArtikullListRow>();
                    foreach (var x in db.MenuItems.Where(y => y.Name.Contains(searchartikull) && y.IsItemActive == true && y.MenuItemTypeId == Constants.COMPOSED).AsNoTracking())
                    {
                        var comitem = new ArtikullListRowComposed
                        {
                            ProduktId = x.Id,
                            OnlineProductid = x.OnlineId,
                            CategoryId = x.MenuCategory_Id,
                            Asortimenti = x.Name,
                            Cmimi = x.Price,


                            CategoryOnlineId = x.MenuCategories.OnlineId,
                            TypeId = x.MenuItemType.Id,
                            TypeName = x.MenuItemType.Name,
                            UnitId = x.UnitId,
                            UnitName = x.Unit.Name
                        };

                        var ingriedents = x.ComposedItems1.Select(q => new ArtikullListRowSimple
                        {
                            ProduktId = q.MenuItems.Id,
                            OnlineProductid = q.MenuItems.OnlineId,

                            Asortimenti = q.MenuItems.Name,
                            Cmimi = q.MenuItems.Price,
                            Sasi = q.quantity,


                            TypeId = q.MenuItems.MenuItemTypeId,

                            UnitId = q.MenuItems.UnitId,
                            UnitName = q.MenuItems.Unit.Name
                        }).ToList();

                        comitem.IngriedentList = new ObservableCollection<ArtikullListRow>(ingriedents);

                        composedlist.Add(comitem);
                    }





                    return new ObservableCollection<ArtikullListRow>(list.Concat(listsimple).Concat(composedlist).ToList());

                }
            }
            catch (Exception ex)
            {
                return new ObservableCollection<ArtikullListRow>();
            }
        }
        public static List<FatureRow> getAllArtikujByStartName(string searchartikull)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    return db.MenuItems.Where(y => y.Name.Contains(searchartikull)&&y.IsItemActive==true).Select(x => new FatureRow { Productid = x.Id,ProductOnlineId=x.OnlineId, Asortimenti = x.Name, Cmim = x.LastBalance.LastPrice, SasiStatus = x.LastBalance.LastQuantity,Njesi=x.Unit.Name }).ToList();

                }
            }
            catch (Exception ex)
            {
                return new List<FatureRow>();
            }
        }
        public static List<FatureRow> getAllArtikuj()
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    return db.MenuItems.Where(y => y.IsItemActive == true).Select(x => new FatureRow { Productid = x.Id, ProductOnlineId = x.OnlineId, Asortimenti = x.Name}).ToList();

                }
            }
            catch (Exception ex)
            {
                return new List<FatureRow>();
            }
        }

        public static MenuCategoriesEditModel getMenuCategorie(int catid)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    return db.MenuCategories.Where(x => x.Id == catid).Select(x => new MenuCategoriesEditModel { Id = x.Id,Online_Id=x.OnlineId, Name = x.Name, Image = x.CategoryImage ,PrinterName=x.Printer}).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                return new MenuCategoriesEditModel();
            }

        }
        public static bool InsertMenuCategories(MenuCategoriesModel m)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuCategories menu = new MenuCategories();
                    menu.Name = m.Name;
                    menu.CategoryImage = m.Image;
                    menu.OnlineId = m.Online_Id;
                    menu.Place_Id = 1; //hardcoded
                    menu.IsItemActive = true;
                    menu.Printer = m.PrinterName;
                    db.MenuCategories.Add(menu);
                    db.SaveChanges();

                    m.Id = menu.Id;

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool UpdateMenuCategories(MenuCategoriesModel m)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuCategories menu = db.MenuCategories.Where(x => x.Id == m.Id).FirstOrDefault();
                    menu.Name = m.Name;
                    menu.Printer = m.PrinterName;
                    menu.CategoryImage = m.Image;
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }   
        public static bool DeleteMenuCategories(MenuCategoriesModel m)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuCategories menu = db.MenuCategories.Where(x => x.Id == m.Id).FirstOrDefault();
                    menu.Name =menu.Name+""+ DateTime.Now.ToString("yymmddhhmm");
                    menu.IsItemActive = false;
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
            

        //veprimet nga serveri  per kategorite
        public static bool InsertMenuCategoriesFromServer(MenuCategorySyncViewModel m)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    if (db.MenuCategories.Where(x => x.OnlineId == m.Id).Any())
                    {
                        return false;
                    }

                    MenuCategories menu = new MenuCategories();
                    menu.Name = m.Name;
                
                    menu.OnlineId = m.Id;
                    menu.Place_Id = 1; //hardcoded
                    menu.IsItemActive = true;
                    db.MenuCategories.Add(menu);
                    db.SaveChanges();

                    m.Id = menu.Id;

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool InsertMenuCategoriesFromServerInStartup(MenuCategoryStartViewModel m)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    if (db.MenuCategories.Where(x => x.OnlineId == m.Id).Any())
                    {
                        return false;
                    }

                    MenuCategories menu = new MenuCategories();
                    menu.Name = m.Name;

                    menu.OnlineId = m.Id;
                    menu.Place_Id = 1; //hardcoded
                    menu.IsItemActive =m.IsCategoryActive;
                    db.MenuCategories.Add(menu);
                    db.SaveChanges();

                    m.Id = menu.Id;

                    return true;

                }
            }
            catch (Exception ex)
            {

                log.Error("Fail to insert categories from server In Startup ! ");
                return false;
            }
        }
        public static bool UpdateMenuCategoriesFromServer(MenuCategorySyncViewModel m)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuCategories menu = db.MenuCategories.Where(x => x.OnlineId == m.Id).FirstOrDefault();
                    menu.Name = m.Name;
                    
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool DeleteMenuCategoriesFromServer(MenuCategorySyncViewModel m)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuCategories menu = db.MenuCategories.Where(x => x.OnlineId == m.Id).FirstOrDefault();
                    menu.Name = menu.Name + "" + DateTime.Now.ToString("yymmddhhmm");
                    menu.IsItemActive = false;
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //veprime lokale nga useri PER produktin e thjeshte
        public static bool InsertNewProduct(ArtikullListRow a)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {



                    using (BPDBEntities db = new BPDBEntities())
                    {

                        MenuItems item = new MenuItems();
                        item.MenuCategory_Id = a.CategoryId;
                        item.Name = a.Asortimenti;
                        item.Price = a.Cmimi;
                        item.OnlineId = a.OnlineProductid;
                        item.Quantity = a.Sasi;
                        item.Supplier_Id = 1;//hardcoded
                        item.IsItemActive = true;
                        item.MinimumQuantityNotify = a.SasiaMinimale;

                        item.UnitId = a.UnitId;
                        item.MenuItemTypeId = a.TypeId;
                        PriceList p = new PriceList();
                        p.Date = DateTime.Now;
                        p.Price = a.Cmimi;
                        item.PriceList.Add(p);
                        db.MenuItems.Add(item);

                        //add i lastBalance and Balance

                        Balance b = new Balance { Price = 0, QuantityState = 0, Date = DateTime.Now };
                        item.Balance.Add(b);
                        item.LastBalance = new LastBalance();
                        item.LastBalance.LastPrice = 0;
                        item.LastBalance.LastQuantity = 0;





                        db.SaveChanges();
                        a.ProduktId = item.Id;

                        ts.Complete();


                        return true;

                    }
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }
       

        public static bool UpdateProduct(ArtikullListRow a)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuItems menuitem = db.MenuItems.Where(x => x.Id == a.ProduktId).FirstOrDefault();
                    menuitem.Name = a.Asortimenti;
                    menuitem.Price = a.Cmimi;
                    menuitem.MinimumQuantityNotify = a.SasiaMinimale;
                    menuitem.MenuCategory_Id = a.CategoryId;
                    menuitem.UnitId = a.UnitId;
                    menuitem.MenuItemTypeId = a.TypeId;
                    //nse ka ndryshuar cmimi atehere bejme vendosje ne listen e cmimeve
                    if (menuitem.Price != a.Cmimi)
                    {
                        PriceList p = new PriceList();
                        p.MenuItemId = a.ProduktId;
                        p.Date = DateTime.Now;
                        p.Price = a.Cmimi;
                        db.PriceList.Add(p);
                    }
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool DeleteProduct(ArtikullListRow a)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuItems menuitem = db.MenuItems.Where(x => x.Id == a.ProduktId).FirstOrDefault();

                    menuitem.Name=menuitem.Name+""+ DateTime.Now.ToString("MM'/'dd'/'yyyy HH':'mm':'ss.fff");
                    menuitem.IsItemActive = false;
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //veprime per produktet per produktet e perbera
        public static bool InsertNewProductComposed(ArtikullListRowComposed a)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {



                    using (BPDBEntities db = new BPDBEntities())
                    {

                        MenuItems item = new MenuItems();
                        item.MenuCategory_Id = a.CategoryId;
                        item.Name = a.Asortimenti;
                        item.Price = a.Cmimi;
                        item.OnlineId = a.OnlineProductid;
                        item.Quantity = a.Sasi;
                        item.Supplier_Id = 1;//hardcoded
                        item.IsItemActive = true;
                        item.MinimumQuantityNotify = a.SasiaMinimale;

                        item.UnitId = a.UnitId;
                        item.MenuItemTypeId = a.TypeId;

                       

                        PriceList p = new PriceList();
                        p.Date = DateTime.Now;
                        p.Price = a.Cmimi;
                        item.PriceList.Add(p);

                      
                        db.MenuItems.Add(item);

                        db.SaveChanges();

                        a.ProduktId = item.Id;

                        

                        //add Ingredients
                        foreach (var ingriedentrow in a.IngriedentList)
                        {

                            db.ComposedItems.Add(new ComposedItems {ParentId=a.ProduktId, ChildId = ingriedentrow.ProduktId, quantity = ingriedentrow.Sasi });

                        }
                        db.SaveChanges();
                        ts.Complete();


                        return true;

                    }
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }
        public static bool UpdateProductComposed(ArtikullListRow a)
        {
            using (TransactionScope ts = new TransactionScope())
            {

                try
            {


              
                    using (BPDBEntities db = new BPDBEntities())
                    {

                        MenuItems menuitem = db.MenuItems.Where(x => x.Id == a.ProduktId).FirstOrDefault();
                        menuitem.Name = a.Asortimenti;
                        menuitem.Price = a.Cmimi;
                        menuitem.MinimumQuantityNotify = a.SasiaMinimale;
                        menuitem.MenuCategory_Id = a.CategoryId;
                        menuitem.UnitId = a.UnitId;
                        menuitem.MenuItemTypeId = a.TypeId;
                        //nse ka ndryshuar cmimi atehere bejme vendosje ne listen e cmimeve
                        if (menuitem.Price != a.Cmimi)
                        {
                            PriceList p = new PriceList();
                            p.MenuItemId = a.ProduktId;
                            p.Date = DateTime.Now;
                            p.Price = a.Cmimi;
                            db.PriceList.Add(p);
                        }

                        db.ComposedItems.RemoveRange(menuitem.ComposedItems1);

                        db.SaveChanges();

                        foreach (var item in a.GetIngredientList())
                        {
                            menuitem.ComposedItems1.Add(new ComposedItems { ChildId = item.ProduktId, quantity = item.Sasi });
                        }

                        db.SaveChanges();
                        ts.Complete();
                        return true;

                    }

                
            }
            catch (Exception ex)
            {
                    ts.Dispose();
               
                return false;
            }

        }
        }

        //veprimet me produktet nga serveri

        public static bool InsertNewProductFromServer(MenuItemSyncViewModel a)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {

                   

                    using (BPDBEntities db = new BPDBEntities())
                    {


                        if (db.MenuItems.Where(x => x.OnlineId == a.Id).Any())
                        {
                            return false;
                        }

                        var category = db.MenuCategories.Where(x => x.OnlineId == a.MenuCategory_Id).FirstOrDefault();

                        MenuItems item = new MenuItems();
                        item.MenuCategory_Id = category.Id;
                        item.Name = a.Name;
                        item.Price = a.Price;
                        item.OnlineId = a.Id;
                        item.Quantity = a.Quantity;
                        item.Supplier_Id = 1;//hardcoded
                        item.IsItemActive = true;
                        item.MinimumQuantityNotify = a.MinQuantity;
                        item.UnitId = a.Unit_Id;
                        item.MenuItemTypeId = a.MenuItemType_Id;
                        PriceList p = new PriceList();
                        p.Date = DateTime.Now;
                        p.Price = a.Price;
                        item.PriceList.Add(p);
                        db.MenuItems.Add(item);

                        //add i lastBalance and Balance

                        Balance b = new Balance { Price = 0, QuantityState = 0, Date = DateTime.Now };
                        item.Balance.Add(b);
                        item.LastBalance = new LastBalance();
                        item.LastBalance.LastPrice = 0;
                        item.LastBalance.LastQuantity = 0;

                        db.SaveChanges();

                        if (a.MenuItemType_Id == Constants.COMPOSED)
                        {
                            // get all ingriedents for localid
                            var IdList = a.ComposingItems.Select(x => x.Child_Id).ToList();
                            var locallist = db.MenuItems.Where(x => IdList.Contains(x.OnlineId)).ToList();

                            foreach (var ingriedentrow in a.ComposingItems)
                            {
                                var localid = locallist.Where(x => x.OnlineId == ingriedentrow.Child_Id).FirstOrDefault().Id;
                                db.ComposedItems.Add(new ComposedItems { ParentId = item.Id, ChildId = localid, quantity = ingriedentrow.Portion_Quantity });

                            }

                            db.SaveChanges();

                        }



                     
                       

                        ts.Complete();


                        return true;

                    }
                }
                catch (Exception ex)
                {
                   
                    return false;
                }

            }
        }
        public static bool InsertNewProductFromServerInStartUp(MenuItemSyncViewModel a)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {



                    using (BPDBEntities db = new BPDBEntities())
                    {


                        if (db.MenuItems.Where(x => x.OnlineId == a.Id).Any())
                        {
                            return false;
                        }

                        var category = db.MenuCategories.Where(x => x.OnlineId == a.MenuCategory_Id).FirstOrDefault();

                        MenuItems item = new MenuItems();
                        item.MenuCategory_Id = category.Id;
                        item.Name = a.Name;
                        item.Price = a.Price;
                        item.OnlineId = a.Id;
                        item.Quantity = a.Quantity;
                        item.Supplier_Id = 1;//hardcoded
                        item.IsItemActive = a.IsItemActive;
                        item.MinimumQuantityNotify = a.MinQuantity;
                        item.MenuItemTypeId = a.MenuItemType_Id;
                        item.UnitId = a.Unit_Id;
                        PriceList p = new PriceList();
                        p.Date = DateTime.Now;
                        p.Price = a.Price;
                        item.PriceList.Add(p);
                        db.MenuItems.Add(item);

                        //add i lastBalance and Balance

                        Balance b = new Balance { Price = 0, QuantityState = 0, Date = new DateTime(2016,5,5) };
                        item.Balance.Add(b);
                        item.LastBalance = new LastBalance();
                        item.LastBalance.LastPrice = 0;
                        item.LastBalance.LastQuantity = 0;





                        db.SaveChanges();


                        ts.Complete();


                        return true;

                    }
                }
                catch (Exception ex)
                {
                   
                    
                    log.Error("Fail to insert MenuItem Simple from server in Startup ! "+ex.Message.ToString());
                    return false;
                }

            }
        }
        public static bool InsertNewProductComposedFromServerInStartUp(MenuItemSyncViewModel a)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {



                    using (BPDBEntities db = new BPDBEntities())
                    {


                        if (db.MenuItems.Where(x => x.OnlineId == a.Id).Any())
                        {
                            return false;
                        }

                        var category = db.MenuCategories.Where(x => x.OnlineId == a.MenuCategory_Id).FirstOrDefault();

                        MenuItems item = new MenuItems();
                        item.MenuCategory_Id = category.Id;
                        item.Name = a.Name;
                        item.Price = a.Price;
                        item.OnlineId = a.Id;
                        item.Quantity = a.Quantity;
                        item.Supplier_Id = 1;//hardcoded
                        item.IsItemActive = a.IsItemActive;
                        item.MinimumQuantityNotify = a.MinQuantity;
                        item.MenuItemTypeId = a.MenuItemType_Id;
                        item.UnitId = a.Unit_Id;
                        PriceList p = new PriceList();
                        p.Date = DateTime.Now;
                        p.Price = a.Price;
                        item.PriceList.Add(p);



                        // get all ingriedents for localid
                        var IdList = a.ComposingItems.Select(x => x.Child_Id).ToList();
                        var locallist = db.MenuItems.Where(x => IdList.Contains(x.OnlineId)).ToList();

                     

                            foreach (var ing in a.ComposingItems)
                        {
                            
                                var localid = locallist.Where(x => x.OnlineId == ing.Child_Id).FirstOrDefault().Id;
                                item.ComposedItems1.Add(new ComposedItems { ChildId = localid, quantity = ing.Portion_Quantity });
                        }


                        db.MenuItems.Add(item);
                        db.SaveChanges();


                        ts.Complete();


                        return true;

                    }
                }
                catch (Exception ex)
                {


                    log.Error("Fail to insert MenuItem Composed from server in Startup ! " + ex.Message.ToString());
                    return false;
                }

            }
        }

        public static bool UpdateProductFromServer(MenuItemSyncViewModel a)
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    var category = db.MenuCategories.Where(x => x.OnlineId == a.MenuCategory_Id).FirstOrDefault();

                    MenuItems menuitem = db.MenuItems.Where(x => x.OnlineId== a.Id).FirstOrDefault();
                    menuitem.Name = a.Name;
                    menuitem.Price = a.Price;
                    menuitem.MinimumQuantityNotify = a.MinQuantity;
                    menuitem.MenuCategory_Id =category.Id;
                    menuitem.UnitId = a.Unit_Id;
                    menuitem.MenuItemTypeId = a.MenuItemType_Id;
                    
                    //nse ka ndryshuar cmimi atehere bejme vendosje ne listen e cmimeve
                    if (menuitem.Price != a.Price)
                    {
                        PriceList p = new PriceList();
                        p.MenuItemId = menuitem.Id;
                        p.Date = DateTime.Now;
                        p.Price = a.Price;
                        db.PriceList.Add(p);
                    }

                    //produkt i perbere 


                    if (a.MenuItemType_Id == Constants.COMPOSED)
                    {
                        db.ComposedItems.RemoveRange(menuitem.ComposedItems1);
                        // get all ingriedents for localid
                        var IdList = a.ComposingItems.Select(x => x.Child_Id).ToList();
                        var locallist = db.MenuItems.Where(x => IdList.Contains(x.OnlineId)).ToList();

                        foreach (var ingriedentrow in a.ComposingItems)
                        {
                            var localid = locallist.Where(x => x.OnlineId == ingriedentrow.Child_Id).FirstOrDefault().Id;
                            db.ComposedItems.Add(new ComposedItems { ParentId = menuitem.Id, ChildId = localid, quantity = ingriedentrow.Portion_Quantity });

                        }

                        db.SaveChanges();

                    }
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteProductFromServer(MenuItemSyncViewModel a)
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    MenuItems menuitem = db.MenuItems.Where(x => x.OnlineId== a.Id).FirstOrDefault();

                    menuitem.Name = menuitem.Name + "" + DateTime.Now.ToString("yymmddhhmm");
                    menuitem.IsItemActive = false;
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<ArtikullListRow> getMenuItemsInMinimumQuantity()
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {


                    return (db.MenuItems.Where(x => x.LastBalance.LastQuantity <= x.MinimumQuantityNotify&&x.IsItemActive==true&&x.MenuCategories.IsItemActive==true).Select(x => new ArtikullListRowSimple { ProduktId = x.Id,OnlineProductid=x.OnlineId, Asortimenti = x.Name, SasiaMinimale = x.MinimumQuantityNotify, Sasi = x.LastBalance.LastQuantity, Cmimi = x.LastBalance.LastPrice }).ToList()).Cast<ArtikullListRow>().ToList();

                }
            }
            catch (Exception ex)
            {
                return new List<ArtikullListRow>();
            }
        }


        //mer produketet me onlineId

        public static List<FatureRow>  getMenuItemsWithOnlineId(List<int> lista)
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {


                    return db.MenuItems.Where(x =>lista.Contains(x.OnlineId)).Select(x => new FatureRow { Productid = x.Id,ProductOnlineId=x.OnlineId}).ToList();

                }
            }
            catch (Exception ex)
            {
                return new List<FatureRow>();
            }

        }
        public static bool ImportArtikujExcel(List<ArtikullListRow> lista)
        {

                try
                {

                    foreach(var item in lista)
                    {
                        InsertNewProduct(item);
                    }


                    return true;
                }
                catch (Exception ex)
                {
                   
                    return false;
                }

            
        }


        public static List<InventarModel> GetArtikujForExcelExport()
        {


            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    //if (catid != 0)
                    //    return new ObservableCollection<ArtikullListRow>(db.MenuItems.Where(y => y.MenuCategory_Id == catid&& y.Name.StartsWith(searchartikull)).Select(x => new ArtikullListRow { ProduktId = x.Id, Asortimenti = x.Name, Cmimi = x.Price, Sasi = x.LastBalance.LastQuantity,SasiaMinimale=x.MinimumQuantityNotify }).ToList());
                    //else
                    return new List<InventarModel>(db.MenuItems.Where(x =>x.IsItemActive == true).Select(x => new InventarModel { Asortimenti=x.Name,Cmimi=x.Price,Kategoria=x.MenuCategories.Name}).ToList());

                }
            }
            catch (Exception ex)
            {
                return new List<InventarModel>();
            }
        }

        //get Tipet e artikujve
        public static List<ComboBoxData> getMenuItemsTypes()
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    
                    return new List<ComboBoxData>(db.MenuItemType.Select(x => new ComboBoxData {DataValue=x.Id, DisplayValue=x.Name }).ToList());

                }
            }
            catch (Exception ex)
            {
                return new List<ComboBoxData>();
            }

        }

        public static List<ComboBoxData> getMenuItemsUnits()
        {
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    return new List<ComboBoxData>(db.Unit.Select(x => new ComboBoxData { DataValue = x.Id, DisplayValue = x.Name }).ToList());

                }
            }
            catch (Exception ex)
            {
                return new List<ComboBoxData>();
            }

        }


        public static List<KorrigjimInventariModel> getKorrigjimInventariList()
        {

            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {

                    return db.MenuItems.Where(x => x.IsItemActive == true&&x.MenuItemTypeId!=Constants.COMPOSED).Select(x => new KorrigjimInventariModel { ProduktId = x.Id, Emri = x.Name, SasiaAktuale = x.LastBalance.LastQuantity, SasiRe = x.LastBalance.LastQuantity,LastBuyPrice=x.LastBalance.LastPrice,OnlineProduktId=x.OnlineId,Cmimi=x.Price }).ToList();

                }
            }
            catch (Exception ex)
            {
                return new List<KorrigjimInventariModel>();
            }


        }
    }
}
