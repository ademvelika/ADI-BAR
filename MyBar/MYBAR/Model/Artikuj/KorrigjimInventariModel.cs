using MYBAR.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model.Artikuj
{
  public  class KorrigjimInventariModel:BindingInteface
    {

        public static string GREEN = "SeaGreen";
        public static string REED = "Tomato";
        public int _newsasi;
        public int SasiaAktuale { get; set; }
        public int ProduktId { get; set; }
        public int OnlineProduktId { get; set; }
        public string Emri { get; set; }
        public int _differenca { get; set; }
        public string _ngjyra { get; set; }
        public  decimal LastBuyPrice { get; set; }

        public decimal Cmimi { get; set; }

        public string Ngjyra
        {
            get
            {
                return _ngjyra;
            }
            set
            {
                _ngjyra = value;
                NotifyPropertyChanged("Ngjyra");
            }
        }
        public int SasiRe
        {
            get
            {
                return _newsasi;
            }
            set
            {
                _newsasi = value;
                Diferenca =  value-SasiaAktuale;

                NotifyPropertyChanged("SasiRe");
            }
        }

        public int Diferenca
        {
            get
            {
                return _differenca;
            }
            set
            {
                _differenca = value;

                if(value==0)
                {
                    Ngjyra = "f2f2f2";
                }
                else if (value > 0)
                {
                    Ngjyra = GREEN;
                }
                else
                {
                    Ngjyra = REED; 
                    
                }
                NotifyPropertyChanged("Diferenca");
               
            }
        }
    }
}
