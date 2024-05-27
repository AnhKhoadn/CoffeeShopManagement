using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id) //id cùa bill
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idBeverage, int count) //thêm billinfo sau khi đã có bill với trường hợp món uống này chưa tồn tại
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @idBill , @idBeverage , @count", new object[] { idBill, idBeverage, count });
        }

        public void UpdateBillInfo(int idBill, int idBeverage, int count) 
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateBillInfoByMinus @idBill , @idBeverage , @count", new object[] { idBill, idBeverage, count });
        }

        public void DeleteBillInfoByBeverageID(int idBeverage)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.BillInfo WHERE idBeverage = " + idBeverage);
        }

        public void DeleteBillInfoByCategoryID(int idCategory)
        {
            string query = string.Format("DELETE dbo.BillInfo WHERE idBeverage IN (SELECT id FROM dbo.Beverage WHERE idCategory = {0})", idCategory);
            DataProvider.Instance.ExecuteQuery(query);
        }

        public void DeleteBillInfoByTableID(int idTable)
        {
            string query = string.Format("DELETE dbo.BillInfo WHERE idBill IN (SELECT id FROM dbo.Bill WHERE idTable = {0})", idTable);
            DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
