using MYBAR.Helper;
using MYBAR.Model;
using MYBAR.Model.Xhiro;
using MYBAR.Raports;
using MYBAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MYBAR.View
{
    /// <summary>
    /// Interaction logic for MbyllTurnin.xaml
    /// </summary>
    public partial class MbyllTurnin : Window
    {

        private string UserId;
        private bool KaloTekUser;
        private List<TurnetRowModel> turnetlist;
        private decimal XhirojaDitore;
        public MbyllTurnin(decimal xhiro,decimal xhirofiskale, string userid)
        {
            InitializeComponent();
            KaloTekUser = false;
            XhirojaDitore = xhiro;
           
          
            UserId = userid;
            OtherUsers.ItemsSource = UserService.GetOtherUsers(userid);

            if(RegisterData.ShowAllBillTypes)
            {
                Shuma.Content = xhiro.ToString("#,#0.00");
            }
            else
            {
                Shuma.Content = xhirofiskale.ToString("#,#0.00");
            }
           
            turnetlist= FinanceService.MerTurnet(DateTime.Now, DateTime.Now, userid);
            TurnetEPara.ItemsSource = turnetlist;

            if (hasOpenTable())
            {
                OtherUsers.SelectedIndex = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void mbyllTurn(decimal ShumaEFutur)
        {

           

            int id = FinanceService.MbyllTurn(UserId, ShumaEFutur, ShumaEFutur-XhirojaDitore);
            if (id>=0)
            {
                var turniadded = FinanceService.MerTurnetSync(id);
               


                MainWindow m = (MainWindow)App.Current.MainWindow;

               
                string username = m.UserName;
                var model = FinanceService.getXhiroDitore(UserId);

                model.RequestedForCancelOrders = FinanceService.getOrdersRequestedForCancel(UserId);
                model.CancelOrders = FinanceService.getCancelledOrders(UserId);

                TurnetRowModel turn = new TurnetRowModel {
                    Cash = turniadded.Cash_Total,
                    Total = turniadded.Orders_Total_Sum,
                    Tips = turniadded.Tips_Total_Sum,
                    NrProduktesh = turniadded.Sold_Items_No,
                    NumerFaturash = turniadded.Orders_No,
                    Fiscal_Orders_Total_Sum = turniadded.Fiscal_Orders_Total_Sum,
                    Data=turniadded.Date_Time
                    
                    
                    
                    
                };
                   model.Turni = turn;









               
                

                XhiroDitoreBuilder builder = new XhiroDitoreBuilder(model, username);
                

                //update collected after crete bill
                FinanceService.UpdateUnCollapsedOrders(UserId);

                //refresh gui
                FinanceService.CalculateXhiroDitore();

                Printer.PrintFlowDocumentOneCopy(builder.Document);
               
            
               
            }

            //TurnInfo info = new TurnInfo(XhirojaDitore, ShumaEFutur, ShumaEFutur - XhirojaDitore);
            //info.ShowDialog();
        }
        private bool hasOpenTable()
        {
            var list = TavolinaService.GetAllTables();

            foreach (var item in list)
            {
                if (item.open && item.UserId == UserId)
                {
                   
                    return true;
                }
            }

            return false;
        }

        private bool HasOtherUser()
        {
            if (OtherUsers.Items.Count > 0)
                return true;

            return false;
        }

        private void MbyllTurnBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // MessageBoxResult messageBoxResult = MessageBox.Show("Jeni te sigurt per mbylljen e turnit ?", "Konfirmim", MessageBoxButton.YesNo);
            

                MbyllTurnBtn.Visibility = Visibility.Hidden;

                decimal LekNeXhep = XhirojaDitore;

                //if (decimal.TryParse(CashTotalText.Text, out LekNeXhep))
                //{
                //    //if (LekNeXhep < XhirojaDitore)
                //    //{
                //    //    MessageBox.Show("Parate nuk mund te jene me e vogel se shuma totale !");

                //    //    return;
                //    //}


                //}
                //else
                //{
                //    MessageBox.Show("Shuma e futur duhet te jete numer !");

                //    return;
                //}


                //check if have non closed tavolina for this user

                if (KaloTekUser)
                {
                    //transfero

                    if (TavolinaService.TransferTableToUser(UserId, ((ComboBoxData)OtherUsers.SelectedItem).DataValueOpt).Result)
                    {

                        //pas kalimit perllogaritet xhirua
                        FinanceService.CalculateXhiroDitore();
                        //mbyllet dritarja

                        MessageBox.Show("Tavolinat u transferuan !");
                        Close();
                        return;

                    }

                }

                if (hasOpenTable())
                {
                    var pergjigje = MessageBox.Show("Disa nga tavolinat jane ende  te hapura ,shtypni OK per tia kaluar faturat nje perdoruesi tjeter !", "Kujdes !", MessageBoxButton.YesNo);

                    if (pergjigje == MessageBoxResult.Yes)
                    {
                        KaloTekUser = true;

                        //CashTotalText.Visibility = Visibility.Hidden;
                        //ParaLabel.Visibility = Visibility.Hidden;
                        OnlyBtn.Text = "Transfero";
                    }
                    else
                    {
                        Close();
                    }

                    OtherUsersPanel.Visibility = Visibility.Visible;

                    return;
                }


                if(LekNeXhep>turnetlist.Sum(x=>x.Total))
                mbyllTurn(LekNeXhep);

                e.Handled = true;
                Close();
            }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            if (RegisterData.ShowAllBillTypes)
            {
                TurnetEPara.Columns[2].Visibility = Visibility.Collapsed;

            }
            else
            {
                TurnetEPara.Columns[1].Visibility = Visibility.Collapsed;
            }
        }
    }
}
