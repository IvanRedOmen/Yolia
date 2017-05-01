using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.Yolia.App.Data.Service;
using System.Collections;

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
            int i = 0;
            ArrayList dtoSavedList = new ArrayList();
            do {
                var dto = Mock.ClienteMock.New;
                var dtoSaved = service.Save(dto);
                dtoSavedList.Add(dtoSaved);
                i = i + 1;
            }
            while (i<=9);
            Assert.IsNotNull(dtoSavedList);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var list = service.GetAll();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void FindByIdTest()
        {
            int id = 1;
            var dtoresult = service.FindClienteById(id);
            Assert.IsNotNull(dtoresult);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var list = service.GetAll();
            if (list.Count > 0)
            {
                var dto = list[0];
                dto.Nombre = Mock.Util.GenerateWord(20);
                dto.NumMovil = "5534343454";
                var updated = service.Update(dto);
                Assert.IsNotNull(updated);
            }
        }

    }
}
