using com.Yolia.App.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Test.Mock
{
    public static class ClienteMock
    {
        public static ClienteDto New
        {
            get
            {
                ClienteDto dto = new ClienteDto();
                dto.ClienteRFC = Util.GenerateWord(11);
                dto.Nombre = Util.GenerateWord(20);
                dto.ApellidoMaterno = Util.GenerateWord(20);
                dto.ApellidoPaterno = Util.GenerateWord(20);
                dto.NumFijo = Util.GenerateWord(10);
                dto.NumMovil = Util.GenerateWord(15);
                dto.Domicilios = null;
                dto.Servicios = null;
                return dto;
            }
        }

        public static List<ClienteDto> List(int n)
        {
            List<ClienteDto> list = new List<ClienteDto>();
            for (int i = 0; i < n; i++)
            {
                list.Add(New);
            }
            return list;
        }
    }
}
