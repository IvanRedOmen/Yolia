using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Yolia.App.Data.Model;
using Nelibur.ObjectMapper;
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

        internal static List<DomicilioDto> ToMap(List<Domicilio> listEntity)
        {
            List<DomicilioDto> listDto = (from entity in listEntity select ToMap(entity)).ToList();
            return listDto;
        }

        internal static DomicilioDto ToMap(Domicilio entity)
        {
            if (entity == null) return null;
            TinyMapper.Bind<Domicilio, DomicilioDto>(config =>
            {
                config.Bind(a => a.DomicilioId, b => b.DomicilioId);
            });
            var dto = TinyMapper.Map<DomicilioDto>(entity);
            return dto;

        }
        internal static Domicilio ToUnMap(DomicilioDto dto)
        {
            if (dto == null) return null;
            TinyMapper.Bind<DomicilioDto, Domicilio>(config =>
            {
                config.Ignore(_dto => _dto.ClienteClienteId);
                config.Bind(a => a.DomicilioId, b => b.DomicilioId);
            });
            Domicilio entity = TinyMapper.Map<Domicilio>(dto);
            return entity;
        }

    }

}

