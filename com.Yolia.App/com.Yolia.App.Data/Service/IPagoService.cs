using com.Yolia.App.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Service
{
    public interface IPagoService
    {
        List<PagoDto> GetAll();
        PagoDto Save(int servicioId,PagoDto dto);
        PagoDto FindPagobyId(int pagoId);
        PagoDto Update(PagoDto dto);
    }
}