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
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();

            llenarGrid();
        }


        public void llenarGrid()
        {
            Categoria objCategoria = new Categoria();
            DataTable mdatos = objCategoria.ListarCategoria("");

            dgCategoria.AutoGenerateColumns = true;
            dgCategoria.DataSource = mdatos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategorizar frm = new FormCategorizar(this, "", false);
            frm.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCategoria.SelectedRows.Count > 0)
            {
                string id = dgCategoria.SelectedRows[0].Cells["IdCategoria"].Value.ToString();
                FormCategorizar frm = new FormCategorizar(this, id, true);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgCategoria.SelectedRows.Count > 0)
            {
                string id = dgCategoria.SelectedRows[0].Cells["IdCategoria"].Value.ToString();
                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar la categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Categoria cat = new Categoria();
                    cat.EliminarCategoria(id);
                    llenarGrid();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCategoria.SelectedRows.Count > 0)
            {
                string id = dgCategoria.SelectedRows[0].Cells["IdCategoria"].Value.ToString();
                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar la categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Categoria cat = new Categoria();
                    cat.EliminarCategoria(id);
                    llenarGrid(); // refresca el grid
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }
