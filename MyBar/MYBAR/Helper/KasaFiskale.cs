using MYBAR.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MYBAR.Helper
{
    /// <Class>
    /// klasa pergjegjese per kasen fiskale
    /// </Class>
    public class KasaFiskale
    {
        /// <Constructor>
        /// Kasa Fiskale merr fatuere
        /// </Constructor>
        /// 
        private FatureBase fatura;
     
        private const string SM= ";";
        private string Pershkrim = "-adisoft-";
        public static string TVSHCLASS;
      
        public KasaFiskale(FatureBase fature)
        {
            fatura = fature;
          
        }

        public static void FindTvshClass()
        {

            try
            {
                var xmlStr = File.ReadAllText(@"TVSHCLASSES.xml");
                var data = XElement.Parse(xmlStr);

                var KASA = data.Element("TVSHCLASSES").Element(RegisterData.KasaType);
                var tvshvalue = data.Element("MYCHOISE").Attribute("TVSHVALUE").Value;
                TVSHCLASS = KASA.Element(tvshvalue).Value;

            }
            catch(Exception ex)
            {
              
            }
           
        }


        public void SaveFile()
        {

            try
            {
                KasaFile file = getFile();
                string path = RegisterData.KasaPath;
                if (Directory.Exists(path))
                {
                    File.WriteAllText(path + "\\" + file.FileName, file.FileContent);
                }

            }
            catch
            {

            }
        }
        private KasaFile getFile()
        {
            
            
            switch (RegisterData.KasaType)
            {
                case "AED":

                    return new KasaFile { FileName = "skontrino.txt" ,FileContent=AEDText()};

                case "IVA":
                    return new KasaFile { FileName = "cashfile.txt",FileContent=IVAText() };

                case "BNT":
                    return new KasaFile { FileName = "Skedari.txt", FileContent = BNTText() };

                case "BNT-SC-Link":
                    
                    return new KasaFile { FileName = "rcpt.inp", FileContent = SCLinkBNTText() };
                case "BNT-SUPERCASH":

                    return new KasaFile { FileName = "rcpt.txt", FileContent = SuperCashText() };

                default:
                    return new KasaFile {FileName="notype",FileContent="No type found for kasa device !" };
            }
        }

        private string AEDText()
        {

            StringBuilder str = new StringBuilder();
            str.AppendLine( "CLEAR");
            str.AppendLine("CHIAVE REG");


            foreach (var item in fatura.ReferenceFatureRows)
            {
                string name = item.Asortimenti;
                int quantity = item.Sasi;
                int price = Decimal.ToInt32(item.Cmim);
              str.AppendLine("VEND REP=1,qty="+quantity+ ",PREZZO=" + price+ ",DES='" + item.Asortimenti+"'");
            }

            str.AppendLine("CHIU TEND=1");

            return str.ToString();
        }

     

        private string IVAText()
        {
            StringBuilder strbuilder = new StringBuilder();

            string underscoreline= ",______,_,__;";

            strbuilder.AppendLine("H,1" + underscoreline);
            strbuilder.AppendLine("M,1" + underscoreline+"102;");
            foreach (var item in fatura.ReferenceFatureRows)
            {
                string name = item.Asortimenti;
                int quantity = item.Sasi;
                int price = Decimal.ToInt32(item.Cmim);
                strbuilder.AppendLine("S,1" + underscoreline+name+SM+price+SM+quantity+SM+ "1;1;2;0;0;");
            }

            //add pershkrim
            strbuilder.AppendLine("P,1" + underscoreline + Pershkrim);

            strbuilder.AppendLine("T,1" + underscoreline);
            strbuilder.AppendLine("F,1" + underscoreline);

            return strbuilder.ToString();
           
        }

        private string BNTText()
        {
            StringBuilder strbuilder = new StringBuilder();

            string underscoreline = ",______,_,__;";

            strbuilder.AppendLine("H,1" + underscoreline);

            foreach (var item in fatura.ReferenceFatureRows)
            {
                string name = item.Asortimenti;
                int quantity = item.Sasi;
                int price = Decimal.ToInt32(item.Cmim);
                strbuilder.AppendLine("S,1" + underscoreline + name + SM + price + SM + quantity + ";1;1;1;0;0;");
            }

            strbuilder.AppendLine("T,1" + underscoreline);
         

            return strbuilder.ToString();
            
        }


        public string SuperCashText()
        {
            StringBuilder strbuilder = new StringBuilder();


            foreach (var item in fatura.ReferenceFatureRows)
            {
                string name = item.Asortimenti;
                int quantity = item.Sasi;
                int price = Decimal.ToInt32(item.Cmim);
                strbuilder.AppendLine(item.Productid + SM + name + SM+"2"+SM+ price + SM + quantity);
            }

            strbuilder.AppendLine("Ga;");


            return strbuilder.ToString();


        }
        public string SCLinkBNTText()
        {
            StringBuilder strbuilder = new StringBuilder();

            string underscoreline = ",______,_,__;";
            foreach (var item in fatura.ReferenceFatureRows)
            {
                string name = item.Asortimenti;
                int quantity = item.Sasi;
                int price = Decimal.ToInt32(item.Cmim);
                strbuilder.AppendLine("S,1" + underscoreline + name + SM + price + SM + quantity + ";1;1;1;0;"+item.Productid);
            }

            strbuilder.AppendLine("T,1" + underscoreline+SM+"0"+SM);


            return strbuilder.ToString();
        }

       
        public class KasaFile
        {

            public string FileName { get; set; }
            public string FileContent { get; set; }
        }
    }
}
