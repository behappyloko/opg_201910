using Microsoft.VisualStudio.TestTools.UnitTesting;
using opg_201910_interview.Services.IO;
using System;
using System.IO;

namespace UnitTest_Project
{
    [TestClass]
    public class UnitTest1
    {
        ReadService _readService;
        [TestInitialize]
        public void Initialize()
        {
            _readService = new ReadService();

        }

        [TestMethod]
        [DataRow("../../../../opg-201910Base-master/UploadFiles/ClientA", 6)]
        public void ReadWithoutSortOptions_Test(string directory, int expectedFileCount)
        {
            FileInfo[] files = _readService.ReadDirectory(directory);

            Assert.AreEqual(expectedFileCount, files.Length);
        }

        [TestMethod]
        [DataRow("../../../../opg-201910Base-master/UploadFiles/ClientA", 5 , "shovel", "waghor", "blaze", "discus")]
        [DataRow("../../../../opg-201910Base-master/UploadFiles/ClientA", 4 , "waghor", "blaze", "discus")]
        [DataRow("../../../../opg-201910Base-master/UploadFiles/ClientA", 3 , "shovel", "waghor", "discus")]
        public void ReadWithSortOptions_Test(string directory, int expectedFileCount, params string[] customSort)
        {
            FileInfo[] files = _readService.ReadDirectory(directory, customSort);

            Assert.AreEqual(expectedFileCount, files.Length);
        }
    }
}
