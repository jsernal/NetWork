using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelSOL
{
    public partial class FormLogin : Form
    {
        private const string ConexionString = "Data Source=(local);Initial Catalog=DB;Integrated Security=True";
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            using (ConexionDB db = new ConexionDB())
            {
                db.Open();

                string query = "SELECT COUNT(*) FROM Clientes WHERE Nombre=@Nombre AND Contraseña=@Contraseña";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Inicio de sesión exitoso");
                      
                    }
                    else
                    {
                        MessageBox.Show("Inicio de sesión fallido. Nombre de usuario o contraseña incorrectos");
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.ShowDialog();
        }
    }
}
