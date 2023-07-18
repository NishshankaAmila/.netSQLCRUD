using System.Data.SqlClient;

namespace Backend.Files
{
    public class Customer1
    {

        private readonly string StringConnection;
        

        public Customer1(string stringConnection)
        {
            this.StringConnection = stringConnection;
        }

        public void Customer(Customer customer) {

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "INSERT INTO Customers (CId, CName,Mobile) VALUES (@CId, @CName,@Mobile)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", customer.CId);
                command.Parameters.AddWithValue("@Email", customer.CName);
                command.Parameters.AddWithValue("@Mobile", customer.Mobile);


                connection.Open();
                command.ExecuteNonQuery();
            }

    }


        public List<Customer> GetAllCustomers()
        {

            List<Customer> customer = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "select* from Customer";

                SqlCommand sql = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer1 = new Customer();
                    customer1.CId = (int)reader["CId"];
                    customer1.CName = (string)reader["CName"];
                    customer1.Mobile = (string)reader["Mobile"];

                    customer.Add(customer1);
                }
            }
            return customer;
        }

        public void updateCustomer (Customer customer)
        {
            using(SqlConnection connection = new SqlConnection(StringConnection))
            {

                string query = "update Customer set CName = @CName ,Mobile = @Mobile where CId = @CId   ";

                SqlCommand command = new SqlCommand(query, connection);
                
                //command.Parameters.AddWithValue("@Name", customer.CId); Id not updated
                command.Parameters.AddWithValue("@Email", customer.CName);
                command.Parameters.AddWithValue("@Mobile", customer.Mobile);


                connection.Open();
                command.ExecuteNonQuery();

            }
        }


        public void deleteCustomer (Customer customer)
        {
            using(SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "DELETE FROM Customers WHERE CId = @CId ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CID",customer.CId);
            }
        }


    }
}
