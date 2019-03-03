using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Services
{
    public class OrderForCancellationService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool addOrderForCancellation(OrderForCancellationModel model)
        {


            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    OrderForCancellation orcancel = new OrderForCancellation();
                    orcancel.OrderId = model.OrderId;
                    orcancel.Date = model.Data;
                    db.OrderForCancellation.Add(orcancel);
                    db.SaveChanges();
                    return true;

                }

                catch (Exception ex)
                {
                    return false;
                }
        }
        
        public static  bool DeleteOrderForCancellation(OrderForCancellationModel model)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    var order = db.OrderForCancellation.Where(x => x.OrderId == model.OrderId).FirstOrDefault();
                    db.OrderForCancellation.Remove(order);
                    db.SaveChanges();
                    return true;

                }

                catch (Exception ex)
                {
                    
                    return false;
                }
        }

        public static bool IsRequestedForCancel(int orderid)
        {
            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    return db.OrderForCancellation.Where(x => x.OrderId == orderid).Any();
                  

                }

                catch (Exception ex)
                {

                    log.Error("can not delete from waiting order for cacellation from OrderFromCancellation");
                    return false;
                }
        }
    }


    public class OrderForCancellationModel
    {

        public int Id { get; set; }
        public int OrderId { get; set; }

        public DateTime Data { get; set; }

    }

}
