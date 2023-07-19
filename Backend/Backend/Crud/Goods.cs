using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Backend.Files
{
    public class Goods1
    {

        private readonly string StringConnection;

        public Goods1(string stringConnection) {
        
            this.StringConnection = stringConnection;
        
        }

        public void Good(Goods goods)
        {
            using (SqlConnection connection = new SqlConnection(StringConnection))

            {
                    string query = "INSERT INTO Customer (Gid, GName,GPrice) VALUES (@Gid, @GName,@GPrice)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", goods.Gid);
                    command.Parameters.AddWithValue("@Email", goods.GName);
                    command.Parameters.AddWithValue("@Mobile", goods.GPrice);


                    connection.Open();
                    command.ExecuteNonQuery();
                }


            }


        public List<Goods> GetAllGodds()
        {
            List<Goods> list = new List<Goods>();

          using (SqlConnection connection =  new SqlConnection(StringConnection))
            {
                string query = "select * from Goods";

                SqlCommand command = new SqlCommand(query, connection);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Goods goods = new Goods();
                    goods.Gid = (int)reader["Gid"];
                    goods.GName = (string)reader["GName"];
                    goods.GPrice = (float)reader["GPrice"];


                    list.Add(goods);
                }
                return list;
            }
        }


        public void UpdateGoods(Goods goods)
        {
            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "update Goods set GName = @GName , GPrice = @GPrice ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GName", goods.GName);
                command.Parameters.AddWithValue("@GPrice" , goods.GPrice);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteGoods(Goods goods)
        {
            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "delete from Goods where Gid = @Gid";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Gid", goods.Gid);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        }
    }

