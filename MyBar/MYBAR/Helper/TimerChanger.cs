using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MYBAR.Helper
{
    public class TimerChanger
    {

        public static bool HasTimeChanged()
        {


            return false;


        }

 


        public static DateTime GetNistTime()
        {
            DateTime dateTime = DateTime.MinValue;
            try
            {



                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
                //request.Method = "GET";

                //request.Accept = "text/html, application/xhtml+xml, */*";
                //request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
                //request.ContentType = "application/x-www-form-urlencoded";
                //request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                //    StreamReader stream = new StreamReader(response.GetResponseStream());
                //    string html = stream.ReadToEnd();//<timestamp time=\"1395772696469995\" delay=\"1395772696469995\"/>
                //    string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
                //    double milliseconds = Convert.ToInt64(time) / 1000.0;
                //    dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
                //}

                //return dateTime;

                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.microsoft.com");
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
                request.ContentType = "application/x-www-form-urlencoded";
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string todaysDates = response.Headers["date"];

                    dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                        System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);
                }

                return dateTime;

            }
            catch(Exception e)
            {

                return dateTime;
            }
        }
    }
}
