using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Yolia.App.Data.Dto;
using com.Yolia.App.Data.Model;

namespace com.Yolia.App.Data.Service
{
    public class ServicioService : IServicioService
    {
        public ServicioDto FindServicioById(int id)
        {
            ServicioDto dto = null;
            using (var context = new YoliaEntities())
            {
                dto = ServicioDto.ToMap(context.Servicios.Where
                    (e => e.FolioServicio == id).FirstOrDefault());
            }
            return dto;
        }

        public List<ServicioDto> GetAll()
        {
            List<ServicioDto> list = null;
            using (var context = new YoliaEntities())
            {
                list = (from c in context.Servicios.ToList<Servicio>()
                        select ServicioDto.ToMap(c)).ToList();
            }
            return list;
        }

        public ServicioDto Save(int clienteId, ServicioDto dto)
        {
            ServicioDto servicio = null;
            using (var context = new YoliaEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Cliente cliente = context.Clientes.Where(e => e.ClienteId  == clienteId).FirstOrDefault();
                    if (cliente != null)
                    {
                        Servicio entity = ServicioDto.ToUnMap(dto);
                        entity.Pago = null;
                        cliente.Servicios.Add(entity);
                        int nrecords = context.SaveChanges();
                        nrecords = context.SaveChanges();
                        transaction.Commit();
                        if (nrecords > 0)
                        {
                            dto.FolioServicio = entity.FolioServicio;
                            dto.TipoServicio = dto.TipoServicio;
                            servicio = dto;
                        }
                    }
                }
            }
            return servicio;
        }

        public ServicioDto Update(ServicioDto dto)
        {
            ServicioDto updated = null;
            Servicio item = null;
            using (var context = new YoliaEntities())
            {
                item = context.Servicios.Where(e => e.FolioServicio == dto.FolioServicio).FirstOrDefault();
            }
            using (var context = new YoliaEntities())
            {
                if (item != null)
                {
                    Servicio entity = ServicioDto.ToUnMap(dto);
                    context.Entry<Servicio>(entity).State = System.Data.Entity.EntityState.Modified;
                    int nrecords = context.SaveChanges();
                    if (nrecords > 0)
                        updated = dto;
                }
            }
            return updated;
        }
    }
}
