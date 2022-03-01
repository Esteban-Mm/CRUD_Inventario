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
    public partial class agregar : Form
    {
        private Ingreso _ingreso;
        private Producto _producto;
        public agregar()
        {
            InitializeComponent();
            _ingreso = new Ingreso();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
            this.Close();
            ((Main)this.Owner).TodosProductos();
        }

        private void GuardarProducto()
        {
            Producto producto = new Producto();
            producto.producto = Convert.ToString(txt_nombre.Text);
            producto.cantidad = Convert.ToInt32(txt_cantidad.Text);
            producto.peso = Convert.ToInt32(txt_peso.Text);
            producto.fecha = Convert.ToDateTime(txt_fecha.Text);
            producto.valor = Convert.ToInt32(txt_valor.Text);

            producto.Id = _producto != null ? _producto.Id : 0;

            _ingreso.guardarProducto(producto);
        }

        public void CargarProducto(Producto producto)
        {
            _producto = producto;
            if(producto != null)
            {
                Limpiar();

                txt_nombre.Text = producto.producto.ToString();
                txt_cantidad.Text = producto.cantidad.ToString(); 
                txt_peso.Text = producto.peso.ToString(); 
                txt_fecha.Text = producto.fecha.ToString();
                txt_valor.Text = producto.valor.ToString();
            }
        }

        private void Limpiar()
        {
            txt_nombre.Text = string.Empty;
            txt_cantidad.Text = string.Empty;
            txt_peso.Text = string.Empty;
            txt_fecha.Text = string.Empty;
            txt_valor.Text = string.Empty;
        }
    }
}
