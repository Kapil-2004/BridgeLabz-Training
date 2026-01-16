using System;

namespace BrowserBuddy
{
    public class HistoryNode
    {
        public string Url;
        public HistoryNode Previous;
        public HistoryNode Next;

        public HistoryNode(string url)
        {
            Url = url;
            Previous = null;
            Next = null;
        }
    }
}
