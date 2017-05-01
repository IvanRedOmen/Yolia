using com.Yolia.App.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Test.Mock
{
    public static class DomicilioMock
    {

        public static DomicilioDto New
        {
            get
            {
                DomicilioDto dto = new DomicilioDto();
                dto.Calle = Util.GenerateWord(11);
                dto.CodPostal = Util.GenerateWord(20);
                dto.Colonia = Util.GenerateWord(20);
                dto.Estado = Util.GenerateWord(20);
                dto.NumExterior = Util.GenerateWord(10);
                dto.NumInterior = Util.GenerateWord(15);
                return dto;
            }
        }


        public static List<DomicilioDto> List(int n)
        {
            List<DomicilioDto> list = new List<DomicilioDto>();
            for (int i = 0; i < n; i++)
            {
                list.Add(New);
            }
            return list;
        }
    }
}
