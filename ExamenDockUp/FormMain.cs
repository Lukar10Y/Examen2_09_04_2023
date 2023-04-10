using borrador;
using DatosEmpresa;
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
using Vender_Bosquejo_2;

namespace ExamenDockUp
{
    public partial class FormMain : Form
    {
        //Listas de Datos que se Manejan
        private List<Usuario> Usuarios = new List<Usuario>();
        private List<Productos> Productos = new List<Productos>();
        private List<string> DatosEmpresa = new List<string>();
        private List<Cliente> Clientes = new List<Cliente>();

        //Form Utilizados (La mayoria son llamados desde el Main)
        private FormGestionDatosEmpresa Empresa = new FormGestionDatosEmpresa();
        private FormLogin Login = new FormLogin();
        //private FormVender Vender = new FormVender();
        private FormVenderV2 Vender = new FormVenderV2();
        private FormGestionDeProductos GestionDeProductos = new FormGestionDeProductos();
        private FormCambiarDatosUsuario Configuracion = new FormCambiarDatosUsuario();
        private FormGestionDatosClientes GestionClientes = new FormGestionDatosClientes();
        //FormVender Vender = new FormVender();

        //Direcciones Utilizadas
        private string pathUsers = @"UsersEXAMEN2.json";
        private string pathFacturas = @"FacturasEXAMEN2.json";
        private string pathClientes = @"ClientesEXAMEN2.json";
        private string pathProductos = @"ProductosEXAMEN2.json";
        private string pathDatosEmpresa = @"DatosEmpresaEXAMEN2.json";
        public FormMain()
        {
            InitializeComponent();
        }
        private void EstablecerDirecciones()
        {
            /*Sin importar que las demas Form se abran o no; desde un inicio; desde el main,
            Se le da Valor a las direcciones que se van a utilizar en las distintas ventanas*/

            Login.Path = pathUsers;
            Configuracion.Path = pathUsers;
            Vender.PathFacturas = pathFacturas;
            Empresa.PathDatos = pathDatosEmpresa;
            Empresa.PathEmpleados = pathUsers;
            GestionClientes.PathClientes = pathClientes;
            GestionDeProductos.PathProductos = pathProductos;
        }
        private void GuardarUsuarios()
        {
            string JsonUsuarios = JsonConvert.SerializeObject(Usuarios.ToArray(), Formatting.Indented);
            File.WriteAllText(Login.Path, JsonUsuarios);
        }
        private void LeerDatosEmpresa()
        {
            try
            {
                DatosEmpresa = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(pathDatosEmpresa));
            }
            catch{ }
        }
        private void LeerListadeClientes()
        {
            try
            {
                Clientes = JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText(pathClientes));
            }
            catch
            { 
                MessageBox.Show("La Lista de Clientes Esta Vacia"); 
            }
        }
        private void LeerListadeProductos()
        {
            try
            {
                Productos = JsonConvert.DeserializeObject<List<Productos>>(File.ReadAllText(pathProductos));
            }
            catch
            {
                MessageBox.Show("La Lista de Productos Esta Vacia");
            }
        }
        private void DatosRepartidosEnElMain()
        {
            /*En esta linea hago "copia de la lista" para simplificar codigo; por que o sino para referirnos a la
            Lista de Usuarios tendriamos que escribir a cada rato 'Login.ListaUsuarios'*/
            Usuarios = Login.ListaUsuarios; 

            //Datos que aparecen junto a la imagen del usuario en el main
            lblNombre.Text = Usuarios[Login.Posicion].Nombre;
            lblCargo.Text = Usuarios[Login.Posicion].Cargo;

            /*Aqui a la Ventana de Configuracion de Usuarios se le pasa la Lista de Usuarios y La posicion 
            en la Lista del Usuario Que se utilizo para ingresar (Login.Posicion)*/
            Configuracion.Usuarios = Usuarios;
            Configuracion.Posicion = Login.Posicion;

            /*Para la Form de Vender, se necesita saber unicamente el usuario que ingreso al programa en el login
             por lo cual nos evitamos pasar la lista completa y en cambio unicamente le pasamos el vendedor/Usuario
            como tal*/ 
            Vender.Vendedor = Usuarios[Login.Posicion];
            Vender.Productos = Productos;
            Vender.DatosEmpresa = DatosEmpresa;
            Vender.Clientes = Clientes;

            Empresa.Empleados = Usuarios;
            Empresa.DatosEmpresa = DatosEmpresa;

            GestionClientes.ListaClientes = Clientes;

            GestionDeProductos.ListaProductos = Productos;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            EstablecerDirecciones();

            /*Condicional para que el programa pase del Login: EL usuario debe ingresar un nombre de usuario y clave
            Correctas. De lo Contrario el Login nunca nos va a dar como resultado 'Ok' por lo cual se llama al Exit();*/

            if (Login.ShowDialog()!=DialogResult.OK){
                Application.Exit();
            }
            else
            {
                LeerListadeClientes();
                LeerListadeProductos();
                LeerDatosEmpresa();
                DatosRepartidosEnElMain();

                if (Usuarios.Count < 2)
                {
                    Usuarios.Add(new Usuario("Vendedor1","Vendedor1","No Asignada", false));
                    MessageBox.Show("Ademas se ha creado un usuario No Administrador de prueba\n\nUsuario: Vendedor1\nClave: Vendedor1");
                }

                /*Solo existe un Administrador, por lo cual cuando cargamos el Main comprobamos si la persona que
                Ingreso tiene como cargo: Administrador, de lo contrario haremos invisible el recuadro de opciones
                de administradores llamado: 'gBoxAdmin'*/

                if (Usuarios[Login.Posicion].Cargo != "Administrador")
                {
                    gBoxAdmin.Visible = false;
                }

                GuardarUsuarios();
            }
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnVender_Click(object sender, EventArgs e)
        {
            Vender.ShowDialog();
        }
        private void rtbConfiguracion_Click(object sender, EventArgs e)
        {
            Configuracion.ShowDialog();
        }
        private void pbConfiguracion_Click(object sender, EventArgs e)
        {
            Configuracion.ShowDialog();
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            GestionDeProductos.ShowDialog();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            Empresa.ShowDialog();
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            GestionClientes.ShowDialog();
        }
    }
}
