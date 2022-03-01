using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class Main : Form
    {
        private Ingreso _ingreso;
        public Main()
        {
            InitializeComponent();
            _ingreso = new Ingreso();   
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            agregar agregar = new agregar();
            agregar.ShowDialog(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            TodosProductos();
        }

        public void TodosProductos(string buscartext = null)
        {
            List<Producto> productos = _ingreso.GetProductos(buscartext);
            grid_contenido.DataSource = productos;
        }

        private void grid_contenido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)grid_contenido.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value.ToString() == "Editar")
            {
                agregar Agregar = new agregar();
                Agregar.CargarProducto(new Producto
                {
                    Id = int.Parse(grid_contenido.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    producto = Convert.ToString(grid_contenido.Rows[e.RowIndex].Cells[1].Value).ToString(),
                    cantidad = int.Parse(grid_contenido.Rows[e.RowIndex].Cells[2].Value.ToString()),
                    peso = int.Parse(grid_contenido.Rows[e.RowIndex].Cells[3].Value.ToString()),
                    fecha = Convert.ToDateTime(grid_contenido.Rows[e.RowIndex].Cells[4].Value.ToString()),
                    valor = int.Parse(grid_contenido.Rows[e.RowIndex].Cells[5].Value.ToString()),
                });
                Agregar.ShowDialog(this);
            }
            else if(cell.Value.ToString() == "Eliminar")
            {
                EliminarProducto(int.Parse(grid_contenido.Rows[e.RowIndex].Cells[0].Value.ToString()));
                TodosProductos();
            }
        }

        private void EliminarProducto(int id)
        {
            _ingreso.EliminarProducto(id);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            TodosProductos(txt_buscar.Text);
            txt_buscar.Text = string.Empty.ToString();
        }
    }
}
