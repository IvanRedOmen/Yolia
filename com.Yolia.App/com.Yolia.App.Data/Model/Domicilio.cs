using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Model
{
    public class Domicilio
    {
        [Key]
        public int DomicilioId { get; set; }
        public string Calle { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; }
        public string CodPostal { get; set; }

        public Cliente Cliente{ get; set; }

    }
}
