class Book
{
    private string title;
    private string author;
    private bool isAvailable;

    public Book(string title, string author)
    {
        this.title = title;
        this.author = author;
        isAvailable = true;
    }

    public string Title
    {
        get { return title; }
    }

    public string Author
    {
        get { return author; }
    }

    public bool IsAvailable
    {
        get { return isAvailable; }
        set { isAvailable = value; }
    }
}
