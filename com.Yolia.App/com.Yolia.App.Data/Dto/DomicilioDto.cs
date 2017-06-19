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
        public virtual Cliente Cliente { get; set; }

        internal static List<DomicilioDto> ToMap(List<Domicilio> list)
        {
            List<DomicilioDto> listDto = new List<DomicilioDto>();
            if (list == null)
                return listDto;
            list.ForEach(e => listDto.Add(ToMap(e,null)));
            return listDto;
        }

        internal static DomicilioDto ToMap(Domicilio entity, DomicilioDto dto)
        {
            if (dto == null) dto = new DomicilioDto();

            dto.Calle = entity.Calle;
            dto.Cliente = entity.Cliente;
            dto.CodPostal = entity.CodPostal;
            dto.Colonia = entity.Colonia;
            dto.DomicilioId = entity.DomicilioId;
            dto.Estado = entity.Estado;
            dto.NumExterior = entity.NumExterior;
            dto.NumInterior = entity.NumInterior;
            return dto;
        }

        internal static Domicilio ToUnMap(DomicilioDto dto,Domicilio entity)
        {
            if (dto == null) return null;
            if (entity == null) entity = new Domicilio();

            entity.Calle = dto.Calle;
            entity.Cliente = dto.Cliente;
            entity.CodPostal = dto.CodPostal;
            entity.Colonia = dto.Colonia;
            entity.Estado = dto.Estado;
            entity.NumExterior = dto.NumExterior;
            entity.NumInterior = dto.NumInterior;
            entity.DomicilioId = dto.DomicilioId;
            return entity;
        }

    }

}

