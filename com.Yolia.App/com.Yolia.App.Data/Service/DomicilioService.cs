using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Yolia.App.Data.Dto;
using com.Yolia.App.Data.Model;

namespace com.Yolia.App.Data.Service
{
    public class DomicilioService : IDomicilioService
    {
        public DomicilioDto FindDomicilioById(int id)
        {
            DomicilioDto dto = null;
            using (var context = new YoliaEntities())
            {
                dto = DomicilioDto.ToMap(context.Domicilios.Where
                    (e => e.DomicilioId == id).FirstOrDefault());
            }
            return dto;
        }

        public List<DomicilioDto> GetAll()
        {
            List<DomicilioDto> list = null;
            using (var context = new YoliaEntities())
            {
                list = (from c in context.Domicilios.ToList<Domicilio>()
                        select DomicilioDto.ToMap(c)).ToList();
            }
            return list;
        }

        public DomicilioDto Save(int clienteId, DomicilioDto dto)
        {
            DomicilioDto domicilio = null;
            using (var context = new YoliaEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Cliente cliente = context.Clientes.Where(e => e.ClienteId == clienteId).FirstOrDefault();
                    if (cliente != null)
                    {
                        Domicilio entity = DomicilioDto.ToUnMap(dto,null);
                        cliente.Domicilios.Add(entity);
                        int nrecords = context.SaveChanges();
                        transaction.Commit();
                        if (nrecords > 0)
                        {
                            dto.DomicilioId = entity.DomicilioId;
                            domicilio = dto;
                        }
                    }
                }
            }
            return domicilio;
        }

        public DomicilioDto Update(DomicilioDto dto)
        {
            DomicilioDto updated = null;
            Domicilio item = null;
            using (var context = new YoliaEntities())
            {
                item = context.Domicilios.Where(
                    e => e.DomicilioId == dto.DomicilioId).FirstOrDefault();
            }
            using (var context = new YoliaEntities())
            {
                if (item != null)
                {
                    Domicilio entity = DomicilioDto.ToUnMap(dto,null);
                    context.Entry<Domicilio>(entity).State = 
                        System.Data.Entity.EntityState.Modified;
                    int nrecords = context.SaveChanges();
                    if (nrecords > 0)
                        updated = dto;
                }
            }
            return updated;
        }
    }
}
