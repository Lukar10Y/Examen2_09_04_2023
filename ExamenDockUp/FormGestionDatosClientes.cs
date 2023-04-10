using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenDockUp;

namespace DatosEmpresa
{
    public partial class FormGestionDatosClientes : Form
    {
        private string _pathClientes = "";
        private int aux = 0;
        private List<Cliente> _datosCliente = new List<Cliente>();
        
        public FormGestionDatosClientes()
        {
            InitializeComponent();
        }
        public string PathClientes { set { _pathClientes = value;} get { return _pathClientes; } }
        public List<Cliente> ListaClientes { get { return _datosCliente;} set { _datosCliente = value; } }
        private void GuardarClientes()
        {
            string empleadosJson = JsonConvert.SerializeObject(_datosCliente.ToArray(), Formatting.Indented);
            File.WriteAllText(_pathClientes, empleadosJson);
            MessageBox.Show("Guardado Exitosamente");
        }
        private bool CedulaRepetida()
        {
            bool Repetido = false;
            for (int i = 0; i < _datosCliente.Count; i++)
            {
                if (_datosCliente[i].Cedula == txtCI.Text)
                {
                    Repetido = true;
                    break;
                }
            }
            return Repetido;
        }
        private void LlenarTablaClientes()
        {
            if (_datosCliente.Count > 0)
            {
                for (int i = 0; i < _datosCliente.Count; i++)
                {
                    for (int j = 0; j < dtgvClientes.Columns.Count; j++)
                    {
                        if (j == 0) dtgvClientes[j, i].Value = _datosCliente[i].Nombre;
                        else if (j == 1) dtgvClientes[j, i].Value = _datosCliente[i].Apellido;
                        else if (j == 2) dtgvClientes[j, i].Value = _datosCliente[i].Cedula;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //try { _datosEmpleado = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText(_pathEmpleados)); }
            //catch { MessageBox.Show("No pude leer el Json"); }
            //_datosEmpleado = Empleados.Lista();

            dtgvClientes.Rows.Clear();

            if(_datosCliente.Count != 0) dtgvClientes.Rows.Add(_datosCliente.Count);

            LlenarTablaClientes();

            /*int aux = dtgvEmpleados.Rows.Add();

            dtgvEmpleados.Rows[aux].Cells[0].Value = "Luis";
            dtgvEmpleados.Rows[aux].Cells[1].Value = "Galindez";
            dtgvEmpleados.Rows[aux].Cells[2].Value = "28.692.623";*/
        }
        private void btnAgregarVen_Click(object sender, EventArgs e)
        {
            if (CedulaRepetida()) MessageBox.Show("La Cedula Introducida ya esta registrada en la base de Datos");
            else
            {
                int aux = dtgvClientes.Rows.Add();
                dtgvClientes.Rows[aux].Cells[0].Value = txtNombre.Text;
                dtgvClientes.Rows[aux].Cells[1].Value = txtApellido.Text;
                dtgvClientes.Rows[aux].Cells[2].Value = txtCI.Text;
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCI.Text = "";
                txtTelefono.Text = "";
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (aux != -1 && dtgvClientes.Rows.Count > 0)
                {
                dtgvClientes.Rows.RemoveAt(aux);
                }
                else
                {
                    throw new Exception("No se pueden eliminar más Clientes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dtgvClientes.Rows.Count > 0)
            {
                _datosCliente.Clear();
                for (int i = 0; i < dtgvClientes.Rows.Count; i++)
                {
                    _datosCliente.Add(new Cliente(dtgvClientes[0,i].Value.ToString(), dtgvClientes[1, i].Value.ToString(), dtgvClientes[2, i].Value.ToString()));
                }
                GuardarClientes();
            }
            else MessageBox.Show("no hay nada que guardar");
        }
    }
}