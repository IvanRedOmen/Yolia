using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Yolia.App.Data.Dto;
using com.Yolia.App.Data.Model;

namespace com.Yolia.App.Data.Service
{
    public class ClienteService : IClienteService
    {
        public List<ClienteDto> GetAll()
        {
            List<ClienteDto> list = null;
            using(var context = new YoliaEntities())
            {
                list = (from cl in context.Clientes.ToList<Cliente>()
                        select ClienteDto.ToMap(cl)).ToList();
            }
            return list;
        }

        public ClienteDto Save(ClienteDto dto)
        {
            Cliente entity = null;
            using (var context = new YoliaEntities())
            {
                entity = ClienteDto.ToUnMap(dto);
                entity.Domicilios = null;
                context.Clientes.Add(entity);
                int nrecords = context.SaveChanges();
                dto.ClienteId = entity.ClienteId;
                if (nrecords <= 0)
                    return null;
            }
            return dto;
        }

        public ClienteDto FindClienteById(int id)
        {
            ClienteDto dto = null;
            using(var context = new YoliaEntities())
            {
                dto = ClienteDto.ToMap(context.Clientes.Where
                    (e => e.ClienteId == id).FirstOrDefault());
            }
            return dto;
        }

        public ClienteDto Update(ClienteDto dto)
        {
            ClienteDto updated = null;
            using(var context = new YoliaEntities())
            {
                Cliente entity = ClienteDto.ToUnMap(dto);
                context.Entry<Cliente>(entity).State = System.Data.Entity.EntityState.Modified;
                int nrecords = context.SaveChanges();
                if (nrecords > 0)
                {
                    updated = dto;
                }
            }
            return updated;
        }
    }
}
