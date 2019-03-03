using MYBAR.Helper;
using MYBAR.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model
{
    [Serializable]
    public class FatureRow:BindingInteface
    {
        public string Asortimenti { get; set; }
        public int Productid;
        public int ProductOnlineId;
        public int Sasi { get; set; }
        public int SasiStatus { get; set; }
        //used for data
        public decimal Cmim { get; set; }

        //used for view in GUI
        public string Cmimi { get; set; }
        public int CategoryId { get; set; }
        public string PrinterName { get; set; }
        public string Njesi { get; set; }
        public int TypeId { get; set; }
        public DateTime Date { get; set; }
        public List<FatureRow> Ingredients = new List<FatureRow>();

        //gui atributtes
        public int SASI
        {
            get
            {
                return Sasi;
            }
            set
            {
                Sasi = value;
                NotifyPropertyChanged("SASI");
                Dependency.setTotalFatureHyrje();
                Dependency.setTotalPosView();
            }
        }
       
        public decimal CMIM
        {
            get
            {
                return Cmim;
            }
            set
            {
                Cmim = value;
                Dependency.setTotalFatureHyrje();
            }
        }
     

        public int GetProductId()
        {

            return Productid;
        }

        public virtual List<FatureRow> getProdukteDalje()
        {
           
            Ingredients.Add(this);
           return Ingredients;
        }

        public virtual FatureRow getInstance()
        {
            return new FatureRow();
        }
        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }


    }
}
