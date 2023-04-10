using ExamenDockUp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vender
{
    public partial class FormVender : Form
    {
        private int n = 0;
        private List<Cliente> _clientes = new List<Cliente>();
        private List<Productos> _compras = new List<Productos>(); //Carrito del Comprador
        private List<Productos> _productos = new List<Productos>(); //Productos Disponibles
        private List<string> _datosEmpresa = new List<string>();
        private Usuario _vendedor = new Usuario();
        private FormFactura Factura = new FormFactura();
        private string _pathFacturas = "";
        public FormVender()
        {
            InitializeComponent();
        }
        public List<string> DatosEmpresa { get { return _datosEmpresa; } set { _datosEmpresa = value; } }
        public List<Productos> Productos { get { return _productos; } set { _productos = value; } }
        public List<Cliente> Clientes { get { return _clientes; } set { _clientes = value; } }
        public Usuario Vendedor { get { return _vendedor; } set { _vendedor = value; } }
        public string PathFacturas { get { return _pathFacturas; } set { _pathFacturas = value; } }
        private void dtgvVender_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (n != -1)
            {
                dtgvVender.Rows.RemoveAt(n);
            }
        }

        private void FormVenderS_Load(object sender, EventArgs e)
        {
            Factura.Vendedor = _vendedor;
            dtgvVender.Rows.Clear();
            if(Productos.Count != 0) dtgvVender.Rows.Add(Productos.Count);
            if (_productos.Count > 0)
            {
                for (int i = 0; i < Productos.Count; i++)
                {
                    for (int j = 0; j < dtgvVender.Columns.Count; j++)
                    {
                        if (j == 0) dtgvVender[j, i].Value = Productos[i]._codigo;
                        else if (j == 1) dtgvVender[j, i].Value = Productos[i]._nombre;
                        else if (j == 2) dtgvVender[j, i].Value = Productos[i]._descripcion;
                        else if (j == 3) dtgvVender[j, i].Value = Productos[i]._precio;
                        else if (j == 4) dtgvVender[j, i].Value = Productos[i]._cantidad;
                    }
                }
            }
            else MessageBox.Show("No existe Producto alguno para mostrar");
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Factura.Compras = _compras;
            Factura.Path = _pathFacturas;
            Factura.DatosEmpresa = _datosEmpresa;
            //Factura.Cliente = _clientes[IndexDelComprador];
            if (_compras.Count > 0)
            {
                if (_datosEmpresa.Count != 0)
                {
                    Factura.ShowDialog();
                }
                else MessageBox.Show("No se han definido los Datos de la Empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("No se ha Seleccionado producto Alguno a Vender","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            //Agregamos nueva fila
            int n = dtgvVender.Rows.Add();

            //Agregamos Informacion
            dtgvVender.Rows[n].Cells[0].Value = txtCodigo.Text;
            dtgvVender.Rows[n].Cells[1].Value = txtDescripcion.Text;
            dtgvVender.Rows[n].Cells[2].Value = txtCantidad.Text;
            dtgvVender.Rows[n].Cells[3].Value = txtPrecio.Text;

            //Limpia los cuadros
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_productos.Count>0)
            {
                _compras.Add(_productos[n]);
                lstvProductos.Items.Add($"{_productos[n]._codigo}# {_productos[n]._nombre}");
            }
        }
    }   
}