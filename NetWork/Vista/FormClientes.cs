using NetWork.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                
                string dni = textdni.Text;
                string nombre = textnombre.Text;
                int telefono = int.Parse(texttelefono.Text);
                TipoCliente tipo = (TipoCliente)combtipo.SelectedItem;
                string email = textemail.Text;

                Clientes cliente = new Clientes(dni, nombre, telefono, tipo, email);

                
                using (var db = new ConexionDB())
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                }

                MessageBox.Show("Cliente registrado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el cliente: {ex.Message}");
            }
        }
    }
}
