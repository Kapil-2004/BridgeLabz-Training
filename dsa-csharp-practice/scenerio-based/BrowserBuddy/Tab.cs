using System;

namespace BrowserBuddy
{
    public class Tab
    {
        private HistoryNode currentPage;

        public void VisitPage(string url)
        {
            HistoryNode newPage = new HistoryNode(url);

            if (currentPage != null)
            {
                currentPage.Next = null; // clear forward history
                newPage.Previous = currentPage;
                currentPage.Next = newPage;
            }

            currentPage = newPage;
            Console.WriteLine("Visited: " + url);
        }

        public void GoBack()
        {
            if (currentPage != null && currentPage.Previous != null)
            {
                currentPage = currentPage.Previous;
                Console.WriteLine("Back to: " + currentPage.Url);
            }
            else
            {
                Console.WriteLine("No previous page available");
            }
        }

        public void GoForward()
        {
            if (currentPage != null && currentPage.Next != null)
            {
                currentPage = currentPage.Next;
                Console.WriteLine("Forward to: " + currentPage.Url);
            }
            else
            {
                Console.WriteLine("No forward page available");
            }
        }

        public void ShowCurrentPage()
        {
            if (currentPage != null)
            {
                Console.WriteLine("Current Page: " + currentPage.Url);
            }
            else
            {
                Console.WriteLine("Tab is empty");
            }
        }
    }
}
