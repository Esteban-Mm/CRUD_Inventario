using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    public class Producto
    {
        public int Id { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public int peso { get; set; }
        public DateTime fecha { get; set; }
        public int valor { get; set; }

    }
}
