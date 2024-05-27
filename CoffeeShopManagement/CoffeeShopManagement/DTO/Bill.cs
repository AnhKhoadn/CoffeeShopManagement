using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckOut, int status, int discount = 0)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckin"];

            //cách giải quyết khi bị null
            var dateCheckOutTemp = row["dateCheckOut"];
            if(dateCheckOutTemp.ToString() != "") // là "" ko phải null vì kết quả trả ra không phải null mà là ký tự rỗng 
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.Status = (int)row["status"];

            if(row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
        }
        
        private int iD;
        private DateTime? dateCheckIn; // kiểu datetime ko cho phép null, dấu "?" để cho phép null
        private DateTime? dateCheckOut;
        private int status;
        private int discount;

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
