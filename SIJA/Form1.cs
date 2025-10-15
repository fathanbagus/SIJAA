using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIJA
{
    public partial class FormLogin : Form
    {
        public static string name;
        public FormLogin()
        {
            InitializeComponent();
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {
            tbName.Text = "Fathan";
            tbPass.Text = "1234";
        }
        private void btnLogin_Click(object sender, EventArgs e) 
        {
            if (tbName.Text == "" || tbPass.Text == "")
            {
                MessageBox.Show("All field must be filled");
                return;
            }
            var db = new DataBaseDataContext();

            var user = db.Teacher_Tables.Where(x => x.name == tbName.Text && x.password == tbPass.Text).FirstOrDefault();

            if (user != null)
            {
                Helper.id = user.id;
                Helper.password = user.password;
                new FormMain(user.name).Show();

                Hide();
            }
            else
            {
                MessageBox.Show("Your dat is not valid!!");

                tbName.Text = "";
                tbPass.Text = "";
            }
        }
    }
}
