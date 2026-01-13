public class MovieMain
{
    public void Start()
    {
        CinemaUtility utility = new CinemaUtility(10);
        Menu menu = new Menu(utility);
        menu.Show();
    }
}
