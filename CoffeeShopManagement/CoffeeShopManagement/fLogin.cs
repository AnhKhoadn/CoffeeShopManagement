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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string password = txbPassword.Text;
            if (Login(userName, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                fTableManager f = new fTableManager(loginAccount);
                this.Hide(); //ẩn form login
                f.ShowDialog(); //dialog (top most) phải xử lý xong form dialog mới được xử lý form ở dưới, nếu không vẫn thao tác được đăng nhập
                this.Show(); //form login hiện ra sau khi xử lý xong form trên
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng");
            }
        }

        bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            } 
                
        }
    }
}
