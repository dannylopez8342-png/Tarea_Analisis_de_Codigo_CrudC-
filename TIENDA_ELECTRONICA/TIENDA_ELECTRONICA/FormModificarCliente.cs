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
    public partial class FormModificarCliente : Form
    {

        
        private string _idOriginal;
        private FormCliente _formCliente;

        public FormModificarCliente(FormCliente formCliente,string Id,bool gdmodificar)

        {
            InitializeComponent();
            this._formCliente = formCliente;
            this._idOriginal = Id;
            if (gdmodificar)
                 CargarDatos();

            
        }

        private void CargarDatos()
        {
            Ciente objcliente = new Ciente();
            DataTable dt = objcliente.ListarCliente(_idOriginal);



            if (dt.Rows.Count > 0)
            {
                txt_IdCliente.Text = dt.Rows[0]["IdCliente"].ToString();
                txt_NombreCliente.Text = dt.Rows[0]["Nombre"].ToString();
                txt_Apellido_Cliente.Text = dt.Rows[0]["Apellido"].ToString();
                txt_Telefono.Text = dt.Rows[0]["Telefono"].ToString();
                txt_Correo.Text = dt.Rows[0]["Correo"].ToString();
                txt_Direccion.Text = dt.Rows[0]["Direccion"].ToString();

              
                _idOriginal = dt.Rows[0]["IdCliente"].ToString();
            }
        }








        private void txt_NombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txt_IdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            Ciente c = new Ciente();

            if (string.IsNullOrEmpty(_idOriginal))
            {
                // Nuevo cliente
                c.AgregarCliente(
                    txt_IdCliente.Text.Trim(),
                    txt_NombreCliente.Text.Trim(),
                    txt_Apellido_Cliente.Text.Trim(),
                    txt_Telefono.Text.Trim(),
                    txt_Correo.Text.Trim(),
                    txt_Direccion.Text.Trim());

                MessageBox.Show("Cliente agregado correctamente.");
            }
            else
            {
                // Modificar cliente
                c.ModificarCliente(
                    _idOriginal,
                    txt_NombreCliente.Text.Trim(),
                    txt_Apellido_Cliente.Text.Trim(),
                    txt_Telefono.Text.Trim(),
                    txt_Correo.Text.Trim(),
                    txt_Direccion.Text.Trim());

                MessageBox.Show("Cliente modificado correctamente.");
            }

            if (_formCliente != null)
            {
                _formCliente.llenarGrid();
            }
            this.Close();
        }

        private void FormModificarCliente_Load(object sender, EventArgs e)
        {
            // Si no estamos modificando, entonces se trata de un nuevo cliente
            if (string.IsNullOrEmpty(_idOriginal))
            {
                Ciente objCliente = new Ciente();
                string nuevoId = objCliente.GenerarCodigoCliente();
                txt_IdCliente.Text = nuevoId;
            }
        }

        private void txt_Apellido_Cliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
