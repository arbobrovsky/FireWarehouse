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
using System.Data.Entity;
using System.IO;
namespace FireWarehouse
{
    public partial class MainForm : Form
    {
        private UserIdentification IdentificationId = new UserIdentification();

        public MainForm(int id, int Prioritet)
        {
            InitializeComponent();
            IdentificationId.IDUser = id;
            IdentificationId.Prioritet = Prioritet;
        }

        private IList<Product> applicationProduct;
        private IList<OrderToProduct> applicationOrderToProduct;
        private IList<Customer> applicationCustomer;
        private IList<Order> applicationOrdering;
        private IList<UserProfile> applicationUserProfel;

        private StorehouseContext db = new StorehouseContext();


        public void displayCustomer(IList<Customer> redrd)
        {
            var bindingList = new BindingList<Customer>(redrd);
            var bindingSource = new BindingSource(bindingList, null);
            dbGridClient.DataSource = bindingSource;
        }
        public void displayProduct(IList<Product> redrd)
        {
            var bindingList = new BindingList<Product>(redrd);
            var bindingSource = new BindingSource(bindingList, null);
            listProducts.DataSource = bindingSource;
            gridCatalog.DataSource = bindingSource;
        }

        public void displayOrder(IList<Order> redrd)
        {
            var bindingList = new BindingList<Order>(redrd);
            var bindingSource = new BindingSource(bindingList, null);
            gridOrder.DataSource = bindingSource;
        }

        public void displayOrderToProducts(IList<OrderToProduct> redrd)
        {
            var bindingList = new BindingList<OrderToProduct>(redrd);
            var bindingSource = new BindingSource(bindingList, null);
            gridOrderToProduct.DataSource = bindingSource;
            gridOrderProduct.DataSource = bindingSource;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }

        private void Massage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void PersonalArea()// личный кабинет 
        {
            db.UserProfiles.Load();
            applicationUserProfel = db.UserProfiles.Local.ToBindingList();
            var UserProfile = applicationUserProfel.Where(x => x.UserId == IdentificationId.IDUser).FirstOrDefault();
            LabelStatusPersone.Text = string.Format("{0}, {1}, идентификационный номер: {2}", UserProfile.FIO, UserProfile.Position, IdentificationId.IDUser);
        }


        private async void MainForm_Load(object sender, EventArgs e)
        {
            PersonalArea();
            applicationProduct = await Controller.Controller.getProductAsync();
            applicationCustomer = await Controller.Controller.getCustomerAsync();
            applicationOrdering = await Controller.Controller.getOrderAsync();
            applicationOrderToProduct = await Controller.Controller.getOrderToProductAsync();

            var displayData = applicationProduct.OrderBy(x => x.Id).ToList();
            displayProduct(displayData);

            var displayCustomers = applicationCustomer.OrderBy(x => x.Id).ToList();
            displayCustomer(displayCustomers);


            var ordirings = applicationOrdering.OrderBy(x => x.Id).ToList();
            displayOrder(ordirings);

            LabelOrderInfo.Text = "Количество заказов: " + (gridOrder.RowCount).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(IdentificationId.IDUser);
            addProduct.ShowDialog();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (NewClientChBox.Checked == true)
            {
                if (txtFIOCustomer.Text.Length > 0 && txtPasportCustomer.Text.Length > 0 && txtSityCustomer.Text.Length > 0 && txtAdressCustomer.Text.Length > 0 && txtPhoneCustomer.Text.Length > 0 && txtMailCustomer.Text.Length > 0 && TimeCreateOnCustomer.Value.Date != null)
                {
                    var searchBy = applicationCustomer.Where(x => x.PasportData == txtPasportCustomer.Text.Replace(" ", string.Empty)).FirstOrDefault();
                    if (searchBy == null)
                    {
                        var Customer = new Customer()
                        {
                            FIOClient = txtFIOCustomer.Text,
                            PasportData = txtPasportCustomer.Text.Replace(" ", string.Empty),
                            Sity = txtSityCustomer.Text,
                            Adress = txtAdressCustomer.Text,
                            Phone = txtPhoneCustomer.Text,
                            Email = txtMailCustomer.Text,
                            CreateOnCustomer = TimeCreateOnCustomer.Value.Date
                        };
                        db.Customers.Add(Customer);
                        db.SaveChanges();
                        applicationCustomer = await Controller.Controller.getCustomerAsync();
                        displayCustomer(applicationCustomer);
                    }
                    else
                    {
                        Massage("Этот клиент уже есть в базе данных!");
                    }
                }
                else
                {
                    Massage("Одно из полей не заполненно!");
                }
            }

        }

