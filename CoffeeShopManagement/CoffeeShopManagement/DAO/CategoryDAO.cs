using CoffeeShopManagement.DTO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "SELECT * FROM dbo.BeverageCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "SELECT * FROM dbo.BeverageCategory where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }

        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT dbo.BeverageCategory(name) VALUES(N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCategory(int idCategory, string name)
        {
            string query = string.Format("UPDATE dbo.BeverageCategory SET name = N'{0}' WHERE id = {1}", name, idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int idCategory)
        {
            BillInfoDAO.Instance.DeleteBillInfoByCategoryID(idCategory);
            BeverageDAO.Instance.DeleteBeverageByCategoryID(idCategory);

            string query = string.Format("DELETE dbo.BeverageCategory WHERE id = {0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<Category> SearchCategoryByName(string name)
        {
            List<Category> list = new List<Category>();

            string query = string.Format("SELECT * FROM dbo.BeverageCategory WHERE dbo.fuConvertToUnsign1(name) LIKE '%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
    }
}
