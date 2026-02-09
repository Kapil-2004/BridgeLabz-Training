using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public class CsvDataSource : IAddressBookDataSource
    {
        private string GetPath(string bookName)
        {
            return $"{bookName}.csv";
        }

        public async Task SaveAsync(AddressBook book)
        {
            string path = GetPath(book.Name);

            using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            using StreamWriter writer = new StreamWriter(fs);

            await writer.WriteLineAsync("FirstName,LastName,Address,City,State,Zip,Phone,Email");

            foreach (Contact c in book.Contacts)
            {
                string line = $"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State},{c.Zip},{c.PhoneNumber},{c.Email}";
                await writer.WriteLineAsync(line);
            }
        }

        public async Task<AddressBook> LoadAsync(string addressBookName)
        {
            string path = GetPath(addressBookName);

            AddressBook book = new AddressBook(addressBookName);

            if (!File.Exists(path))
                return book;

            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using StreamReader reader = new StreamReader(fs);

            string header = await reader.ReadLineAsync(); // skip header

            while (!reader.EndOfStream)
            {
                string line = await reader.ReadLineAsync();
                string[] parts = line.Split(',');

                if (parts.Length < 8) continue;

                book.Contacts.Add(new Contact
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    Address = parts[2],
                    City = parts[3],
                    State = parts[4],
                    Zip = parts[5],
                    PhoneNumber = parts[6],
                    Email = parts[7]
                });
            }

            return book;
        }
    }
}
