using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int beverageID, int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.BeverageID = BeverageID;
            this.Count = count; 
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.BeverageID = (int)row["idBeverage"];
            this.Count = (int)row["count"];
        }

        private int iD;
        private int billID;
        private int beverageID;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public int BeverageID { get => beverageID; set => beverageID = value; }
        public int Count { get => count; set => count = value; }
    }
}
