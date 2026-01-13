using System;

namespace MovieScheduleManager
{
    class Movie
    {
        public string Title { get; set; }
        public string Time { get; set; }

        public Movie(string title, string time)
        {
            Title = title;
            Time = time;
        }

        public string ShowDetails()
        {
            return "Title: " + Title + ", Time: " + Time;
        }
    }
}
