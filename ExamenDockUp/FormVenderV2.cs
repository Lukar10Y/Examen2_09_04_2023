using borrador;
using DatosEmpresa;
using ExamenDockUp;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vender;

namespace Vender_Bosquejo_2
{
    public partial class FormVenderV2 : Form
    {
        private int n = 0;
        private int _precioBase = 0;
        private int _precioTotal = 0;
        private int _cantidadSeleccionada = 0;
        private List<Cliente> _clientes = new List<Cliente>();
        private List<Productos> _compras = new List<Productos>(); //Carrito del Comprador
        private List<Productos> _productos = new List<Productos>(); //Productos Disponibles
        private List<string> _datosEmpresa = new List<string>();
        private Usuario _vendedor = new Usuario();
        private FormFactura Factura = new FormFactura();
        private FormAgregarProducto ListaDeProductos = new FormAgregarProducto();
        private string _pathFacturas = "";
        public FormVenderV2()
        {
            InitializeComponent();
        }
        public List<string> DatosEmpresa { get { return _datosEmpresa; } set { _datosEmpresa = value; } }
        public List<Productos> Productos { get { return _productos; } set { _productos = value; } }
        public List<Cliente> Clientes { get { return _clientes; } set { _clientes = value; } }
        public Usuario Vendedor { get { return _vendedor; } set { _vendedor = value; } }
        public string PathFacturas { get { return _pathFacturas; } set { _pathFacturas = value; } }
        private void ConectarInformacion()
        {
            ListaDeProductos.Productos = _productos;
            ListaDeProductos.ComprasCliente = _compras;
            ListaDeProductos.CantidadSeleccionada = _cantidadSeleccionada;
            ListaDeProductos.DataGrid = dtgvPreview;
            Factura.Vendedor = _vendedor;
            Factura.Compras = _compras;
            Factura.Path = _pathFacturas;
            Factura.DatosEmpresa = _datosEmpresa;
        }
        private void LlenarComboBoxClientes()
        {
            cbBoxClientes.Items.Clear();
            for(int i=0; i<_clientes.Count; i++)
            {
                cbBoxClientes.Items.Add(_clientes[i].Identificacion());
            }
        }
        private void LlenarPreviewProductos()
        {
            dtgvPreview.Rows.Clear();
            if (Productos.Count != 0) dtgvPreview.Rows.Add(Productos.Count);
            if (_productos.Count > 0)
            {
                for (int i = 0; i < Productos.Count; i++)
                {
                    for (int j = 0; j < dtgvPreview.Columns.Count; j++)
                    {
                        if (j == 0) dtgvPreview[j, i].Value = _compras[i]._codigo;
                        else if (j == 1) dtgvPreview[j, i].Value = _compras[i]._nombre;
                        else if (j == 2) dtgvPreview[j, i].Value = _compras[i]._descripcion;
                        else if (j == 3) dtgvPreview[j, i].Value = _compras[i]._precio;
                        else if (j == 4) dtgvPreview[j, i].Value = _cantidadSeleccionada;
                    }
                }
            }
            else MessageBox.Show("No existe Producto alguno para mostrar");
        }
        private void btnListaProductos_Click(object sender, EventArgs e)
        {
            ListaDeProductos.ShowDialog();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
        }

        private void FormVenderV2_Load(object sender, EventArgs e)
        {
            ConectarInformacion();
            lblVendedor.Text = $"{_vendedor.Nombre} {_vendedor.Apellido}";
            lblFechaActual.Text = $"{ DateTime.Now.Day}/{ DateTime.Now.Month}/{ DateTime.Now.Year}";
            lblBase.Text = _precioBase.ToString();
            lblPrecioToTal.Text = _precioTotal.ToString();
            LlenarComboBoxClientes();
        }
        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (n != -1)
            {
                dtgvPreview.Rows.RemoveAt(n);
            }
        }

        private void dtgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
        }

        private void btnFacturar_Click_1(object sender, EventArgs e)
        {
            if (_compras.Count > 0)
            {
                if (_datosEmpresa.Count != 0)
                {
                    Factura.Cliente = _clientes[cbBoxClientes.SelectedIndex];
                    Factura.ShowDialog();
                }
                else MessageBox.Show("No se han definido los Datos de la Empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("No se ha Seleccionado producto Alguno a Vender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDatosCliente.Text = _clientes[cbBoxClientes.SelectedIndex].Identificacion();
        }
    }
}