using System;

namespace BrowserBuddy
{
    public class BrowserMenu
    {
        private Browser browser;

        public BrowserMenu()
        {
            browser = new Browser();
        }

        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n=== BrowserBuddy Menu ===");
                Console.WriteLine("1. Open New Tab");
                Console.WriteLine("2. Visit Page");
                Console.WriteLine("3. Back");
                Console.WriteLine("4. Forward");
                Console.WriteLine("5. Show Current Page");
                Console.WriteLine("6. Close Current Tab");
                Console.WriteLine("7. Reopen Closed Tab");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        browser.OpenNewTab();
                        break;

                    case 2:
                        if (browser.GetCurrentTab() != null)
                        {
                            Console.Write("Enter URL: ");
                            string url = Console.ReadLine();
                            browser.GetCurrentTab().VisitPage(url);
                        }
                        else
                        {
                            Console.WriteLine("Open a tab first");
                        }
                        break;

                    case 3:
                        if (browser.GetCurrentTab() != null)
                            browser.GetCurrentTab().GoBack();
                        else
                            Console.WriteLine("No tab open");
                        break;

                    case 4:
                        if (browser.GetCurrentTab() != null)
                            browser.GetCurrentTab().GoForward();
                        else
                            Console.WriteLine("No tab open");
                        break;

                    case 5:
                        if (browser.GetCurrentTab() != null)
                            browser.GetCurrentTab().ShowCurrentPage();
                        else
                            Console.WriteLine("No tab open");
                        break;

                    case 6:
                        browser.CloseCurrentTab();
                        break;

                    case 7:
                        browser.ReopenClosedTab();
                        break;

                    case 0:
                        Console.WriteLine("Exiting BrowserBuddy...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 0);
        }
    }
}
