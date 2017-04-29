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
            throw new NotImplementedException();
        }

        public ClienteDto Save(ClienteDto dto)
        {
            ClienteSet entity = null;
            using (var context = new YoliaEntities())
            {
                entity = ClienteDto.ToUnMap(dto);
                entity.DomicilioSet = null;
                entity.ServicioSet = null;
                context.ClienteSet.Add(entity);
                int nrecords = context.SaveChanges();
                dto.ClienteId = entity.ClienteId;
                if (nrecords <= 0)
                    return null;
            }
            return dto;
        }
    }
}
