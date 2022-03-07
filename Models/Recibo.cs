using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRecibos.Models
{
    public class Recibo
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public float Monto { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }
        public string  Comentario { get; set; }
    }
}
