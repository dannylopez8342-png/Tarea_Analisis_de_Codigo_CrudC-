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
    public partial class FormCategorizar : Form
    {
     
        private string _idOriginal;
        private FormCategoria _formCategoria;

        public FormCategorizar(FormCategoria formCategoria, string id, bool gdmodificar)
        {
            InitializeComponent();
            this._formCategoria = formCategoria;
            this._idOriginal = id;

            if (gdmodificar)
                CargarDatos();
            else
                GenerarNuevoId();
        }

        private void CargarDatos()
        {
            Categoria objCategoria = new Categoria();
            DataTable dt = objCategoria.ListarCategoria(_idOriginal);

            if (dt.Rows.Count > 0)
            {
                txtIdCategoria.Text = dt.Rows[0]["IdCategoria"].ToString();
                txtNombre.Text = dt.Rows[0]["NombreCategoria"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
            }
        }

        private void GenerarNuevoId()
        {
            Categoria objCategoria = new Categoria();
            string nuevoId = objCategoria.GenerarCodigoCategoria();
            txtIdCategoria.Text = nuevoId;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            if (string.IsNullOrEmpty(_idOriginal))
            {
                categoria.AgregarCategoria(
                    txtIdCategoria.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim());

                MessageBox.Show("Categoría agregada correctamente.");
            }
            else
            {
                categoria.ModificarCategoria(
                    _idOriginal,
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim());

                MessageBox.Show("Categoría modificada correctamente.");
            }

            _formCategoria.llenarGrid();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
    
}
