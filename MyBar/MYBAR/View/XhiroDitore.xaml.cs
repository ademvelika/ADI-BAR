using MYBAR.Raports;
using MYBAR.Services;
using System;
using System.Windows.Controls;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for XhiroDitoreView.xaml
    /// </summary>
    public partial class XhiroDitore : UserControl
    {
        public XhiroDitore()
        {
            InitializeComponent();

            BuildXhiroDitore();
        }

        public void BuildXhiroDitore()
        {
            MainWindow m = (MainWindow)App.Current.MainWindow;

            string userid = m.UserId;
            string username = m.UserName;
            var model = FinanceService.getXhiroDitore(userid);
            model.Turni = new Model.Xhiro.TurnetRowModel();
         
            model.RequestedForCancelOrders.Add(new Model.FaturePreview { Id = 1, Data=DateTime.Now,FatureBody=new System.Collections.Generic.List<Model.FatureRow>()});
            model.CancelOrders.Add(new Model.FaturePreview { Id = 1, Data = DateTime.Now, FatureBody = new System.Collections.Generic.List<Model.FatureRow>() });
            XhiroDitoreBuilder builder = new XhiroDitoreBuilder(model,username);
            XhiroView.Document = builder.Document;
            
        }
    }
}
