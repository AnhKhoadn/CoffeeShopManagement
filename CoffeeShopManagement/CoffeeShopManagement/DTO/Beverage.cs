using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DTO
{
    public class Beverage
    {
        public Beverage(int id, string name, int categoryID, float price)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }

        public Beverage(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.CategoryID = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private int iD;
        private string name;
        private int categoryID;
        private float price;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
    }
}
