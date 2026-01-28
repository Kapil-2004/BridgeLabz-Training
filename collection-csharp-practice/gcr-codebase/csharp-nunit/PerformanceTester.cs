using System;
using System.Threading;

namespace CSharpNUnit
{
    public class PerformanceTester
    {
        public string LongRunningTask()
        {
            Thread.Sleep(3000);
            return "Task completed";
        }

        public string QuickTask()
        {
            Thread.Sleep(500);
            return "Task completed";
        }
    }
}
