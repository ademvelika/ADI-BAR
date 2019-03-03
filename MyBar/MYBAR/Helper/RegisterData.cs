using MYBAR.Model;
using MYBAR.Model.Xhiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Helper
{
    public class RegisterData
    {

        public static int Place_Id { get; set; }

        public static int POS_Id { get; set; }

        public static string PosName { get; set; }

        public static bool IsActive { get; set; }
        public static string KasaType { get; set; }
    
       
        public static string KasaPath { get; set; }
        public static string UserId { get; set; }
        public static bool IsKasaActive { get; set; }
        public static Guid PlaceKey { get; set; }
        public static int SHOW_PRICE { get; set; }

        //bill part for print with thread
        public static string BILL_HEADER { get; set; }
        public static string BILL_FOOTER { get; set; }
        public static byte[] Image { get; set; }

        //show or hide unfiscal bill
        public static bool ShowAllBillTypes = true;


        public static string MAC_ADRESS { get; set; }

        public static GUICreator DYNAMIC_Creator = new GUICreator();

        public static Dictionary<string, XhiroDitoreUser> XHIRO_DITORE_USER;
        public static  string FULL_BILL;
        public static string PM;
        public RegisterData()
        {

         
           
          
        }
    }
}
