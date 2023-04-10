using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//importante
using ExamenDockUp;
using Newtonsoft.Json;

namespace borrador
{
    public partial class FormGestionDeProductos : Form
    {
        private string _pathProductos = "";
        public static List<Productos> productos = new List<Productos>();
        public int n = 0;
        public List<Productos> ListaProductos { get { return productos; } set { productos = value; } }
        public string PathProductos { get { return _pathProductos; } set { _pathProductos = value; } }
        public FormGestionDeProductos()
        {
            InitializeComponent();
            lblform.Text = " ";
        }
        private void GuardarProductos()
        {
            string jsonFacturas = JsonConvert.SerializeObject(ListaProductos.ToArray(), Formatting.Indented);
            File.WriteAllText(_pathProductos, jsonFacturas);
        }
        private void LlenarTablaProductos()
        {
            for (int i = 0; i < productos.Count; i++)
            {
                for (int j = 0; j < dtgvProductos.Columns.Count; j++)
                {
                    if (j == 0) dtgvProductos[j, i].Value = productos[i]._codigo;
                    else if (j == 1) dtgvProductos[j, i].Value = productos[i]._nombre;
                    else if (j == 2) dtgvProductos[j, i].Value = productos[i]._descripcion;
                    else if (j == 3) dtgvProductos[j, i].Value = productos[i]._precio;
                    else if (j == 4) dtgvProductos[j, i].Value = productos[i]._cantidad;
                }
            }
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);
                string descripcion = txtDescripcion.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                if (precio == 0)
                {
                    throw new Exception("El precio no puede ser 0");
                }
                else if (precio < 0)
                {
                    throw new Exception("El precio no puede ser negativo");
                }
                else if (txtPrecio.Text == null)
                {
                    throw new Exception("el precio no puede ser vacio");
                }
                else if (string.IsNullOrEmpty(descripcion) || txtDescripcion.Text == null)
                {
                    throw new Exception("Descripcion invalida");
                }
                else if (cantidad == 0 || cantidad < 0)
                {
                    throw new Exception("Ingrese una cantidad de productos correcta");
                }
                else if (string.IsNullOrEmpty(nombre))
                {
                    throw new Exception("El nombre del producto no puede ser vacio!");
                }

                int n = dtgvProductos.Rows.Add();
                Productos prod = new Productos(codigo, nombre, descripcion, cantidad, precio);
                productos.Add(prod);
                dtgvProductos.Rows[n].Cells[0].Value = codigo;
                dtgvProductos.Rows[n].Cells[1].Value = nombre;
                dtgvProductos.Rows[n].Cells[2].Value = descripcion;
                dtgvProductos.Rows[n].Cells[3].Value = precio + "$";
                dtgvProductos.Rows[n].Cells[4].Value = cantidad;
                //GrabarDatos();
                GuardarProductos();
                txtPrecio.Clear();
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtCantidad.Clear();
                txtCodigo.Text = ((productos.Count()+1).ToString()).PadLeft(5, '0');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dtgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex; 
            
            if (n != -1)
            {
                lblform.Text = " ";
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (n != -1 && dtgvProductos.Rows.Count > 0)
                {
                    dtgvProductos.Rows.RemoveAt(n);
                    productos.Remove(productos[n]);
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
            //GrabarBorrado();
        }

        private void GrabarBorrado()
        {
            StreamWriter archivo = new StreamWriter("Productos.txt");
            for (int x=0;x < dtgvProductos.Rows.Count;x++)
            {
                archivo.WriteLine(dtgvProductos.Rows[x].Cells[0].Value/*ToString()*/);
                archivo.WriteLine(dtgvProductos.Rows[x].Cells[1].Value/*ToString()*/);
                archivo.WriteLine(dtgvProductos.Rows[x].Cells[2].Value/*ToString()*/);
                archivo.WriteLine(dtgvProductos.Rows[x].Cells[3].Value/*ToString(*/);
                archivo.WriteLine(dtgvProductos.Rows[x].Cells[4].Value/*ToString()*/);
            }
            archivo.Close();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Productos Importados");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Productos Exportados");           
        }

        private void Form2_Load(object sender, EventArgs e)
        {//using systen.io
            
            /*Con este condicional; al cargarse la ventana se escribe el codigo correspondiente al siguiente
             porducto a crear*/

            if (productos.Count == 0)
            {
                txtCodigo.Text = ("1".PadLeft(5, '0'));
            }
            else
            {
                txtCodigo.Text = ((productos.Count() + 1).ToString()).PadLeft(5, '0');
            }

            //Con este otro se crean las filas necesarias para mostrar los productos que hay

            if (dtgvProductos.Rows.Count == 0 && productos.Count != 0) dtgvProductos.Rows.Add(productos.Count);

            LlenarTablaProductos();

            /*if (!File.Exists("Productos.txt")) //compruebo que este el documento 
            {
                StreamWriter archivo = new StreamWriter("Productos.txt");
                archivo.Close();
            }
            else 
            {
                StreamReader archivo = new StreamReader("Productos.txt");
                while (!archivo.EndOfStream) 
                {
                    string codigo = archivo.ReadLine();
                    string nombre = archivo.ReadLine();
                    string descripcion = archivo.ReadLine();
                    string precio = archivo.ReadLine();
                    string cantidad = archivo.ReadLine();
                    dtgvProductos.Rows.Add(codigo, nombre, descripcion, precio, cantidad);
                }
                archivo.Close();
            }*/
        }
        private void GrabarDatos()
        {
            StreamWriter archivo = new StreamWriter("Productos.txt", true);
            archivo.WriteLine(txtCodigo.Text);
            archivo.WriteLine(txtNombre.Text);
            archivo.WriteLine(txtDescripcion.Text);
            archivo.WriteLine(txtPrecio.Text + "$");
            archivo.WriteLine(txtCantidad.Text);
            archivo.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
