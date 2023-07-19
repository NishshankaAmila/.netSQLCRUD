using System.Reflection;
using System.Security.Cryptography;

namespace Backend.Files
{
    public class Main
    {

        static void main()
        {
            string connectionString = "Server=DESKTOP-HHKH320\\SQLEXPRESS;Database=Customer1;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            Customer1 c1 = new Customer1(connectionString);
            Bills b1 = new Bills(connectionString);
            Goods1 G1 = new Goods1(connectionString);

            Customer customer3 = new Customer
            {
                CId = 1,
                CName = "Amila",
                Mobile = "0715306998",
            };

            c1.Customer(customer3);


            List<Customer> customer = c1.GetAllCustomers();
            foreach (Customer customers in customer)
            {
                Console.WriteLine($"ID: {customers.CId}, Name: {customers.CName}, Email: {customers.Mobile}");
            }
        }

    }

    }

