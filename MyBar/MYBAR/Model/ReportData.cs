using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYBAR.Model
{
  public  class ReportData
    {
        public dynamic Data { get; set; }
        public string DataSource { get; set; }
        public string RaportPath { get; set; }
        public List<ReportParameter> Parametrat { get; set; }

        public ReportData()
        {
            Parametrat = new List<ReportParameter>();
        }

        public void addParameter(string key,string value)
        {

            Parametrat.Add(new ReportParameter(key, value));
        }

        public LocalReport getLocalReport()
        {
            LocalReport local = new LocalReport();
            var data = Data;
            var reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = DataSource;
            reportDataSource1.Value = data;

              local.DataSources.Add(reportDataSource1);

              local.ReportEmbeddedResource = RaportPath;

             local.SetParameters(Parametrat);

            return local;
        }
    
    }
}