        private async void Ordering_Click(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            if (txtAdressDelivery.Text.Length > 0)
            {
                var searchByCustomer = applicationCustomer.Where(x => x.PasportData == txtPasportCustomer.Text).FirstOrDefault();
                if (searchByCustomer != null)
                {
                    var searchByOrderuing = applicationOrdering.Where(x => x.CustomerId == searchByCustomer.Id).FirstOrDefault();
                    if (searchByCustomer != null)
                    {
                        if (searchByOrderuing == null)
                        {
                            var order = new Order()
                            {
                                AdressDelivery = txtAdressDelivery.Text,
                                DeliveryDate = dateDeliveryDate.Value.Date,
                                OrderDate = thisDay,
                                CustomerId = searchByCustomer.Id
                            };
                            db.Orders.Add(order);
                            db.SaveChanges();

                            applicationOrdering = await Controller.Controller.getOrderAsync();
                            var testing = applicationOrdering.Where(x => x.CustomerId == searchByCustomer.Id).FirstOrDefault();
                            if (testing != null)
                            {
                                LabelStatusOrder.Text = "Заказ оформлен!";
                            }
                            else
                            {
                                LabelStatusOrder.Text = "Оформите заказ!";
                            }
                        }
                        else
                        {
                            Massage("Клиент с такими данными уже оформлен заказ");
                        }
                    }
                    else
                    {
                        Massage("Клиент с таким ID не найден!");
                    }
                }
                else
                {
                    Massage("Клиент с таким ID не найден!");
                }
            }
            else
            {
                Massage("Адресная строка не заполнена, введите адрес доставки");
            }
            applicationCustomer = await Controller.Controller.getCustomerAsync();
            applicationOrdering = await Controller.Controller.getOrderAsync();
            applicationOrderToProduct = await Controller.Controller.getOrderToProductAsync();

        }

