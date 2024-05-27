using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class Table
    {
        public Table(int id, string name, string status) //hàm dựng
        {
            this.ID = iD;
            this.Name = name;
            this.Status = status;
        }

        public Table(DataRow row) //hàm dựng xử lý data row
        {
            this.ID = (int)row["id"]; //lấy theo tên các cột trong sql
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }

                
        private int iD;
        private string name;
        private string status;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
