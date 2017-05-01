using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Model
{
    public class Pago
    {
        [Key]
        public int FolioPago { get; set; }
        public string ClavePago { get; set; }
        public string MontoPago { get; set; }
        public DateTime FechaPago { get; set; }

        public ICollection<Servicio> Servicio { get; set; }

    }
}
