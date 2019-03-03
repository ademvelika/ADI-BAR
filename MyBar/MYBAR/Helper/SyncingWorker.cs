using MYBAR.Model.Artikuj;
using MYBAR.Model.Porosi;
using MYBAR.Model.SyncModel;
using MYBAR.Model.SyncModel.InventarySyncOnly;
using MYBAR.Model.SyncModel.IvoiceReceive;
using MYBAR.Model.SyncModel.StartUp;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MYBAR.Helper
{
    public class SyncingWorker
    {

        //logger construct
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly object _lock = new object();


        #region Data_To_Server


        public static void SyncOrderAsync(NewOrderViewModel model)
        {


            Thread th = new Thread(() => SyncOrderNoAsync(model));

            th.Start();
            

      

        }

        public static  void SyncOrderNoAsync(NewOrderViewModel model)
        {

            lock (_lock)
            {
                try
               {

           
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                    client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.PostAsJsonAsync("Orders/AddOrder", model).Result;






                    if (response.IsSuccessStatusCode)
                    {


                        //is ok,remove id from file if have one

                        XMLFileSync.RemoveORDERIFSYNCISOK(XMLElementTypes.ORDER, model.Local_Id.ToString());

                    }
                    else
                    {
                        //if something go wrog make 

                        XMLFileSync.AddNewOrder(model.Local_Id.ToString());

                        log.Error("Fail to send Order to server ,data is register in log with Id " + model.Local_Id + "http status=" + response.StatusCode);
                    }


                }
                catch (Exception e)
                {
                    XMLFileSync.AddNewOrder(model.Local_Id.ToString());


                }

            }
        }

     
        



        //update open Order
        public static void SyncUpdateOrder(NewOrderViewModel model)
        {


                Thread th = new Thread(() => UpdateOrderAsync(model));

                th.Start();

       
            

        }

        public static void UpdateOrderAsync(NewOrderViewModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("Orders/UpdateOrder", model).Result;


                if (response.IsSuccessStatusCode)
                {

                    XMLFileSync.RemoveORDERIFSYNCISOK("", model.Local_Id.ToString());

                }
                else
                {

                    var list = new List<int>();

                    foreach (var item in model.Items)
                    {
                        list.Add(item.Id);
                    }
                    XMLFileSync.UpdateOrder(model.Local_Id, list);

                    //if something go wrog make 
                    log.Error("Fail to Update Order to server,stored in log for later " +response.ToString());
                }
                

            }

            catch
            {


                var list = new List<int>();

                foreach (var item in model.Items)
                {
                    list.Add(item.Id);
                }
                XMLFileSync.UpdateOrder(model.Local_Id, list);

               
            }
 

      
        }
        public static IEnumerable<ClientOrderModel> getAllClientPorosi()
        {


            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync("orders/getall/" + RegisterData.Place_Id).Result;

                if (response.IsSuccessStatusCode)
                {

                    var clientOrders = response.Content.ReadAsAsync<IEnumerable<ClientOrderModel>>().Result;
                    //synced signal 

                    return clientOrders;
                }
                else
                {
                    //if something go wrog make 

                    return new List<ClientOrderModel>();
                }
            }
            catch
            {
                return new List<ClientOrderModel>();
            }

        }
        public static IEnumerable<ClientOrderDetailsModel> getClientPorosiDetails(int Id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));


            var response = client.GetAsync("orders/getorderdetails/"+Id).Result;

            if (response.IsSuccessStatusCode)
            {

                var clientOrders = response.Content.ReadAsAsync<IEnumerable<ClientOrderDetailsModel>>().Result;
                //synced signal 

                return clientOrders;
            }
            else
            {
                //if something go wrog make 

                return new List<ClientOrderDetailsModel>();
            }

        }

        //send new category to Server
        public async  static Task<int> AddCategory(MenuCategoriesModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                MenuCategorySyncViewModel category = new MenuCategorySyncViewModel { Local_Id = model.Id,POS_Id=RegisterData.POS_Id, Name = model.Name, Media_Id = 2, Place_Id = RegisterData.Place_Id };

                var response = client.PostAsJsonAsync("Products/AddCategory", category).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return Int32.Parse(returnValue.ToString());
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to send Category to Server !" +returnValue.ToString());
                    return 0;
                }

            }
            catch(Exception e)
            {
               
                return 0;
            }


        }
        //update category in server
        public static async Task<bool> UpdateCategory(MenuCategoriesModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                MenuCategorySyncViewModel category = new MenuCategorySyncViewModel { Id = model.Online_Id, Name = model.Name, Media_Id = 2, Place_Id = RegisterData.Place_Id, POS_Id = RegisterData.POS_Id };

                var response = client.PostAsJsonAsync("Products/EditCategory", category).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return true;
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to update Category to Server !" +returnValue.ToString());
                    return false;
                }

            }
            catch (Exception e)
            {

                return false;
            }


        }

        //delete Category In Server
        public static async Task<bool> DeleteCategory(MenuCategoriesModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                MenuCategorySyncViewModel category = new MenuCategorySyncViewModel { Id = model.Online_Id, Name = model.Name, Media_Id = 2, Place_Id = RegisterData.Place_Id, POS_Id = RegisterData.POS_Id };

                var response = client.PostAsJsonAsync("Products/DeleteCategory", category).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return true;
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to delete Category to Server !" +returnValue.ToString());
                    return false;
                }

            }
            catch (Exception e)
            {
                
                return false;
            }


        }

        //send a request for cancel order
        public static async void RequestForCancelOrder(string user_id, int orderId, int placeId, string Notes)
        {


            try
            {
                CancelOrderViewModel model = new CancelOrderViewModel {  Order_LocalId = orderId, User_Id = user_id,POS_Id=RegisterData.POS_Id, Notes = Notes };

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("orders/cancelrequest", model).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                }
                else
                {
                    //if something go wrog make 
                    log.Error("Send request for cancel order to Server with id " + orderId + "  !" + returnValue.ToString());
                }
            }
            catch(Exception e)
            {
                XMLFileSync.addCancelRequest(orderId, user_id, Notes);
               
            }
        }

        public static void CloseTable(int orderid,int tableId)
        {

            Thread th = new Thread(() =>
             {

                 CloseTableNotAsync(orderid, tableId);

             });

            th.Start();
           
        }

        public static void  CloseTableNotAsync(int orderid,int tableId)
        {

            lock (_lock)
            {
                try
                {


                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                    client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.PostAsJsonAsync("orders/CloseOrder", new { Local_Id = orderid, Table_Id = tableId }).Result;


                    if (response.IsSuccessStatusCode)
                    {
                        //synced signal

                        XMLFileSync.RemoveORDERIFSYNCISOK(XMLElementTypes.ORDER, orderid.ToString());

                    }
                    else
                    {
                        XMLFileSync.addCloseTable(orderid, tableId);

                        //if something go wrog make 
                        log.Error("Fail to Close Table  " + "[Table Id =" + tableId + "] ! response code " + response.StatusCode);

                    }



                }
                catch (Exception e)
                {
                    XMLFileSync.addCloseTable(orderid, tableId);


                }
            }
        }

        public static void TransferTable(int OrderId, int TableId, int TransferTableId)
        {
            Thread th = new Thread(async () =>
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                    client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.PostAsJsonAsync("orders/TransferTable", new TransferTableViewModel { Local_Id = OrderId, Table_Id = TableId, NewTable_Id = TransferTableId }).Result;

                    var returnValue = await response.Content.ReadAsAsync<object>();

                    if (response.IsSuccessStatusCode)
                    {
                        //synced signal



                    }
                    else
                    {
                        //if something go wrog make 

                        log.Error("Fail to transfer table to server "+returnValue.ToString());
                    }


                }
                catch
                {

                }

            });

            

        
        

            th.Start();

        }

        public static async Task<bool> TranserTableToUser(List<TransferWaiterViewModel> model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("orders/TransferWaiter", model).Result;

                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {

                    return true;
                }
                else
                {

                    log.Error("Fail to transfer a list of  table to server " + returnValue.ToString());
                    return false;
                }


            }

            catch (Exception e)
            {

                List<Tuple<int, int, string>> List = new List<Tuple<int, int, string>>();

                foreach (var item in model)
                {
                    List.Add(new Tuple<int, int, string>(item.Local_Id, item.Table_Id, item.User_Id));

                }


                XMLFileSync.AddTransferToUser(List);

                return false;

            }



        }

        //adding an new product
        public async static Task<int> AddProduct(ArtikullListRow model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                MenuItemSyncViewModel menuitem = new MenuItemSyncViewModel
                {
                    Name =model.Asortimenti,
                    Price =model.Cmimi,
                    Quantity =0,
                    MinQuantity =model.SasiaMinimale,
                    MenuCategory_Id =model.CategoryOnlineId,
                    POS_Id =RegisterData.POS_Id,
                    Unit_Id =model.UnitId,
                    MenuItemType_Id=model.TypeId
                  
                };
                if (model.TypeId == Constants.COMPOSED)
                {
                    List<ComposedMenuItem> l = new List<ComposedMenuItem>();
                    foreach (var item in model.GetIngredientList())
                    {
                        l.Add(new ComposedMenuItem { Parent_Id = model.ProduktId, Child_Id = item.OnlineProductid, Portion_Quantity = item.Sasi });

                    }

                    menuitem.ComposingItems = l;
                }

                var response = client.PostAsJsonAsync("Products/AddMenuItem", menuitem).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return Int32.Parse(returnValue.ToString());
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to Add a new Product To Server, product is not saved locally too  !" + returnValue.ToString());
                    return 0;
                }

            }
            catch(Exception e)
            {

               
                return 0;
            }


        }
        //update a product
        public static async Task<int> UpdateProduct(ArtikullListRow model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                MenuItemSyncViewModel menuitem = new MenuItemSyncViewModel { Id = model.OnlineProductid,
                    Name = model.Asortimenti,
                    Price = model.Cmimi,
                    Quantity = 0,
                    MinQuantity = model.SasiaMinimale,
                    MenuCategory_Id = model.CategoryOnlineId,
                    POS_Id = RegisterData.POS_Id ,
                    Unit_Id = model.UnitId,
                    MenuItemType_Id = model.TypeId
                };

                if (model.TypeId == Constants.COMPOSED)
                {
                    List<ComposedMenuItem> l = new List<ComposedMenuItem>();
                    foreach (var item in model.GetIngredientList())
                    {
                        l.Add(new ComposedMenuItem { Parent_Id = model.ProduktId, Child_Id = item.OnlineProductid, Portion_Quantity = item.Sasi });

                    }

                    menuitem.ComposingItems = l;
                }

                var response = client.PostAsJsonAsync("Products/EditMenuItem", menuitem).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return 1;
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to Update a new Product To Server, product is not updated locally too  !" + returnValue.ToString());
                    return 0;
                }

            }
            catch (Exception e)
            {


                return 0;
            }


        }
        //delete product in server 

        public static async Task<bool> DeleteProduct(ArtikullListRow model)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                MenuItemSyncViewModel menuitem = new MenuItemSyncViewModel { Id = model.OnlineProductid,
                    Name = model.Asortimenti,
                    Price = model.Cmimi,
                    Quantity = 0,
                    MinQuantity = model.SasiaMinimale,
                    MenuCategory_Id = model.CategoryOnlineId,
                    POS_Id = RegisterData.POS_Id ,
                    Unit_Id = model.UnitId,
                    MenuItemType_Id = model.TypeId
                };

                var response = client.PostAsJsonAsync("Products/DeleteMenuItem", menuitem).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return true;
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to delete a  Product To Server, product is not deleted locally too  !" +returnValue.ToString());
                    return false;
                }

            }
            catch (Exception e)
            {

               
                return false;
            }
        }

        //add a Table in Server 
        public async static Task<int> AddTable(WaiterTableViewModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

              

                var response = client.PostAsJsonAsync("Tables/AddTable", model).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return Int32.Parse(returnValue.ToString());
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to Add a new Table To Server, table is not saved locally too  !" + returnValue.ToString());
                    return 0;
                }

            }
            catch(Exception e)
            {
               
                return 0;
            }


        }

        //update Table to Server
        public static async Task<int> EditTable(WaiterTableViewModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));



                var response = client.PostAsJsonAsync("Tables/EditTable", model).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return 1;
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to edit a  Table To Server, table is not saved locally too  !" + returnValue.ToString());
                    return 0;
                }

            }
            catch (Exception e)
            {
                
                return 0;
            }


        }

        //delete Table to Server

        public static async Task<int> DeleteTable(WaiterTableViewModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));



                var response = client.PostAsJsonAsync("Tables/DeleteTable", model).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return 1;
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to delete a table To Server, table is not deleted locally too  !" + returnValue.ToString());
                    return 0;
                }

            }
            catch (Exception e)
            {


                return 0;
            }
        }

        

        //sinkronizimi i fatures se hyrjes 

        public async static Task<int> AddFatureHyrje(WaiterInvoiceViewModel model)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));



                var response = client.PostAsJsonAsync("Invoices/AddInvoice", model).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    return Int32.Parse(returnValue.ToString());
                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fature Hyrje is send to server , but an error occured !" + returnValue.ToString());
                    return 0;
                }

            }
            catch(Exception e)
            {

                
                return 0;
            }


        }

        //shtimi i raporteve ne server asinkron,kur ka internet
        public static void AddReportAsync(NewReportViewModel report)
        {
            Thread th = new Thread(() => AddReport(report));

            th.Start();
        }

        //sinkronizimi i raportit[turnit]
        public static async void AddReport(NewReportViewModel report)
        {



            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));



                var response = client.PostAsJsonAsync("Reports/AddReport", report).Result;
                var returnValue1 = await response.Content.ReadAsAsync<object>();
                
                if (response.IsSuccessStatusCode)
                {
                    //synced signal 

                    XMLFileSync.RemoveifReportIsSynced(report.Id);
                }
                else
                {
                    //if something go wrog make 

                    log.Error("Fail to send a report to server saved in log !" + "e1=>" + returnValue1.ToString()+"http status="+response.StatusCode);

                   
                        XMLFileSync.AddReport(report.Id);
                    
                }

            }
            catch (Exception e)
            {
                //no iternet  

                XMLFileSync.AddReport(report.Id);

            }

        }

        //ndryshimi i statusin klient order pas pranimit ose mos pranimit nga kamarieri
        public static async Task<bool> ChangeStatusClientOrder(UpdateClientOrderViewModel model)
        {




            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("Orders/UpdateClientOrder", model).Result;
                var returnValue = await response.Content.ReadAsAsync<object>();

                if (response.IsSuccessStatusCode)
                {

                    return true;
                    //is ok,remove id from file if have one

                    // XMLFileSync.RemoveFromXMLFile(XMLElementTypes.ORDER,model.Local_Id.ToString());

                }
                else
                {
                    //if something go wrog make 
                    log.Error("Can not Chnge status for order: "+model.ClientOrder_Id+"["+returnValue.ToString());
                    return false;
                }


            }
            catch (Exception e)
            {
                return false;
            }





        }


        //add notification to server

        public static async Task<bool> SendNotificationToServer(WaiterNotificationViewModel model, int localid)
        {




            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));
                model.Place_Id = RegisterData.Place_Id;

                var response = client.PostAsJsonAsync("Notifications/Add", model).Result;

                var returnValue1 = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {

                    return true;
                    //is ok,remove id from file if have one

                    // XMLFileSync.RemoveFromXMLFile(XMLElementTypes.ORDER,model.Local_Id.ToString());

                }
                else
                {
                    //if something go wrog make 
                    log.Error("Fail to Send Notification to server !" + returnValue1.ToString());
                    return false;
                }


            }
            catch (Exception e)
            {

                XMLFileSync.addNotification(localid, model.User_Id, model.Text);

                return false;
            }





        }

        //not used 
        public async static Task<bool> AnulloNeServer (ManagerOrderCancelViewModel model)
        {
          try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));
         

                var response = client.PostAsJsonAsync("Orders/CancelOrder", model).Result;

                var returnValue = await response.Content.ReadAsAsync<object>();
                if (response.IsSuccessStatusCode)
                {
                    return true;
             
                    //is ok,remove id from file if have one

                    // XMLFileSync.RemoveFromXMLFile(XMLElementTypes.ORDER,model.Local_Id.ToString());

                }
                else
                {
                    log.Error("Fail to Cancel Order from Desktop App with number " + model.Order_Local_Id + " !"+returnValue.ToString());
                    //if something go wrog make 

                    XMLFileSync.RemoveLocalCancel(model.Order_Local_Id);
                    return false;
                }


            }
            catch (Exception e)
            {
                XMLFileSync.AddLocalCancel(model.User_Id, model.Order_Local_Id);
                //when fail store localy
                return false;
            }





        }


        public static bool SaveAndClose(NewOrderViewModel model,int tableid,int orderid)
        {

            Thread th = new Thread(() => SaveAndCloseNotAsync(model, tableid, orderid));
              


                  


            

            th.Start();

            return true;

        }

        public static void SaveAndCloseNotAsync(NewOrderViewModel model, int tableid, int orderid)
        {
            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("Orders/AddOrderAndClose", model).Result;

                if (response.IsSuccessStatusCode)
                {


                    //is ok,remove id from file if have one

                    XMLFileSync.RemoveORDERIFSYNCISOK(XMLElementTypes.ORDER, model.Local_Id.ToString());

                }
                else
                {
                    //if something go wrog make 

                    XMLFileSync.AddSaveAndCloseOrder(model.Local_Id.ToString(), tableid.ToString());

                    log.Error("Fail to send Order to server ,data is register in log with Id " + model.Local_Id + "http status=" + response.StatusCode);
                }


            }
            catch (Exception e)
            {
                XMLFileSync.AddSaveAndCloseOrder(model.Local_Id.ToString(), tableid.ToString());


            }

        }


        #endregion


        #region Data_From_Server

        //=================================================From Server To Me=============================================
        public static void SyncAllObjectsFromServer()
        {

            Thread th = new Thread( () =>
              {
                  List<int> ListOfIdToDeleteInServer = new List<int>();
                  try
                  {
                      HttpClient client = new HttpClient();
                      client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                      client.DefaultRequestHeaders.Accept.Add(
                         new MediaTypeWithQualityHeaderValue("application/json"));


                      var response = client.GetAsync("sync/get/" + RegisterData.POS_Id).Result;
                     // var returnValue = await response.Content.ReadAsAsync<object>();
                      
                      if (response.IsSuccessStatusCode)
                      {

                          var dataSynced = response.Content.ReadAsAsync<SyncViewModel>().Result;





                          //veprimet me userat
                          foreach (var item in dataSynced.Users)
                          {



                              int veprim = item.Item1.SyncType;
                              ListOfIdToDeleteInServer.Add(item.Item1.SyncId);

                              if (veprim == 1)
                              {
                                  //insert

                                  UserService.InsertUserFromServer(item.Item2);

                              }
                              else if (veprim == 2)
                              {
                                  //update

                                  UserService.UpdateUserFromServer(item.Item2);
                              }

                              else if (veprim == 3)
                              {
                                  //delete

                                  UserService.DeleteUserFromServer(item.Item2);
                              }

                          }





                          //veprimet me kategorite
                          foreach (var item in dataSynced.MenuCategories)
                          {



                              int veprim = item.Item1.SyncType;
                              ListOfIdToDeleteInServer.Add(item.Item1.SyncId);

                              if (veprim == 1)
                              {
                                  //insert

                                  ArtikullService.InsertMenuCategoriesFromServer(item.Item2);

                              }
                              else if (veprim == 2)
                              {
                                  //update

                                  ArtikullService.UpdateMenuCategoriesFromServer(item.Item2);
                              }

                              else if (veprim == 3)
                              {
                                  //delete

                                  ArtikullService.DeleteMenuCategoriesFromServer(item.Item2);
                              }










                          }

                          //veprimet me tableat
                          foreach (var item in dataSynced.Tables)
                          {


                              int veprim = item.Item1.SyncType;
                              ListOfIdToDeleteInServer.Add(item.Item1.SyncId);

                              if (veprim == 1)
                              {
                                  //insert

                                  TavolinaService.AddTableFromServer(item.Item2);

                              }
                              else if (veprim == 2)
                              {
                                  //update

                                  TavolinaService.EditTableFromServer(item.Item2);
                              }

                              else if (veprim == 3)
                              {
                                  //delete

                                  TavolinaService.DeleteTableFromServer(item.Item2);
                              }

                          }



                          //veprimet me Produktet
                          foreach (var item in dataSynced.MenuItems)
                          {

                              int veprim = item.Item1.SyncType;
                              ListOfIdToDeleteInServer.Add(item.Item1.SyncId);

                              if (veprim == 1)
                              {
                                  //insert

                                  ArtikullService.InsertNewProductFromServer(item.Item2);

                              }
                              else if (veprim == 2)
                              {
                                  //update

                                  ArtikullService.UpdateProductFromServer(item.Item2);


                              }

                              else if (veprim == 3)
                              {
                                  //delete

                                  ArtikullService.DeleteProductFromServer(item.Item2);
                              }

                          }



                          //veprimet me faturen e hyrjes

                          foreach (var item in dataSynced.Invoices)
                          {
                              ListOfIdToDeleteInServer.Add(item.Item1.SyncId);
                              var modli = FatureService.PrepareFatureHyrjeFromServer(item.Item2);

                              if (modli != null)
                                  FatureService.SaveFatureHyrjeFromServer(modli);

                          }


                          //anullimet e faturave


                          foreach (var item in dataSynced.Orders)
                          {
                              var itsOk = FatureService.AnulloFature(item.Item2.Local_Id);
                              OrderForCancellationService.DeleteOrderForCancellation(new OrderForCancellationModel { OrderId = item.Item2.Local_Id });
                              ListOfIdToDeleteInServer.Add(item.Item1.SyncId);
                          }


                          //update e info te banakut

                          foreach (var pos in dataSynced.POSes)
                          {
                              if (pos.Item2.Id == RegisterData.POS_Id)
                              {
                                  BackgroundWorker.UpdatePOSData(pos.Item2.Name, pos.Item2.IsActive);

                                  ListOfIdToDeleteInServer.Add(pos.Item1.SyncId);
                              }
                          }

                          SyncingWorker.SyncOnlyInventary();


                          
                          //detete object in server


                          var responsedeletete = client.PostAsJsonAsync("Sync/Delete", ListOfIdToDeleteInServer).Result;

                          if (responsedeletete.IsSuccessStatusCode)
                          {

                          }


                      }
                      else
                      {
                          //if something go wrog make 

                          //  log.Error("Error  in syncing from server  " + returnValue.ToString());
                      }
                  }
                  catch (Exception E)
                  {
                      log.Error("Error in data Inserting in DataBase locally" + E.Message.ToString());
                  }


              });

            th.Start();

            

        }

        #endregion


        #region Startup_First_Time

        public static async Task<bool> SyncFirstTime(string PlaceKey)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));



                //dergojme kerkesen me place ket dhe me mac adresen e kompjuterin lokal

                RequestAccessViewModel request = new RequestAccessViewModel { POSKey =new Guid(PlaceKey), MacAddress = BackgroundWorker.GetMACAdress() };
                var response = client.PostAsJsonAsync("request/get", request).Result;
                var key = await response.Content.ReadAsAsync<object>();




                if (response.IsSuccessStatusCode)
                {
                    //key value

                    //StartupRequestViewModel startupRequest = new StartupRequestViewModel { RequestKey = new Guid(key), PlaceKey = RegisterData.PlaceKey };
                    var queryStrig = "?RequestKey=" + key.ToString() + "&POSKey=" + PlaceKey.ToString();
                    response = client.GetAsync("Startup/get"+queryStrig).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var dataSynced = response.Content.ReadAsAsync<StartupViewModel>().Result;

                        //important !!!!!!!!  data will storetd in register
                        RegisterData.Place_Id = dataSynced.Place.Id;
                        RegisterData.POS_Id = dataSynced.POS.Id;
                        RegisterData.PosName = dataSynced.POS.Name;
                        RegisterData.IsActive = true;

                        //save  in register
                        BackgroundWorker.LoadRegister();

                        FatureInfoService.UpdateInfo(dataSynced.Place.Name, dataSynced.Place.Name, null);

                        //set start identity for orders
                        int kufi;
                        int kufiafterload=0;
                        if (dataSynced.Orders.Count > 0)
                        {
                            kufi = dataSynced.Orders.Select(x => x.Local_Id).Min();
                            kufiafterload = dataSynced.Orders.Select(x => x.Local_Id).Max();
                        }
                        else
                        {
                            kufi = 1;
                        }

                        FatureService.STARTIDORDER(kufi);

                        foreach (var item in dataSynced.Users)
                        {
                            UserService.InsertUserFromServer(item);
                        }


                        var ALLArtikuj = new List<MenuItemSyncViewModel>();
                        foreach (var item in dataSynced.Products)
                        {
                            ArtikullService.InsertMenuCategoriesFromServerInStartup(item);
                            foreach (var prod in item.MenuItems)
                            {
                                ALLArtikuj.Add(prod);
                            }
                        }

                          //insert simple  or ingredients,after this insert composed because composed require simple localid
                            foreach (var prod in ALLArtikuj.Where(x => x.MenuItemType_Id != Constants.COMPOSED))
                            {
                                ArtikullService.InsertNewProductFromServerInStartUp(prod);
                            }
                            foreach (var prod in ALLArtikuj.Where(x => x.MenuItemType_Id == Constants.COMPOSED).OrderBy(x=>x.Id))
                            {
                                ArtikullService.InsertNewProductComposedFromServerInStartUp(prod);
                            }
                        

                        


                        foreach (var table in dataSynced.Tables)
                        {

                            TavolinaService.AddTableFromServerInStartup(table);
                        }



                        List<Tuple<object, DateTime>> ListaINvoice_Order = new List<Tuple<object, DateTime>>();

                        foreach (var invoice in dataSynced.Invoices)
                        {
                            ListaINvoice_Order.Add(new Tuple<object, DateTime>(invoice, invoice.Date));
                          
                            
                        }


                        foreach (var order in dataSynced.Orders)
                        {


                            ListaINvoice_Order.Add(new Tuple<object, DateTime>(order, order.OperationTime));
                            
                        }

                       
                        ListaINvoice_Order = ListaINvoice_Order.OrderBy(x => x.Item2).ToList();


                        foreach (var item in ListaINvoice_Order)
                        {

                            var obj = item.Item1 as InvoiceSyncViewModel;
                            if(obj==null)
                            {
                              var  obj1 = item.Item1 as OrderStartViewModel;
                                  var id=FatureService.InsertOrdersFromServerInStartup(obj1);
                                  if(obj1.OrderStatus_Id==13)
                                {
                                    FatureService.AnulloFature(id);
                                }
                            }
                            else
                            {
                                FatureService.SaveFatureHyrjeFromServer(FatureService.PrepareFatureHyrjeFromServer(obj));
                            }


                        }

                        FatureService.STARTIDORDER(kufiafterload);

                        FinanceService.InsertNewReportFromServer(dataSynced.Reports);

                        log.Info("Register process and data import completed succssesfully!!!!!");
                        return true;


                    }

                    else
                    {


                        log.Error("Fail to get key from server ");
                        return false;
                    }

                }
                else
                {
                    log.Error("Fail to Send a Request for register ");
                    return false;
                }

            }

            catch(Exception ex)
            {
                log.Error("Fail to Retreive data from server " + ex.Message.ToString());

                return false;
            }

        }
        #endregion


        #region SyncOnlyInventary

        public static void SyncOnlyInventary()
        {
            Thread th = new Thread(() =>
            {
                List<int> ListOfIdToDeleteInServer = new List<int>();
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                    client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.GetAsync("InventorySync/Get/" + RegisterData.POS_Id).Result;

                    if (response.IsSuccessStatusCode)
                    {

                        var dataSynced = response.Content.ReadAsAsync<InventorySyncViewModel>().Result;

                        foreach (var item in dataSynced.Syncs)
                        {

                            //add or remove sasi

                            FinanceService.AddInventaryStatic(item);
                            ListOfIdToDeleteInServer.Add(item.Id);

                        }
                            




                        var responsedeletete = client.PostAsJsonAsync("InventorySync/Delete", ListOfIdToDeleteInServer).Result;

                        if (responsedeletete.IsSuccessStatusCode)
                        {

                        }


                    }
                    else
                    {
                        //if something go wrog make 


                    }
                }
                catch (Exception E)
                {

                }

            });

            th.Start();
        }


        #endregion


        #region check_version

        public static string CheckVersion()
        {


            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://update.out-guide.com/Api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync("Update").Result;

                if (response.IsSuccessStatusCode)
                {

                    var version = response.Content.ReadAsAsync<string>().Result;
                    //synced signal 

                    return version;
                }
                else
                {
                    //if something go wrog make 

                    return "NO_INTERNET";
                }
            }
            catch(Exception e)
            {
                return "NO_INTERNET";
            }

        }

        public static void GetOrderShowTypes()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync("POS/GetOrdersStatus/"+RegisterData.POS_Id).Result;

                if (response.IsSuccessStatusCode)
                {

                    var answer = response.Content.ReadAsAsync<bool>().Result;
                    //synced signal 

                    var value = "0";
                    if (answer==false)
                    {
                        RegisterData.ShowAllBillTypes = false;
                    }
                    else
                    {
                        value = "1";
                        RegisterData.ShowAllBillTypes = true;
                    }

                    BackgroundWorker.UpdateConfigKey("JOKE", value);
                }
                else
                {
                    //if something go wrog make 

                 
                }
            }
            catch
            {
               
            }
        }

        public static bool SendUpdateConfirm(string  Newversion,string oldver)
        {


            POSINFO p=new POSINFO { ID=RegisterData.POS_Id,Name=RegisterData.PosName,newversion=Newversion,oldVersion=oldver};

            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://update.out-guide.com/Api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));
             

                var response = client.PostAsJsonAsync("Update", p).Result;

             if(response.IsSuccessStatusCode)
                {

                    return true;
                    //is ok,remove id from file if have one

                    // XMLFileSync.RemoveFromXMLFile(XMLElementTypes.ORDER,model.Local_Id.ToString());

                }
                else
                {
                    //if something go wrog make 
                  
                    return false;
                }


            }
            catch 
            {

           
                return false;
            }





        }
        #endregion



        public static bool ChangePassword(string userid, string oldpass,string newpassword)
        {


            PasswordResetViewModel p = new PasswordResetViewModel {User_Id=userid,Old_Password=oldpass,New_Password=newpassword ,POS_Id=RegisterData.POS_Id};

            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.PostAsJsonAsync("Waiters/ResetPassword", p).Result;

                if (response.IsSuccessStatusCode)
                {

                    return true;
                    //is ok,remove id from file if have one

                    // XMLFileSync.RemoveFromXMLFile(XMLElementTypes.ORDER,model.Local_Id.ToString());

                }
                else
                {
                    //if something go wrog make 

                    return false;
                }


            }
            catch
            {


                return false;
            }





        }

        public static async void TestKorrogjo( CollectViewModel collectid)
        {



            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://out-guide.com/waiter/api/");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));



               
                var response2 = client.PostAsJsonAsync("Reports/CollectOrders", collectid).Result;
                var returnValue2 = await response2.Content.ReadAsAsync<object>();
                if (response2.IsSuccessStatusCode)
                {
                    //synced signal 

                }
                else
                {
                    //if something go wrog make 

                 
                }

            }
            catch (Exception e)
            {
                //no iternet  

               

            }

        }
    }
}
