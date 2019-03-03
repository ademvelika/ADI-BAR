using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model
{
    public class ComboBoxData
    {

        public int DataValue{get;set;}
        public int DataValueOnline { get; set; }
        public string DataValueOpt { get; set; }
        
        public string DisplayValue { get; set; }

        public static string TeGjitha = "ALL";
        public static ComboBoxData DefaultOption= new ComboBoxData { DataValueOpt = "ALL", DisplayValue = "Te Gjithe" };
        public override string ToString()
        {
            return DisplayValue;
        }

      
    }
}
