using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIENDA_ELECTRONICA
{
    public partial class FormInventario : Form
    {
        private FormProducto _formProductos;
        private string _idProducto;
        private bool _esEditar;

        // Constructor corregido que acepta 3 parámetros
        public FormInventario(FormProducto formProducto, string idProducto, bool esEditar)
        {
            InitializeComponent();

            _formProductos = formProducto;
            _idProducto = idProducto;
            _esEditar = esEditar;

            CargarCategorias(); // ComboBox

            if (_esEditar)
            {
                CargarDatosProducto(); // si es edición
            }
            else
            {
                Producto prod = new Producto();
                txtIdpro.Text = prod.GenerarCodigoProducto();
                txtIdpro.ReadOnly = true;
            }
        }

        private void CargarCategorias()
        {
            Categoria cat = new Categoria(); // Clase que debe devolver lista de categorías
            DataTable datos = cat.ListarCategoria("");

            cboCategoria.DataSource = datos;
            cboCategoria.DisplayMember = "NombreCategoria";
            cboCategoria.ValueMember = "IdCategoria";
        }

        private void CargarDatosProducto()
        {
            Producto obj = new Producto();
            DataTable dt = obj.ListarProducto(_idProducto);

            if (dt.Rows.Count > 0)
            {
                txtIdpro.Text = dt.Rows[0]["IdProducto"].ToString();
                txtNombre.Text = dt.Rows[0]["Nombre"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtPrecio.Text = dt.Rows[0]["Precio"].ToString();
                txtStock.Text = dt.Rows[0]["Stock"].ToString();
                cboCategoria.SelectedValue = dt.Rows[0]["IdCategoria"].ToString();

                txtIdpro.ReadOnly = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos requeridos.");
                return;
            }

            // Obtener datos del formulario
            string id = txtIdpro.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            decimal precio;
            int stock;

            // Validar que precio y stock sean números válidos
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("El stock debe ser un número entero válido.");
                return;
            }

            string idCategoria = cboCategoria.SelectedValue.ToString();

            Producto producto = new Producto();

            try
            {
                if (_esEditar)
                {
                    producto.ModificarProducto(id, nombre, descripcion, precio, stock, idCategoria);
                    MessageBox.Show("Producto actualizado correctamente.");
                }
                else
                {
                    producto.AgregarProducto(id, nombre, descripcion, precio, stock, idCategoria);
                    MessageBox.Show("Producto guardado correctamente.");
                }

                _formProductos.llenarGrid(); // actualizar lista productos
                this.Close(); // cerrar formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el producto: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}



