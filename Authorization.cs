using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireWarehouse.Model;
using FireWarehouse.Controller;
using FireWarehouse.EntityContext;
using System.Data.Entity;

namespace FireWarehouse
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private IList<User> applicationUser;

       
        private void Authorization_Load(object sender, EventArgs e)
        {
            using (StorehouseContext db = new StorehouseContext())
            {
                db.Users.Load();
                applicationUser = db.Users.Local.ToBindingList();
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            var accept = applicationUser
                .Where(x => x.Login == txtLogin.Text)
                .Where(x => x.Password == txtPassword.Text)
                .Where(x => x.Prioritet == comboBox1.SelectedIndex + 1).FirstOrDefault();

            if (accept != null)
            {
                MainForm IDUser = new MainForm(accept.ID,accept.Prioritet);
                IDUser.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("ERROR");
            }

        }
    }
}
