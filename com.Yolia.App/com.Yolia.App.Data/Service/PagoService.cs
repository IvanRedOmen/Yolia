using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Yolia.App.Data.Dto;
using com.Yolia.App.Data.Model;

namespace com.Yolia.App.Data.Service
{
    public class PagoService : IPagoService
    {
        public PagoDto FindPagobyId(int pagoId)
        {
            PagoDto dto = null;
            using (var context = new YoliaEntities())
            {
                dto = PagoDto.ToMap(context.Pagos.Where
                    (e => e.FolioPago == pagoId).FirstOrDefault());
            }
            return dto;
        }

        public List<PagoDto> GetAll()
        {
            List<PagoDto> list = null;
            using (var context = new YoliaEntities())
            {
                list = (from c in context.Pagos.ToList<Pago>()
                        select PagoDto.ToMap(c)).ToList();
            }
            return list;
        }

        public PagoDto Save(int servicioId, PagoDto dto)
        {
            PagoDto pago = null;
            using (var context = new YoliaEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Model.Servicio servicio = context.Servicios.Where(e => 
                        e.FolioServicio == servicioId).FirstOrDefault();
                    if (servicio != null)
                    {
                        Pago entity = PagoDto.ToUnMap(dto);
                        servicio.Pago = entity;
                        int nrecords = context.SaveChanges();
                        if (nrecords > 0)
                        {
                            dto.FolioPago = entity.FolioPago;
                            pago = dto;
                        }
                    }
                }
            }
            return pago;
        }

        public PagoDto Update(PagoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
