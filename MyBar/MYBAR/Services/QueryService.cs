using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Services
{
    public class QueryService
    {

        public static string ExecuteQuerySelect(string query)
        {


            using (BPDBEntities db = new BPDBEntities())
            {

                try
                { 
                var connectionString = db.Database.Connection.ConnectionString;


                StringBuilder s = new StringBuilder();
                s.Append("<table class=' table  table-responsive'  style=' background: #f1efef; font-size: 15px; font-family: sans-serif; font-weight: 500;  '>");
                //
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //
                    // Open the SqlConnection.
                    //
                    con.Open();
                    //
                    // The following code uses an SqlCommand based on the SqlConnection.
                    //
                    using (SqlCommand command = new SqlCommand(query, con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        s.AppendLine("<tr>");
                        int columnNumber = reader.FieldCount;
                        for (int i = 0; i < columnNumber; i++)
                        {
                            s.AppendLine("<td style=' background: #77a6d6; color: white;' >" + reader.GetName(i).ToString() + "</td>");
                        }
                        s.AppendLine("</tr>");
                        while (reader.Read())
                        {

                            s.AppendLine("<tr>");
                            for (int i = 0; i < columnNumber; i++)
                            {
                                s.AppendLine("<td>" + reader.GetValue(i).ToString() + "</td>");
                            }

                            s.AppendLine("</tr>");
                        }

                        s.AppendLine("</table>");
                    }
                }


                    return s.ToString();
            }

                catch (Exception e)
                {
                    return e.Message.ToString();
                }


        }


        }
        public static string ExecuteQuery(string query)
        {


            using (BPDBEntities db = new BPDBEntities())
            {

                try
                {


                    db.Database.ExecuteSqlCommand(query);
                   

                    return "sukses";
                }

                catch (Exception e)
                {
                    return e.Message.ToString();
                }


            }


        }
    }
}
