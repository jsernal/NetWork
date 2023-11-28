using System;
using System.Linq;
using System.Windows.Forms;
using NetWork.Modelo;

namespace NetWork.Vista
{
    public partial class FormRegistrarUsuario : Form
    {
        public FormRegistrarUsuario()
        {
            InitializeComponent();
        }

        private void FormRegistrarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegistroUsuario();
        }

        public void RegistroUsuario()
        {
            ConexionDB contexto = new ConexionDB();

           
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                string email = textBox1.Text;
                string contraseña = textBox2.Text;
                string contraseña2 = textBox3.Text;

               
                bool registroExitoso = ValidarYRegistrarUsuario(contexto, email, contraseña, contraseña2);

               
                if (registroExitoso)
                {
                    MessageBox.Show("Usuario creado correctamente.");
                    this.Close();
                    FormIniciarSesionUsuario formIniciarSesionUsuario = new FormIniciarSesionUsuario();
                    formIniciarSesionUsuario.Show();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar el usuario, verifica los datos introducidos.");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingresa un email y contraseña validos");
            }
        }

        public bool ValidarYRegistrarUsuario(ConexionDB contexto, string email, string contraseña, string contraseña2)
        {

            if (contraseña.Equals(contraseña2))
            {
                
                if (!contexto.Set<Clientes>().Any(c => c.Email == email))
                {
                    
                    Clientes usuario = new Clientes
                    {
                        Email = email
                    };

                    
                    contexto.Set<Clientes>().Add(usuario);
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show($"Ya existe en la base de datos un usuario con este email: {email}.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return false; 
            }
        }
    }
}
