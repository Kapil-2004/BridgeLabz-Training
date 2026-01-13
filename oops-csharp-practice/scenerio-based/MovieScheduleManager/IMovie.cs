using System.Runtime.CompilerServices;

public interface IMovie
{
    void AddMovie(string title, string time);   
    void SearchMovie(string keyword);
    void DisplaySchedule(); 
}