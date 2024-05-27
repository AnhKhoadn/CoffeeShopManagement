using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class Menu
    {
        public Menu(string beverageName, int count, int price, int totalPrice = 0)
        {
            this.BeverageName = beverageName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.BeverageName = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }

        private string beverageName;
        private int count;
        private float price;
        private float totalPrice;

        public string BeverageName { get => beverageName; set => beverageName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
