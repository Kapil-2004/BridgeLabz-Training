using NUnit.Framework;
using CSharpNUnit;
using System.Collections.Generic;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class ListManagerTests
    {
        private ListManager listManager;
        private List<int> testList;

        [SetUp]
        public void SetUp()
        {
            listManager = new ListManager();
            testList = new List<int>();
        }

        [Test]
        public void AddElement_SingleElement_AddsElementToList()
        {
            listManager.AddElement(testList, 5);
            Assert.AreEqual(1, testList.Count);
            Assert.Contains(5, testList);
        }

        [Test]
        public void AddElement_MultipleElements_AddsAllElements()
        {
            listManager.AddElement(testList, 5);
            listManager.AddElement(testList, 10);
            listManager.AddElement(testList, 15);
            Assert.AreEqual(3, testList.Count);
        }

        [Test]
        public void AddElement_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => listManager.AddElement(null, 5));
        }

        [Test]
        public void RemoveElement_ExistingElement_RemovesElement()
        {
            testList.Add(5);
            testList.Add(10);
            testList.Add(15);

            listManager.RemoveElement(testList, 10);
            Assert.AreEqual(2, testList.Count);
            Assert.IsFalse(testList.Contains(10));
        }

        [Test]
        public void RemoveElement_NonExistingElement_ListRemainsUnchanged()
        {
            testList.Add(5);
            testList.Add(10);

            listManager.RemoveElement(testList, 20);
            Assert.AreEqual(2, testList.Count);
        }

        [Test]
        public void RemoveElement_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => listManager.RemoveElement(null, 5));
        }

        [Test]
        public void GetSize_EmptyList_ReturnsZero()
        {
            int size = listManager.GetSize(testList);
            Assert.AreEqual(0, size);
        }

        [Test]
        public void GetSize_ListWithElements_ReturnsCorrectSize()
        {
            testList.Add(5);
            testList.Add(10);
            testList.Add(15);

            int size = listManager.GetSize(testList);
            Assert.AreEqual(3, size);
        }

        [Test]
        public void GetSize_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => listManager.GetSize(null));
        }

        [Test]
        public void AddAndRemove_VerifySizeUpdates()
        {
            listManager.AddElement(testList, 5);
            Assert.AreEqual(1, listManager.GetSize(testList));

            listManager.AddElement(testList, 10);
            Assert.AreEqual(2, listManager.GetSize(testList));

            listManager.RemoveElement(testList, 5);
            Assert.AreEqual(1, listManager.GetSize(testList));
        }
    }
}
