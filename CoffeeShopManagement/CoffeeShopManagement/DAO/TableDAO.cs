using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        public List<Table> LoadTableList() //lấy danh sách bàn
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public DataTable LoadTableListIntoAdmin() 
        {
            return DataProvider.Instance.ExecuteQuery("select id, name from TableBeverage");
        }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[] {id1, id2});
        }

        public void CombineTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_CombineTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }

        public bool InsertTable(string name)
        {
            string query = string.Format("INSERT dbo.TableBeverage(name) VALUES(N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTable(int idBTable, string name)
        {
            string query = string.Format("UPDATE dbo.TableBeverage SET name = N'{0}' WHERE id = {1}", name, idBTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int idTable)
        {
            BillInfoDAO.Instance.DeleteBillInfoByTableID(idTable);
            BillDAO.Instance.DeleteBilllByTableID(idTable);

            string query = string.Format("DELETE dbo.TableBeverage WHERE id = {0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<Table> SearchTableByName(string name)
        {
            List<Table> tableList = new List<Table>();

            string query = string.Format("SELECT * FROM dbo.TableBeverage WHERE dbo.fuConvertToUnsign1(name) LIKE '%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}
