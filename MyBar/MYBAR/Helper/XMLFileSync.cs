using MYBAR.Model;
using MYBAR.Model.SyncModel;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MYBAR.Helper
{
  public  class XMLFileSync
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string FilePath = @"NotSyncedIDS.xml";
        private static XElement ALLDATA { get; set; }

        // syncLock object, used to lock the code block
        private static object syncLock = new object();

        public static void  LoadSyncFile()
        {

            var xmlStr = File.ReadAllText(FilePath);


            ALLDATA = XElement.Parse(xmlStr);
        } 

        public static void SaveDoc()
        {
            lock (syncLock)
            {
                ALLDATA.Save(FilePath);
            }

        }

        public static string  getAllData()
        {
            return ALLDATA.ToString();
        }

        public  static void DeleteALLOrder()
        {
            var list = XMLFileSync.ALLDATA.Element(XMLElementTypes.ORDERS).Elements(XMLElementTypes.ORDER).ToList();



            foreach (var node in list)
                node.Remove();
            SaveDoc();
        }

        public static List<int> GetNeworderID()
        {
           
            var xmlStr = File.ReadAllText(FilePath);
           var stream= File.Open(FilePath,FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            
            var str = XElement.Parse(xmlStr);
            
            return   str.Element(XMLElementTypes.ORDER).Elements().Select(x=>x.Value).ToList().Select(int.Parse).ToList();

        }

     

        public static void AddNewOrder(string id)
        {


            lock (syncLock)
            {
                var isinList = ALLDATA.Element(XMLElementTypes.ORDERS).Elements().Where(x => x.Attribute("ID").Value == id).Any();

                if (isinList)
                {

                    return;
                }

                var result = ALLDATA.Element(XMLElementTypes.ORDERS);


                var neworder = new XElement(XMLElementTypes.ORDER, new XAttribute("ID", id), new XAttribute("TYPE", "new"));
                var newKey = new XElement(XMLElementTypes.NEWORDER);
                neworder.Add(newKey);

                result.Add(neworder);
            }
                SaveDoc();
            
          
        }
        public static void AddSaveAndCloseOrder(string id,string tableid)
        {
            lock (syncLock)
            {
                var isinList = ALLDATA.Element(XMLElementTypes.ORDERS).Elements().Where(x => x.Attribute("ID").Value == id).Any();

                if (isinList)
                {

                    return;
                }

                var result = ALLDATA.Element(XMLElementTypes.ORDERS);


                var neworder = new XElement(XMLElementTypes.ORDER, new XAttribute("ID", id), new XAttribute("TYPE", "new"));
                var newKey = new XElement(XMLElementTypes.NEWORDER);
                neworder.Add(newKey);
               
                neworder.Add(new XElement(XMLElementTypes.CLOSEORDER, new XAttribute("TABLEID", tableid)));

                result.Add(neworder);
            }
            SaveDoc();
        }

       public static void UpdateOrder(int orderId,List<int> listaMeId)
        {

            lock (syncLock)
            {
                var IsInList = ALLDATA.Element(XMLElementTypes.ORDERS).Elements(XMLElementTypes.ORDER).Where(x => x.Attribute("ID").Value == orderId.ToString() && x.Attribute("TYPE").Value == "new").Any();

                if (IsInList)
                {

                    return;
                }


                var IsInList2 = ALLDATA.Element(XMLElementTypes.ORDERS).Elements(XMLElementTypes.ORDER).Where(x => x.Attribute("ID").Value == orderId.ToString() && x.Attribute("TYPE").Value == "edit").Any();

                if (IsInList2)
                {
                    var element = ALLDATA.Element(XMLElementTypes.ORDERS).Elements().Where(x => x.Attribute("ID").Value == orderId.ToString()).FirstOrDefault();
                    foreach (var item in listaMeId)
                    {

                        var newelid = new XElement(XMLElementTypes.MENUITEM, item);
                        element.Element(XMLElementTypes.EDITORDER).Add(newelid);

                    }
                }
                else
                {
                    var result = ALLDATA.Element(XMLElementTypes.ORDERS);



                    var neworder = new XElement(XMLElementTypes.ORDER, new XAttribute("ID", orderId), new XAttribute("TYPE", "edit"));
                    var editKey = new XElement(XMLElementTypes.EDITORDER);

                    foreach (var item in listaMeId)
                    {

                        var newelid = new XElement(XMLElementTypes.MENUITEM, item);
                        editKey.Add(newelid);

                    }
                    neworder.Add(editKey);

                    result.Add(neworder);
                }
            }

            SaveDoc();

        }


        public static void addCloseTable(int orderId,int tableid)
        {

            

            lock (syncLock)
            {
                var IsInList = ALLDATA.Element(XMLElementTypes.ORDERS).Elements(XMLElementTypes.ORDER).Where(x => x.Attribute("ID").Value == orderId.ToString()).Any();

                if (IsInList)
                {
                    var order = ALLDATA.Element(XMLElementTypes.ORDERS).Elements(XMLElementTypes.ORDER).Where(x => x.Attribute("ID").Value == orderId.ToString()).FirstOrDefault();
                    if (order.Elements(XMLElementTypes.CLOSEORDER).ToList().Count < 1)
                    {
                        order.Add(new XElement(XMLElementTypes.CLOSEORDER, new XAttribute("TABLEID", tableid)));
                        SaveDoc();
                    }


                }
                else
                {
                    var result = ALLDATA.Element(XMLElementTypes.ORDERS);

                    var CLOSEorder = new XElement(XMLElementTypes.ORDER, new XAttribute("ID", orderId));

                    CLOSEorder.Add(new XElement(XMLElementTypes.CLOSEORDER, new XAttribute("TABLEID", tableid)));

                    result.Add(CLOSEorder);
                    SaveDoc();
                }

               
            }


        }
        public static void RemoveORDERIFSYNCISOK(string element,string value)
        {



            lock (syncLock)
            {

                var list = ALLDATA.Element(XMLElementTypes.ORDERS).Elements(XMLElementTypes.ORDER).Where(x => x.Attribute("ID").Value.ToString().Equals(value)).ToList();



                foreach (var node in list)
                    node.Remove();


            }

        }

        public static void RemoveifReportIsSynced(int reportdid)
        {
            lock (syncLock)
            {
                var list = ALLDATA.Element(XMLElementTypes.USERREPORT).Elements(XMLElementTypes.REPORT).Where(x => x.Attribute("ID").Value.ToString() == reportdid.ToString()).ToList();

                foreach (var node in list)
                    node.Remove();
            }

        }

        //add new cancel requests

         public static   void addCancelRequest(int orderId,string USERid,string notes)
        {
           

            var IsInList = ALLDATA.Element(XMLElementTypes.CANCELORDER).Elements(XMLElementTypes.ORDER).Where(x => x.Attribute("ID").Value == orderId.ToString()).Any();

            if (IsInList)
            {
                return;
            }

            var result = ALLDATA.Element(XMLElementTypes.CANCELORDER);


            var cancelreqorder = new XElement(XMLElementTypes.ORDER, new XAttribute("ID", orderId),new XAttribute("USERID",USERid),new XAttribute("NOTES",notes));
            result.Add(cancelreqorder);
          ALLDATA.Save(FilePath);

        } 

        /// <summary>
        /// ADD A NEW REPORT
        /// </summary>
        /// 
        public static void AddReport(int id)
        {
          

            var IsInList = ALLDATA.Element(XMLElementTypes.USERREPORT).Elements(XMLElementTypes.REPORT).Where(x => x.Attribute("ID").Value == id.ToString()).Any();

            if (IsInList)
            {
                return;
            }

            var result = ALLDATA.Element(XMLElementTypes.USERREPORT);


            var cancelreqorder = new XElement(XMLElementTypes.REPORT, new XAttribute("ID", id));
          
            result.Add(cancelreqorder);
            SaveDoc();

        }

        /// <summary>
        ///     Add transfer  Tuple;; orderid,tableid,userid
        /// </summary>
        /// <param name=""></param>
        public static void AddTransferToUser(List<Tuple<int,int,string>> list)
        {
            
           

          

            var result = ALLDATA.Element(XMLElementTypes.TRANSFER_ROOT);

            foreach (var  item in list)
            {
                var ROW = new XElement(XMLElementTypes.TRANSFER_ROW, new XAttribute("LOCALID", item.Item1), new XAttribute("TABLEID", item.Item2), new XAttribute("USERID", item.Item3));

                result.Add(ROW);
            }

            ALLDATA.Save(FilePath);
        }

        public static void RemoveTransferToUser()
        {
           



           
            var result = ALLDATA.Element(XMLElementTypes.TRANSFER_ROOT);

            result.Elements().Remove();
            SaveDoc();

        }


        /// <summary>
        /// ADD notification for later  syncing[ offline]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <param name="message"></param>

        public static void addNotification(int id,string userid,string message)
        {

          

           if(ALLDATA.Element(XMLElementTypes.NOTIFICATIONS).Elements().Any())
            {
                if (ALLDATA.Element(XMLElementTypes.NOTIFICATIONS).Elements(XMLElementTypes.NOTIFICATION).Where(x => x.Attribute("ID").Value == id.ToString()).Any())
                    return;


                
            }

            var element = new XElement(XMLElementTypes.NOTIFICATION, new XAttribute("ID", id), new XAttribute("USERID", userid), new XAttribute("MESSAGE", message));

            ALLDATA.Element(XMLElementTypes.NOTIFICATIONS).Add(element);

            ALLDATA.Save(FilePath);

        }

        public static  void RemoveNotification(int id)
        {
            
           
           var element= ALLDATA.Element(XMLElementTypes.NOTIFICATIONS).Elements(XMLElementTypes.NOTIFICATION).Where(x => x.Attribute("ID").Value == id.ToString()).FirstOrDefault();

            element.Remove();

            ALLDATA.Save(FilePath);
          
        }
             
        //add cancel localy 
        public static void AddLocalCancel(string userid,int localid)
        {
          

            if (ALLDATA.Element(XMLElementTypes.LOCALCANCEL).Elements().Where(x=>x.Attribute("LOCALID").Value==localid.ToString()).Any())
            {


                return;

            }

            var element = new XElement(XMLElementTypes.LOCALCANCELITEM, new XAttribute("LOCALID", localid), new XAttribute("USERID", userid));

            ALLDATA.Element(XMLElementTypes.LOCALCANCEL ).Add(element);

            ALLDATA.Save(FilePath);
        }

        public static void RemoveLocalCancel(int localid)
        {


            lock (syncLock)
            {
                var t = ALLDATA.Element(XMLElementTypes.LOCALCANCEL).Elements().Where(x => x.Attribute("LOCALID").Value == localid.ToString()).FirstOrDefault();

                if (t != null)
                {
                    t.Remove();
                }
            }
            SaveDoc();
        }
    //========================================syncing =================================================
        public static void SyncOrders()
        {


            lock (syncLock)
            {
                try
                {



                    var list = ALLDATA.Element(XMLElementTypes.ORDERS).Elements().ToList();

                    foreach (var item in list)
                    {


                        var id = int.Parse(item.Attribute("ID").Value);

                        var newkey = item.Element(XMLElementTypes.NEWORDER);
                        var editkey = item.Element(XMLElementTypes.EDITORDER);
                        var closekey = item.Element(XMLElementTypes.CLOSEORDER);

                        //save and close issue
                        if (newkey != null && closekey != null)
                        {
                            var orderid = id;
                            var tableid = int.Parse(closekey.Attribute("TABLEID").Value);

                            SyncingWorker.SaveAndCloseNotAsync(FatureService.getFatureByIdForTransferToServer(id), tableid, orderid);
                        }

                        else
                        {



                            if (newkey != null)
                            {
                                SyncingWorker.SyncOrderNoAsync(FatureService.getFatureByIdForTransferToServer(id));
                            }

                            if (editkey != null)
                            {

                                //GET ONLY Products that are added

                                var onlinelistId = editkey.Elements().Select(x => x.Value).ToList().Select(int.Parse).ToList();

                                SyncingWorker.UpdateOrderAsync(FatureService.getFatureByIdForTransferToServerUpdate(id, onlinelistId));

                            }

                            if (closekey != null)
                            {


                                var orderid = id;
                                var tableid = int.Parse(closekey.Attribute("TABLEID").Value);
                                SyncingWorker.CloseTableNotAsync(orderid, tableid);
                            }
                        }

                    }






                }
                catch (Exception e)
                {
                    log.Error("Cant read unsynced order from file !" + e.Message.ToString());
                }

                finally
                {

                }

            }


 
        }

        public static void SyncCancelRequest()
        {
          
            try
            {
               

                var list = ALLDATA.Element(XMLElementTypes.CANCELORDER).Elements().ToList();

                foreach (var item in list)
                {


                    var order = int.Parse(item.Attribute("ID").Value);
                    var userid = item.Attribute("USERID").Value.ToString();
                    var notes = item.Attribute("NOTES").Value.ToString();


                    SyncingWorker.RequestForCancelOrder(userid, order, RegisterData.Place_Id, notes);

                }

                ALLDATA.Element(XMLElementTypes.CANCELORDER).Elements().Remove();
              
     
               
            }

            catch
            {


            }
            finally
            {
                
            }

        }

        public static void SyncReport()
        {


            try
            {
         

                var list = ALLDATA.Element(XMLElementTypes.USERREPORT).Elements().ToList();
                
                foreach (var item in list)
                {




                    var id = int.Parse(item.Attribute("ID").Value.ToString());
                   

                    SyncingWorker.AddReport(FinanceService.MerTurnetSync(id));


                }

        
           
            }

            catch
            {
                log.Error("Cant read file for unsynced Reports");

            }
            finally
            {
            }


        }


        public static void SyncTableToUser()
        {

           
            try
            {
               

                var list = ALLDATA.Element(XMLElementTypes.TRANSFER_ROOT).Elements().ToList();
                var objlist = new List<TransferWaiterViewModel>();
                foreach (var item in list)
                {


                    var LOCALID = int.Parse(item.Attribute("LOCALID").Value.ToString());
                    var USERID = item.Attribute("USERID").Value.ToString();
                    var TABLEID = int.Parse(item.Attribute("TABLEID").Value.ToString());

                    objlist.Add(new TransferWaiterViewModel { Local_Id = LOCALID, Table_Id = TABLEID, User_Id = USERID });


                }


                if (SyncingWorker.TranserTableToUser(objlist).Result)
                {
                    RemoveTransferToUser();
                }
            }

            catch
            {


            }
            finally
            {
                
            }


        }

        public static async void SyncNotification()
        {

            try
            {
              

                var list = ALLDATA.Element(XMLElementTypes.NOTIFICATIONS).Elements().ToList();

                foreach (var item in list)
                {


                    var LOCALID = int.Parse(item.Attribute("ID").Value.ToString());
                    var USERID = item.Attribute("USERID").Value.ToString();
                    var message = item.Attribute("MESSAGE").Value.ToString();


                    //GET FROM DATABASE and sent to server

                 var ok=   await SyncingWorker.SendNotificationToServer(new WaiterNotificationViewModel { User_Id = USERID, Text = message }, LOCALID);
                    if (ok)
                    {
                        RemoveNotification(LOCALID);
                    }

                }



            }

            catch
            {


            }

            finally
            {
               
            }
        }


        public static void syncLocalCancel()
        {

            try
            {
               

                var list = ALLDATA.Element(XMLElementTypes.LOCALCANCEL).Elements().ToList();
             
                foreach (var item in list)
                {


                    var LOCALID = int.Parse(item.Attribute("LOCALID").Value.ToString());
                    var USERID = item.Attribute("USERID").Value.ToString();

                    var anullim = new ManagerOrderCancelViewModel { Order_Local_Id = LOCALID, User_Id = USERID,Place_Id=RegisterData.Place_Id };

                    if (SyncingWorker.AnulloNeServer(anullim).Result)
                     {


                        var itsOk = FatureService.AnulloFature(LOCALID);
                        OrderForCancellationService.DeleteOrderForCancellation(new OrderForCancellationModel { Id = LOCALID, OrderId = LOCALID });
                        FinanceService.CalculateXhiroDitore();

                        RemoveLocalCancel(LOCALID);
                    }

                }



               


               
            }

            catch
            {


            }

        }
    }

    public static class XMLElementTypes
    {
        public static string ORDERS = "ORDERS";
        public static string ORDER = "ORDER";

        public static string NEWORDER = "NEW";
        public static string EDITORDER = "EDIT";
        public static string CLOSEORDER = "CLOSE";
        public static string MENUITEM = "ITEM";
        public static string CANCELORDER = "CANCELORDERS";


        public static string USERREPORT = "USERREPORT";
        public static string REPORT = "REPORT";


        //transfer TABLE  AND ORDER TO OTHER USER 
        public static string TRANSFER_ROOT = "TRANSFER";
        public static string TRANSFER_ROW="TRANFERROW";

        public static string NOTIFICATIONS = "NOTIFICATIONS";
        public static string NOTIFICATION = "NOTIFICATION";

        public static string LOCALCANCEL = "LOCALCANCEL";
        public static string LOCALCANCELITEM = "LOCALCANCELITEM";





    }
}
