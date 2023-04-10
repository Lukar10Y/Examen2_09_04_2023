using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using borrador;
using DatosEmpresa;
using Newtonsoft.Json;
using System.Collections;
using System.IO;
using Vender;
using ExamenDockUp;

namespace Vender_Bosquejo_2
{
    public partial class FormAgregarProducto : Form
    {
        private int n = 0;
        private int _cantidadSeleccionada = 0;
        private List<Productos> _compras = new List<Productos>(); //Carrito del Comprador
        private List<Productos> _productos = new List<Productos>(); //Productos Disponibles
        private DataGridView CopiaPreview = new DataGridView();
        public int CantidadSeleccionada { get { return _cantidadSeleccionada; } set { _cantidadSeleccionada=value; } }
        public List<Productos> Productos { get { return _productos; } set { _productos = value; } }
        public List<Productos> ComprasCliente { get { return _compras; } set { _compras = value; } }
        public DataGridView DataGrid { get { return CopiaPreview; } set { CopiaPreview = value; } }
        public FormAgregarProducto()
        {
            InitializeComponent();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            dtgvListaDeProductos.Rows.Clear();
            if (Productos.Count != 0) dtgvListaDeProductos.Rows.Add(Productos.Count);
            if (_productos.Count > 0)
            {
                for (int i = 0; i < Productos.Count; i++)
                {
                    for (int j = 0; j < dtgvListaDeProductos.Columns.Count; j++)
                    {
                        if (j == 0) dtgvListaDeProductos[j, i].Value = Productos[i]._codigo;
                        else if (j == 1) dtgvListaDeProductos[j, i].Value = Productos[i]._nombre;
                        else if (j == 2) dtgvListaDeProductos[j, i].Value = Productos[i]._descripcion;
                        else if (j == 3) dtgvListaDeProductos[j, i].Value = Productos[i]._precio;
                        else if (j == 4) dtgvListaDeProductos[j, i].Value = Productos[i]._cantidad;
                    }
                }
            }
            else MessageBox.Show("No existe Producto alguno para mostrar");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _compras.Add(_productos[n]);
            _cantidadSeleccionada = Convert.ToInt32(txtCantidad.Text);
            int aux = CopiaPreview.Rows.Add();
            CopiaPreview[0, aux].Value = _productos[n]._codigo;
            CopiaPreview[1, aux].Value = _productos[n]._nombre;
            CopiaPreview[2, aux].Value = _productos[n]._descripcion;
            CopiaPreview[3, aux].Value = _productos[n]._precio;
            CopiaPreview[4, aux].Value = _cantidadSeleccionada;
        }

        private void dtgvListaDeProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
        }
    }
}
