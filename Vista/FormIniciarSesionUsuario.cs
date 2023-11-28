using System;
using System.Linq;
using System.Windows.Forms;
using NetWork.Modelo;

namespace NetWork.Vista
{
    public partial class FormIniciarSesionUsuario : Form
    {
        public FormIniciarSesionUsuario()
        {
            InitializeComponent();
        }

        private void FormIniciarSesionUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form formulario = new FormRegistrarUsuario();
            formulario.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string contraseña = textBox2.Text;

            if (VerificarCredenciales(email, contraseña))
            {
                Form formulario = new MenuPrincipal(email);
                formulario.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El email o la contraseña introducidos no coincide con ningún usuario.");
            }
        }

        public bool VerificarCredenciales(string email, string contraseña)
        {
            ConexionDB contexto = new ConexionDB();

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(contraseña))
            {
                return contexto.Clientes.Any(c => c.Email == email);
            }

            return false;
        }


    }
}
