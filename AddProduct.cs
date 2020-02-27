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
using FireWarehouse.EntityContext;
using FireWarehouse.Controller;
using System.IO;
using System.Data.Entity;

namespace FireWarehouse
{
    public partial class AddProduct : Form
    {
        private int IdUser;
        public AddProduct(int id)
        {
            InitializeComponent();
            IdUser = id;
        }
        private string path = Application.StartupPath.ToString() + "/images";
        private string LoadImage;
        private string LoadScheme;

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(LoadImage+"\n" +LoadScheme);
            using (StorehouseContext db = new StorehouseContext())
            {
                if (txtFIOpvd.Text.Length > 0 && txtAdresprv.Text.Length > 0 && dateTimeGet.Value.Date != null)
                {
                    var provider = new Provider()
                    {
                        FIO = txtFIOpvd.Text,
                        Legaladdress = txtAdresprv.Text,
                        dateProviderProduct = dateTimeGet.Value.Date,

                    };
                    db.Providers.Add(provider);
                    db.SaveChanges();
                    if (txtNameProduct.Text.Length > 0 && txtCount.Text.Length > 0 && txtPrvd.Text.Length > 0
                        && ComboEdSize.Text.Length > 0 && dateDid.Value.Date != null && dateTimeGet.Value.Date != null && txtPrice.Text.Length > 0)
                    {
                        if (LoadImage.Length > 0 && LoadScheme.Length > 0)
                        {
                            if (richTextBox1.Text.Length > 0)
                            {

                                var product = new Product()
                                {
                                    NameProduct = txtNameProduct.Text,
                                    CountProductOnStorehome = Convert.ToInt32(txtCount.Text),
                                    NameFirma = txtPrvd.Text,
                                    Measure = ComboEdSize.SelectedItem.ToString(),
                                    CreateOn = dateDid.Value.Date,
                                    ReceiptDate = dateTimeGet.Value.Date,
                                    PriceProduct = Convert.ToDecimal(txtPrice.Text),
                                    ProviderId = provider.ID,
                                    Images = LoadImage,
                                    ImageScheme = LoadScheme,
                                    InformationProduct = richTextBox1.Text,
                                    UserId = IdUser

                                };
                                db.Products.AddRange(new List<Product> { product });
                                db.SaveChanges();
                                SaveFile();
                                MessageBox.Show("Добавлен!");
                            }
                            else { MessageBox.Show("Добавьте изображение!"); }
                        }
                        else { MessageBox.Show("Добавьте описание!"); }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                }
            }
        }
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IdUser.ToString());
        }

        private void btnLoadScheme_Click(object sender, EventArgs e)
        {

        }

        private void SaveFile()
        {
            string path = Application.StartupPath.ToString() + "/text";
            StreamWriter textFile = new StreamWriter(path + "/" + txtNameProduct.Text + ".txt");
            textFile.WriteLine(richTextBox1.Text);
            textFile.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathFIle = openFileDialog1.FileName;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                Image img = Image.FromStream(fs);
                fs.Close();
                btnLoadScheme.Image = img;

                //save Схема

                try
                {
                    File.Copy(pathFIle, path + "\\" + Path.GetFileName(pathFIle));
                    LoadScheme = Path.GetFileName(pathFIle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathFIle = openFileDialog1.FileName;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                Image img = Image.FromStream(fs);
                fs.Close();
                btnLoadImage.Image = img;

                //save image
                try
                {
                    File.Copy(pathFIle, path + "\\" + Path.GetFileName(pathFIle));
                    LoadImage = Path.GetFileName(pathFIle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("ID пользователя:{0}", IdUser);
            StorehouseContext db = new StorehouseContext();
            db.Products.Load();
            var bindingSource = new BindingSource(db.Products.Local.ToBindingList(), null);
            dataGridView1.DataSource = bindingSource;



        }
    }
}
