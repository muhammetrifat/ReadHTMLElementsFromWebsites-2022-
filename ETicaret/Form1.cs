using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ETicaret.Model.Entity;
using ETicaret.Model.LogClasses;

namespace ETicaret
{
    public partial class Form1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //DATABASE CLASSES
        TrendyolDB db = new TrendyolDB();//BU TrendyolDB BAĞLANTI CLASS'I
        ProgramLogInsert prlg;//BU PROGRAMDAKİ DB ERRORLARIN KAYIT ALTINA ALAN CLASS'A TANIMLANMIŞ ÖĞE
        UserLogInsert usrlg;//BU KULLANICILARIN DB İŞLEMLERİNİ KAYIT ALTINA ALAN CLASS'A TANIMLANMIŞ ÖĞE
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                chromiumWebBrowser1.Load("https://www.trendyol.com/sr?wg=2&wc=73&wb=103500&vr=beden|s");
        }
        public static int startingPosition = 0;
        public static int artisMiktari = 1500;
        //ChromiumWebBrowser browser;
        private void Form1_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://www.trendyol.com/sr?wg=2&wc=73&wb=103500&vr=beden|s");
            //browser = new ChromiumWebBrowser(textBox1.Text);
            //browser.Dock = DockStyle.Fill;
            //this.panel1.Controls.Add(browser);
        }


        private void chromiumWebBrowser1_FrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scrollDown();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //string script = "function myF(){" +
            //    "return document.getElementsByClassName('p-card-wrppr').length;};" +
            //    "myF();";
            //var result = chromiumWebBrowser1.GetMainFrame().EvaluateScriptAsync(script)
            //.ContinueWith(t =>
            //{
            //    var resultt = t.Result;
            //    //listBox1.Items.Add(resultt.Result.ToString());
            //    return resultt.ToString();
            //});
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabMenuNames();
            //listBox1.Items.Add("Tamamlandı");
        }

        void scrollDown()
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    string script = "function myF(){" +
            //    " const collection = document.getElementsByClassName('prc-box-dscntd');" +
            //    "return collection[" + i + "].innerHTML};" +
            //    "myF();";
            //    var result = chromiumWebBrowser1.GetMainFrame().EvaluateScriptAsync(script)
            //    .ContinueWith(t =>
            //    {
            //        var resultt = t.Result;
            //        listBox1.Items.Add(resultt.Result.ToString());
            //        return resultt.ToString();
            //    });
            //}



            //string deger = "";
            //string script = "const collection = document.getElementsByClassName('prc-box-dscntd'); " +
            //    "collection[0].innerHTML = 'Hello World!';";
            //chromiumWebBrowser1.ExecuteScriptAsync(script);

            //string script = "window.scrollTo(" + startingPosition + ", " + (startingPosition + artisMiktari) + ");";
            //chromiumWebBrowser1.ExecuteScriptAsync(script);
            //startingPosition += artisMiktari;
        }

        void urunLinklerini()
        {
            for (int i = 0; i < 3; i++)
            {
                string script = "function myF(){" +
                "var targetDiv = document.getElementsByClassName('p-card-chldrn-cntnr')[" + i + "].getElementsByTagName('A')[0].href;" +
                "return targetDiv;}" +
                "myF();";
                var result = chromiumWebBrowser1.GetMainFrame().EvaluateScriptAsync(script)
                .ContinueWith(t =>
                {
                    var resultt = t.Result;
                    listBox1.Items.Add(resultt.Result.ToString());
                    return resultt.ToString();
                });
            }
        }
        public static int tabMenuCount;
        public static string[] nameArray = new string[tabMenuCount];
        void tabMenuNames()
        {
            string tabMenuLengthScript = "function myF(){" +
                "return document.getElementsByClassName('tab-link').length;};" +
                "myF();";
            var tabMenuLengthResult = chromiumWebBrowser1.GetMainFrame().EvaluateScriptAsync(tabMenuLengthScript)
            .ContinueWith(t =>
            {
                var resultt = t.Result;
                tabMenuCount = Convert.ToInt32(resultt.Result);
                for (int i = 0; i < tabMenuCount; i++)
                {
                    
                    string script = "function myF(){" +
                    "if ("+i+" == "+(tabMenuCount - 1) +") {" +
                    "var targetDiv = document.getElementsByClassName('tab-link')[" + i + "].getElementsByTagName('A')[0].innerHTML + ' | Tamamlandı';return targetDiv;" +
                    "} else {" +
                    "var targetDiv = document.getElementsByClassName('tab-link')[" + i + "].getElementsByTagName('A')[0].innerHTML;return targetDiv;" +
                    "}" +
                    "}" +
                    "myF();";
                    var result = chromiumWebBrowser1.GetMainFrame().EvaluateScriptAsync(script)
                    .ContinueWith(y =>
                    {
                        var resultt1 = y.Result;
                        listBox1.Items.Add(resultt1.Result.ToString());
                        return resultt1.ToString();
                    });
                }
                return resultt.ToString();
            });
        }

        void tabMenuInsert(string name)
        {
            TabMenu tabMenuData = new TabMenu();
            tabMenuData.Name = name;
            tabMenuData.CreateDate = DateTime.Now;
            tabMenuData.CreateUserID = Login.LoggedUser.ID;
            db.TabMenus.Add(tabMenuData);
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == tabMenuCount)
            {
                MessageBox.Show("Tamamlandı!");
                //for (int i = 0; i < tabMenuCount; i++)
                //{
                //    tabMenuInsert(listBox1.Items[i].ToString());
                //}
            }
            else
            {
                MessageBox.Show("Devam ediyor..");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(0);
        }
    }
}
