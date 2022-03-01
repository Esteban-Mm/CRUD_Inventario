using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    internal class AccesoDatos
    {
        private SqlConnection productos = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Londoño_varela_BD;Data Source=LAPTOP-V1P0RF7H");

        public void InsertarProducto(Producto producto)
        {
            try
            {
                productos.Open();
                string query = @"
                                INSERT INTO inventario ([producto], [cantidad], [peso], [fecha], [valor])
                                 VALUES (@producto, @cantidad, @peso, @fecha, @valor) ";

                SqlParameter Producto = new SqlParameter("@producto", producto.producto);
                SqlParameter Cantidad = new SqlParameter("@cantidad", producto.cantidad);
                SqlParameter Peso = new SqlParameter("@peso", producto.peso);
                SqlParameter Fecha = new SqlParameter("@fecha", producto.fecha);
                SqlParameter Valor = new SqlParameter("@valor", producto.valor);

                SqlCommand command = new SqlCommand(query, productos);
                command.Parameters.Add(Producto);
                command.Parameters.Add(Cantidad);
                command.Parameters.Add(Peso);
                command.Parameters.Add(Fecha);
                command.Parameters.Add(Valor);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                productos.Close();
            }
        }

        public void ActualizarProducto(Producto producto)
        {
            try
            {
                productos.Open();
                string query = @"UPDATE inventario SET
                                    producto = @producto,
                                    cantidad = @cantidad,
                                    peso = @peso,
                                    fecha = @fecha,
                                    valor = @valor
                                WHERE Id = @Id";

                SqlParameter Id = new SqlParameter("@Id", producto.Id);
                SqlParameter Producto = new SqlParameter("@producto", producto.producto);
                SqlParameter Cantidad = new SqlParameter("@cantidad", producto.cantidad);
                SqlParameter Peso = new SqlParameter("@peso", producto.peso);
                SqlParameter Fecha = new SqlParameter("@fecha", producto.fecha);
                SqlParameter Valor = new SqlParameter("@valor", producto.valor);

                SqlCommand command = new SqlCommand(query, productos);
                command.Parameters.Add(Id);
                command.Parameters.Add(Producto);
                command.Parameters.Add(Cantidad);
                command.Parameters.Add(Peso);
                command.Parameters.Add(Fecha);
                command.Parameters.Add(Valor);

                command.ExecuteNonQuery();
                MessageBox.Show("Producto actualizado");
            }
            catch (Exception)
            {
                throw;
            }
            finally { productos.Close(); }
        }

        public void EliminarProducto(int id)
        {
            try
            {
                productos.Open();
                string query = @"DELETE FROM inventario WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, productos);
                command.Parameters.Add(new SqlParameter("@id", id));

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }finally { productos.Close(); }
        }

        public List<Producto> GetProductos(string buscartext = null)
        {
            List<Producto> producto = new List<Producto>();    
            try
            {
                productos.Open();
                string query = @"SELECT id, producto, cantidad, peso, fecha, valor FROM inventario ";

                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(buscartext))
                {
                    query += "WHERE producto LIKE @buscartext OR cantidad LIKE @buscartext OR cantidad LIKE @buscartext OR peso LIKE @buscartext OR fecha LIKE @buscartext OR valor LIKE @buscartext";
                    command.Parameters.Add(new SqlParameter("@buscartext", $"%{buscartext}%"));
                }

                command.CommandText = query;
                command.Connection = productos;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    producto.Add(new Producto
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        producto = reader["producto"].ToString(),
                        cantidad = int.Parse(reader["cantidad"].ToString()),
                        peso = int.Parse(reader["peso"].ToString()),
                        fecha = DateTime.Parse(reader["fecha"].ToString()),
                        valor = int.Parse(reader["valor"].ToString())
                    });
                }
            }   
            catch (Exception)
            {

                throw;
            }finally { productos.Close(); }
            return producto;
        }

    }
}
