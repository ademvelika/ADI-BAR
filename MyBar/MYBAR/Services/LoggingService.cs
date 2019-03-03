using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Services
{
   public class LoggingService
    {

        public static int  AddLog(LogModel model)
        {

            using (BPDBEntities db = new BPDBEntities())
                try
                {

                    Logs l = new Logs();

                    l.Text = model.Text;
                    db.Logs.Add(l);
                    db.SaveChanges();
                   var  id= l.Id;

                    return id;

                }

                catch
                {
                    return 0;
                }

        }

        public class LogModel
        {
            public int Id { get; set; }

            public string Text { get; set; }
        }
    }
}
