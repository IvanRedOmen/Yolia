using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class ServicioDto
    {
        public int FolioServicio { get; set; }
        public System.DateTime FechaIniServicio { get; set; }
        public System.DateTime FechaFinServicio { get; set; }
        public string TipoServicio { get; set; }
        public PagoDto Pago { get; set; }



    }
}
