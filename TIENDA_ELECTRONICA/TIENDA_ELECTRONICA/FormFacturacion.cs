using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TIENDA_ELECTRONICA
{
    public partial class FormFacturacion : Form
    {

        string idFactura = "";
        bool facturaInsertada = false;
        string cadena = @"Data Source=DESKTOP-P2SN1UU\MSSQLSERVER12;Initial Catalog=Examen_TiendaElectronica;Integrated Security=True";
        public FormFacturacion()
        {
            InitializeComponent();
            CargarClientes();
            CargarVendedores();
            CargarProductos();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.Columns.Add("IdProducto", "ID Producto");
            dgvDetalle.Columns.Add("NombreProducto", "Producto");
            dgvDetalle.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("Subtotal", "Subtotal");
        }

        private void CargarClientes()
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdCliente, (Nombre + ' ' + Apellido) AS Nombre FROM Clientes", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmb_Cliente.DataSource = dt;
                cmb_Cliente.DisplayMember = "Nombre";  // ← Mostrar nombre completo
                cmb_Cliente.ValueMember = "IdCliente";
                cmb_Cliente.SelectedIndex = -1;
            }
        }

      

        private void CargarVendedores()
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT IdVendedor, (Nombre + ' ' + Apellido) as Nombre FROM Vendedores", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmb_Vendedor.DataSource = dt;
                cmb_Vendedor.DisplayMember = "Nombre";
                cmb_Vendedor.ValueMember = "IdVendedor";
                cmb_Vendedor.SelectedIndex = -1;
            }
        }

        private void CargarProductos()
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT IdProducto, Nombre FROM Productos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmb_Agregarproducto.DataSource = dt;
                cmb_Agregarproducto.DisplayMember = "Nombre";
                cmb_Agregarproducto.ValueMember = "IdProducto";
                cmb_Agregarproducto.SelectedIndex = -1;
            }
            cmb_Agregarproducto.SelectedIndexChanged += cmb_Agregarproducto_SelectedIndexChanged;
        }

       

        private decimal ObtenerPrecioProducto(string idProducto)
        {

            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Precio FROM Productos WHERE IdProducto = @id", conn);
                cmd.Parameters.AddWithValue("@id", idProducto);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
        }

        private int ObtenerStockDisponible(string idProducto)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Stock FROM Productos WHERE IdProducto = @id", conn);
                cmd.Parameters.AddWithValue("@id", idProducto);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            txt_Totalfactura.Text = total.ToString("N2");

            if (!string.IsNullOrEmpty(idFactura))
            {
                ActualizarTotalFactura(idFactura, total); // ✅ actualiza el total automáticamente
            }
        }

        private void ActualizarTotalFactura(string idFactura, decimal Total)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Facturas SET Total = @total WHERE IdFactura = @id", conn);
                cmd.Parameters.AddWithValue("@total", Total);
                cmd.Parameters.AddWithValue("@id", idFactura);
                cmd.ExecuteNonQuery();
            }
        }

        private string ObtenerNuevoIdFactura()
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GENERAR_ID_FACTURA", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? throw new Exception("No se pudo generar el nuevo Id de factura.");
            }
        }

        private string ObtenerNuevoIdDetalle()
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GENERAR_ID_DETALLE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? throw new Exception("No se pudo generar el nuevo Id de detalle.");
            }
        }

        private void LimpiarFormulario()
        {
            cmb_Cliente.SelectedIndex = -1;
            cmb_Vendedor.SelectedIndex = -1;
            cmb_Agregarproducto.SelectedIndex = -1;
            dgvDetalle.Rows.Clear();
            txt_Totalfactura.Text = "";
            numericUpDown1.Value = 1;
            idFactura = "";
            facturaInsertada = false;
            btn_agregarProducto.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmb_Vendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_AgregarCliente_Click(object sender, EventArgs e)
        {
            FormModificarCliente form = new FormModificarCliente(null, "", false);
            form.ShowDialog();
            CargarClientes(); // Recargar después de agregar nuevo cliente
        }

        private void btn_IngresarFactura_Click(object sender, EventArgs e)
        {
            if (cmb_Cliente.SelectedIndex == -1 || cmb_Vendedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente y un vendedor.");
                return;
            }

            idFactura = ObtenerNuevoIdFactura();
            btn_agregarProducto.Enabled = true;
            MessageBox.Show("Factura preparada. Agregue al menos un producto para registrarla.");



        }

        private void cmb_Agregarproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Agregarproducto.SelectedIndex != -1)
            {
                string idProducto = cmb_Agregarproducto.SelectedValue.ToString();
                int stockDisponible = ObtenerStockDisponible(idProducto);
                numericUpDown1.Maximum = stockDisponible > 0 ? stockDisponible : 1;
                numericUpDown1.Value = 1;
            }
        }

           
        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            if (idFactura == "")
            {
                MessageBox.Show("Primero ingrese el encabezado de la factura.");
                return;
            }

        

            if (cmb_Agregarproducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            string idProducto = cmb_Agregarproducto.SelectedValue.ToString();
            int cantidad = (int)numericUpDown1.Value;
            int stockDisponible = ObtenerStockDisponible(idProducto);
          

            if (cantidad > stockDisponible)
            {
                MessageBox.Show($"No hay suficiente stock disponible. Stock actual: {stockDisponible}", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!facturaInsertada)
            {
                using (SqlConnection conn = new SqlConnection(cadena))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SP_INSERTAR_FACTURA", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFactura", idFactura);
                    cmd.Parameters.AddWithValue("@Fecha", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@IdCliente", cmb_Cliente.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@IdVendedor", cmb_Vendedor.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Total", 0);
                    cmd.ExecuteNonQuery();
                }

                facturaInsertada = true;
            }

            decimal precioUnitario = ObtenerPrecioProducto(idProducto);
            decimal subtotal = precioUnitario * cantidad;
            string idDetalle = ObtenerNuevoIdDetalle();

            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DetalleFactura (IdDetalle, IdFactura, IdProducto, Cantidad, PrecioUnitario) VALUES (@idDetalle, @idFactura, @idProducto, @cantidad, @precio)", conn);
                cmd.Parameters.AddWithValue("@idDetalle", idDetalle);
                cmd.Parameters.AddWithValue("@idFactura", idFactura);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@precio", precioUnitario);
                cmd.ExecuteNonQuery();
            }


            // Agregar al DataGridView
            dgvDetalle.Rows.Add(idProducto, cmb_Agregarproducto.Text, precioUnitario, cantidad, subtotal);
            CalcularTotal();
        }

        private void btn_FinyguardarFact_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idFactura))
            {
                MessageBox.Show("Debe ingresar una factura primero.");
                return;
            }


            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto antes de finalizar la factura.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 

            decimal total;
            if (!decimal.TryParse(txt_Totalfactura.Text, out total))
            {
                MessageBox.Show("El total no es válido.");
                return;
            }

          

         
            ActualizarTotalFactura(idFactura, total);
            MessageBox.Show("Factura Ingresada correctamente.");
            LimpiarFormulario();
        }

        private void btn_eliminarproducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count > 0)
            {
                dgvDetalle.Rows.RemoveAt(dgvDetalle.SelectedRows[0].Index);
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }

        }

        private void txt_Totalfactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.Columns.Add("IdProducto", "ID Producto");
            dgvDetalle.Columns.Add("NombreProducto", "Producto");
            dgvDetalle.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("Subtotal", "Subtotal");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
