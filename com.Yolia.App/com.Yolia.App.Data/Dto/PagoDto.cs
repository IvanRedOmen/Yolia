using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nelibur.ObjectMapper;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class PagoDto
    {
        public int FolioServicio { get; set; }

        public int FolioPago { get; set; }
        public string ClavePago { get; set; }
        public string MontoPago { get; set; }
        public DateTime FechaPago { get; set; }

        public ICollection<ServicioDto> Servicio { get; set; }

        internal static List<PagoDto> ToMap(List<Model.Pago> listEntity)
        {
            List<PagoDto> listDto = (from e in listEntity select ToMap(e)).ToList();
            return listDto;
        }

        internal static PagoDto ToMap(Model.Pago entity)
        {
            if (entity == null) return null;
            PagoDto dto = TinyMapper.Map<PagoDto>(entity);
            return dto;
        }

        internal static Model.Pago ToUnMap(PagoDto dto)
        {
            TinyMapper.Bind<PagoDto, Model.Pago>();
            Model.Pago entity = TinyMapper.Map<Model.Pago>(dto);
            return entity;
        }

    }
}
