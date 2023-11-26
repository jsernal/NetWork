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
            ConexionDB contexto = new ConexionDB(); // Asegúrate de tener tu contexto de Entity Framework aquí
            // Verificar si TextBox1 y TextBox2 no están vacíos
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                string email = textBox1.Text;
                string contraseña = textBox2.Text;
                // Verificar si el cliente existe
                if (contexto.Clientes.Any(c => c.Email == email))
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
            else
            {
                MessageBox.Show("Por favor, ingresa un email y contraseña válidos.");
            }
        }
    }
}
