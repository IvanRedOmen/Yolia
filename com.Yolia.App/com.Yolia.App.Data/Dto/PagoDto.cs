﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.Yolia.App.Data.Dto
{
    public class PagoDto
    {
        public int FolioServicio { get; set; }

        public int FolioPago { get; set; }
        public string ClavePago { get; set; }
        public string MontoPago { get; set; }
        public DateTime FechaPago { get; set; }

        public ICollection<ServicioDto> Servicio { get; set; }



    }
}
