using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NetWork.Vista
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }
        private void FormClientes_Load(object sender, EventArgs e)
        {
            combtipo.DataSource = Enum.GetValues(typeof(TipoCliente));
            Refresh();
        }
        new
       public void Refresh()
        {
            using (ConexionDB db = new ConexionDB())
            {
                var clientes = db.Clientes.ToList();

                // Supongamos que la base de datos tiene más columnas de las que quieres mostrar en el DataGridView
                // Por ejemplo, tiene las columnas Nombre, Apellido, Email, Telefono, Direccion, Ciudad, FechaNacimiento, etc.

                // Asignar solo las seis primeras columnas de la base de datos a las columnas correspondientes del DataGridView
                foreach (var cliente in clientes)
                {
                    // Suponiendo que los nombres de las propiedades en el objeto cliente coinciden con las columnas en la base de datos
                    dataGridView1.Rows.Add(cliente.IdCliente, cliente.Dni, cliente.Nombre,cliente.Telefono, cliente.Tipo, cliente.Email);
                }
            }


        }
        /*
        private void FormClientes_Load(object sender, EventArgs e)
        {
            
        }
        */
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = textdni.Text;
                string nombre = textnombre.Text;
                string email = textemail.Text;

                if (!Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("El nombre solo puede contener letras y espacios.");
                    return;
                }

                if (!int.TryParse(texttelefono.Text, out int telefono))
                {
                    MessageBox.Show("El teléfono solo puede contener números.");
                    return;
                }

                TipoCliente tipo = (TipoCliente)combtipo.SelectedItem;

                using (var db = new ConexionDB())
                {
                    bool emailExists = db.Clientes.Any(c => c.Email == email);

                    if (emailExists)
                    {
                        MessageBox.Show("Este email ya está en uso, por favor ingrese otro email.");
                        return;
                    }

                    Clientes cliente = new Clientes(dni, nombre, telefono, tipo, email);
                    db.Clientes.Add(cliente);
                    db.SaveChanges();

                    MessageBox.Show("Cliente registrado con éxito.");
                    dataGridView1.Rows.Add(cliente.IdCliente, dni, nombre, telefono.ToString(), tipo.ToString(), email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el cliente: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var importarXML = new CreacionXML();
            importarXML.CrearXMLClientes(dataGridView1);
            MessageBox.Show("Clientes exportados a XML con éxito.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnabrirXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var rutaArchivo = openFileDialog.FileName;

                var importarXML = new CreacionXML();
                var clientes = importarXML.LeerXML(rutaArchivo);

                FormXML formularioXML = new FormXML(clientes);
                formularioXML.Show();
            }
        }
    }
}
