using System.Data.SqlClient;

namespace Backend.Files
{
    public class Bills
    {
        private readonly string StringConnection;
        public Bills(string StringConnection)
        {
            this.StringConnection = StringConnection;
        }

        public void Bill1(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "insert into Bill (InvoiceNo ,QTY, TotalPrice) values(@InvoiceNo ,@QTY, @TotalPrice)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InvoiceNo", bill.InvoiceNo);
                command.Parameters.AddWithValue("@QTY", bill.QTY);
                command.Parameters.AddWithValue("@TotalPrice", bill.TotalPrice);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public List<Bill> BillList()
        {
            List<Bill> list = new List<Bill>();

            using(SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "select * from Bill";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Bill bill = new Bill();
                    bill.InvoiceNo = (int)reader["InvoiceNo"];
                    bill.QTY = (int)reader["QTY"];
                    bill.TotalPrice = (float)reader["TotalPrice"];

                    list.Add(bill);
                }
                return list;
            }
        }

        public void UpdateBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "update Bill set  QTY = @QTY, TotalPrice = @TotalPrice  ";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@QTY", bill.QTY);
                command.Parameters.AddWithValue("@TotalPrice", bill.TotalPrice);

                connection.Open();
                command.ExecuteNonQuery();


            }
        }

        public void DeleteBill(Bill bill)
        {
            using(SqlConnection connection = new SqlConnection(StringConnection))
            {
                string query = "delete from Bill where InvoiceNo = @InvoiceNo ";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InvoiceNo", bill.InvoiceNo);

                connection.Open();
                command.ExecuteNonQuery();  
            }
        }
    }
}
