using System.Data.SqlClient;

namespace Backend.Files
{
    public class Customer1
    {

        private readonly string StringConnection;
        string query;

        public Customer1(string stringConnection)
        {
            this.StringConnection = stringConnection;
        }

        public void Customer(Customer customer) {

            using SqlConnection connection = new SqlConnection(StringConnection)
            {
                 query = "INSERT INTO Customers (CId, CName,Mobile) VALUES (@CId, @CName,@Mobile)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", customer.Cid);
            command.Parameters.AddWithValue("@Email", customer.CName);
        }

    }
    }
}
