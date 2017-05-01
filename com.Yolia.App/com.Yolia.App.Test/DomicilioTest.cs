using com.Yolia.App.Data.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Test
{
    [TestClass]
    public class DomicilioTest
    {
        IDomicilioService service;

        [TestInitialize]
        public void Init()
        {
            service = new DomicilioService();
        }

        [TestMethod]
        public void SaveTest()
        {
            ClienteService clientService = new ClienteService();
            var clientes = clientService.GetAll();
            if (clientes.Count > 0)
            {
                int clienteId = clientes[0].ClienteId;
                var dto = Mock.DomicilioMock.New;
                var dtoSaved = service.Save(clienteId, dto);
                Assert.IsNotNull(dtoSaved);
            }
        }

        [TestMethod]
        public void GetAllTest()
        {

        }
    }
}
