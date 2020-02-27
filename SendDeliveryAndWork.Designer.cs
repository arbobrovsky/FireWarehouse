namespace FireWarehouse
{
    partial class SendDeliveryAndWork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAdressConsignee = new System.Windows.Forms.TextBox();
            this.comboDeliveryMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboFIODriver = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.countLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.NDSSumma = new System.Windows.Forms.ToolStripStatusLabel();
            this.PriceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboWorker1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboWorker2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboWorker3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboWorker4 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboWorker5 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderToProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderToProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Оформить!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAdressConsignee
            // 
            this.txtAdressConsignee.Location = new System.Drawing.Point(134, 28);
            this.txtAdressConsignee.Name = "txtAdressConsignee";
            this.txtAdressConsignee.Size = new System.Drawing.Size(201, 20);
            this.txtAdressConsignee.TabIndex = 2;
            // 
            // comboDeliveryMethod
            // 
            this.comboDeliveryMethod.FormattingEnabled = true;
            this.comboDeliveryMethod.Items.AddRange(new object[] {
            "Монтаж устройств",
            "Установка устройств",
            "Монтаж устройств и установка устройств"});
            this.comboDeliveryMethod.Location = new System.Drawing.Point(134, 111);
            this.comboDeliveryMethod.Name = "comboDeliveryMethod";
            this.comboDeliveryMethod.Size = new System.Drawing.Size(201, 21);
            this.comboDeliveryMethod.TabIndex = 3;
            this.comboDeliveryMethod.Text = "Выберите из списка";
            this.comboDeliveryMethod.SelectedIndexChanged += new System.EventHandler(this.comboDeliveryMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата доставки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Тип работы:";
            // 
            // comboFIODriver
            // 
            this.comboFIODriver.FormattingEnabled = true;
            this.comboFIODriver.Location = new System.Drawing.Point(134, 54);
            this.comboFIODriver.Name = "comboFIODriver";
            this.comboFIODriver.Size = new System.Drawing.Size(201, 21);
            this.comboFIODriver.TabIndex = 3;
            this.comboFIODriver.Text = "Выберите из списка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Адрес грузополучателя:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(134, 83);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(201, 20);
            this.txtDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ФИО водителя:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.productDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.countProductDataGridViewTextBoxColumn,
            this.measureDataGridViewTextBoxColumn,
            this.orderDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.orderToProductBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(967, 178);
            this.dataGridView1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countLabel,
            this.PriceLabel,
            this.NDSSumma});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(967, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // countLabel
            // 
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(135, 17);
            this.countLabel.Text = "Количество продуктов:";
            this.countLabel.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // NDSSumma
            // 
            this.NDSSumma.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NDSSumma.IsLink = true;
            this.NDSSumma.Name = "NDSSumma";
            this.NDSSumma.Size = new System.Drawing.Size(90, 17);
            this.NDSSumma.Text = "с учетом  НДС:";
            // 
            // PriceLabel
            // 
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(88, 17);
            this.PriceLabel.Text = "Общая сумма:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Рабочй 1";
            // 
            // comboWorker1
            // 
            this.comboWorker1.FormattingEnabled = true;
            this.comboWorker1.Location = new System.Drawing.Point(68, 22);
            this.comboWorker1.Name = "comboWorker1";
            this.comboWorker1.Size = new System.Drawing.Size(320, 21);
            this.comboWorker1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Рабочй 2:";
            // 
            // comboWorker2
            // 
            this.comboWorker2.FormattingEnabled = true;
            this.comboWorker2.Location = new System.Drawing.Point(68, 49);
            this.comboWorker2.Name = "comboWorker2";
            this.comboWorker2.Size = new System.Drawing.Size(320, 21);
            this.comboWorker2.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Рабочй 3:";
            // 
            // comboWorker3
            // 
            this.comboWorker3.FormattingEnabled = true;
            this.comboWorker3.Location = new System.Drawing.Point(68, 76);
            this.comboWorker3.Name = "comboWorker3";
            this.comboWorker3.Size = new System.Drawing.Size(320, 21);
            this.comboWorker3.TabIndex = 3;
            this.comboWorker3.SelectedIndexChanged += new System.EventHandler(this.comboWorker3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Рабочй 4:";
            // 
            // comboWorker4
            // 
            this.comboWorker4.FormattingEnabled = true;
            this.comboWorker4.Location = new System.Drawing.Point(68, 103);
            this.comboWorker4.Name = "comboWorker4";
            this.comboWorker4.Size = new System.Drawing.Size(320, 21);
            this.comboWorker4.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Рабочй 5:";
            // 
            // comboWorker5
            // 
            this.comboWorker5.FormattingEnabled = true;
            this.comboWorker5.Location = new System.Drawing.Point(68, 129);
            this.comboWorker5.Name = "comboWorker5";
            this.comboWorker5.Size = new System.Drawing.Size(320, 21);
            this.comboWorker5.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(290, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(29, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "6";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Ставка НДС:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(320, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboWorker5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboWorker1);
            this.groupBox1.Controls.Add(this.comboWorker2);
            this.groupBox1.Controls.Add(this.comboWorker4);
            this.groupBox1.Controls.Add(this.comboWorker3);
            this.groupBox1.Location = new System.Drawing.Point(368, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 187);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список работников задействованных для работы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtAdressConsignee);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.comboFIODriver);
            this.groupBox2.Controls.Add(this.comboDeliveryMethod);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 187);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отправление товара ";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // productDataGridViewTextBoxColumn
            // 
            this.productDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productDataGridViewTextBoxColumn.DataPropertyName = "Product";
            this.productDataGridViewTextBoxColumn.HeaderText = "Название";
            this.productDataGridViewTextBoxColumn.Name = "productDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // countProductDataGridViewTextBoxColumn
            // 
            this.countProductDataGridViewTextBoxColumn.DataPropertyName = "CountProduct";
            this.countProductDataGridViewTextBoxColumn.HeaderText = "Кол.";
            this.countProductDataGridViewTextBoxColumn.Name = "countProductDataGridViewTextBoxColumn";
            // 
            // measureDataGridViewTextBoxColumn
            // 
            this.measureDataGridViewTextBoxColumn.DataPropertyName = "Measure";
            this.measureDataGridViewTextBoxColumn.HeaderText = "ед.";
            this.measureDataGridViewTextBoxColumn.Name = "measureDataGridViewTextBoxColumn";
            // 
            // orderDataGridViewTextBoxColumn
            // 
            this.orderDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orderDataGridViewTextBoxColumn.DataPropertyName = "Order";
            this.orderDataGridViewTextBoxColumn.HeaderText = "Адрес доставки";
            this.orderDataGridViewTextBoxColumn.Name = "orderDataGridViewTextBoxColumn";
            // 
            // orderToProductBindingSource
            // 
            this.orderToProductBindingSource.DataSource = typeof(FireWarehouse.Model.OrderToProduct);
            // 
            // SendDeliveryAndWork
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(967, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendDeliveryAndWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправка товара";
            this.Load += new System.EventHandler(this.SendDeliveryAndWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderToProductBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAdressConsignee;
        private System.Windows.Forms.ComboBox comboDeliveryMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFIODriver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel countLabel;
        private System.Windows.Forms.ToolStripStatusLabel NDSSumma;
        private System.Windows.Forms.ToolStripStatusLabel PriceLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboWorker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboWorker3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboWorker4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboWorker5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countProductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource orderToProductBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}