using MYBAR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MYBAR.Helper;
using MYBAR.Model.SyncModel;
using MYBAR.Model.UserModel;
using static MYBAR.Mobile.MobileSyncer.MyHub;
using System.Transactions;

namespace MYBAR.Services
{
    public  class UserService
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static async Task<bool> ExistUser(string username, string password, List<User> users)
        {


            try
            {
                MainWindow m = (MainWindow)App.Current.MainWindow;

                var user = users.Where(x => x.UserName == username).Single();
                PasswordHasher pwd = new PasswordHasher();

                var isok = pwd.VerifyHashedPassword(user.Password, password);
                if (isok == PasswordVerificationResult.Failed)
                {

                    if (user.ID == m.MenagerUserId)
                    {
                        int count = int.Parse(BackgroundWorker.ReadKey("WRONG_PASSWORD_TRY"));


                        if (count == 1)
                        {
                            //notify id for offline use
                            var id = LoggingService.AddLog(new LoggingService.LogModel { Text = "eshte tentuar te hapet llogaria juaj !" });

                           
                            //reset
                            BackgroundWorker.UpdateConfigKey("WRONG_PASSWORD_TRY", "0");
                        }
                        else
                        {
                            count++;
                            BackgroundWorker.UpdateConfigKey("WRONG_PASSWORD_TRY", count.ToString());
                        }

                      
                    }


                    return false;
                }
                else
                {


                    m.UserId = user.ID;
                    m.UserName = username;
                    m.Title = username;
                    m.CurrentUser = user;

                    RegisterData.UserId = user.ID;
                    //dergimi i notifikimit kur hyn menaxheri
                    //Thread th = new Thread(() => SendLoginNotificationToServer(user));
                    //th.Start();
                    return true;
                }



            }

            catch (Exception e)

            {

                return false;
            }



        }

        public static async void SendLoginNotificationToServer(User u)
        {

            if (u.Role == "Manager")
            {

                string text = "Menaxheri u logua nga programi !  [" + DateTime.Now.ToString() + "]";
                //send notification to server
                var idnotification = LoggingService.AddLog(new LoggingService.LogModel { Text = text });
               
            }
        }

