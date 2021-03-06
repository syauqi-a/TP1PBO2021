using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1DPBO
{
    public partial class Login : Form
    {
        private string uname;
        private string ps;
        private void closeForm()
        {
            this.Close();
        }
        public Login()
        {
            InitializeComponent();
            tbPass.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            uname = tbUname.Text.ToString();
            ps = tbPass.Text.ToString();
            if (uname != "" && ps != "")
            {
                if (ps == "pbo123")
                {
                    MessageBox.Show("Hi " + uname + ", welcome!");
                    this.Hide();
                    var menuUtama = new MenuUtama(uname);
                    menuUtama.Closed += (s, args) => MessageBox.Show("Thank you for your visit. See you next time " + uname + " ^.^");
                    menuUtama.Closed += (s, args) => this.Show();
                    menuUtama.Show();
                }
                else
                    MessageBox.Show("Your password is incorrect!");
            }else
                MessageBox.Show("Please fill in all the blanks!");
        }
    }
}
