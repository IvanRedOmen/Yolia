using com.Yolia.App.Data.Model;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class ServicioDto
    {
        [Key]
        public int FolioServicio { get; set; }
        public DateTime FechaIniServicio { get; set; }
        public DateTime FechaFinServicio { get; set; }
        public string TipoServicio { get; set; }

        public ICollection<Cliente> Cliente { get; set; }

        public virtual Pago Pago { get; set; }

        internal static List<ServicioDto> ToMap(List<Servicio> listEntity)
        {
            List<ServicioDto> listDto = (from entity in listEntity select ToMap(entity)).ToList();
            return listDto;
        }

        internal static ServicioDto ToMap(Servicio entity)
        {
            if (entity == null) return null;
            TinyMapper.Bind<Servicio, ServicioDto>(config =>
            {
                config.Bind(a => a.FolioServicio, b => b.FolioServicio);
            });
            var dto = TinyMapper.Map<ServicioDto>(entity);
            return dto;
        }

        internal static Servicio ToUnMap(ServicioDto dto)
        {
            if (dto == null) return null;
            TinyMapper.Bind<ServicioDto, Servicio>(config =>
            {
                config.Ignore(_dto => _dto.Pago);
                config.Bind(a => a.FolioServicio, b => b.FolioServicio);
            });
            Servicio entity = TinyMapper.Map<Servicio>(dto);
            return entity;
        }

    }
}
