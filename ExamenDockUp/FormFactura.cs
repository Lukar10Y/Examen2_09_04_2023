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

namespace ExamenDockUp
{
    public partial class FormFactura : Form
    {
        private string _path = "";
        private Usuario _vendedor = new Usuario();
        private List<Productos> _compras = new List<Productos>();
        private List<Factura> _facturas = new List<Factura>();
        private List<string> _datosEmpresa = new List<string>();
        private Cliente _cliente = new Cliente();
        public FormFactura()
        {
            InitializeComponent();
        }
        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }
        public List<string> DatosEmpresa { get { return _datosEmpresa; } set { _datosEmpresa = value; } }
        public Usuario Vendedor { get { return _vendedor; } set { _vendedor = value; } }
        public List<Productos> Compras { get { return _compras; } set { _compras = value; } }
        public string Path { get { return _path;} set { _path = value; } }
        private void GuardarFactura()
        {
            string jsonFacturas = JsonConvert.SerializeObject(_facturas.ToArray(), Formatting.Indented);
            File.WriteAllText(_path, jsonFacturas);
        }
        private void LeerListaDeFacturas()
        {
            try { _facturas = JsonConvert.DeserializeObject<List<Factura>>(_path); }
            catch { }
        }
        private void LlenarDatosDeFactura()
        {
            lblNumeroFactura.Text = $"Numero de Factura  {((_facturas.Count + 1).ToString()).PadLeft(5, '0')}";
            lblFecha.Text = $"Fecha de Emision:  {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}  {DateTime.Now.ToString("hh:mm:ss tt")}";
            lblNombreEmpresa.Text = DatosEmpresa[0];
            lblRif.Text = $"Rif: {DatosEmpresa[1]}";
            rtbDireccionEmpresa.Text = $"Direccion: {DatosEmpresa[2]}";
            lblCorreoElectronico.Text = $"Correo Electronico: {DatosEmpresa[3]}";
            lblNombreVendedor.Text = $"Vendedor: {_vendedor.Nombre} {_vendedor.Apellido}";
            lblCedulaVendedor.Text = $"Cedula Vendedor: {_vendedor.Cedula}";
            lblNombreComprador.Text = $"Comprador: {_cliente.Nombre} {_cliente.Apellido}";
            lblCedulaComprador.Text = $"Cedula Comprador: {_cliente.Cedula}";
            lblTelefonoComprador.Text = $"Numero de Contacto: {_cliente.NumeroDeTlf}";
        }
        private void LlenarTablaDeCompras()
        {
            dgvProductos.Rows.Clear();
            dgvProductos.Rows.Add(_compras.Count);
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                for (int j = 0; j < dgvProductos.Columns.Count; j++)
                {
                    if (j == 0) dgvProductos[j, i].Value = _compras[i]._cantidad;
                    else if (j == 1) dgvProductos[j, i].Value = _compras[i]._nombre;
                    else if (j == 2) dgvProductos[j, i].Value = _compras[i]._precio;
                    else if (j == 3) dgvProductos[j, i].Value = _compras[i]._precio*2;
                }
            }
        }
        private void FormFactura_Load(object sender, EventArgs e)
        {
            LeerListaDeFacturas();
            LlenarDatosDeFactura();
            LlenarTablaDeCompras();
            dgvTotalImpuestos();
        }
        private void dgvTotalImpuestos()
        {
            if (dgvImpuestos.Rows.Count == 0)
            {
                dgvImpuestos.Rows.Add(3);
                dgvImpuestos.Rows[0].Cells[0].Value = "SubTotal";
                dgvImpuestos.Rows[1].Cells[0].Value = "Iva 16%";
                dgvImpuestos.Rows[2].Cells[0].Value = "Monto Total";
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _facturas.Add(new Factura());
            GuardarFactura();
            this.Close();
        }
    }
}
