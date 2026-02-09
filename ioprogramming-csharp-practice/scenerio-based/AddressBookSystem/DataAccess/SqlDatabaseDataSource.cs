using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public class SqlDatabaseDataSource : IAddressBookDataSource
    {
        private readonly string connectionString =
            "Server=localhost;Database=AddressBookDB;Trusted_Connection=True;TrustServerCertificate=True";

        public async Task SaveAsync(AddressBook book)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            await con.OpenAsync();

            foreach (Contact c in book.Contacts)
            {
                string query = @"
IF NOT EXISTS (SELECT 1 FROM Contacts WHERE FirstName=@FirstName AND LastName=@LastName AND AddressBookName=@Book)
INSERT INTO Contacts(AddressBookName, FirstName, LastName, Address, City, State, Zip, Phone, Email)
VALUES(@Book,@FirstName,@LastName,@Address,@City,@State,@Zip,@Phone,@Email)";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Book", book.Name);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@City", c.City);
                cmd.Parameters.AddWithValue("@State", c.State);
                cmd.Parameters.AddWithValue("@Zip", c.Zip);
                cmd.Parameters.AddWithValue("@Phone", c.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", c.Email);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<AddressBook> LoadAsync(string addressBookName)
        {
            AddressBook book = new AddressBook(addressBookName);

            using SqlConnection con = new SqlConnection(connectionString);
            await con.OpenAsync();

            string query = "SELECT * FROM Contacts WHERE AddressBookName=@Book";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Book", addressBookName);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                book.Contacts.Add(new Contact
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Address = reader["Address"].ToString(),
                    City = reader["City"].ToString(),
                    State = reader["State"].ToString(),
                    Zip = reader["Zip"].ToString(),
                    PhoneNumber = reader["Phone"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }

            return book;
        }
    }
}
