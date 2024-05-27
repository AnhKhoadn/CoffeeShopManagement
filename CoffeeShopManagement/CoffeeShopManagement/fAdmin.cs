using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class fAdmin : Form
    {
        BindingSource beverageList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountList = new BindingSource();

        public Account loginAccount;

        public fAdmin() //thực hiện các hàm ngay khi mở form lên 
        {
            InitializeComponent();
            LoadMethods();
        }

        #region methods
        void LoadMethods()
        {
            dtgvBeverage.DataSource = beverageList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;
            dtgvAccount.DataSource = accountList;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListBeverage();
            LoadCategoryIntoComboBox();
            LoadListCategory();
            LoadListTable();
            LoadListAccount();
            AddBeverageBinding();
            AddCategoryBinding();
            AddTableBinding();
            AddAccountBinding();
            LoadCategoryIntoComboBox(cbBeverageCategory);
        }

        List<Beverage> SearchBeverageByName(string name)
        {
            List<Beverage> listBeverage = BeverageDAO.Instance.SearchBeverageByName(name);

            return listBeverage;
        }

        List<Category> SearchCategoryByName(string name)
        {
            List<Category> listCategory = CategoryDAO.Instance.SearchCategoryByName(name);

            return listCategory;
        }

        List<Table> SearchTableByName(string name)
        {
            List<Table> listTable = TableDAO.Instance.SearchTableByName(name);

            return listTable;
        }

        private void LoadCategoryIntoComboBox()
        {
            cbBeverageCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cbBeverageCategory.DisplayMember = "Name";
            cbBeverageCategory.ValueMember = "ID";
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1); //tháng hiện tại cộng thêm 1 tháng rồi trừ đi một ngày sẽ ra ngày cuối cùng của tháng hiện tại
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void AddBeverageBinding()
        {
            txbBeverageName.DataBindings.Add(new Binding("Text", dtgvBeverage.DataSource, "name", true, DataSourceUpdateMode.Never)); //kỹ thuật binding, thay đổi thuộc tính "text" bằng giá trị của "name"
            txbBeverageID.DataBindings.Add(new Binding("Text", dtgvBeverage.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmBeveragePrice.DataBindings.Add(new Binding("Value", dtgvBeverage.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }

        void LoadListBeverage()
        {
            beverageList.DataSource = BeverageDAO.Instance.GetListBeverage();
        }

        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void AddTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableListIntoAdmin();
        }

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        #endregion

        #region events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void btnShowBeverage_Click(object sender, EventArgs e)
        {
            LoadListBeverage();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void txbBeverageID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvBeverage.SelectedCells.Count > 0 && dtgvBeverage.SelectedCells[0].OwningRow.Cells["CategoryID"].Value != null)
            {
                int id = (int)dtgvBeverage.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                cbBeverageCategory.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (Category item in cbBeverageCategory.Items)
                {
                    if (item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbBeverageCategory.SelectedIndex = index;
            }
        }

        private void btnAddBeverage_Click(object sender, EventArgs e)
        {
            string name = txbBeverageName.Text;
            int CategoryID = (cbBeverageCategory.SelectedItem as Category).ID;
            float price = (float)nmBeveragePrice.Value;

            foreach (DataGridViewRow row in dtgvBeverage.Rows)
            {
                if (row.Cells["Name"].Value != null && (string.Equals(row.Cells["Name"].Value.ToString(), txbBeverageName.Text, StringComparison.OrdinalIgnoreCase) && string.Equals(row.Cells["Name"].Value.ToString(), txbBeverageName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show("Tên món đã tồn tại trong danh sách!", "Thông báo");
                    return;
                }
            }

            if (txbBeverageName.Text == "")
            {
                MessageBox.Show("Tên món không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (BeverageDAO.Instance.InsertBeverage(name, CategoryID, price))
                {
                    if (MessageBox.Show("Bạn muốn thêm món?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Thêm món thành công!");
                        LoadListBeverage();
                        if (insertBeverage != null)
                            insertBeverage(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm món");
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            foreach (DataGridViewRow row in dtgvCategory.Rows)
            {
                if (row.Cells["Name"].Value != null && (string.Equals(row.Cells["Name"].Value.ToString(), txbCategoryName.Text, StringComparison.OrdinalIgnoreCase) && string.Equals(row.Cells["Name"].Value.ToString(), txbCategoryName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show("Tên danh mục đã tồn tại trong danh sách!", "Thông báo");
                    return;
                }
            }

            if (txbCategoryName.Text == "")
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Thông báo");
            }
            else
            {
                if (CategoryDAO.Instance.InsertCategory(name))
                {
                    if (MessageBox.Show("Bạn muốn thêm danh mục?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Thêm danh mục thành công!");
                        LoadListCategory();
                        LoadListBeverage();
                        LoadCategoryIntoComboBox();
                        if (insertCategory != null)
                            insertCategory(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm danh mục");
                }
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;

            foreach (DataGridViewRow row in dtgvTable.Rows)
            {
                if (row.Cells["name"].Value != null && (string.Equals(row.Cells["Name"].Value.ToString(), txbTableName.Text, StringComparison.OrdinalIgnoreCase) && string.Equals(row.Cells["Name"].Value.ToString(), txbTableName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show("Tên bàn đã tồn tại trong danh sách!", "Thông báo");
                    return;
                }
            }

            if (txbTableName.Text == "")
            {
                MessageBox.Show("Tên bàn không được để trống!", "Thông báo");
            }
            else
            {
                if (TableDAO.Instance.InsertTable(name))
                {
                    if (MessageBox.Show("Bạn muốn thêm bàn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Thêm bàn thành công!");
                        LoadListTable();
                        if (insertTable != null)
                            insertTable(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm bàn");
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmAccountType.Value;

            foreach (DataGridViewRow row in dtgvAccount.Rows)
            {
                if (row.Cells["UserName"].Value != null && (string.Equals(row.Cells["UserName"].Value.ToString(), txbUserName.Text, StringComparison.OrdinalIgnoreCase) && string.Equals(row.Cells["UserName"].Value.ToString(), txbUserName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại trong danh sách!", "Thông báo");
                    return;
                }
            }

            if (txbUserName.Text == "" && txbDisplayName.Text == "")
            {
                MessageBox.Show("Tên tài khoản, tên hiển thị không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                {
                    if (MessageBox.Show("Bạn muốn thêm tài khoản?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Thêm tài khoản thành công!");
                        LoadListAccount();
                        if (insertBeverage != null)
                            insertBeverage(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm tài khoản");
                }
            }
        }

        private void btnEditBeverage_Click(object sender, EventArgs e)
        {
            string name = txbBeverageName.Text;
            int CategoryID = (cbBeverageCategory.SelectedItem as Category).ID;
            float price = (float)nmBeveragePrice.Value;
            int id = Convert.ToInt32(txbBeverageID.Text);

            if (BeverageDAO.Instance.UpdateBeverage(id, name, CategoryID, price))
            {
                if (MessageBox.Show("Bạn muốn cập nhật món?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Cập nhật món thành công");
                    LoadListBeverage();
                    if (updateBeverage != null)
                        updateBeverage(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật món");
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                if (MessageBox.Show("Bạn muốn cập nhật danh mục?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Cập nhật danh mục thành công");
                    LoadListCategory();
                    LoadListBeverage();
                    LoadCategoryIntoComboBox();
                    if (updateCategory != null)
                        updateCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật danh mục");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            int id = Convert.ToInt32(txbTableID.Text);

            if (TableDAO.Instance.UpdateTable(id, name))
            {
                if (MessageBox.Show("Bạn muốn cập nhật bàn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Cập nhật bàn thành công");
                    LoadListTable();
                    if (updateTable != null)
                        updateTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật bàn");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmAccountType.Value;



            if (txbUserName.Text == "" && txbDisplayName.Text == "")
            {
                MessageBox.Show("Tên tài khoản, tên hiển thị không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccountByAdmin(userName, displayName, type))
                {
                    if (MessageBox.Show("Bạn muốn cập nhật tài khoản?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công!");
                        LoadListAccount();
                        if (insertBeverage != null)
                            insertBeverage(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật tài khoản");
                }
            }
        }

        private void btnDeleteBeverage_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbBeverageID.Text);

            if (BeverageDAO.Instance.DeleteBeverage(id))
            {
                if (MessageBox.Show("Bạn muốn xóa món? Mọi dữ liệu liên quan đều sẽ bị xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Xóa món thành công");
                    LoadListBeverage();
                    if (deleteBeverage != null)
                        deleteBeverage(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xóa món");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                if (MessageBox.Show("Bạn muốn xóa danh mục? Mọi dữ liệu liên quan đều sẽ bị xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Xóa danh mục thành công");
                    LoadListCategory();
                    LoadListBeverage();
                    LoadCategoryIntoComboBox();
                    if (deleteCategory != null)
                        deleteCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbTableID.Text);

            if (TableDAO.Instance.DeleteTable(id))
            {
                if (MessageBox.Show("Bạn muốn xóa bàn? Mọi dữ liệu liên quan đều sẽ bị xóa", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Xóa bàn thành công");
                    LoadListTable();
                    if (deleteTable != null)
                        deleteTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xóa bàn");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Tài khoản hiện đang được sử dụng");
                return;
            }

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                if (MessageBox.Show("Bạn muốn xóa tài khoản?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                    LoadListAccount();
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xóa tài khoản");
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }

        private void btnSearchBeverage_Click(object sender, EventArgs e)
        {
            beverageList.DataSource = SearchBeverageByName(txbSearchBeverageName.Text);
        }

        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            categoryList.DataSource = SearchCategoryByName(txbSearchCategoryName.Text);
        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            tableList.DataSource = SearchTableByName(txbSearchTableName.Text);
        }

        private event EventHandler insertBeverage;
        public event EventHandler InsertBeverage
        {
            add { insertBeverage += value; }
            remove { insertBeverage -= value; }
        }

        private event EventHandler deleteBeverage;
        public event EventHandler DeleteBeverage
        {
            add { deleteBeverage += value; }
            remove { deleteBeverage -= value; }
        }

        private event EventHandler updateBeverage;
        public event EventHandler UpdateBeverage
        {
            add { updateBeverage += value; }
            remove { updateBeverage -= value; }
        }

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        #endregion
    }
}
