using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class DomicilioDto
    {

        public int DomicilioId { get; set; }
        public string Calle { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; }
        public string CodPostal { get; set; }
        public int ClienteClienteId { get; set; }


    }
}
