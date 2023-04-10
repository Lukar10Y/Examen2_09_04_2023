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
    public partial class FormGestionDatosEmpresa : Form
    {
        private string _pathDatos = "";
        private string _pathEmpleados = "";
        private int aux = 0;
        private List<Usuario> _datosEmpleado = new List<Usuario>();
        private List<string> _datosEmpresa = new List<string>();
        public FormGestionDatosEmpresa()
        {
            InitializeComponent();
        }
        public string PathEmpleados { set { _pathEmpleados = value;} get { return _pathEmpleados; } }
        public string PathDatos { set { _pathDatos = value; } get { return _pathDatos; } }
        public List<string> DatosEmpresa { set { _datosEmpresa = value; } get { return _datosEmpresa; } }
        public List<Usuario> Empleados { get { return _datosEmpleado;} set { _datosEmpleado = value; } }
        private void GuardarEmpleados()
        {
            string empleadosJson = JsonConvert.SerializeObject(_datosEmpleado.ToArray(), Formatting.Indented);
            File.WriteAllText(_pathEmpleados, empleadosJson);
            MessageBox.Show("Guardado Exitosamente");
        }
        private void LlenarTablaEmpleados()
        {
            if (_datosEmpleado.Count > 0)
            {
                for (int i = 0; i < _datosEmpleado.Count; i++)
                {
                    for (int j = 0; j < dtgvEmpleados.Columns.Count; j++)
                    {
                        if (j == 0) dtgvEmpleados[j, i].Value = _datosEmpleado[i].Nombre;
                        else if (j == 1) dtgvEmpleados[j, i].Value = _datosEmpleado[i].Apellido;
                        else if (j == 2) dtgvEmpleados[j, i].Value = _datosEmpleado[i].Cedula;
                    }
                }
            }
        }
        private bool CedulaRepetida()
        {
            bool Repetido = false;
            for (int i = 0; i < _datosEmpleado.Count; i++)
            {
                if (_datosEmpleado[i].Cedula == txtCI.Text)
                {
                    Repetido = true;
                    break;
                }
            }
            return Repetido;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //try { _datosEmpleado = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText(_pathEmpleados)); }
            //catch { MessageBox.Show("No pude leer el Json"); }
            //_datosEmpleado = Empleados.Lista();

            dtgvEmpleados.Rows.Clear();

            if(_datosEmpleado.Count != 0) dtgvEmpleados.Rows.Add(_datosEmpleado.Count);

            LlenarTablaEmpleados();

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
                int aux = dtgvEmpleados.Rows.Add();
                dtgvEmpleados.Rows[aux].Cells[0].Value = txtNombre.Text;
                dtgvEmpleados.Rows[aux].Cells[1].Value = txtApellido.Text;
                dtgvEmpleados.Rows[aux].Cells[2].Value = txtCI.Text;
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCI.Text = "";
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (aux != -1 && dtgvEmpleados.Rows.Count > 0)
                {
                    dtgvEmpleados.Rows.RemoveAt(aux);
                }
                else
                {
                    throw new Exception("No se pueden eliminar más artículos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dtgvEmpleados.Rows.Count > 0)
            {
                _datosEmpleado.Clear();
                for (int i = 0; i < dtgvEmpleados.Rows.Count; i++)
                {
                    _datosEmpleado.Add(new Usuario(dtgvEmpleados[0, i].Value.ToString(), dtgvEmpleados[1, i].Value.ToString(), dtgvEmpleados[2, i].Value.ToString(), false));
                }
                GuardarEmpleados();
            }
            else MessageBox.Show("no hay nada que guardar");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _datosEmpresa.Clear();
            _datosEmpresa.Add(txtNomEmpresa.Text);
            _datosEmpresa.Add(txtRif.Text);
            _datosEmpresa.Add(txtDireccion.Text);
            _datosEmpresa.Add(txtCorreo.Text);
            string DatosEmpresaJson = JsonConvert.SerializeObject(_datosEmpresa.ToArray(), Formatting.Indented);
            File.WriteAllText(_pathDatos, DatosEmpresaJson);
        }
    }
}