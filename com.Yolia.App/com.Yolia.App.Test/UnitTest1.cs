using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.Yolia.App.Data.Service;

namespace com.Yolia.App.Test
{
    [TestClass]
    public class UnitTest1
    {
        ClienteService service;

        [TestInitialize]
        public void Init()
        {
            service = new ClienteService();
        }

        [TestMethod]
        public void SaveTest()
        {
            var dto = Mock.ClienteMock.New;

        }
    }
}
