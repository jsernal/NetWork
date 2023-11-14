using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelSOL
{
    public partial class FormRegistro : Form
    {
        private const string ConnectionString = "Data Source=(local);Initial Catalog=DB;Integrated Security=True";
        
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoUsuario.Text;
            string contraseña = txtNuevaContraseña.Text;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Usuarios (Nombre, Contraseña) VALUES (@Nombre, @Contraseña)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro exitoso");
                        this.Close(); // Cierra la ventana de registro después de un registro exitoso.
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el usuario");
                    }
                }
            }
        }
    }
}
