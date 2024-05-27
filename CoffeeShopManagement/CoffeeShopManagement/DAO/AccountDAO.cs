using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type FROM dbo.Account");
        }

        public string Encrypt(string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hashPass = "";

            foreach (byte item in hashData)
            {
                hashPass += item;
            }

            return hashPass;
        }

        public bool Login(string userName, string password)
        {
            //string query = "SELECT * FROM dbo.Account WHERE UserName = '"+ userName +"' AND Password = '"+ password +"'"; //nối chuỗi

            string hashPass = Encrypt(password);

            string query = "USP_Login @userName , @password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashPass });
            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string password, string newPassword)
        {
            string hashPass = Encrypt(password);
            string hashNewPassword = Encrypt(newPassword);

            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, hashPass, hashNewPassword });

            return result > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Account where UserName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.Account(UserName, DisplayName, Type, Password) VALUES(N'{0}', N'{1}', {2}, {3})", userName, displayName, type, $"N'{Encrypt("0")}'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccountByAdmin(string userName, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}'", userName, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = string.Format("DELETE dbo.Account WHERE UserName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string userName)
        {
            string query = string.Format("UPDATE dbo.Account SET Password = N'{0}' WHERE UserName = N'{1}'", Encrypt("0"), userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
