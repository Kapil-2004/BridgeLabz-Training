using System.Threading.Tasks;
using AddressBookSystem.Entities;

namespace AddressBookSystem.DataAccess
{
    public interface IAddressBookDataSource
    {
        Task SaveAsync(AddressBook book);
        Task<AddressBook> LoadAsync(string addressBookName);
    }
}
