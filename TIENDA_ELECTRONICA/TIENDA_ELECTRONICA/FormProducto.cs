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
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();

            llenarGrid();
        } 

        public void llenarGrid()
        {
            Producto objProducto = new Producto();
            DataTable mDatos = objProducto.ListarProducto("0"); // PASAR "0" para traer todos los productos

            dgProducto.AutoGenerateColumns = true;
            dgProducto.DataSource = mDatos;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInventario frm = new FormInventario(this,"",false);
            frm.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgProducto.CurrentRow != null)
            {
                string idProducto = dgProducto.CurrentRow.Cells["IdProducto"].Value.ToString();

                var confirmar = MessageBox.Show($"¿Estás seguro de eliminar el producto con ID: {idProducto}?",
                                                "Confirmar eliminación",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    Producto objProducto = new Producto();
                    objProducto.EliminarProducto(idProducto);

                    MessageBox.Show("Producto eliminado correctamente.");
                    llenarGrid(); // Refresca el DataGridView
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto primero.");
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgProducto.SelectedRows.Count > 0)
            {
                string id = dgProducto.SelectedRows[0].Cells["IdProducto"].Value.ToString();

                FormInventario frm = new FormInventario(this, id, true); // true indica que es edición
                frm.Show();
            }
            else
            {
                MessageBox.Show("Selecciona un producto para modificar.");
            }
        }

        private void dgProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
