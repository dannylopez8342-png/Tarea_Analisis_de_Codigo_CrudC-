
namespace TIENDA_ELECTRONICA
{
    partial class FormFacturacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_Vendedor = new System.Windows.Forms.ComboBox();
            this.cmb_Cliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_AgregarCliente = new System.Windows.Forms.Button();
            this.btn_IngresarFactura = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Agregarproducto = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_agregarProducto = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_eliminarproducto = new System.Windows.Forms.Button();
            this.btn_FinyguardarFact = new System.Windows.Forms.Button();
            this.txt_Totalfactura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Vendedor
            // 
            this.cmb_Vendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Vendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Vendedor.FormattingEnabled = true;
            this.cmb_Vendedor.Location = new System.Drawing.Point(97, 37);
            this.cmb_Vendedor.Name = "cmb_Vendedor";
            this.cmb_Vendedor.Size = new System.Drawing.Size(209, 21);
            this.cmb_Vendedor.TabIndex = 0;
            this.cmb_Vendedor.SelectedIndexChanged += new System.EventHandler(this.cmb_Vendedor_SelectedIndexChanged);
            // 
            // cmb_Cliente
            // 
            this.cmb_Cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Cliente.FormattingEnabled = true;
            this.cmb_Cliente.Location = new System.Drawing.Point(97, 76);
            this.cmb_Cliente.Name = "cmb_Cliente";
            this.cmb_Cliente.Size = new System.Drawing.Size(209, 21);
            this.cmb_Cliente.TabIndex = 1;
            this.cmb_Cliente.SelectedIndexChanged += new System.EventHandler(this.cmb_Cliente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vendedor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(109, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha de Factura";
            // 
            // btn_AgregarCliente
            // 
            this.btn_AgregarCliente.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_AgregarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AgregarCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_AgregarCliente.Location = new System.Drawing.Point(341, 35);
            this.btn_AgregarCliente.Name = "btn_AgregarCliente";
            this.btn_AgregarCliente.Size = new System.Drawing.Size(137, 23);
            this.btn_AgregarCliente.TabIndex = 6;
            this.btn_AgregarCliente.Text = "Agregar Nuevo Cliente";
            this.btn_AgregarCliente.UseVisualStyleBackColor = false;
            this.btn_AgregarCliente.Click += new System.EventHandler(this.btn_AgregarCliente_Click);
            // 
            // btn_IngresarFactura
            // 
            this.btn_IngresarFactura.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_IngresarFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_IngresarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IngresarFactura.Location = new System.Drawing.Point(341, 76);
            this.btn_IngresarFactura.Name = "btn_IngresarFactura";
            this.btn_IngresarFactura.Size = new System.Drawing.Size(137, 23);
            this.btn_IngresarFactura.TabIndex = 7;
            this.btn_IngresarFactura.Text = "Agregar Factura";
            this.btn_IngresarFactura.UseVisualStyleBackColor = false;
            this.btn_IngresarFactura.Click += new System.EventHandler(this.btn_IngresarFactura_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Productos";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmb_Agregarproducto
            // 
            this.cmb_Agregarproducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Agregarproducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Agregarproducto.FormattingEnabled = true;
            this.cmb_Agregarproducto.Location = new System.Drawing.Point(97, 204);
            this.cmb_Agregarproducto.Name = "cmb_Agregarproducto";
            this.cmb_Agregarproducto.Size = new System.Drawing.Size(209, 21);
            this.cmb_Agregarproducto.TabIndex = 9;
            this.cmb_Agregarproducto.SelectedIndexChanged += new System.EventHandler(this.cmb_Agregarproducto_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(393, 204);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cantidad";
            // 
            // btn_agregarProducto
            // 
            this.btn_agregarProducto.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_agregarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregarProducto.Location = new System.Drawing.Point(549, 202);
            this.btn_agregarProducto.Name = "btn_agregarProducto";
            this.btn_agregarProducto.Size = new System.Drawing.Size(137, 23);
            this.btn_agregarProducto.TabIndex = 12;
            this.btn_agregarProducto.Text = "Agregar Producto";
            this.btn_agregarProducto.UseVisualStyleBackColor = false;
            this.btn_agregarProducto.Click += new System.EventHandler(this.btn_agregarProducto_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Total,
            this.Fecha,
            this.Subtotal});
            this.dgvDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetalle.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDetalle.Location = new System.Drawing.Point(28, 238);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(746, 174);
            this.dgvDetalle.TabIndex = 13;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "ID Producto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha de Factura";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // btn_eliminarproducto
            // 
            this.btn_eliminarproducto.BackColor = System.Drawing.SystemColors.Control;
            this.btn_eliminarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eliminarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminarproducto.Location = new System.Drawing.Point(261, 420);
            this.btn_eliminarproducto.Name = "btn_eliminarproducto";
            this.btn_eliminarproducto.Size = new System.Drawing.Size(137, 23);
            this.btn_eliminarproducto.TabIndex = 15;
            this.btn_eliminarproducto.Text = "Eliminar Producto";
            this.btn_eliminarproducto.UseVisualStyleBackColor = false;
            this.btn_eliminarproducto.Click += new System.EventHandler(this.btn_eliminarproducto_Click);
            // 
            // btn_FinyguardarFact
            // 
            this.btn_FinyguardarFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FinyguardarFact.Location = new System.Drawing.Point(69, 420);
            this.btn_FinyguardarFact.Name = "btn_FinyguardarFact";
            this.btn_FinyguardarFact.Size = new System.Drawing.Size(150, 23);
            this.btn_FinyguardarFact.TabIndex = 16;
            this.btn_FinyguardarFact.Text = "Finalizar y Guardar Factura";
            this.btn_FinyguardarFact.UseVisualStyleBackColor = true;
            this.btn_FinyguardarFact.Click += new System.EventHandler(this.btn_FinyguardarFact_Click);
            // 
            // txt_Totalfactura
            // 
            this.txt_Totalfactura.Location = new System.Drawing.Point(586, 423);
            this.txt_Totalfactura.Name = "txt_Totalfactura";
            this.txt_Totalfactura.ReadOnly = true;
            this.txt_Totalfactura.Size = new System.Drawing.Size(100, 20);
            this.txt_Totalfactura.TabIndex = 17;
            this.txt_Totalfactura.TextChanged += new System.EventHandler(this.txt_Totalfactura_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(535, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("News701 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(69, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(651, 31);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "Detalle de la Factura";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.Font = new System.Drawing.Font("News701 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(69, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(651, 31);
            this.textBox2.TabIndex = 20;
            this.textBox2.Text = "Facturación";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // FormFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Totalfactura);
            this.Controls.Add(this.btn_FinyguardarFact);
            this.Controls.Add(this.btn_eliminarproducto);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btn_agregarProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.cmb_Agregarproducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_IngresarFactura);
            this.Controls.Add(this.btn_AgregarCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_Cliente);
            this.Controls.Add(this.cmb_Vendedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFacturacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturacion";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Vendedor;
        private System.Windows.Forms.ComboBox cmb_Cliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_AgregarCliente;
        private System.Windows.Forms.Button btn_IngresarFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Agregarproducto;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_agregarProducto;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btn_eliminarproducto;
        private System.Windows.Forms.Button btn_FinyguardarFact;
        private System.Windows.Forms.TextBox txt_Totalfactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
    }
}