
public interface ILibrary
{
    void AddBook(string title, string author);
    void DisplayBooks();
    void SearchBookByTitle(string title);
    void CheckoutBook(int index);
}
