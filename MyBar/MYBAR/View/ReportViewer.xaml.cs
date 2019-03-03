using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;
using MYBAR.Services;
using MYBAR.Model;
using System.Windows.Threading;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : UserControl
    {
        public ReportViewer(ReportData d)
        {
            InitializeComponent();

           // reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            Action action = delegate ()
            {
                var data = d.Data;
                var reportDataSource1 = new ReportDataSource();
                reportDataSource1.Name = d.DataSource;
                reportDataSource1.Value = data;
              
                
                reportViewer.LocalReport.DataSources.Add(reportDataSource1);
             
                reportViewer.LocalReport.ReportEmbeddedResource = d.RaportPath;

                reportViewer.LocalReport.SetParameters(d.Parametrat);
                reportViewer.RefreshReport();
            };

            Dispatcher.Invoke(DispatcherPriority.Normal, action);
          
        }


    }
}
