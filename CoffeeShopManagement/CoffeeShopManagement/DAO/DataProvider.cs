using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance 
        { 
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connectionSTR = "Data Source=.;Initial Catalog=CoffeeShopManagement;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null) // can biet thuc thi cau query nao // can mot mang object de truyen du lieu cho n parameter(kieu du lieu co the khac nhau), parameter co the null
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR)) //su dung using: neu co gap van de gi thi sau khi thuc hien khoi lenh trong {} du lieu duoc khai bao trong () tu dong duoc giai phong
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if(parameter != null)
                {
                    string[] listPara = query.Split(' '); //split theo khoang trang
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]); //neu co dau @ thi do la parameter
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        //su dung ExecuteNonQuery de lay ket qua tra ve so dong thuc hien thanh cong(int), khong can phai tra ve ca bang nhu public DataTable ExecuteQuery
        public int ExecuteNonQuery(string query, object[] parameter = null) // can biet thuc thi cau query nao // can mot mang object de truyen du lieu cho n parameter(kieu du lieu co the khac nhau), parameter co the null
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR)) //su dung using: neu co gap van de gi thi sau khi thuc hien khoi lenh trong {} du lieu duoc khai bao trong () tu dong duoc giai phong
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); //split theo khoang trang
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]); //neu co dau @ thi do la parameter
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        //dung ExecuteSaclar khi chi can biet so luong tra ve dong dau tien, cot dau tien trong datatable, dung khi dem so luong(count trong sql)
        public object ExecuteSaclar(string query, object[] parameter = null) // can biet thuc thi cau query nao // can mot mang object de truyen du lieu cho n parameter(kieu du lieu co the khac nhau), parameter co the null
        {
            object data = 0; //ExecuteSaclar phai tra ve object

            using (SqlConnection connection = new SqlConnection(connectionSTR)) //su dung using: neu co gap van de gi thi sau khi thuc hien khoi lenh trong {} du lieu duoc khai bao trong () tu dong duoc giai phong
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' '); //split theo khoang trang
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]); //neu co dau @ thi do la parameter
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
//excute query tra ra nhung dong ket qua
//excute non query tra ra so dong duoc thuc thi (insert, delete, update)
//excute scalar tra ra ket qua la dong dau tien, cot dau tien (count)