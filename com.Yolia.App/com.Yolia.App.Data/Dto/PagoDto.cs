using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class PagoDto
    {
        public int FolioPago { get; set; }
        public string ClavePago { get; set; }
        public string MontoPago { get; set; }
        public System.DateTime FechaPago { get; set; }
        public ServicioDto Servicio { get; set; }

    }
}
