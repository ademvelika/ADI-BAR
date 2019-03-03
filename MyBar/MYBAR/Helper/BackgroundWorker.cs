using Microsoft.Win32;
using MYBAR.Model.Xhiro;
using MYBAR.Services;
using MYBAR.View;
using System;
using System.Windows.Controls;
using System.Net.NetworkInformation;
using System.Configuration;
using MYBAR.Model.FatureModel;

namespace MYBAR.Helper
{
    public class BackgroundWorker
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static FatureInfo LoadFaturaInfoAsync()
        {



  


           return FatureInfoService.getInfo();

        }

        public static void getAllArtikujAsync( DataGrid d,int catid)
        {

            d.ItemsSource = ArtikullService.getAllArtikujByCategory(catid);
        }

        public static void CalculateXhiroDitoreUser()
        {

            FinanceService.CalculateXhiroDitore();


        }

        public static XhiroDitoreUser getXhiroDitore()
        {

            MainWindow m = (MainWindow)App.Current.MainWindow;

            if (m.XhiroDitore.ContainsKey(m.UserId))
            {
                return m.XhiroDitore[m.UserId];
            }

            return new XhiroDitoreUser();

        }


        public static void AddFatureTotalToXhiroTotale(decimal value)
        {
            MainWindow m = (MainWindow)App.Current.MainWindow;


            if (m.XhiroDitore.ContainsKey(m.UserId))
            {

                if (RegisterData.IsKasaActive)
                {
                    m.XhiroDitore[m.UserId].XhiroKaseFiskale += value;
                    
                }
               
                
                    m.XhiroDitore[m.UserId].XhiroReale += value;
                
            }
            else
            //if not have xhiro for today open a new xhiro  
            {
                m.XhiroDitore.Add(m.UserId, new XhiroDitoreUser { UserId = m.UserId });
                if (RegisterData.IsKasaActive)
                {
                    m.XhiroDitore[m.UserId].XhiroKaseFiskale += value;
                }
              
                    m.XhiroDitore[m.UserId].XhiroReale += value;
                

            }
            

        }
        public static void AddFatureTotalToXhiroTotaleFromMobile(decimal value,string USERID,bool fiscal)
        {
            


            if (RegisterData.XHIRO_DITORE_USER.ContainsKey(USERID))
            {

                if (fiscal)
                {
                    RegisterData.XHIRO_DITORE_USER[USERID].XhiroKaseFiskale += value;

                }


                RegisterData.XHIRO_DITORE_USER[USERID].XhiroReale += value;

            }
            else
            //if not have xhiro for today open a new xhiro  
            {
                RegisterData.XHIRO_DITORE_USER.Add(USERID, new XhiroDitoreUser { UserId = USERID });
                if (fiscal)
                {
                    RegisterData.XHIRO_DITORE_USER[USERID].XhiroKaseFiskale += value;
                }

                RegisterData.XHIRO_DITORE_USER[USERID].XhiroReale += value;


            }


        }

        public static void LoadFirstTime()
        {

           

            ReportViewer r = new ReportViewer(Services.RaporteService.getInventarRaport());

        }

        public static void LoadRegister()
        {


            try
            {


                var key = GetRegister();

                if (key == null)
                {

                    //perdoret per shfaqjen e cmimit
                    RegisterData.SHOW_PRICE = 0;
                    RegisterData.KasaPath = @"c:\";
                    RegisterData.KasaType = "AED";

                    RegistryKey newkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\G-H-BAR");

                    saveParameters( newkey);
                    newkey.Close();
                    
                }
                else
                {
                    LoadParameters();

                }

            }

            catch(Exception e)
            {

            }

        }

      

        private static void saveParameters(RegistryKey newkey)
        {

            try
            {


                newkey.SetValue("KasaType", RegisterData.KasaType);
                newkey.SetValue("Place_Id", RegisterData.Place_Id);
                newkey.SetValue("KasaPath", RegisterData.KasaPath);
                newkey.SetValue("IsKasaActive", RegisterData.IsKasaActive);
                newkey.SetValue("COPYNR", RegisterData.SHOW_PRICE);
                newkey.SetValue("POS_ID", RegisterData.POS_Id);
              //  newkey.SetValue("POS_NAME", RegisterData.PosName);

                newkey.SetValue("ALIVE", RegisterData.IsActive);
            }
            catch(Exception E)
            {
                log.Error("============Fail To Save data in Register============="+E.Message.ToString());
            }
        }

        public static void SaveKasaState(bool state)
        {

            try
            {
                RegistryKey newkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\G-H-BAR");
                newkey.SetValue("IsKasaActive",state );

            }
            catch
            {

            }
        }
        public static void SaveNumberOfCopies(int number)
        {

            try
            {
                RegistryKey newkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\G-H-BAR");
                newkey.SetValue("COPYNR", number);

            }
            catch
            {

            }
        }

        public static void UpdatePOSData(string name,bool alive)
        {
            try
            {
                RegistryKey newkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\G-H-BAR");
                newkey.SetValue("POS_NAME", name);
                newkey.SetValue("ALIVE", alive);
                RegisterData.PosName = name;
                RegisterData.IsActive = alive;

            }
            catch
            {

            }

        }

        private static void LoadParameters()
        {
            var key = GetRegister();
            RegisterData.KasaType= (string)key.GetValue("KasaType");
            RegisterData.KasaPath = (string)key.GetValue("KasaPath");
            RegisterData.Place_Id = (int)key.GetValue("Place_Id");

            RegisterData.POS_Id = (int)key.GetValue("POS_ID");
            RegisterData.PosName = (string)key.GetValue("POS_NAME");
           
             string boolvalueStr = (string)key.GetValue("IsKasaActive");

            if (boolvalueStr == "True")
            {
                RegisterData.IsKasaActive = true;

            }
            else
            {
                RegisterData.IsKasaActive = false;
            }

            RegisterData.SHOW_PRICE=(int)key.GetValue("COPYNR");
            string boolIsAlive = (string)key.GetValue("ALIVE");
            if (boolIsAlive == "True")
            {
                RegisterData.IsActive = true;

            }
            else
            {
                RegisterData.IsActive = false;
            }


        }

        public static RegistryKey GetRegister()
        {

            try
            {
                return Registry.CurrentUser.OpenSubKey(@"SOFTWARE\G-H-BAR", true);

            }
            catch(Exception e)
            {
                log.Error("Fail to Read Register from operating system !" + e.Message.ToString());
                return null;
            }
        }

        public static void UpdateSettings()
        {
            saveParameters(GetRegister());
            LoadParameters();
        }

        public static string GetMACAdress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }

            RegisterData.MAC_ADRESS = sMacAddress;
            return sMacAddress;
        }

        public static string ReadKey(string strKey)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[strKey] ?? "-1";
             

                return result;
            }
            catch (ConfigurationErrorsException)
            {
               log.Error("Error reading app settings");
            }

            return "1";

        }
        public static bool UpdateConfigKey(string strKey, string newValue)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[strKey] == null)
                {
                    settings.Add(strKey, newValue);
                }
                else
                {
                    settings[strKey].Value = newValue;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                log.Error("Error writing app settings");
            }

            return true;
        }
    




    }
}
