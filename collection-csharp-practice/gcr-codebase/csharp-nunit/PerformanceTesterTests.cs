using NUnit.Framework;
using CSharpNUnit;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class PerformanceTesterTests
    {
        private PerformanceTester performanceTester;

        [SetUp]
        public void SetUp()
        {
            performanceTester = new PerformanceTester();
        }

        [Test]
        [Timeout(2000)]
        public void LongRunningTask_ExceedsTimeout_FailsTest()
        {
            // This test will fail because the method takes 3 seconds
            // and the timeout is set to 2 seconds
            Assert.Fail("This test should timeout");
        }

        [Test]
        [Timeout(1000)]
        public void QuickTask_CompletesWithinTimeout_PassesTest()
        {
            string result = performanceTester.QuickTask();
            Assert.AreEqual("Task completed", result);
        }

        [Test]
        public void LongRunningTask_ExecutesWithoutTimeout_ReturnsResult()
        {
            string result = performanceTester.LongRunningTask();
            Assert.AreEqual("Task completed", result);
        }
    }
}
