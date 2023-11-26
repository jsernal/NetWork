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
            ConexionDB contexto = new ConexionDB(); // Asegúrate de tener tu contexto de Entity Framework aquí
            // Verificar si TextBox1, TextBox2 y TextBox3 no están vacíos
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                string email = textBox1.Text;
                string contraseña = textBox2.Text;
                string contraseña2 = textBox3.Text;
                // Verificar que las contraseñas coinciden
                if (contraseña.Equals(contraseña2))
                {
                    // Verificar si el usuario no existe en la base de datos
                    if (!contexto.Clientes.Any(c => c.Email == email))
                    {
                        // Crear un nuevo usuario
                        Clientes usuario = new Clientes
                        {
                            Email = email
                        };

                        // Agregar el nuevo usuario a la base de datos y guardar los cambios
                        contexto.Clientes.Add(usuario);
                        contexto.SaveChanges();

                        MessageBox.Show("Usuario creado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show($"Ya existe en la base de datos un usuario con el email {email}.");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un email y contraseña válidos.");
            }
        }
    }
}
