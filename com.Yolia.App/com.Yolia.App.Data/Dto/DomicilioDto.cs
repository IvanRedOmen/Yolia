using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class DomicilioDto
    {

        public int DomicilioId { get; set; }
        public string Calle { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; }
        public string CodPostal { get; set; }
        public int ClienteClienteId { get; set; }

        public DomicilioDto()
        {

        }

        internal static List<DomicilioDto> ToMap(List<Model.Domicilio> listEntity)
        {
            List<DomicilioDto> listDto = (from e in listEntity select ToMap(e)).ToList();
            return listDto;
        }
       
        internal static DomicilioDto ToMap(Model.Domicilio entity)
        {
            if (entity == null) return null;
            DomicilioDto dto = TinyMapper.Map<DomicilioDto>(entity);
            return dto;
        }

        internal static Model.Domicilio ToUnMap(DomicilioDto dto)
        {
            TinyMapper.Bind<DomicilioDto, Model.Domicilio>();
            Model.Domicilio entity = TinyMapper.Map<Model.Domicilio>(dto);
            return entity;
        }
    }
}
