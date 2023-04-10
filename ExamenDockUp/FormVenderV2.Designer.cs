using System.Windows.Forms;

namespace Vender_Bosquejo_2
{
    partial class FormVenderV2
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgvPreview = new System.Windows.Forms.DataGridView();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblPrecioToTal = new System.Windows.Forms.Label();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.cbBoxClientes = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblBase = new System.Windows.Forms.Label();
            this.lblPrecioBase = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnListaProductos = new System.Windows.Forms.Button();
            this.lblDatosVendedor = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblDatosDelCliente = new System.Windows.Forms.Label();
            this.lblDatosCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            // 
            // dtgvPreview
            // 
            this.dtgvPreview.AllowUserToAddRows = false;
            this.dtgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPreview.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dtgvPreview.ColumnHeadersHeight = 29;
            this.dtgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Descripcion,
            this.Precio,
            this.Cantidad});
            this.dtgvPreview.Location = new System.Drawing.Point(17, 116);
            this.dtgvPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgvPreview.Name = "dtgvPreview";
            this.dtgvPreview.RowHeadersVisible = false;
            this.dtgvPreview.RowHeadersWidth = 51;
            this.dtgvPreview.RowTemplate.Height = 29;
            this.dtgvPreview.Size = new System.Drawing.Size(625, 249);
            this.dtgvPreview.TabIndex = 4;
            this.dtgvPreview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPreview_CellContentClick);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(37, 386);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(80, 25);
            this.btnRegresar.TabIndex = 7;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnFacturar.Location = new System.Drawing.Point(665, 184);
            this.btnFacturar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(80, 25);
            this.btnFacturar.TabIndex = 6;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click_1);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Brown;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(665, 116);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(80, 25);
            this.btnBorrar.TabIndex = 5;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click_1);
            // 
            // lblPrecioToTal
            // 
            this.lblPrecioToTal.AutoSize = true;
            this.lblPrecioToTal.Location = new System.Drawing.Point(581, 392);
            this.lblPrecioToTal.Name = "lblPrecioToTal";
            this.lblPrecioToTal.Size = new System.Drawing.Size(41, 13);
            this.lblPrecioToTal.TabIndex = 6;
            this.lblPrecioToTal.Text = "lblTotal";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnNuevoCliente.Location = new System.Drawing.Point(17, 60);
            this.btnNuevoCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(115, 40);
            this.btnNuevoCliente.TabIndex = 2;
            this.btnNuevoCliente.Text = "Crear Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // cbBoxClientes
            // 
            this.cbBoxClientes.FormattingEnabled = true;
            this.cbBoxClientes.Location = new System.Drawing.Point(17, 29);
            this.cbBoxClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBoxClientes.Name = "cbBoxClientes";
            this.cbBoxClientes.Size = new System.Drawing.Size(115, 21);
            this.cbBoxClientes.TabIndex = 1;
            this.cbBoxClientes.Text = "Seleccionar";
            this.cbBoxClientes.SelectedIndexChanged += new System.EventHandler(this.cbBoxClientes_SelectedIndexChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(552, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Location = new System.Drawing.Point(594, 16);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(77, 13);
            this.lblFechaActual.TabIndex = 11;
            this.lblFechaActual.Text = "lblFechaActual";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(509, 392);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(67, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Precio Total:";
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(443, 392);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(41, 13);
            this.lblBase.TabIndex = 14;
            this.lblBase.Text = "lblBase";
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Location = new System.Drawing.Point(373, 392);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(67, 13);
            this.lblPrecioBase.TabIndex = 15;
            this.lblPrecioBase.Text = "Precio Base:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(14, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 16;
            this.lblCliente.Text = "Cliente:";
            // 
            // btnListaProductos
            // 
            this.btnListaProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnListaProductos.Location = new System.Drawing.Point(532, 60);
            this.btnListaProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListaProductos.Name = "btnListaProductos";
            this.btnListaProductos.Size = new System.Drawing.Size(110, 40);
            this.btnListaProductos.TabIndex = 3;
            this.btnListaProductos.Text = "Lista de Productos";
            this.btnListaProductos.UseVisualStyleBackColor = true;
            this.btnListaProductos.Click += new System.EventHandler(this.btnListaProductos_Click);
            // 
            // lblDatosVendedor
            // 
            this.lblDatosVendedor.AutoSize = true;
            this.lblDatosVendedor.Location = new System.Drawing.Point(235, 16);
            this.lblDatosVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatosVendedor.Name = "lblDatosVendedor";
            this.lblDatosVendedor.Size = new System.Drawing.Size(104, 13);
            this.lblDatosVendedor.TabIndex = 17;
            this.lblDatosVendedor.Text = "Datos del Vendedor:";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(235, 32);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(63, 13);
            this.lblVendedor.TabIndex = 18;
            this.lblVendedor.Text = "lblVendedor";
            // 
            // lblDatosDelCliente
            // 
            this.lblDatosDelCliente.AutoSize = true;
            this.lblDatosDelCliente.Location = new System.Drawing.Point(392, 16);
            this.lblDatosDelCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatosDelCliente.Name = "lblDatosDelCliente";
            this.lblDatosDelCliente.Size = new System.Drawing.Size(90, 13);
            this.lblDatosDelCliente.TabIndex = 19;
            this.lblDatosDelCliente.Text = "Datos del Cliente:";
            // 
            // lblDatosCliente
            // 
            this.lblDatosCliente.AutoSize = true;
            this.lblDatosCliente.Location = new System.Drawing.Point(392, 32);
            this.lblDatosCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatosCliente.Name = "lblDatosCliente";
            this.lblDatosCliente.Size = new System.Drawing.Size(60, 13);
            this.lblDatosCliente.TabIndex = 20;
            this.lblDatosCliente.Text = "Sin Asignar";
            // 
            // FormVenderV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 422);
            this.Controls.Add(this.lblDatosCliente);
            this.Controls.Add(this.lblDatosDelCliente);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblDatosVendedor);
            this.Controls.Add(this.btnListaProductos);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblPrecioBase);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.lblFechaActual);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cbBoxClientes);
            this.Controls.Add(this.btnNuevoCliente);
            this.Controls.Add(this.lblPrecioToTal);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.dtgvPreview);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormVenderV2";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormVenderV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridView dtgvPreview;
        private Button btnRegresar;
        private Button btnFacturar;
        private Button btnBorrar;
        private Label lblPrecioToTal;
        private Button btnNuevoCliente;
        private ComboBox cbBoxClientes;
        private Label lblFecha;
        private Label lblFechaActual;
        private Label lblTotal;
        private Label lblBase;
        private Label lblPrecioBase;
        private Label lblCliente;
        private Button btnListaProductos;
        private Label lblDatosVendedor;
        private Label lblVendedor;
        private Label lblDatosDelCliente;
        private Label lblDatosCliente;
    }
}