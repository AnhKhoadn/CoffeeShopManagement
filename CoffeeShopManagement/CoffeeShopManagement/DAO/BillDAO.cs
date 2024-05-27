using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopManagement.DTO;

namespace CoffeeShopManagement.DAO
{
    public class BillDAO //có nhiệm vụ lấy ra bill từ id table
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        //thành công: lấy ra được bill ID
        //thất bại: ID = -1
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id +" AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1; // id = -1 nghĩa là không có bill nào  
        }

        public void ChekOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1, " + "discount = " + discount + ", totalPrice = " + totalPrice + " WHERE id = " + id;

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertBill(int id) //tạo ra bill mới dựa vào bàn khi chưa có bill
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[]{id});
        }

        public void DeleteBilllByTableID(int idTable)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Bill WHERE idTable = " + idTable);
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut) //cấu trúc của nó là datatable, vì chỉ cần hiển thị nên ko cần thiết tạo thêm model
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListByDate @checkIn , @checkOut", new object[] {checkIn, checkOut});
        }            

        public int GetMaxIDBill() //trong sql id tự tăng -> khi thêm (insert) bill mới vào thì id sẽ có giá trị lớn nhất
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteSaclar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
