using System;
using System.Collections.Generic;

namespace BrowserBuddy
{
    public class Browser
    {
        private Tab currentTab;
        private Stack<Tab> closedTabs;

        public Browser()
        {
            closedTabs = new Stack<Tab>();
            currentTab = null;
        }

        public void OpenNewTab()
        {
            currentTab = new Tab();
            Console.WriteLine("New tab opened");
        }

        public Tab GetCurrentTab()
        {
            return currentTab;
        }

        public void CloseCurrentTab()
        {
            if (currentTab != null)
            {
                closedTabs.Push(currentTab);
                currentTab = null;
                Console.WriteLine("Current tab closed");
            }
            else
            {
                Console.WriteLine("No tab is open");
            }
        }

        public void ReopenClosedTab()
        {
            if (closedTabs.Count > 0)
            {
                currentTab = closedTabs.Pop();
                Console.WriteLine("Closed tab reopened");
                currentTab.ShowCurrentPage();
            }
            else
            {
                Console.WriteLine("No closed tabs available");
            }
        }
    }
}
