using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFinal2
{
    public class Pedido
    {
        public string IdCliente { get; set; }
        public string IdPedido { get; set; }
        public string IdEmpleado { get; set; }
        public string FechaPedido { get; set; }
        public string FechaEntrega { get; set; }
        public string FechaEnvio { get; set; }
        public string FormaEnvio { get; set; }
        public string Cargo { get; set; }
        public string Destinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string CiudadDestinatario { get; set; }
        public string RegionDestinatario { get; set; }
        public string CodPostalDestinatario { get; set; }
        public string PaisDestinatario { get; set; }

        public Pedido()
        {
        }
    }
}
