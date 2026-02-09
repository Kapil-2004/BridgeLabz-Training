using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public class JsonServerDataSource : IAddressBookDataSource
    {
        private readonly HttpClient client = new HttpClient();

        // Example: http://localhost:3000/addressbooks
        private readonly string baseUrl = "http://localhost:3000/addressbooks";

        public async Task SaveAsync(AddressBook book)
        {
            string json = JsonSerializer.Serialize(book);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // PUT (update)
            await client.PutAsync($"{baseUrl}/{book.Name}", content);
        }

        public async Task<AddressBook> LoadAsync(string addressBookName)
        {
            HttpResponseMessage res = await client.GetAsync($"{baseUrl}/{addressBookName}");

            if (!res.IsSuccessStatusCode)
                return new AddressBook(addressBookName);

            string json = await res.Content.ReadAsStringAsync();

            AddressBook book = JsonSerializer.Deserialize<AddressBook>(json);

            return book ?? new AddressBook(addressBookName);
        }
    }
}
