public class Menu
{
    private CinemaUtility utility;

    public Menu(CinemaUtility utility)
    {
        this.utility = utility;
    }

    public void Show()
    {
        while (true)
        {
            System.Console.WriteLine("\n--- CinemaTime Menu ---");
            System.Console.WriteLine("1. Add Movie");
            System.Console.WriteLine("2. Search Movie");
            System.Console.WriteLine("3. Display Movies");
            System.Console.WriteLine("4. Exit");
            System.Console.Write("Choice: ");

            int choice = int.Parse(System.Console.ReadLine());

            switch (choice)
            {
                case 1:
                    System.Console.Write("Title: ");
                    string title = System.Console.ReadLine();
                    System.Console.Write("Time (HH:mm): ");
                    string time = System.Console.ReadLine();
                    utility.AddMovie(title, time);
                    break;

                case 2:
                    System.Console.Write("Keyword: ");
                    utility.SearchByKeyword(System.Console.ReadLine());
                    break;

                case 3:
                    utility.DisplayMovies();
                    break;

                case 4:
                    return;
            }
        }
    }
}
