using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.SyncModel;
using MYBAR.Model.SyncModel.StartUp;
using MYBAR.Model.Tavoline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Documents;
using static MYBAR.Mobile.MobileSyncer.MyHub;

namespace MYBAR.Services
{
    public class TavolinaService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static dynamic GetAllTables()
        {


            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {

                    List<dynamic> l = new List<dynamic>();
                    var temp = db.Tables.Where(X => X.IsItemActive == true).ToList();

                    foreach (var x in temp)
                    {
                        bool open = false;
                        if (x.OrderSessions.Count > 0)
                        {
                            open = true;
                        }
                        var useridl = x.OrderSessions.Select(y => y.User_Id).ToList();

                        string UserId = "";
                        if (useridl.Count > 0)
                        {
                            UserId = useridl[0].ToString();
                        }
                        //tableid,number tavoline,indeksi ne nderfaqe ,eshte e hapur apo e mbyllur ,perdorues id
                        var a = new { x.Id, x.Number, x.index, open, UserId, x.OnLineId };

                        l.Add(a);

                    }

                    return l;


                }


            }

            catch (Exception e)
            {
                return new List<dynamic>();

            }

        }

        public static void SaveIndexOfTable(int idtable, int index)
        {


            try
            {
                //update table 
                using (BPDBEntities DB = new BPDBEntities())
                {



                    Tables T = DB.Tables.Where(x => x.Id == idtable).FirstOrDefault();
                    T.index = index;

                    DB.SaveChanges();
                }

            }
            catch
            {


            }

        }
        public static void resetPositions()
        { try
            {
                //update table 
                using (BPDBEntities DB = new BPDBEntities())
                {



                    var l = DB.Tables.Where(x => x.IsItemActive == true).ToList();
                    l.ForEach(x => x.index = null);


                    DB.SaveChanges();
                }

            }
            catch
            {


            }


        }

        public static List<ComboBoxData> getFreeTables(int mytableid)
        {


            try
            {
                using (BPDBEntities DB = new BPDBEntities())
                {

                    List<Int32> exeptionlist = DB.OrderSessions.Select(x => x.Table_Id).ToList();
                    //if is busy remove to display in edit mode, if table if free the id is 0 and has no effect
                    exeptionlist.Remove(mytableid);


                   
                    return DB.Tables.Select(x => new  ComboBoxData{DataValue=x.Id,DataValueOnline=x.OnLineId,DisplayValue=x.Number.ToString() }).Where(x => !exeptionlist.Contains(x.DataValue)).ToList();


               
                }

            }


            catch(Exception ex)
            {
                return new List<ComboBoxData>();
            }
        }

        /// <summary>
        /// Change Order Table And return OrderId [-1 for error]
        /// </summary>
        /// <param name="tableid"></param>
        /// <param name="newtableid"></param>
        /// <returns>int</returns>
        public static int TransferTable(int tableid,int newtableid)
        {

           using(TransactionScope ts=new TransactionScope())
            {

                int orderid=-1;

                using (BPDBEntities db=new BPDBEntities())
                try
                {

                        OrderSessions osses = db.OrderSessions.Where(x => x.Table_Id == tableid).FirstOrDefault();
                       orderid = osses.Order_Id;
                        Orders o = db.Orders.Where(x => x.Id == orderid).FirstOrDefault();
                        o.Table_Id = newtableid;
                        osses.Table_Id = newtableid;

                        db.SaveChanges();
                        ts.Complete();
                        return orderid;

                }

                catch(Exception ex)
                {
                        return orderid;
                }
            }

        }

        public static async Task<bool> TransferTableToUser(string currentuser, string transferuser)
        {
            using (TransactionScope ts = new TransactionScope())
            {

                using (BPDBEntities db = new BPDBEntities())
                    try
                    {


                        var sessions = db.OrderSessions.Where(x => x.User_Id == currentuser).ToList();
                        var openordersIDs = sessions.Select(x => x.Order_Id).ToList();
                        sessions.ForEach(x => x.User_Id = transferuser);

                        var orders = db.Orders.Where(x => openordersIDs.Contains(x.Id)).ToList();
                        orders.ForEach(x => x.User_Id = transferuser);


                        //prepare a list of transfertables
                        List<TransferWaiterViewModel> lista = new List<TransferWaiterViewModel>();

                        foreach (var item in orders)
                        {
                            lista.Add(new TransferWaiterViewModel { Local_Id = item.Id, Table_Id = item.Tables.OnLineId, User_Id = transferuser });
                        }

                      
                        db.SaveChanges();
                        ts.Complete();


                        return true;



                    }

                    catch (Exception ex)
                    {

                        ts.Dispose();
                        return false;
                    }
            }

        }


        public static bool AddTable(TavolineModel t)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    Tables table = new Tables();
                    table.Number = t.Number;
                    table.Place_Id = 1;
                    table.POS_Id = RegisterData.POS_Id;
                    table.IsItemActive = true;
                    table.OnLineId = t.OnlineId;
                    db.Tables.Add(table);
                    
                    db.SaveChanges();
                 
                    return true;

                }

                catch (Exception ex)
                {
                    return false;
                }
        }

        public static bool EditTable(TavolineModel t)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    var edittable = db.Tables.Where(x => x.Id == t.Id).FirstOrDefault();
                    edittable.Number = t.Number;
                
                    db.SaveChanges();

                    return true;

                }

                catch (Exception ex)
                {
                    return false;
                }

        }

        public static bool DeleteTable(TavolineModel t)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    var edittable = db.Tables.Where(x => x.Id == t.Id).FirstOrDefault();
                    edittable.IsItemActive = false;

                    db.SaveChanges();

                    return true;

                }

                catch (Exception ex)
                {
                    return false;
                }

        }


        //funksionet per shtimin e tabelava nga serveri

        public static bool AddTableFromServer(WaiterTableViewModel t)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    if(db.Tables.Where(x=>x.OnLineId==t.Id).Any())
                    {

                            return false;
                    }


                    Tables table = new Tables();
                    table.Number = t.Number;
                    table.Place_Id = 1;
                    table.POS_Id = t.POS_Id;
                    table.IsItemActive = true;
                    table.OnLineId = t.Id;
                    db.Tables.Add(table);

                    db.SaveChanges();

                    return true;

                }

                catch (Exception ex)
                {
                    return false;
                }
        }
        //add table in startup
        public static bool AddTableFromServerInStartup(TableSyncViewModel t)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    if (db.Tables.Where(x => x.OnLineId == t.Id).Any())
                    {

                        return false;
                    }


                    Tables table = new Tables();
                    table.Number = t.Number;
                    table.Place_Id = 1;
                    table.IsItemActive =t.Is_Active;
                    table.OnLineId = t.Id;
                    table.POS_Id = RegisterData.POS_Id;
                    db.Tables.Add(table);

                    db.SaveChanges();

                    return true;

                }

                catch (Exception ex)
                {

                    log.Error("Fail to Insert Tavolina from server ! " + ex.Message.ToString());
                    return false;
                }
        }

        public static bool EditTableFromServer(WaiterTableViewModel t)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    var edittable = db.Tables.Where(x => x.OnLineId == t.Id).FirstOrDefault();
                    edittable.Number = t.Number;
                    edittable.POS_Id = RegisterData.POS_Id;
                    db.SaveChanges();

                    return true;

                }

                catch (Exception ex)
                {
                    log.Error("Fail to edit Tavolina from server ! " + ex.Message.ToString());
                    return false;
                }

        }

        public static bool DeleteTableFromServer(WaiterTableViewModel t)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    var edittable = db.Tables.Where(x => x.OnLineId == t.Id).FirstOrDefault();
                    edittable.IsItemActive = false;

                    db.SaveChanges();

                    return true;

                }

                catch (Exception ex)
                {
                    log.Error("Fail to edit Tavolina from server ! " + ex.Message.ToString());
                    return false;
                }

        }

        public static TavolineModel GetTable(int id)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                   
                    var dbtable= db.Tables.Where(x => x.Id == id).FirstOrDefault();
                    TavolineEditModel t = new TavolineEditModel {Id=dbtable.Id,Number=dbtable.Number,OnlineId=dbtable.OnLineId };

                    return t;
                }

                catch (Exception ex)
                {
                    return new TavolineEditModel();
                }
        }


        //get table for mobile


        public static List<TableMobile> getTableForMobile()
        {
            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {

                    List<TableMobile> l = new List<TableMobile>();
                    var temp = db.Tables.Where(X => X.IsItemActive == true).ToList();

                    foreach (var x in temp)
                    {
                        bool open = false;
                        if (x.OrderSessions.Count > 0)
                        {
                            open = true;
                        }
                        var useridl = x.OrderSessions.Select(y => y.User_Id).ToList();

                        string UserId = "";
                        if (useridl.Count > 0)
                        {
                            UserId = useridl[0].ToString();
                        }
                        //tableid,number tavoline,indeksi ne nderfaqe ,eshte e hapur apo e mbyllur ,perdorues id
                       

                        l.Add(new TableMobile {id=x.Id,tablenumber=x.Number, isopen=open,  userid=UserId, onlineid=x.OnLineId });

                    }

                    return l;


                }


            }

            catch (Exception e)
            {
                return new List<TableMobile>();

            }
        }

    }

}
