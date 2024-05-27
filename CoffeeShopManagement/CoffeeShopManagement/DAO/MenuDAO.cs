using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopManagement.DTO;
using Menu = CoffeeShopManagement.DTO.Menu;

namespace CoffeeShopManagement.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT be.name, bi.count, be.price, be.price*bi.count AS totalPrice FROM dbo.Bill AS b, dbo.BillInfo AS bi, dbo.Beverage AS be WHERE bi.idBill = b.id AND bi.idBeverage = be.id AND b.status = 0 AND b.idTable = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