        public static List<User> GetUsers()
        {


            try
            {
              using(BPDBEntities db = new BPDBEntities())
                {




     
                    return db.Database.SqlQuery<User>(@"select a.id as ID,PasswordHash as Password,roles.Name as Role,roles.Id as RoleId,isnull(d.FirstName,a.UserName) as UserName
 from AspNetUsers a join AspNetUserRoles aur on a.Id=aur.UserId
 join AspNetRoles roles on roles.Id=aur.RoleId
 left join UserDatas d on d.User_Id=a.Id where a.IsActive=1").ToList();
                }

            }

            catch(Exception e3)
            {

                log.Error("Fail to get all users " + e3.Message.ToString());

                return new List<User>();
            }


        }


        public static List<ComboBoxData> GetUsersCombo()
        {
        
            try
            {
                using (BPDBEntities db = new BPDBEntities())
                {
                    var list = new List<ComboBoxData>();
                 
                    list.Add(ComboBoxData.DefaultOption);

                   list.AddRange( GetUsers().Select(x => new ComboBoxData { DataValueOpt = x.ID, DisplayValue = x.UserName }).ToList());

                    return list;
                        
                        //db.Database.SqlQuery<ComboBoxData>("select a.id as DataValueOpt,Email as DisplayValue from AspNetUsers a join AspNetUserRoles aur on a.Id=aur.UserId").ToList();
                }

            }

            catch
            {

                return new List<ComboBoxData>();
            }


        }



        public static List<ComboBoxData> GetOtherUsers(string userid)
        {
            return GetUsersCombo().Where(x => x.DataValueOpt != userid && x.DataValueOpt != "ALL").ToList();
        }

        //insert user from server 


        public static bool InsertUserFromServer(UserSyncViewModel model)
        {

            try
            {
                

                using (BPDBEntities db = new BPDBEntities())
                {

                    AspNetUsers a = new AspNetUsers();
                    a.Id = model.Id;
                    a.Email = model.Email;
                    a.EmailConfirmed = model.EmailConfirmed;
                    a.PasswordHash = model.PasswordHash;
                    a.SecurityStamp = model.SecurityStamp;
                    a.PhoneNumber = model.PhoneNumber;
                    a.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
                    a.TwoFactorEnabled = model.TwoFactorEnabled;
                    a.LockoutEndDateUtc = model.LockoutEndDateUtc;
                    a.LockoutEnabled = model.LockoutEnabled;
                    a.AccessFailedCount = model.AccessFailedCount;
                    a.UserName = model.UserName;
                    a.IsActive = model.IsActive;

                    UserDatas udata = new UserDatas();

                    udata.User_Id = model.UserData.User_Id;
                    udata.FirstName = model.UserData.FirstName;
                    udata.LastName = model.UserData.LastName;
                    udata.Place_Id = RegisterData.Place_Id;
                    a.UserDatas.Add(udata);



                    db.AspNetUsers.Add(a);
                    db.SaveChanges();

                    string insertquery = "insert into AspNetUserRoles values('" + model.Id+"','"+model.RoleID+"')";
                    db.Database.ExecuteSqlCommand(insertquery);


                    return true;
                }

            }

            catch (Exception e3)
            {
                log.Error("Fail to insert users from server " + e3.Message.ToString());
                return false;
            }
        }

        //update user from server

        public static bool UpdateUserFromServer(UserSyncViewModel model)
        {

            try
            {


                using (BPDBEntities db = new BPDBEntities())
                {

                    AspNetUsers a = db.AspNetUsers.Where(x => x.Id == model.Id).SingleOrDefault();
                 
                    a.Email = model.Email;
                    a.EmailConfirmed = model.EmailConfirmed;
                    a.PasswordHash = model.PasswordHash;
                    a.SecurityStamp = model.SecurityStamp;
                    a.PhoneNumber = model.PhoneNumber;
                    a.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
                    a.TwoFactorEnabled = model.TwoFactorEnabled;
                    a.LockoutEndDateUtc = model.LockoutEndDateUtc;
                    a.LockoutEnabled = model.LockoutEnabled;
                    a.AccessFailedCount = model.AccessFailedCount;
                    a.UserName = model.UserName;
                    a.IsActive = model.IsActive;

                    UserDatas udata = a.UserDatas.FirstOrDefault();

                   
                    udata.FirstName = model.UserData.FirstName;
                    udata.LastName = model.UserData.LastName;
                   
               

                    db.SaveChanges();

                  


                    return true;
                }

            }

            catch (Exception e3)
            {
                log.Error("Fail to update users from server " + e3.Message.ToString());
                return false;
            }
        }

        //update Locally
        public static bool UpdateUserLocaly(UserModel model)
        {

            try
            {


                using (BPDBEntities db = new BPDBEntities())
                {

                    AspNetUsers a = db.AspNetUsers.Where(x => x.Id == model.ID).SingleOrDefault();

                   

                    UserDatas udata = a.UserDatas.FirstOrDefault();


                    udata.FirstName = model.Name;


                   
                    db.SaveChanges();
                    string updateRole = "update AspNetUserRoles set RoleId='" + model.RoleId + "' where UserId='" + model.ID + "'";

                    db.Database.ExecuteSqlCommand(updateRole);



                    return true;
                }

            }

            catch (Exception e3)
            {
                log.Error("Fail to update users localy " + e3.Message.ToString());
                return false;
            }
        }
        //delete user

            public static bool AddUser(UserModel model)
        {

            using (TransactionScope s = new TransactionScope())
            {
                try
                {


                    using (BPDBEntities db = new BPDBEntities())
                    {
                        AspNetUsers a = new AspNetUsers();
                        a.Id = Guid.NewGuid().ToString();
                        a.Email = model.Name + "@example.com";
                        a.EmailConfirmed = true;
                         a.PasswordHash = "AICQZom2BxdM20s4ZJxP1E+9tQ7oLtBQS5E+KbbvA0FiAmY+xEA4JTPEkqmlEjRaCg==";
                         a.SecurityStamp = "adadd"+model.Name;
                        a.PhoneNumber = "0000";
                        a.PhoneNumberConfirmed = true;
                        a.TwoFactorEnabled = true;
                        a.LockoutEndDateUtc = DateTime.Now;
                        a.LockoutEnabled = true;
                        a.AccessFailedCount = 500;
                        a.UserName = model.Name;
                        a.IsActive = true; ;

                        db.AspNetUsers.Add(a);
                        db.SaveChanges();
                        UserDatas udata = new UserDatas();

                        udata.User_Id = a.Id;
                        udata.FirstName = model.Name;
                        udata.LastName = model.Name;
                        udata.Place_Id = RegisterData.Place_Id;
                        a.UserDatas.Add(udata);





                        string insertquery = "insert into AspNetUserRoles values('" + a.Id + "','" + model.RoleId + "')";
                        db.Database.ExecuteSqlCommand(insertquery);

                        db.SaveChanges();
                        s.Complete();
                        return true;
                    }

                }

                catch (Exception e3)
                {
                    log.Error("Fail to add users localy " + e3.Message.ToString());
                    return false;
                }

            }
        }

        public static bool DeleteUserFromServer(UserSyncViewModel model)
        {

            try
            {


                using (BPDBEntities db = new BPDBEntities())
                {



                    AspNetUsers a = db.AspNetUsers.Where(x => x.Id == model.Id).FirstOrDefault();
                    a.IsActive = false;

                    db.SaveChanges();

                    return true;
                }

            }

            catch (Exception e3)
            {
                log.Error("Fail to update User Locally" + e3.Message.ToString());
                return false;
            }
        }


        public static bool UpdatePassword(string userid,string newpassword)
        {

            try
            {


                using (BPDBEntities db = new BPDBEntities())
                {



                    AspNetUsers a = db.AspNetUsers.Where(x => x.Id == userid).FirstOrDefault();
                    a.PasswordHash = newpassword;

                    db.SaveChanges();

                    return true;
                }

            }

            catch (Exception e3)
            {
                log.Error("Fail to update User Locally" + e3.Message.ToString());
                return false;
            }
        }

        //mobile region for users

        public static List<UserMobile> getUsersMobile()
        {

            var list = new List<UserMobile>();
            foreach (var item in GetUsers().Where(x=>x.Role!= "Manager").ToList())
            {

                list.Add(new UserMobile { UserId = item.ID, UserName = item.UserName });

            }

            return list;
        }

        public static bool LoginMobile(string username ,string password)
        {
                   


            try
            {
               

                var user = GetUsers().Where(x => x.UserName == username).Single();
                PasswordHasher pwd = new PasswordHasher();

                var isok = pwd.VerifyHashedPassword(user.Password, password);
                if (isok == PasswordVerificationResult.Failed)
                {

                  


                    return false;
                }
                else
                {


                  
                    return true;
                }



            }

            catch
            {
                return false;
            }



        }
    }


    
}
