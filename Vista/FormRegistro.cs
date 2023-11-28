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
            string dni = txtDNI.Text;
            string nombre = txtNuevoUsuario.Text;
            string contraseña = txtNuevaContraseña.Text;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;

            using (ConexionDB db = new ConexionDB())
            {
                db.Open();

                string insertQuery = "INSERT INTO Clientes (DNI, Nombre, Contraseña, Telefono, Email) " +
                                     "VALUES (@DNI, @Nombre, @Contraseña, @Telefono, @Email)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@DNI", dni);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro exitoso");
                        this.Close(); // Cierra la ventana de registro después de un registro exitoso.
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el cliente");
                    }
                }
            }
        }
    }
}
