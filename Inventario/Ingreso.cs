using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    internal class Ingreso
    {
        private AccesoDatos _accesoDatos;

        public Ingreso()
        {
            _accesoDatos = new AccesoDatos();   
        }
        public Producto guardarProducto(Producto producto)
        {
            if (producto.Id == 0)
                _accesoDatos.InsertarProducto(producto);
            else
                _accesoDatos.ActualizarProducto(producto);

            return producto;
        }

        public List<Producto> GetProductos(string buscartext = null)
        {
            return _accesoDatos.GetProductos(buscartext);
        }

        public void EliminarProducto(int id)
        {
            _accesoDatos.EliminarProducto(id);
        }
    }
}
