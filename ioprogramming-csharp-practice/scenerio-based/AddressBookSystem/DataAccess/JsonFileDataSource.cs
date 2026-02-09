using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public class JsonFileDataSource : IAddressBookDataSource
    {
        private string GetPath(string bookName)
        {
            return $"{bookName}.json";
        }

        public async Task SaveAsync(AddressBook book)
        {
            string path = GetPath(book.Name);

            string json = JsonSerializer.Serialize(book, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(path, json);
        }

        public async Task<AddressBook> LoadAsync(string addressBookName)
        {
            string path = GetPath(addressBookName);

            if (!File.Exists(path))
                return new AddressBook(addressBookName);

            string json = await File.ReadAllTextAsync(path);

            AddressBook book = JsonSerializer.Deserialize<AddressBook>(json);

            if (book == null)
                return new AddressBook(addressBookName);

            return book;
        }
    }
}
