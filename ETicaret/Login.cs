using EasyTabs;
using ETicaret.Model.Entity;
using ETicaret.Model.LogClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaret
{
    public partial class Login : Form
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //DATABASE CLASSES
        TrendyolDB db = new TrendyolDB();//BU TrendyolDB BAĞLANTI CLASS'I
        ProgramLogInsert prlg;//BU PROGRAMDAKİ DB ERRORLARIN KAYIT ALTINA ALAN CLASS'A TANIMLANMIŞ ÖĞE
        UserLogInsert usrlg;//BU KULLANICILARIN DB İŞLEMLERİNİ KAYIT ALTINA ALAN CLASS'A TANIMLANMIŞ ÖĞE
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static User LoggedUser { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = db.Users.Where(x => x.UserName == textBox1.Text && x.Password == textBox2.Text).ToList();
            if (data.Count == 1)
            {
                LoggedUser = data.FirstOrDefault();
                this.Hide();
                Form1 fr1 = new Form1();
                fr1.Show();
                usrlg = new UserLogInsert(data[0].ID, "Uygulamaya Giriş Yapıldı");
            }
            else
            {
                MessageBox.Show("Hatalı giriş yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
