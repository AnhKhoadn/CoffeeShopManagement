
namespace CoffeeShopManagement
{
    partial class fTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCaNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuâtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCombineTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnSwitchTable = new System.Windows.Forms.Button();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmBeverageCount = new System.Windows.Forms.NumericUpDown();
            this.btnMinusBeverage = new System.Windows.Forms.Button();
            this.btnAddBeverage = new System.Windows.Forms.Button();
            this.cbBeverage = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBeverageCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinCaNhânToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.adminToolStripMenuItem.Text = "Quản lý";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinCaNhânToolStripMenuItem
            // 
            this.thôngTinCaNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountProfileToolStripMenuItem,
            this.đăngXuâtToolStripMenuItem});
            this.thôngTinCaNhânToolStripMenuItem.Name = "thôngTinCaNhânToolStripMenuItem";
            this.thôngTinCaNhânToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.thôngTinCaNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            // 
            // accountProfileToolStripMenuItem
            // 
            this.accountProfileToolStripMenuItem.Name = "accountProfileToolStripMenuItem";
            this.accountProfileToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.accountProfileToolStripMenuItem.Text = "Thông tin tài khoản";
            this.accountProfileToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTaiKhoanToolStripMenuItem_Click);
            // 
            // đăngXuâtToolStripMenuItem
            // 
            this.đăngXuâtToolStripMenuItem.Name = "đăngXuâtToolStripMenuItem";
            this.đăngXuâtToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.đăngXuâtToolStripMenuItem.Text = "đăng xuất";
            this.đăngXuâtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuâtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(561, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 361);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(3, 3);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(488, 355);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên đồ uống";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 70;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnCombineTable);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txbTotalPrice);
            this.panel3.Controls.Add(this.nmDiscount);
            this.panel3.Controls.Add(this.btnSwitchTable);
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.btnCheckOut);
            this.panel3.Location = new System.Drawing.Point(565, 493);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 131);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Giảm giá (%)";
            // 
            // btnCombineTable
            // 
            this.btnCombineTable.Location = new System.Drawing.Point(4, 21);
            this.btnCombineTable.Name = "btnCombineTable";
            this.btnCombineTable.Size = new System.Drawing.Size(137, 28);
            this.btnCombineTable.TabIndex = 8;
            this.btnCombineTable.Text = "Gộp bàn";
            this.btnCombineTable.UseVisualStyleBackColor = true;
            this.btnCombineTable.Click += new System.EventHandler(this.btnCombineTable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tổng tiền:";
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.ForeColor = System.Drawing.Color.Coral;
            this.txbTotalPrice.Location = new System.Drawing.Point(295, 21);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(192, 28);
            this.txbTotalPrice.TabIndex = 6;
            this.txbTotalPrice.Text = "0";
            this.txbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nmDiscount
            // 
            this.nmDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmDiscount.Location = new System.Drawing.Point(151, 104);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(138, 22);
            this.nmDiscount.TabIndex = 5;
            // 
            // btnSwitchTable
            // 
            this.btnSwitchTable.Location = new System.Drawing.Point(3, 69);
            this.btnSwitchTable.Name = "btnSwitchTable";
            this.btnSwitchTable.Size = new System.Drawing.Size(138, 29);
            this.btnSwitchTable.TabIndex = 4;
            this.btnSwitchTable.Text = "Chuyển bàn";
            this.btnSwitchTable.UseVisualStyleBackColor = true;
            this.btnSwitchTable.Click += new System.EventHandler(this.btnSwitchTable_Click);
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(3, 102);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(138, 24);
            this.cbSwitchTable.TabIndex = 1;
            this.cbSwitchTable.Text = "Chọn bàn";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(295, 70);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(192, 58);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Thanh toán";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            this.btnCheckOut.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmBeverageCount);
            this.panel4.Controls.Add(this.btnMinusBeverage);
            this.panel4.Controls.Add(this.btnAddBeverage);
            this.panel4.Controls.Add(this.cbBeverage);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(561, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(494, 87);
            this.panel4.TabIndex = 4;
            // 
            // nmBeverageCount
            // 
            this.nmBeverageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmBeverageCount.Location = new System.Drawing.Point(408, 29);
            this.nmBeverageCount.Name = "nmBeverageCount";
            this.nmBeverageCount.Size = new System.Drawing.Size(79, 22);
            this.nmBeverageCount.TabIndex = 3;
            this.nmBeverageCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnMinusBeverage
            // 
            this.btnMinusBeverage.Location = new System.Drawing.Point(306, 44);
            this.btnMinusBeverage.Name = "btnMinusBeverage";
            this.btnMinusBeverage.Size = new System.Drawing.Size(93, 28);
            this.btnMinusBeverage.TabIndex = 2;
            this.btnMinusBeverage.Text = "Bớt món";
            this.btnMinusBeverage.UseVisualStyleBackColor = true;
            this.btnMinusBeverage.Click += new System.EventHandler(this.btnMinusBeverage_Click);
            // 
            // btnAddBeverage
            // 
            this.btnAddBeverage.Location = new System.Drawing.Point(306, 13);
            this.btnAddBeverage.Name = "btnAddBeverage";
            this.btnAddBeverage.Size = new System.Drawing.Size(93, 28);
            this.btnAddBeverage.TabIndex = 2;
            this.btnAddBeverage.Text = "Thêm món";
            this.btnAddBeverage.UseVisualStyleBackColor = true;
            this.btnAddBeverage.Click += new System.EventHandler(this.btnAddBeverage_Click);
            // 
            // cbBeverage
            // 
            this.cbBeverage.FormattingEnabled = true;
            this.cbBeverage.Location = new System.Drawing.Point(4, 45);
            this.cbBeverage.Name = "cbBeverage";
            this.cbBeverage.Size = new System.Drawing.Size(296, 24);
            this.cbBeverage.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(4, 15);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(296, 24);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(13, 32);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(542, 592);
            this.flpTable.TabIndex = 5;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 636);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán Cafe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmBeverageCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCaNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuâtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbBeverage;
        private System.Windows.Forms.Button btnAddBeverage;
        private System.Windows.Forms.NumericUpDown nmBeverageCount;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.Button btnSwitchTable;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Button btnCombineTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMinusBeverage;
    }
}