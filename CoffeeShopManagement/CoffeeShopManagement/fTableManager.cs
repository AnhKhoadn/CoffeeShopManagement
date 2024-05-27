using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = CoffeeShopManagement.DTO.Menu;

namespace CoffeeShopManagement
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbSwitchTable);
        }

        #region method
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinCaNhânToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
            accountProfileToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory(); //lấy danh sách
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "name"; //sau khi lấy danh sách thì có nhiều trường nên chỉ lấy một trường để hiển thị
        }

        void LoadBeverageListByCategoryID(int id)
        {
            List<Beverage> listBeverage = BeverageDAO.Instance.GetBeverageByCategoryID(id);
            cbBeverage.DataSource = listBeverage;
            cbBeverage.DisplayMember = "name";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;   //enviroment new line = xuống dòng

                btn.Click += Btn_Click;
                btn.Tag = item; //lưu bàn vào tag, dựa vào btn click để xác định tableid

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.DeepSkyBlue;
                        break;
                    case "Có người":
                        btn.BackColor = Color.Yellow;
                        break;
                    default:
                        btn.BackColor = Color.DeepSkyBlue;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear(); //clear sau mỗi lần click vào button
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;

            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.BeverageName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;

                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN"); //thay đổi culture(ngôn ngữ)

            Thread.CurrentThread.CurrentCulture = culture; //chỉ thay đổi format của luồng hiện tại, ko thay đổi format cả máy tính

            txbTotalPrice.Text = totalPrice.ToString("c"); //tổng giá tiền, "c" = currency format

        }

        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion


        #region event
        private void Btn_Click(object sender, EventArgs e) //sau khi click vào btn (bàn) thì sẽ show bill tương ứng
        {
            int TableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);
            f.UpdateAccount += F_UpdateAccount;
            f.ShowDialog();
        }

        private void F_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinCaNhânToolStripMenuItem.Text = "Thông tin cá nhân (" + e.Acc.DisplayName + ")";
            accountProfileToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;

            f.InsertBeverage += F_InsertBeverage;
            f.DeleteBeverage += F_DeleteBeverage;
            f.UpdateBeverage += F_UpdateBeverage;

            f.InsertCategory += F_InsertCategory;
            f.UpdateCategory += F_UpdateCategory;
            f.DeleteCategory += F_DeleteCategory;

            f.InsertTable += F_InsertTable;
            f.UpdateTable += F_UpdateTable;
            f.DeleteTable += F_DeleteTable;
            f.ShowDialog();
        }

        private void F_DeleteTable(object sender, EventArgs e)
        {
            LoadComboBoxTable(cbSwitchTable);
            LoadTable();
        }

        private void F_UpdateTable(object sender, EventArgs e)
        {
            LoadComboBoxTable(cbSwitchTable);
            LoadTable();
        }

        private void F_InsertTable(object sender, EventArgs e)
        {
            LoadComboBoxTable(cbSwitchTable);
            LoadTable();
        }

        private void F_DeleteCategory(object sender, EventArgs e)
        {
            LoadCategory();
            LoadBeverageListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void F_UpdateCategory(object sender, EventArgs e)
        {
            LoadCategory();
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void F_InsertCategory(object sender, EventArgs e)
        {
            LoadCategory();
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void F_UpdateBeverage(object sender, EventArgs e)
        {
            LoadBeverageListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void F_DeleteBeverage(object sender, EventArgs e)
        {
            LoadBeverageListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }

        private void F_InsertBeverage(object sender, EventArgs e)
        {
            LoadBeverageListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if(lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadBeverageListByCategoryID(id);
        }

        private void btnAddBeverage_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table; //lấy ra bàn hiện tại

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn", "Thông báo");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID); //xác định idbill hiện tại
            int beverageID = (cbBeverage.SelectedItem as Beverage).ID;
            int count = (int)nmBeverageCount.Value;

            if (nmBeverageCount.Value == 0)
            {
                MessageBox.Show("Hãy nhập số lượng món", "Thông báo");
            }
            else
            {
                if (idBill == -1) //bill chưa tồn tại
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), beverageID, count);
                }
                else //bill đã tồn tại
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, beverageID, count);
                }
            }

            ShowBill(table.ID); //load lại bill

            LoadTable();
        }

        private void btnMinusBeverage_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table; //lấy ra bàn hiện tại

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn", "Thông báo");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID); //xác định idbill hiện tại
            int beverageID = (cbBeverage.SelectedItem as Beverage).ID;
            int count = (int)nmBeverageCount.Value;

            if (nmBeverageCount.Value == 0)
            {
                MessageBox.Show("Hãy nhập số lượng món", "Thông báo");
            }
            else
            {
                if (idBill == -1) //bill chưa tồn tại
                {
                    return;
                }
                else //bill đã tồn tại
                {
                    BillInfoDAO.Instance.UpdateBillInfo(idBill, beverageID, count);
                }
            }

            ShowBill(table.ID); //load lại bill

            LoadTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table; //lấy ra được bàn

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn", "Thông báo");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nmDiscount.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]); //split kí tự theo dấu phẩy, lấy ra phần đầu tiên [0]
            double finalToTalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có muốn thanh toán {0}\nGiảm giá {1}%\nTổng tiền = {2}₫", table.Name, discount, finalToTalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.ChekOut(idBill, discount, (float)finalToTalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table; //lấy ra được bàn

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn", "Thông báo");
                return;
            }

            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn muốn chuyển {0} qua {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }

        }

        private void btnCombineTable_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table; //lấy ra được bàn

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn", "Thông báo");
                return;
            }

            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn muốn gộp {0} qua {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.CombineTable(id1, id2);
                LoadTable();
            }

        }
        #endregion
    }
}
