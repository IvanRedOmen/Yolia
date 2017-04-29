using com.Yolia.App.Data.Model;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class ClienteDto { 
  
        public ClienteDto()
        {
            Domicilios = new List<DomicilioDto>();
        }

        public int ClienteId { get; set; }
        public string ClienteRFC { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumFijo { get; set; }
        public string NumMovil { get; set; }
        public List<DomicilioDto> Domicilios { get; set; }
        public List<ServicioDto> Servicios { get; set; }

        internal static List<ClienteDto> ToMap(List<ClienteSet> listEntity)
        {
            List<ClienteDto> listDto = (from entity in listEntity select ToMap(entity)).ToList();
            return listDto;
        }


        internal static ClienteDto ToMap(ClienteSet entity)
        {
            if (entity == null) return null;
            TinyMapper.Bind<ClienteSet, ClienteDto>(config =>
            {
                config.Bind(a => a.ClienteId, b => b.ClienteId);
            });
            var dto = TinyMapper.Map<ClienteDto>(entity);
            return dto;
        }

        internal static ClienteSet ToUnMap(ClienteDto dto)
        {
            if (dto == null) return null;
            TinyMapper.Bind<ClienteDto, ClienteSet>(config =>
            {
                config.Ignore(_dto => _dto.Domicilios);
                config.Bind(a => a.ClienteId, b => b.ClienteId);
            });
            ClienteSet entity = TinyMapper.Map<ClienteSet>(dto);
            return entity;
        }

    }
}
