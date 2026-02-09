using System.Threading.Tasks;
using AddressBookSystem.Menu;

namespace AddressBookSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MenuHandler menu = new MenuHandler();
            await menu.ShowMenuAsync();
        }
    }
}
