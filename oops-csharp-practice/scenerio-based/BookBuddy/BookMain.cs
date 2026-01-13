namespace BookBuddy
{
    class BookMain
    {
        public void Start()
        {
            IBookBuddy bookBuddy = new BookUtility();
            Menu menu = new Menu(bookBuddy);
            menu.ShowMenu();
        }
    }
}
