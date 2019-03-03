using MYBAR.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;

namespace MYBAR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Mutex mutex;

        private string NewVer;
        private string OldVer;
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {

            bool newMutext;
            mutex = new Mutex(true,
                "SingleInstanceAppication", out newMutext);
            if (!newMutext)
            {
                MessageBox.Show("Programi eshte i hapur");
                Current.Shutdown();
                return;
            }
            else
            {
                MainWindow M = new MYBAR.MainWindow();
                M.Show();
                Thread th = new Thread(AutoUpdate);
                    
                   th.Start();
            }



            base.OnStartup(e);
            

        }

        protected override void OnExit(ExitEventArgs e)
        {
            mutex.Dispose();
            base.OnExit(e);
        }


        public void AutoUpdate()
        {

          



        }

    }
}
