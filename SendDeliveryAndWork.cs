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
    public partial class SendDeliveryAndWork : Form
    {
        private IList<UserProfile> applicationProfile;
        private IList<Order> applicationOrder;
        private IList<OrderToProduct> applicationOrderToProduct;

        public SendDeliveryAndWork()
        {
            InitializeComponent();
        }
        private int IDOrder;
        public SendDeliveryAndWork(int orderID)
        {
            InitializeComponent();
            IDOrder = orderID;
        }


        private StorehouseContext db = new StorehouseContext();

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Persone()
        {
            var display = applicationProfile.OrderBy(x => x.Id).ToList();
            var bindingList = new BindingList<UserProfile>(display);
            var bindingSource = new BindingSource(bindingList, null);
            comboWorker1.DataSource = bindingSource;
            comboWorker1.DisplayMember = "FIO";

        }

        private void getOrder()
        {
            var displayOrder = db.Orders.Find(IDOrder);
            if (displayOrder != null)
            {
                txtAdressConsignee.Text = displayOrder.AdressDelivery;
                txtDate.Text = displayOrder.DeliveryDate.ToLongDateString();
                comboFIODriver.Text = displayOrder.Customer.ToString();
            }
        }

        private void getPersone()
        {
            var use = applicationProfile.OrderBy(x => x.Id);
            var drivers = applicationProfile.Where(x => x.Position == "Водитель");
            foreach (var t in use)
            {
                comboWorker1.Items.Add(t.FIO + " | " + t.Position);
                comboWorker2.Items.Add(t.FIO + " | " + t.Position);
                comboWorker3.Items.Add(t.FIO + " | " + t.Position);
                comboWorker4.Items.Add(t.FIO + " | " + t.Position);
                comboWorker5.Items.Add(t.FIO + " | " + t.Position);
            }
            foreach (var t in drivers)
            {
                comboFIODriver.Items.Add(t.FIO);
            }
        }

        private void displayOrderToProducts(IList<OrderToProduct> redrd)
        {
            var bindingList = new BindingList<OrderToProduct>(redrd);
            var bindingSource = new BindingSource(bindingList, null);
            dataGridView1.DataSource = bindingSource;

        }
        private decimal summa;
        private void Calculated()
        {
            var calculated = applicationOrderToProduct.OrderBy(x => x.Id);


            foreach (var t in calculated)
            {
                summa += t.Price;
            }
            decimal rashet = (summa / 100) * Convert.ToDecimal(textBox1.Text);
            NDSSumma.Text = " Сумма с учетом НДС: " + (summa + rashet).ToString();
            PriceLabel.Text = " Сумма:" + (summa).ToString();
        }

        private async void SendDeliveryAndWork_Load(object sender, EventArgs e)
        {
            applicationOrderToProduct = await Controller.Controller.getOrderToProductAsync();
            displayOrderToProducts(applicationOrderToProduct.Where(x => x.OrderId == IDOrder).ToList());
            countLabel.Text = "Количество продуктов: " + dataGridView1.RowCount.ToString();
            db.UserProfiles.Load();
            db.Orders.Load();

            applicationProfile = db.UserProfiles.Local.ToBindingList();
            applicationOrder = db.Orders.Local.ToBindingList();

            getPersone();
            getOrder();
            Calculated();
        }


        public void testWord()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var deliveryAndWork = new DeliveryAndWork()
            {
                DriverFIO = comboFIODriver.Text,
                OrderId = IDOrder,
                Typeofwork = comboDeliveryMethod.Text,
                Worker1 = comboWorker1.Text,
                Worker2 = comboWorker2.Text,
                Worker3 = comboWorker3.Text,
                Worker4 = comboWorker4.Text,
                Worker5 = comboWorker5.Text
            };
            db.DeliverysAndWorks.Add(deliveryAndWork);
            db.SaveChanges();
        }

        private void comboWorker3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboDeliveryMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
