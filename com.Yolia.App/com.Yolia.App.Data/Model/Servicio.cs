using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Model
{
    public class Servicio
    {
        [Key]
        public int FolioServicio { get; set; }
        public DateTime FechaIniServicio { get; set; }
        public DateTime FechaFinServicio { get; set; }
        public int ClienteId { get; set; }

        public ICollection<Cliente> Cliente { get; set; }

        public virtual ICollection<Pago> Pago { get; set; }
    }
}
