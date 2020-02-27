using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using FireWarehouse.Model;
using FireWarehouse.EntityContext;

namespace FireWarehouse
{
    public partial class AddUser : Form
    {


        public AddUser()
        {
            InitializeComponent();
        }

        private void loadUsers()
        {
            using (StorehouseContext db = new StorehouseContext())
            {
                db.Users.Load();
                dataGridView1.DataSource = db.Users.Local.ToBindingList();
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            loadUsers();

        }

        public void AddUsers()
        {
            using (StorehouseContext db = new StorehouseContext())
            {
                if (txtLogin.Text != null || txtPassword != null)
                {
                    if (txtAcceptPass.Text == txtPassword.Text)
                    {
                        if (txtFiOUser.Text != null || txtAgeUser.Text != null)
                        {
                            var user = new User()
                            {
                                Login = txtLogin.Text,
                                Password = txtPassword.Text,
                                Prioritet = comboAccept.SelectedIndex + 1
                            };
                            db.Users.AddRange(new List<User> { user });
                            db.SaveChanges();

                            var profile = new UserProfile
                            {
                                Id = user.ID,
                                FIO = txtFiOUser.Text,
                                Age = Convert.ToInt32(txtAgeUser.Text),
                                Position = comboAccept.Text,
                                UserId = user.ID
                            };
                            db.UserProfiles.AddRange(new List<UserProfile> { profile });
                            db.SaveChanges();
                            MessageBox.Show("Пользователь добавлен");
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUsers();
            loadUsers();
        }
    }
}
