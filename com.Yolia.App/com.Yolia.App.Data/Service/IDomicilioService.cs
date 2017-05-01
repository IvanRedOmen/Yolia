using com.Yolia.App.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Service
{
    public interface IDomicilioService
    {
        List<DomicilioDto> GetAll();
        DomicilioDto Save(int clienteId,DomicilioDto dto);
        DomicilioDto FindDomicilioById(int id);
        DomicilioDto Update(DomicilioDto dto);
    }
}
