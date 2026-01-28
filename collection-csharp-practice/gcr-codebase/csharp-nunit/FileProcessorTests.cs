using NUnit.Framework;
using CSharpNUnit;
using System;
using System.IO;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class FileProcessorTests
    {
        private FileProcessor fileProcessor;
        private string testFilePath;

        [SetUp]
        public void SetUp()
        {
            fileProcessor = new FileProcessor();
            testFilePath = Path.Combine(Path.GetTempPath(), "test_file.txt");
            
            // Clean up if file exists
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up test file
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
        }

        [Test]
        public void WriteToFile_ValidInput_CreatesFile()
        {
            fileProcessor.WriteToFile(testFilePath, "Hello, World!");
            Assert.IsTrue(File.Exists(testFilePath));
        }

        [Test]
        public void WriteToFile_ValidInput_WritesContentCorrectly()
        {
            string content = "Test content";
            fileProcessor.WriteToFile(testFilePath, content);
            
            string readContent = File.ReadAllText(testFilePath);
            Assert.AreEqual(content, readContent);
        }

        [Test]
        public void WriteToFile_EmptyFilename_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => fileProcessor.WriteToFile("", "content"));
        }

        [Test]
        public void WriteToFile_NullFilename_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => fileProcessor.WriteToFile(null, "content"));
        }

        [Test]
        public void ReadFromFile_ValidFile_ReadsContentCorrectly()
        {
            string expectedContent = "Test content for reading";
            File.WriteAllText(testFilePath, expectedContent);

            string readContent = fileProcessor.ReadFromFile(testFilePath);
            Assert.AreEqual(expectedContent, readContent);
        }

        [Test]
        public void ReadFromFile_NonExistentFile_ThrowsIOException()
        {
            string nonExistentFile = Path.Combine(Path.GetTempPath(), "non_existent_file.txt");
            Assert.Throws<IOException>(() => fileProcessor.ReadFromFile(nonExistentFile));
        }

        [Test]
        public void ReadFromFile_EmptyFilename_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => fileProcessor.ReadFromFile(""));
        }

        [Test]
        public void FileExists_ExistingFile_ReturnsTrue()
        {
            fileProcessor.WriteToFile(testFilePath, "content");
            Assert.IsTrue(fileProcessor.FileExists(testFilePath));
        }

        [Test]
        public void FileExists_NonExistentFile_ReturnsFalse()
        {
            string nonExistentFile = Path.Combine(Path.GetTempPath(), "non_existent.txt");
            Assert.IsFalse(fileProcessor.FileExists(nonExistentFile));
        }

        [Test]
        public void WriteAndRead_RoundTrip_ContentPreserved()
        {
            string originalContent = "Round trip test content";
            fileProcessor.WriteToFile(testFilePath, originalContent);
            
            string readContent = fileProcessor.ReadFromFile(testFilePath);
            Assert.AreEqual(originalContent, readContent);
        }
    }
}
