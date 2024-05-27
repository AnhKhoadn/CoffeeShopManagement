using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class BeverageDAO
    {
        private static BeverageDAO instance;

        public static BeverageDAO Instance
        {
            get { if (instance == null) instance = new BeverageDAO(); return BeverageDAO.instance; }
            private set { BeverageDAO.instance = value; }
        }

        private BeverageDAO() { }

        public List<Beverage> GetBeverageByCategoryID(int id)
        {
            List<Beverage> list = new List<Beverage>();

            string query = "SELECT * FROM dbo.Beverage WHERE idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Beverage beverage = new Beverage(item);
                list.Add(beverage);
            }

            return list;
        }

        public List<Beverage> GetListBeverage()
        {
            List<Beverage> list = new List<Beverage>();

            string query = "SELECT * FROM dbo.Beverage";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Beverage beverage = new Beverage(item);
                list.Add(beverage);
            }

            return list;

        } 
        
        public bool InsertBeverage(string name, int idCategory, float price)
        {
            string query = string.Format("INSERT dbo.Beverage(name, idCategory, price) VALUES(N'{0}', {1}, {2})", name, idCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateBeverage(int idBeverage, string name, int idCategory, float price)
        {
            string query = string.Format("UPDATE dbo.Beverage SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, idCategory, price, idBeverage);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteBeverage(int idBeverage)
        {
            BillInfoDAO.Instance.DeleteBillInfoByBeverageID(idBeverage);

            string query = string.Format("DELETE dbo.Beverage WHERE id = {0}", idBeverage);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public void DeleteBeverageByCategoryID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Beverage WHERE idCategory = " + id);
        }

        public List<Beverage> SearchBeverageByName(string name)
        {
            List<Beverage> list = new List<Beverage>();

            string query = string.Format("SELECT * FROM dbo.Beverage WHERE dbo.fuConvertToUnsign1(name) LIKE '%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name); //chuyển kí tự đặc biệt(tiếng việt) về kí tự thường rồi so sánh

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Beverage beverage = new Beverage(item);
                list.Add(beverage);
            }

            return list;
        }
    }
}
