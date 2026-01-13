public class CinemaUtility
{
    private string[] titles;
    private string[] times;
    private int count;

    public CinemaUtility(int size)
    {
        titles = new string[size];
        times = new string[size];
        count = 0;
    }

    public void AddMovie(string title, string time)
    {
        if (count == titles.Length)
        {
            System.Console.WriteLine("Movie storage full");
            return;
        }

        titles[count] = title;
        times[count] = time;
        count++;

        System.Console.WriteLine("Movie added successfully");
    }

    public void SearchByKeyword(string keyword)
    {
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (titles[i].Contains(keyword))
            {
                System.Console.WriteLine(
                    "Movie: " + titles[i] + " | Time: " + times[i]
                );
                found = true;
            }
        }

        if (!found)
            System.Console.WriteLine("No movie found");
    }

    public void DisplayMovies()
    {
        if (count == 0)
        {
            System.Console.WriteLine("No movies available");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            System.Console.WriteLine(
                (i + 1) + ". " + titles[i] + " - " + times[i]
            );
        }
    }

    public string[] GenerateReport()
    {
        string[] report = new string[count];

        for (int i = 0; i < count; i++)
        {
            report[i] = titles[i] + " @ " + times[i];
        }

        return report;
    }
}