        private int IDCustomer;
        private void dbGridClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oldClientChBox.Checked == true)
            {
                var Values = dbGridClient.CurrentRow.DataBoundItem as Customer;
                if (Values != null)
                {
                    txtFIOCustomer.Text = Values.FIOClient;
                    txtPasportCustomer.Text = Values.PasportData;
                    IDCustomer = Values.Id;
                    txtSityCustomer.Text = Values.Sity;
                    txtAdressCustomer.Text = Values.Adress;
                    txtPhoneCustomer.Text = Values.Phone;
                    txtMailCustomer.Text = Values.Email;
                    TimeCreateOnCustomer.Value = Convert.ToDateTime(Values.CreateOnCustomer.Date);


                    var getOrderingAndProducts = applicationOrdering.Where(x => x.CustomerId == Values.Id).FirstOrDefault();
                    if (getOrderingAndProducts != null)
                    {
                        if (getOrderingAndProducts != null)
                            txtAdressDelivery.Text = getOrderingAndProducts.AdressDelivery;
                        var getOrderToProduct = applicationOrderToProduct.Where(x => getOrderingAndProducts.Id == x.OrderId).ToList();
                        if (getOrderToProduct != null)
                            displayOrderToProducts(getOrderToProduct);
                        else Massage("ERROR");
                        LabelStatusOrder.Text = "Заказ оформлен!";
                    }
                    else
                    {
                        LabelStatusOrder.Text = "Оформите заказ!";
                    }

                }
            }
        }

        private void txtFIOCustomer_TextChanged(object sender, EventArgs e)
        {
            if (txtFIOCustomer.Text.Length > 0)
            {
                var displayData = applicationCustomer.Where(x => x.FIOClient.Contains(txtFIOCustomer.Text)).ToList();
                displayCustomer(displayData);
            }
            else
            {
                displayCustomer(applicationCustomer);
            }
        }


        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            var Values = dbGridClient.CurrentRow.DataBoundItem as Customer;
            var customerId = applicationCustomer.Where(x => x.PasportData == txtPasportCustomer.Text).FirstOrDefault();

            //  MessageBox.Show(OrderId.Id.ToString());
            if (customerId != null)
            {
                var OrderId = applicationOrdering.Where(x => x.CustomerId == customerId.Id).FirstOrDefault();
                if (OrderId != null)
                {
                    int ID = OrderId.Id;
                    var FindIdOrder = db.Orders.Find(ID);
                    var productID = applicationProduct.Where(x => x.NameProduct == txtNameProduct.Text).FirstOrDefault();

                    //  Massage(FindIdOrder.Id.ToString());
                    if (OrderId != null)
                    {
                        if (txtCountProduct.Text.Length > 0)
                        {
                            if (txtNameProduct.Text.Length > 0)
                            {
                                var addProductList = new OrderToProduct()
                                {
                                    OrderId = FindIdOrder.Id,
                                    ProductId = productID.Id,
                                    Measure = txtEd.SelectedItem.ToString(),
                                    CountProduct = Convert.ToInt32(txtCountProduct.Text),
                                    Price = productID.PriceProduct * Convert.ToInt32(txtCountProduct.Text), //подсчет цены  
                                };
                                db.OrdersToProducts.Add(addProductList);
                                db.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Выберите товар!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Поле 'Количество' не заполнено!");
                        }

                    }
                    applicationCustomer = await Controller.Controller.getCustomerAsync();
                    applicationOrdering = await Controller.Controller.getOrderAsync();
                    applicationOrderToProduct = await Controller.Controller.getOrderToProductAsync();
                    var getProduct = applicationOrdering.Where(x => x.CustomerId == Values.Id).FirstOrDefault();
                    var getOrderToProduct = applicationOrderToProduct.Where(x => getProduct.Id == x.OrderId).ToList();
                    if (getOrderToProduct != null)
                        displayOrderToProducts(getOrderToProduct);
                    else Massage("ERROR");
                }
                else
                {
                    Massage("Заказ не найден!");
                }
            }
            else
            {
                Massage("Заказ не найден!");
            }
        }

        private void txtNameProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtNameProduct.Text.Length != 0)
            {
                var displayData = applicationProduct.Where(x => x.NameProduct.Contains(txtNameProduct.Text)).ToList();
                displayProduct(displayData);
            }
            else
            {
                displayProduct(applicationProduct);
            }
        }

        private void listProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Values = listProducts.CurrentRow.DataBoundItem as Product;
            txtNameProduct.Text = Values.NameProduct;
        }

        private void gridOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var Values = gridOrder.CurrentRow.DataBoundItem as Order;
                id = Values.Id;
                var getOrderToProduct = applicationOrderToProduct.Where(x => x.OrderId == Values.Id).ToList();
                if (getOrderToProduct != null)
                    displayOrderToProducts(getOrderToProduct);
                else Massage("ERROR");
            }
            catch (Exception ex) { }
        }


        private void listProducts_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var Values = listProducts.CurrentRow.DataBoundItem as Product;
            txtNameProduct.Text = Values.NameProduct;
            txtEd.Text = Values.Measure;
        }

        private void getColor()
        {
            for (int i = 0; i < gridOrder.RowCount; i++)
            {
                switch (gridOrder.Rows[i].Cells[6].Value.ToString())
                {
                    case "Оформлен":
                        {
                            gridOrder.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                        }
                        break;
                    case
                        "Отказано":
                        {
                            gridOrder.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        break;
                }

            }
        }
        private ComboBox combo;
        private void gridOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            combo = e.Control as ComboBox;
            if (combo != null)
            {
                // AVOID ATTACHMENT TO MULTIPLE EVENT HANDLERS
                combo.SelectedIndexChanged -= new EventHandler(combo_SelectedIndexChanged);
                //THEN NOW ADD
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            }
        }



        private void coloring(string statusOrder, Color color)
        {
            for (int i = 0; i < gridOrder.RowCount; i++)
            {
                if (statusOrder == gridOrder.Rows[i].Cells[6].Value.ToString())
                {
                    gridOrder.Rows[i].DefaultCellStyle.BackColor = color;
                }
            }
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs ex)
        {
            try
            {
                var Values = gridOrder.CurrentRow.DataBoundItem as Order;
                string selected = (sender as ComboBox).SelectedItem.ToString();
                var EditDb = applicationOrdering.Where(x => x.CustomerId == Values.CustomerId).FirstOrDefault();
                var order = db.Orders.Find(EditDb.Id);

                if (EditDb != null)
                {
                    order.StatusOrder = selected;
                }
                if (selected != null)
                {
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {

            }
        }

        private int? id;
        private async void gridOrderProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ValuesOrderToProduct = gridOrderToProduct.CurrentRow.DataBoundItem as OrderToProduct;

            if (ValuesOrderToProduct != null)
            {
                var deleteItem = db.OrdersToProducts.Find(ValuesOrderToProduct.Id);
                if (deleteItem != null)
                {
                    if (e.ColumnIndex == 8)
                    {
                        MessageBox.Show(ValuesOrderToProduct.Id.ToString());
                        db.OrdersToProducts.Remove(deleteItem);
                        db.SaveChanges();
                        applicationOrderToProduct = await Controller.Controller.getOrderToProductAsync();
                        var x = applicationOrderToProduct.Where(xx => xx.OrderId == id).ToList();
                        displayOrderToProducts(x);
                    }
                }
            }
        }

        private void getImage()
        {
            string path = Application.StartupPath.ToString() + "/images";
            for (int i = 0; i < gridCatalog.RowCount; i++)
            {
                string valueImage = gridCatalog.Rows[i].Cells[1].Value.ToString();
                var valueImages = applicationProduct.Where(x => x.NameProduct == valueImage).FirstOrDefault();
                gridCatalog.Rows[i].Cells[2].Value = new Bitmap(path + "/" + valueImages.Images);
                gridCatalog.Rows[i].Cells[3].Value = new Bitmap(path + "/" + valueImages.ImageScheme);
            }
        }



        private void button7_Click(object sender, EventArgs e)
        {

        }


        private async void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

            if (tabControl1.SelectedIndex == 1)
            {
                applicationProduct = await Controller.Controller.getProductAsync();
                displayProduct(applicationProduct.OrderBy(x => x.Id).ToList());
                try
                {
                    getImage();
                }
                catch (Exception ex)
                {   //(MessageBox.Show("Вы действительно хотите удалить?", "Удалить", MessageBoxButtons.YesNo,
                    //  
                    MessageBox.Show(ex.Message + "\nПроверьте формат картинки", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (tabControl1.SelectedIndex == 0)
            {
                var getOrders = applicationOrdering.OrderBy(x => x.Id).ToList();
                if (getOrders != null)
                    displayOrder(getOrders);
            }


            if (tabControl1.SelectedIndex == 3)
            {
            }

        }

        private void NewClientChBox_CheckedChanged(object sender, EventArgs e)
        {
            oldClientChBox.Checked = false;
            txtFIOCustomer.Text = "";
            txtPasportCustomer.Text = "";
            txtSityCustomer.Text = "";
            txtAdressCustomer.Text = "";
            txtPhoneCustomer.Text = "";
            txtMailCustomer.Text = "";
        }

        private void oldClientChBox_CheckedChanged(object sender, EventArgs e)
        {
            NewClientChBox.Checked = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Удалить", MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var ValuesOrder = gridOrder.CurrentRow.DataBoundItem as Order;
                if (ValuesOrder != null)
                {
                    var deleteItem = db.Orders.Find(ValuesOrder.Id);
                    if (deleteItem != null)
                        db.Orders.Remove(deleteItem);

                    var deleteOrderToProducts = db.OrdersToProducts.Where(x => x.OrderId == deleteItem.Id).FirstOrDefaultAsync();
                    if (deleteOrderToProducts != null)
                        db.OrdersToProducts.Remove(await deleteOrderToProducts);

                    db.SaveChanges();

                    applicationOrdering = await Controller.Controller.getOrderAsync();
                    applicationOrderToProduct = await Controller.Controller.getOrderToProductAsync();
                    displayOrder(applicationOrdering.OrderBy(x => x.Id).ToList());
                    displayOrderToProducts(applicationOrderToProduct.OrderBy(x => x.Id).ToList());
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Authorization test = new Authorization();
            test.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            displayOrder(applicationOrdering.OrderBy(x => x.Id).ToList());
        }

        private void товарнотранспортнаяНакладнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Values = gridOrder.CurrentRow.DataBoundItem as Order;
            SendDeliveryAndWork DeliveryAndWork = new SendDeliveryAndWork(Values.Id);
            DeliveryAndWork.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            user.ShowDialog();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
          

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var ValuesOrder = dbGridClient.CurrentRow.DataBoundItem as Customer;
            if (ValuesOrder != null)
            {
                var deleteItemCustomer = db.Customers.Find(ValuesOrder.Id);
                if (deleteItemCustomer != null)
                    db.Customers.Remove(deleteItemCustomer);

                var searchOrder = applicationOrdering.Where(x => x.CustomerId == deleteItemCustomer.Id).FirstOrDefault();
                if (searchOrder != null)
                {
                    var deleteItemOrder = db.Orders.Find(searchOrder.Id);
                    if (deleteItemOrder != null)
                    {
                        db.Orders.Remove(deleteItemOrder);

                        var deleteOrderToProducts = db.OrdersToProducts.Where(x => x.OrderId == deleteItemOrder.Id).FirstOrDefault();
                        if (deleteOrderToProducts != null)
                            db.OrdersToProducts.Remove(deleteOrderToProducts);
                    } 
                }
                db.SaveChanges();
                applicationCustomer = await Controller.Controller.getCustomerAsync();
                applicationOrdering = await Controller.Controller.getOrderAsync();
                applicationOrderToProduct = await Controller.Controller.getOrderToProductAsync();
                displayCustomer(applicationCustomer.OrderBy(x => x.Id).ToList());
                displayOrder(applicationOrdering.OrderBy(x => x.Id).ToList());
                displayOrderToProducts(applicationOrderToProduct.OrderBy(x => x.Id).ToList());
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddProduct user = new AddProduct(IdentificationId.IDUser);
            user.ShowDialog();
        }

        private void gridCatalog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
