using EasyTabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaret
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.Run(new Form1());




            //AppContainer container = new AppContainer();
            //container.Tabs.Add(new EasyTabs.TitleBarTab(container)
            //{
            //    Content = new Form1
            //    {
            //        Text = "Yeni Sekme"
            //    }
            //});
            //container.SelectedTabIndex = 0;
            //TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            //applicationContext.Start(container);
            //Control.CheckForIllegalCrossThreadCalls = false;
            //
            //Application.Run(applicationContext);
        }
    }
}
