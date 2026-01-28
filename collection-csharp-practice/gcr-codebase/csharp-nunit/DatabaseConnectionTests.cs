using NUnit.Framework;
using CSharpNUnit;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection dbConnection;

        [SetUp]
        public void SetUp()
        {
            dbConnection = new DatabaseConnection();
            dbConnection.Connect();
        }

        [TearDown]
        public void TearDown()
        {
            dbConnection.Disconnect();
        }

        [Test]
        public void Connect_InitializesConnection_IsConnectedIsTrue()
        {
            Assert.IsTrue(dbConnection.IsConnected);
        }

        [Test]
        public void Disconnect_ClosesConnection_IsConnectedIsFalse()
        {
            dbConnection.Disconnect();
            Assert.IsFalse(dbConnection.IsConnected);
        }

        [Test]
        public void GetConnectionStatus_WhenConnected_ReturnsConnected()
        {
            string status = dbConnection.GetConnectionStatus();
            Assert.AreEqual("Connected", status);
        }

        [Test]
        public void GetConnectionStatus_WhenDisconnected_ReturnsDisconnected()
        {
            dbConnection.Disconnect();
            string status = dbConnection.GetConnectionStatus();
            Assert.AreEqual("Disconnected", status);
        }

        [Test]
        public void ReconnectAfterDisconnect_IsConnectedReturnsTrue()
        {
            dbConnection.Disconnect();
            Assert.IsFalse(dbConnection.IsConnected);

            dbConnection.Connect();
            Assert.IsTrue(dbConnection.IsConnected);
        }
    }
}
