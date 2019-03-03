using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Raports;
using MYBAR.Services;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MYBAR.Mobile
{
   public  class MobileSyncer
    {

        public static List<FatureRow> GLOBAL_PRODUCTS;

        public MobileSyncer()
        {



            string url = "http://*:8080";
            GLOBAL_PRODUCTS = new List<FatureRow>();
            try

            {

                using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(url))
                {

                    Thread mthread = new Thread(() =>
                    {

                        GLOBAL_PRODUCTS = FatureService.getALLMenuItems();

                        try
                        {

                            using (WebApp.Start<Startup>(url))
                            {
                                while (true) ;
                            }

                        }
                        catch (Exception ex)
                        {

                        }


                    }
               );
                    mthread.IsBackground = true;
                    mthread.Start();

                }
            }
            catch(Exception my)
            {
                MessageBox.Show(my.Message.ToString());
            }

        }

        class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
            }
        }
        [HubName("myHub")]
        public class MyHub : Hub
        {


            //getUsers for sending to specific mobile
            public void RequestForUsers(string mobileid)
            {
                var list = UserService.getUsersMobile();


                Clients.Group(mobileid).addUsers(list);
            }

            //login from mobile

            public void Login(LoginInfoMobile info)
            {

                bool answer = UserService.LoginMobile(info.userid, info.password);

                var list = new List<TableMobile>();


                if (answer)

                {
                    list = TavolinaService.getTableForMobile();
                }
                Clients.Group(info.mobileid).firstLogin(answer, list);
            }

            //get tables
            public void getTable(string mobileid)
            {
                var list = TavolinaService.getTableForMobile();


                Clients.Group(mobileid).addTable(list);

            }

            //get categories
            public void RequestForCategories(string mobileid)
            {

                var l = FatureService.getMenuCategories().Select(x => new MenuCategoriesMobile { Id = x.Id, Name = x.Name }).ToList();

                Clients.Group(mobileid).addCategories(l);

            }

            public void  RequestForCategories2(string mobileid)
            {
                var l = FatureService.getMenuCategories().Select(x => new MenuCategoriesMobile2 { Id = x.Id, Name = x.Name,Produktet=GLOBAL_PRODUCTS.Where(y=>y.CategoryId==x.Id).Select(y=>new ProductsMobile {Id=y.Productid,Name=y.Asortimenti,Price=y.Cmim }).ToList() }).ToList();

                Clients.Group(mobileid).addCategories2(l);
            }
            public void RequestForProducts(ProductModel model)
            {
                var list = GLOBAL_PRODUCTS.Where(x => x.CategoryId == model.CategoryId).Select(x => new ProductsMobile { Id = x.Productid, Name = x.Asortimenti, Price = x.Cmim }).ToList();
                Clients.Group(model.mobileid).addProducts(list);
            }
            public void RequestProductSearch(ProductSearchModel model)
            {
                var list = GLOBAL_PRODUCTS.Where(x => x.Asortimenti.ToLower().StartsWith(model.text.ToLower())).Select(x => new ProductsMobile { Id = x.Productid, Name = x.Asortimenti, Price = x.Cmim }).ToList();
                Clients.Group(model.mobileid).addProducts(list);
            }

            public void SaveFatureNew(FatureNewMoblie model)
            {
                var productlists = model.FatureRows.ToList();

                model.FatureRows.Clear();
                foreach (var item in productlists)
                {

                    var clone = (FatureRow)GLOBAL_PRODUCTS.Where(x => x.Productid == item.Productid).SingleOrDefault().Clone();
                    clone.Sasi = item.Sasi;
                    model.FatureRows.Add(clone);
                }

                model.ReferenceFatureRows = model.FatureRows;

                Clients.Group(model.mobileid).ServerConfirm(model.Save());
            }

            //mer tavoline te hapur
            public void RequestForOpenTable(OpenTable model)
            {
                var order = FatureService.getFatureOfTable(model.tableid);

                Clients.Group(model.mobileid).addOrder(order);
            }

            //UPDATE OPEN TABLE

            public void UpdateOpenTable(FatureEditMobile ed)
            {
                var productlists = ed.FatureRows.ToList();

                ed.FatureRows.Clear();
                foreach (var item in productlists)
                {

                    var clone = (FatureRow)GLOBAL_PRODUCTS.Where(x => x.Productid == item.Productid).SingleOrDefault().Clone();
                    clone.Sasi = item.Sasi;
                    ed.NewFatureRow.Add(clone);
                }

                ed.ReferenceFatureRows = ed.NewFatureRow;
                Clients.Group(ed.mobileid).ServerConfirm(ed.Save());
            }
            //close automatically open table
            public void CloseNewTable(FatureNewMoblie model)
            {
                var productlists = model.FatureRows.ToList();

                model.FatureRows.Clear();
                foreach (var item in productlists)
                {

                    var clone = (FatureRow)GLOBAL_PRODUCTS.Where(x => x.Productid == item.Productid).SingleOrDefault().Clone();
                    clone.Sasi = item.Sasi;
                    model.FatureRows.Add(clone);
                }

                model.ReferenceFatureRows = model.FatureRows;

                Clients.Group(model.mobileid).ServerConfirm(model.CloseTable());

            }

            //close open table
            public void CloseOpenTable(FatureEditMobile ed)
            {
                var productlists = ed.FatureRows.ToList();

                ed.FatureRows.Clear();
                foreach (var item in productlists)
                {

                    var clone = (FatureRow)GLOBAL_PRODUCTS.Where(x => x.Productid == item.Productid).SingleOrDefault().Clone();
                    clone.Sasi = item.Sasi;
                    ed.NewFatureRow.Add(clone);
                }

                ed.ReferenceFatureRows = ed.NewFatureRow;
                Clients.Group(ed.mobileid).ServerConfirm(ed.CloseTable());
            }

            public void RequestForOrders(MyOrderRequest model)
            {
                DateTime startdate = DateTime.Today;
                DateTime enddate = DateTime.Now;

                enddate = enddate.AddHours(23).AddMinutes(59).AddSeconds(59);


                var l = FatureService.getMyFatura(startdate, enddate, model.User_Id, new List<bool> { true, false });
                Clients.Group(model.mobileid).addOrders(l);
            }

            public void RequestForOrderDetails(OrderDetailsModel model)
            {
               Clients.Group(model.mobileid).addOrderDetails(FatureService.getFaturePreview(model.OrderId));
            }

            public void RequestForFaturePermbledhese(PermbledheseModel model)
            {
                FatureBuilder builder = new FatureBuilder(FatureService.getFaturePreview(model.OrderId));

                Printer.PrintFlowDocumentOneCopy(builder.getFaturePermbledheseReceipment(model.username));
                Clients.Group(model.mobileid).ServerConfirm(true);
            }
            //modelet e klasave  te mobile
            public override Task OnConnected()
            {

                try
                {

                    var allstr = Context.QueryString["mobileId"];


                    Groups.Add(Context.ConnectionId, allstr);
                   

                }
                catch (Exception ex)
                {

                }
                return base.OnConnected();
            }

            public override Task OnDisconnected(bool stopCalled)
            {

                try
                {


                    var allstr = Context.QueryString["mobileId"];



                    Groups.Remove(Context.ConnectionId, allstr);

                }
                catch
                {

                }

                return base.OnDisconnected(stopCalled);
            }
            public class UserMobile
            {

                public string UserId { get; set; }
                public string UserName { get; set; }
                public string Password { get; set; }

            }

            public class LoginInfoMobile
            {

                public string userid;
                public string password;
                public string mobileid;
            }

            public class AfterLogin
            {
                public bool answer;
                public List<TableMobile> tables;
            }

            public class TableMobile
            {
                public int id { get; set; }
                public int tablenumber { get; set; }
                public int onlineid { get; set; }
                public bool isopen { get; set; }
                public int orderid { get; set; }
                public string userid { get; set; }
            }

            public class MenuCategoriesMobile
            {
                public int Id { get; set; }

                public string Name { get; set; }
            }
            public class MenuCategoriesMobile2
            {
                public int Id { get; set; }

                public string Name { get; set; }
                public List<ProductsMobile> Produktet { get; set; }
            }

            public class ProductsMobile
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public decimal Price { get; set; }
            }

            public class ProductModel
            {
                public int CategoryId { get; set; }
                public string mobileid { get; set; }
            }
            public class ProductSearchModel
            {
                public string mobileid { get; set; }
                public string text { get; set; }
            }

            public class OpenTable
            {
                public string mobileid;
                public int tableid;
            }

            public class MyOrderRequest
            {
                public string User_Id;
                public string mobileid;
            }
            public class OrderDetailsModel
            {
                public int OrderId;
                public string mobileid;
            }

            public class PermbledheseModel
            {
                public int OrderId;
                public string mobileid;
                public string username;
            }

            
        }

    }
   
}
