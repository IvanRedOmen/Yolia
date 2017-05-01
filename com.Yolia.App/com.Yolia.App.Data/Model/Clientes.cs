using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Model
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string ClienteRFC { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumFijo { get; set; }
        public string NumMovil { get; set; }
        public List<Domicilio> Domicilios { get; set; }
        public List<Servicio> Servicios { get; set; }

        public Cliente()
        {
            Domicilios = new List<Domicilio>();
            Servicios = new List<Servicio>();
        }

    }
}
