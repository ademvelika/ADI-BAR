using MYBAR.Model.FatureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Services
{
    class FatureInfoService
    {

        public static bool UpdateInfo(string HeadText,string footerText,byte[] myimage)
        {


            try
            {

                using(BPDBEntities db=new BPDBEntities())
                {
                    OrderInfo of = db.OrderInfo.FirstOrDefault();

                    if (of!=null)
                    {
                        of.HeadText = HeadText;
                        of.FootText = footerText;
                        of.Image = myimage;
                        db.SaveChanges();
                    }
                    else
                    {
                        OrderInfo newof = new OrderInfo();
                        newof.HeadText = HeadText;
                        newof.FootText = footerText;
                        newof.Image = myimage;
                        
                        db.OrderInfo.Add(newof);

                        db.SaveChanges();
                    }

                    return true;

                }

            }

            catch(Exception ex)
            {
                return false;
            }
        }
         

        public static FatureInfo getInfo()
        {


            try
            {

                using (BPDBEntities db = new BPDBEntities())
                {
                    OrderInfo of = db.OrderInfo.First();


                    return new FatureInfo { HeadText = of.HeadText, FootText = of.FootText,Image=of.Image };
                    }

                   

                }

            

            catch
            {
                
            return new FatureInfo();
            }


        }
    }
}
